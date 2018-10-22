using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkMapToUi : MonoBehaviour {
	public MapControls Controller;
    public Raycaster Raycaster;

    public string UiSceneName = "UI";

    void Start() {
        StartCoroutine(LoadUiScene());
    }

    private IEnumerator LoadUiScene() {
        if (!SceneManager.GetSceneByName(UiSceneName).isLoaded) {
            Debug.Log("Loading UI");
            var asyncLoad = SceneManager.LoadSceneAsync(UiSceneName, LoadSceneMode.Additive);
            yield return asyncLoad;
        } else {
            Debug.Log("UI already loaded");
        }

        var uiScene = SceneManager.GetSceneByName(UiSceneName);
        Canvas infoCardParent = null;
        UiPanel infoCard = null;
        TerrainToggle toggle = null;
        foreach (var gameObject in uiScene.GetRootGameObjects()) {
            switch (gameObject.tag) {
                case "InfoCard":
                    infoCardParent = gameObject.GetComponent<Canvas>();
                    infoCard = gameObject.GetComponentInChildren<UiPanel>();
                    break;
                case "TerrainControls":
                    toggle = gameObject.GetComponentInChildren<TerrainToggle>();
                    break;
            }
        }

        if (infoCardParent) {
            Raycaster.OnHit.AddListener((_) => infoCardParent.enabled = true);
        }
        if (infoCard) {
            Raycaster.OnHit.AddListener(infoCard.Display);
        }
        if (toggle) {
            toggle.OnChange.AddListener(Controller.SwapTo);
            Controller.Provider = (CurrentMapTypeProvider) toggle;
        }
    }
}
