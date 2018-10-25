using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a modified version of Unity's CanvasScaler, as found here:
/// https://bitbucket.org/Unity-Technologies/ui/src/fadfa14d2a5c?at=4.6
/// Modder: Tess Snider, Hidden Achievement
/// Adapted to extend CanvasScaler instead copying its methods.
/// </summary>
[AddComponentMenu("Layout/DPI Canvas Scaler")]
public class DpiCanvasScaler : CanvasScaler {
    protected override void HandleConstantPhysicalSize()
    {
        float currentDpi = Screen.dpi;
        float dpi = (currentDpi == 0 ? m_FallbackScreenDPI : currentDpi);
        float targetDPI = 160;
#if (UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS))
            targetDPI = 96;
#endif

        SetScaleFactor(dpi / targetDPI);
        SetReferencePixelsPerUnit(m_ReferencePixelsPerUnit * targetDPI / m_DefaultSpriteDPI);
    }
}
