using System.Collections;
using UnityEditor;
using UnityEngine;

namespace BlackPants {
  public static class EditorHelpers {
    public static string TryGetCommandLineArgumentValue(string argument) {
      // http://docs.unity3d.com/Manual/CommandLineArguments.html
      // says we should use command line args to pass values to script functions, so we need this ugly thing
      string[] args = System.Environment.GetCommandLineArgs();

      int argIndex;
      for (argIndex = 0; argIndex < args.Length; argIndex++) {
        var arg = args[argIndex];
        if (arg.ToLower().Equals(argument))
          break;
      }

      if (argIndex + 1 >= args.Length)
        return null;

      return args[argIndex + 1];
    }

    public static string GetCommandLineArgumentValue(string argument) {
      string value = TryGetCommandLineArgumentValue(argument);
      if (value == null)
        throw new System.InvalidOperationException("Missing command line argument " + argument);
      return value;
    }

    public static int GetCommandLineArgumentInt(string argument) {
      string value = GetCommandLineArgumentValue(argument);
      return int.Parse(value);
    }

    // Originally from https://answers.unity.com/questions/47377/how-to-programatically-enable-static-batching-in-t.html
    public static void SetStaticBatchingEnabled(bool value) {
      PlayerSettings[] playerSettings = Resources.FindObjectsOfTypeAll<PlayerSettings>();
      SerializedObject playerSettingsSerializedObject = new SerializedObject(playerSettings);
      SerializedProperty batchingSettings = playerSettingsSerializedObject.FindProperty("m_BuildTargetBatching");

      // Iterate over all platforms
      for (int i = 0; i < batchingSettings.arraySize; i++) {
        SerializedProperty batchingArrayValue = batchingSettings.GetArrayElementAtIndex(i);
        if (batchingArrayValue == null) {
          continue;
        }
        IEnumerator batchingEnumerator = batchingArrayValue.GetEnumerator();
        while (batchingEnumerator.MoveNext()) {
          SerializedProperty property = (SerializedProperty)batchingEnumerator.Current;
          if (property.name == "m_StaticBatching") {
            property.boolValue = value;
          }
        }
      }
      playerSettingsSerializedObject.ApplyModifiedProperties();
    }
  }
}
