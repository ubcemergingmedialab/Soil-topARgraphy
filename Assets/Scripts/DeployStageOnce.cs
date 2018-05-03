using System;
using UnityEngine;
using Vuforia;

/// <summary>
/// Script with handlers for Vurforia's hit test events.
/// </summary>
[RequireComponent(typeof(PlaneFinderBehaviour))]
public class DeployStageOnce : MonoBehaviour
{
    /// <summary>Stage that will be deployed</summary>
    public GameObject AnchorStage;
    private PositionalDeviceTracker _deviceTracker;
    private GameObject _previousAnchor;

    /// <summary>
    /// If true, then the terrain will be placed when the user clicks
    /// </summary>
    public bool willPlace = true;

    public void Awake()
    {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);

        if (AnchorStage == null)
        {
            Debug.Log("AnchorStage must be specified");
            return;
        }

        Reset();
    }

    public void OnDestroy()
    {
        VuforiaARController.Instance.UnregisterVuforiaStartedCallback(OnVuforiaStarted);
    }

    private void OnVuforiaStarted()
    {
        _deviceTracker = TrackerManager.Instance.GetTracker<PositionalDeviceTracker>();
    }

    /// <summary>
    /// Callback for <see cref="Vuforia.PlaneFinderBehaviour.OnInteractiveHitTest"/>
    /// </summary>
    public void OnInteractiveHitTest(HitTestResult result)
    {
        if (!willPlace) return;
        if (result == null || AnchorStage == null)
        {
            Debug.LogWarning("Hit test is invalid or AnchorStage not set");
            return;
        }

        var anchor = _deviceTracker.CreatePlaneAnchor(Guid.NewGuid().ToString(), result);

        if (anchor != null)
        {
            AnchorStage.transform.parent = anchor.transform;
            AnchorStage.transform.localPosition = Vector3.zero;
            AnchorStage.transform.localRotation = Quaternion.identity;
            AnchorStage.SetActive(true);
        }

        if (_previousAnchor != null)
        {
            Destroy(_previousAnchor);
        }

        _previousAnchor = anchor;
        willPlace = false;
    }

    /// <summary>Call to remove the placed stage and allow it to be placed elsewhere</summary>
    public void Reset()
    {
        willPlace = true;
        AnchorStage.SetActive(false);
    }

    /// <summary>Call to not allow the stage to be placed.</summary>
    public void DeactivatePlane()
    {
        willPlace = false;
    }
}
