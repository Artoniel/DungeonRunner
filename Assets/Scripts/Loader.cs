using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    private class LoadingMonoBehaviour : MonoBehaviour { }
    
    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;
    

    public static void Load(int scene)
    {
        
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));        
        };

        int loadingSceneIndex = 1;
        SceneManager.LoadScene(loadingSceneIndex);

    }

    

    private static IEnumerator LoadSceneAsync(int scene) 
    {
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene);

        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static void LoaderCallback()
    {
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback= null;
        }
    }
}
