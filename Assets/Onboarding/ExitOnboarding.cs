using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitOnboarding : MonoBehaviour
{
    [SerializeField]
    private string sceneToOpen;
	[SerializeField]
	private bool preloadOnStart;

    private AsyncOperation loadingScene = null;

	void Start()
	{
		if (preloadOnStart)
		{
			PreloadNewScene();
		}
	}

	void OnApplicationQuit()
    {
        if (loadingScene != null)
        {
            loadingScene.allowSceneActivation = true;
        }
    }

    public void ExitToNewScene()
    {
        StartCoroutine(ExitRoutine());
    }

    public void PreloadNewScene()
    {
        StartCoroutine(PreloadRoutine());
    }

    private IEnumerator ExitRoutine()
    {
        yield return PreloadRoutine();
        loadingScene.allowSceneActivation = true;
    }

    private IEnumerator PreloadRoutine()
    {
        if (loadingScene == null)
        {
            loadingScene = SceneManager.LoadSceneAsync(sceneToOpen, LoadSceneMode.Single);
            loadingScene.allowSceneActivation = false;
            yield return loadingScene;
        }
    }
}
