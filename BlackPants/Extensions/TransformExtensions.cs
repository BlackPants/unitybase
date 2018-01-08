using UnityEngine;

public static class TransformExtensions {
  public static Transform DestroyChildren(this Transform transform) {
    foreach (Transform child in transform) {
      GameObject.Destroy(child.gameObject);
    }
    return transform;
  }

  private static void CalculateHierarchyBounds(Transform transform, ref Bounds bounds, ref bool boundsChanged) {
    var renderer = transform.gameObject.GetComponent<Renderer>();
    if (renderer != null) {
      var rendererBounds = renderer.bounds;
      if (boundsChanged) {
        bounds.Encapsulate(rendererBounds.min);
        bounds.Encapsulate(rendererBounds.max);
      }
      else {
        bounds.min = rendererBounds.min;
        bounds.max = rendererBounds.max;
        boundsChanged = true;
      }
    }

    foreach (Transform child in transform) {
      CalculateHierarchyBounds(child, ref bounds, ref boundsChanged);
    }
  }

  public static bool CalculateHierarchyBounds(this Transform transform, ref Bounds bounds) {
    bool boundsChanged = false;
    CalculateHierarchyBounds(transform, ref bounds, ref boundsChanged);
    return boundsChanged;
  }

  public static Vector3 CalculateHierarchyCenter(this Transform transform) {
    var bounds = new Bounds();
    if (!CalculateHierarchyBounds(transform, ref bounds))
      return transform.position;

    return bounds.center;
  }

  public static Vector3 CalculateHierarchySize(this Transform transform) {
    var bounds = new Bounds();
    if (!CalculateHierarchyBounds(transform, ref bounds))
      return Vector3.zero;

    return bounds.size;
  }
}
