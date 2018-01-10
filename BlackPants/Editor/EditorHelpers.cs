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
  }
}
