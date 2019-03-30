using UnityEngine;

public class Hyperlink : MonoBehaviour
{
    public void OpenURL(string url) {
        Application.OpenURL(url);
    }
}
