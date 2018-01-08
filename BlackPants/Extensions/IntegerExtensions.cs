public static class IntegerExtensions {
  public static int Modulo(this int x, int m) {
    if (m < 0)
      m = -m;
    int r = x % m;
    return r < 0 ? r + m : r;
  }
}
