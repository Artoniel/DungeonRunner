using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame() 
    {
        int sceneNumber = Progress.Instance.PlayerInfo.Level;
        Debug.Log("Loading: " + sceneNumber);

        Loader.Load(sceneNumber);
    }

}
