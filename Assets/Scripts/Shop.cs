using UnityEngine;

public class Shop : MonoBehaviour
{
[SerializeField] private CoinManager _coinManager;
private PlayerModifier _playerModifier;


private void Start() 
{
    _playerModifier = FindObjectOfType<PlayerModifier>();
}

   


    public void BuyBonusLife()
    {
        if (_coinManager.NumberOfCoins >= 150)
        {
            _coinManager.SpendMoney(150);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.Lives ++;
            _playerModifier.SetLives(Progress.Instance.PlayerInfo.Lives);

        }
    }

    public void BuyMaxHealth()
    {
        if (_coinManager.NumberOfCoins >= 50)
        {
            _coinManager.SpendMoney(50);
            Progress.Instance.PlayerInfo.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.PlayerInfo.MaxHealth += 25;
            _playerModifier.SetMaxHealth(Progress.Instance.PlayerInfo.MaxHealth);
            _playerModifier.UpdateHealth();
        }
    }



}
