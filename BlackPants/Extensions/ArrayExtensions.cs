public static class ArrayExtensions {
  public static void Populate<T>(this T[] arr, T value) {
    for (int i = 0; i < arr.Length; i++) {
      arr[i] = value;
    }
  }

  public static bool ContainsIndex<T>(this T[] arr, int index) {
    return index >= 0 && index < arr.Length;
  }
}
