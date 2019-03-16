using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

/// <summary>
/// Our UI panels are split into their own scene for cleanliness.
/// This script imports the UI scene into the current scene, and then
/// links event listeners from the UI to the current scene.
/// </summary>
public class LinkMapToUi : MonoBehaviour {
	public MapControls Controller;
    public Raycaster Raycaster;

    public string UiSceneName = "UI";

    void Start() {
        StartCoroutine(LoadUiScene());
    }

    private IEnumerator LoadUiScene() {
        // Load UI scene
        if (!SceneManager.GetSceneByName(UiSceneName).isLoaded) {
            Debug.Log("Loading UI");
            var asyncLoad = SceneManager.LoadSceneAsync(UiSceneName, LoadSceneMode.Additive);
            yield return asyncLoad;
        } else {
            Debug.Log("UI already loaded");
        }
        var uiScene = SceneManager.GetSceneByName(UiSceneName);

        // Find important UI elements in the new scene
        Card infoCardParent = null;
        UiPanel infoCard = null;
        QuizQuestionsListUi quizList = null;
        Canvas toggleParent = null;
        TerrainToggle toggle = null;
        foreach (var gameObject in uiScene.GetRootGameObjects()) {
            switch (gameObject.tag) {
                case "InfoCard":
                    infoCardParent = gameObject.GetComponent<Card>();
                    infoCard = gameObject.GetComponentInChildren<UiPanel>();
                    quizList = gameObject.GetComponentInChildren<QuizQuestionsListUi>(includeInactive: true);
                    break;
                case "TerrainControls":
                    toggleParent = gameObject.GetComponent<Canvas>();
                    toggle = gameObject.GetComponentInChildren<TerrainToggle>();
                    break;
            }
        }

        if (infoCardParent) {
            // Open an info card when a flag is tapped on
            Raycaster.OnHit.AddListener((_) => {
                infoCardParent.SetVisible(true);
                Raycaster.enabled = false;
            });

            infoCardParent.OnClose.AddListener(() => {
                Raycaster.enabled = true;
            });
        }
        if (infoCard) {
            Raycaster.OnHit.AddListener(infoCard.Display);
        }
        if (quizList) {
            Raycaster.OnHit.AddListener(content => quizList.Display(content.quizzes));
        }
        if (toggleParent) {
            Controller.OnTrack.AddListener(() => toggleParent.enabled = true);
            Controller.OnHidden.AddListener(() => toggleParent.enabled = false);
        }
        if (toggle) {
            toggle.OnChange.AddListener(Controller.SwapTo);
            Controller.Provider = (CurrentMapTypeProvider) toggle;
        }
    }
}
