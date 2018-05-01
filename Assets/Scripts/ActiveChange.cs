using UnityEngine;
using UnityEngine.Events;

/// <summary>Dispatches events when `SetActive()` is called</summary>
public class ActiveChange : MonoBehaviour
{
    /// <summary>If true, also emit the onEnable/onDisable events when the program starts</summary>
    public bool emitOnStart = false;

    public UnityEvent onEnable;
    public UnityEvent onDisable;

    void Start()
    {
        if (emitOnStart)
        {
            if (gameObject.activeInHierarchy) onEnable.Invoke();
            else onDisable.Invoke();
        }
    }

    void OnEnable()
    {
        onEnable.Invoke();
    }
    void OnDisable()
    {
        onDisable.Invoke();
    }
}
