using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern void ShowAdv();


    [SerializeField] private GameObject _startMenu;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private GameObject _finishfWindow;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private GameObject _deathWindow;
    [SerializeField] private GameObject _loseWindow;

    private void Start() 
    {
        _finishfWindow.SetActive(false);
        _deathWindow.SetActive(false);
        _loseWindow.SetActive(false);
        _levelText.text = (SceneManager.GetActiveScene().buildIndex - 1).ToString();
    }

    public void Play()
    {
        Progress.Instance.Save();
        _startMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();

#if UNITY_WEBGL && !UNITY_EDITOR
        Progress.Instance.Save();
#endif
    }
    public void ShowFinishWindow()
    {
        FindObjectOfType<ScoreManager>().SaveToProgress();
        _finishfWindow.SetActive(true);
    }
    public void ShowDeathWindow()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAdv();
#endif
        _deathWindow.SetActive(true);
    }
    public void ShowLoseWindow()
    {
        FindObjectOfType<ScoreManager>().SaveToProgress();
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAdv();
#endif
        _loseWindow.SetActive(true);
    }

    public void NextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();
            FindObjectOfType<ScoreManager>().SaveToProgress();
            Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;


            Progress.Instance.Save();
            SceneManager.LoadScene(nextScene);
        }
        
    }
    public void RestartLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        
        _coinManager.SaveToProgress();
        Progress.Instance.PlayerInfo.Lives += -1;
        Progress.Instance.PlayerInfo.Level = SceneManager.GetActiveScene().buildIndex;
        Progress.Instance.Save();
        SceneManager.LoadScene(currentScene);
           
    }
    public void RestartGame()
    {
        Progress.Instance.ResetProgress();
#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAdv();
#endif
        SceneManager.LoadScene(2);
    }
}
