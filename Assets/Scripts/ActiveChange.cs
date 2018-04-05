using UnityEngine;
using UnityEngine.Events;

/// <summary>Dispatches events when `SetActive()` is called</summary>
public class ActiveChange : MonoBehaviour
{
    public UnityEvent onEnable;
		public UnityEvent onDisable;

		void OnEnable() {
			onEnable.Invoke();
		}
		void OnDisable() {
			onDisable.Invoke();
		}
}
