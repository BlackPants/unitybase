using System;
using System.Collections;
using UnityEngine;

public static class MonoBehaviourExtensions {
  private static IEnumerator ImplWaitForAnimation(Animation animation) {
    do {
      yield return null;
    } while (animation.isPlaying);
  }

  public static Coroutine WaitForAnimation(this MonoBehaviour monoBehaviour, Animation animation) {
    return monoBehaviour.StartCoroutine(ImplWaitForAnimation(animation));
  }

  private static IEnumerator ImplWaitUntil(Func<bool> condition) {
    while (!condition()) {
      yield return null;
    }
  }

  public static Coroutine WaitUntil(this MonoBehaviour monoBehaviour, Func<bool> condition) {
    return monoBehaviour.StartCoroutine(ImplWaitUntil(condition));
  }

  private static IEnumerator ImplWaitWhile(Func<bool> condition) {
    while (condition()) {
      yield return null;
    }
  }

  public static Coroutine WaitWhile(this MonoBehaviour monoBehaviour, Func<bool> condition) {
    return monoBehaviour.StartCoroutine(ImplWaitWhile(condition));
  }
}
