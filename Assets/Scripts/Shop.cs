using System.Runtime.InteropServices;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AddLivesExtern();


    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private GameObject _livesButton;
    private PlayerModifier _playerModifier;


    private void Start() 
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void RewardedLives()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        AddLivesExtern();
#endif
        
    }


    public void BuyBonusLife()
    {
        Progress.Instance.PlayerInfo.Lives ++;
        _playerModifier.SetLives(Progress.Instance.PlayerInfo.Lives);
        Progress.Instance.WatchedAdsCounter();
        _livesButton.SetActive(false);
    }

    public void BuyMaxHealth()
    {
        if (_coinManager.NumberOfCoins >= 50)
        {
            _coinManager.SpendMoney(50);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.MaxHealth += 15;
            _playerModifier.SetMaxHealth(Progress.Instance.PlayerInfo.MaxHealth);
            _playerModifier.UpdateHealth();
        }
    }



}
