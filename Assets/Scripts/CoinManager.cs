using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddCoinsExtern(int value);


    [SerializeField] public int NumberOfCoins;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _textBonusCoins;
    [SerializeField] public GameObject _AdvButton;

    [SerializeField] public ButtonEffect _maxHealthEffect;

    private ScoreManager scoreManager;
    private int _bonusCoins;
    
    private void Start()
    {
        _bonusCoins = 0;
        NumberOfCoins = Progress.Instance.PlayerInfo.Coins;
        UpdateCoins();
        ShopCoinUpdate();
        transform.parent = null;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    

    public void AddOne()
    {        
        NumberOfCoins++;
        _bonusCoins += 2;
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
        
        AddCoinsExtern(_bonusCoins);
#endif

    }

    public void AddCoins (int value)
    {
        NumberOfCoins += value;
        UpdateCoins();
        Progress.Instance.WatchedAdsCounter();
        SaveToProgress();
    }

    private void UpdateCoins()
    {
        _text.text = NumberOfCoins.ToString();
        _textBonusCoins.text = ("+" + _bonusCoins.ToString());
       
    }

    private void ShopCoinUpdate()
    {
        _maxHealthEffect.ResetSize();
        _maxHealthEffect.GetComponentInParent<ButtonEffect>().enabled = false;
        


        if (NumberOfCoins > 50)
        {
            _maxHealthEffect.GetComponentInParent<ButtonEffect>().enabled = true;
            
        }
    }
}
