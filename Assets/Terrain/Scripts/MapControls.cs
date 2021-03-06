﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public interface CurrentMapTypeProvider {
	MapType CurrentMapType { get; }
}

public class MapControls : MonoBehaviour, ITrackableEventHandler {
	public CurrentMapTypeProvider Provider;

	/// <summary>Heightmap terrain object</summary>
    [SerializeField]
	private MeshRenderer heightmap;
    /// <summary>Satellite terrain object</summary>
    [SerializeField]
	private HideMapboxMap satellite;

	public UnityEvent OnTrack;
	public UnityEvent OnHidden;

	// Exposes status for debugger
	private TrackableBehaviour.Status status;

	void Start() {
		var trackableBehaviour = GetComponentInParent<TrackableBehaviour>();
        if (trackableBehaviour)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }
	}

	public void SwapTo()
	{
		SwapTo(Provider != null ? Provider.CurrentMapType : MapType.Heightmap);
	}

    /// <summary>
	/// Swaps between the heightmap and satellite views for the terrain map.
	/// </summary>
	public void SwapTo(MapType mapType)
    {
        if (heightmap != null) {
            heightmap.enabled = mapType == MapType.Heightmap;
        }
        if (satellite != null) {
            satellite.SetActive(mapType == MapType.Satellite);
        }
    }

	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
		status = newStatus;
		if (detected(newStatus) && !detected(previousStatus)) {
			OnTrack.Invoke();
		} else if (newStatus == TrackableBehaviour.Status.NO_POSE) {
			OnHidden.Invoke();
		}
    }

	private bool detected(TrackableBehaviour.Status status) {
		return (status == TrackableBehaviour.Status.DETECTED ||
            status == TrackableBehaviour.Status.TRACKED ||
            status == TrackableBehaviour.Status.EXTENDED_TRACKED);
	}
}
