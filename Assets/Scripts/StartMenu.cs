using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public void StartGame() 
    {
        int sceneNumber = Progress.Instance.PlayerInfo.Level;
        Debug.Log("Loading: " + sceneNumber);
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAdv();
#endif
        Loader.Load(sceneNumber);
    }



}
