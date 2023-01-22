using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int Coins;
    public int MaxHealth = 100;
    public int Level = 2;
    public int Lives = 1;
    public int Score;
    public int BestScore;
    public bool SoundIsMuted = false;
    
}

public class Progress : MonoBehaviour
{

    public PlayerInfo PlayerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField] private TextMeshProUGUI _playerInfoText;

    public static Progress Instance;

    private void Awake() 
    {
        

        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadExternalData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
            ResetProgress();
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);

#if UNITY_WEBGL && !UNITY_EDITOR
        SaveExtern(jsonString);
#endif
    }

 
    public void ResetProgress()
    {
        int scoreBuffer = PlayerInfo.BestScore;
        PlayerInfo = new PlayerInfo();
        PlayerInfo.BestScore= scoreBuffer;
        Save();
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        _playerInfoText.text = "Coins: " + PlayerInfo.Coins + "\n" + "MaxHealth: " + PlayerInfo.MaxHealth + "\n" + "Level: " + PlayerInfo.Level + "\n" + "Lives: " + PlayerInfo.Lives + "\n" + "Score: " + PlayerInfo.Score + "\n" + "Is Muted: " + PlayerInfo.SoundIsMuted;
    }
    public void LoadExternalData()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        LoadExtern();
#endif
    }
}
