using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] GameObject _defaultSkin;
    [SerializeField] GameObject _rewardedSkin;

    private void Start()
    {
        UpdateSkin();
    }

    public void DefaultSkinOn()
    {
        Progress.Instance.PlayerInfo.RewardedSkinOn = false;
        UpdateSkin();
        Progress.Instance.Save();
    }

    public void RewardedSkinOn()
    {
        Progress.Instance.PlayerInfo.RewardedSkinOn = true;
        UpdateSkin();
        Progress.Instance.Save();
    }

    private void UpdateSkin()
    {
        _defaultSkin.SetActive(false);
        _rewardedSkin.SetActive(false);
        if (Progress.Instance.PlayerInfo.RewardedSkinOn)
        {
            _rewardedSkin.SetActive(true);
        }
        else
        {
            _defaultSkin.SetActive(true);
        }
    }
}
