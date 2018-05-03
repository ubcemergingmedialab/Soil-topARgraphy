using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Scales a transform in response to the user pinching the screen</summary>
public class PinchToScale : MonoBehaviour
{
    /// <summary>How quickly the transform is scaled</summary>
    public float scaleSpeed = -0.1f;
    /// <summary>Minimum size of the transform</summary>
    public Vector3 minScale = Vector3.one;
    /// <summary>Maximum size of the transform</summary>
    public Vector3 maxScale = Vector3.one * 4;

    /// <summary>Find the difference in the distances between each frame.</summary>
    /// <returns>Returns delta magnitude between the touches</returns>
    static float GetTouchDeltaMagnitudeDiff()
    {
        // Store both touches.
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        // Find the position in the previous frame of each touch.
        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

        // Find the magnitude of the vector (the distance) between the touches in each frame.
        float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
        float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

        // Find the difference in the distances between each frame.
        float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;
        return deltaMagnitudeDiff;
    }

    /// <summary>Scales a Vector3 using `delta` and `scaleSpeed`</summary>
    /// <param name="oldScale">Vector to scale</param>
    /// <param name="delta">Amount to adjust scale by.</param>
    /// <returns>Returns scaled vector</returns>
    Vector3 Scale(Vector3 oldScale, float delta)
    {
        Vector3 newScale = oldScale + (Vector3.one * delta * scaleSpeed);
        newScale = Vector3.Min(newScale, maxScale);
        newScale = Vector3.Max(newScale, minScale);
        return newScale;
    }

    void Update()
    {
        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            transform.localScale = Scale(transform.localScale, GetTouchDeltaMagnitudeDiff());
        }
    }
}
