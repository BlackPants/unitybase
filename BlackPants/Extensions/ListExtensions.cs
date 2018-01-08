using System.Collections.Generic;

public static class ListExtensions {
  public static void Shuffle<T>(this IList<T> list, int startIndex) {
    int count = list.Count;
    int last = count - 1;
    for (int i = startIndex; i < last; i++) {
      int randomIndex = UnityEngine.Random.Range(i, count);
      var tmp = list[i];
      list[i] = list[randomIndex];
      list[randomIndex] = tmp;
    }
  }

  public static void Shuffle<T>(this IList<T> list) {
    Shuffle(list, 0);
  }

  public static void Shorten<T>(this List<T> list, int size) {
    if (list.Count > size) {
      list.RemoveRange(size, list.Count - size);
    }
  }
}
