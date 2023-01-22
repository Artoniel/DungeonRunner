using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class CoinManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);


    [SerializeField] public int NumberOfCoins;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] public GameObject _AdvButton;

    [SerializeField] public ButtonEffect _maxHealthEffect;
    [SerializeField] public ButtonEffect _livesEffect;

    private ScoreManager scoreManager;
    
    private void Start()
    {
        NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
        UpdateCoins();
        ShopCoinUpdate();
        transform.parent = null;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    

    public void AddOne()
    {        
        NumberOfCoins++;
        UpdateCoins();
        scoreManager.IncreaseScore(1);
    }
    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo.Coins = NumberOfCoins;
    }

    public void SpendMoney(int value)
    {
        NumberOfCoins -= value;
        UpdateCoins();
        ShopCoinUpdate();
    }

    public void ShowAdvButton()
    {
        _AdvButton.SetActive(false);
        AudioListener.volume = 0;
#if UNITY_WEBGL && !UNITY_EDITOR
        
        AddCoinsExtern(100);
#endif

    }

    public void AddCoins (int value)
    {
        NumberOfCoins += value;
        UpdateCoins();
        SaveToProgress();
    }

    private void UpdateCoins()
    {
        _text.text = NumberOfCoins.ToString();
       
    }

    private void ShopCoinUpdate()
    {
        _maxHealthEffect.ResetSize();
        _maxHealthEffect.GetComponentInParent<ButtonEffect>().enabled = false;
        _livesEffect.ResetSize();
        _livesEffect.GetComponentInParent<ButtonEffect>().enabled = false;


        if (NumberOfCoins > 50)
        {
            _maxHealthEffect.GetComponentInParent<ButtonEffect>().enabled = true;
            if (NumberOfCoins > 150)
            {
                _livesEffect.GetComponentInParent<ButtonEffect>().enabled = true;
            }
        }
    }
}
