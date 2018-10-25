using System;
using System.Collections;
using UnityEngine;

public static class NextTickExtension {
    /// <summary>Call the given callback function on the next Unity frame.</summary>
    /// <example>
    /// <code>
    /// // Prints "1" then "2"
    /// this.OnNextTick(() => Debug.Log("2"));
    /// Debug.Log("1");
    /// </code>
    /// </example>
    public static void OnNextTick(this MonoBehaviour component, Action callback) {
        component.StartCoroutine(CallOnNextTick(callback));
    }

    private static IEnumerator CallOnNextTick(Action callback) {
        yield return 0;
        callback();
    }
}
