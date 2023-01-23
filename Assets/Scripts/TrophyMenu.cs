using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrophyMenu : MonoBehaviour
{
    [SerializeField] private GameObject _trophyMenu;
    [SerializeField] private GameObject _bronseMedal;
    [SerializeField] private GameObject _silverMedal;
    [SerializeField] private GameObject _goldMedal;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private GameObject _defaultSkinCheckMark;
    [SerializeField] private GameObject _rewardedSkinCheckMark;

    [SerializeField] private Slider _advSlider;
    [SerializeField] private TextMeshProUGUI _advSliderText;
    [SerializeField] private GameObject _rewardedLockIcon;


    private int _highScore;
    private bool _rewardedSkinUnlocked;
    private SkinManager _skinManager;
    private void Start()
    {
        _trophyMenu.SetActive(false);
        _skinManager = FindObjectOfType<SkinManager>();
        FullTrophyUpdate();
    }
    public void OpenTrophyMenu()
    {
        _trophyMenu.SetActive(true);
        FullTrophyUpdate();
    }

    public void CloseTrophyMenu()
    {
        _trophyMenu.SetActive(false);
    }

    public void SelectDefaultSkin()
    {
        _skinManager.DefaultSkinOn();
        UpdateSkins();
    }
    public void SelectRewardedSkin()
    {
        CheckUnlock();
        if (_rewardedSkinUnlocked)
        {
            _skinManager.RewardedSkinOn();
            UpdateSkins();
        }
    }

    private void CheckUnlock()
    {
        _rewardedSkinUnlocked = Progress.Instance.PlayerInfo.RewardedSkinUnlocked;
        _rewardedLockIcon.SetActive(false);
        _advSlider.gameObject.SetActive(false);
        if (_rewardedSkinUnlocked)
        {
            _rewardedLockIcon.SetActive(false);
            _advSlider.gameObject.SetActive(false);
        }
        else 
        {
            float adsWatched = Progress.Instance.PlayerInfo.AdsWatched;
            _advSlider.gameObject.SetActive(true);
            _rewardedLockIcon.SetActive(true);
            _advSliderText.text = new string(adsWatched.ToString() + "/15");
            float advSliderValue = (adsWatched/15);
            _advSlider.value = advSliderValue;
        }
    }
    
    private void UpdateSkins()
    {
        _rewardedSkinCheckMark.SetActive(false);
        _defaultSkinCheckMark.SetActive(false);
        if (Progress.Instance.PlayerInfo.RewardedSkinOn)
        {
            _rewardedSkinCheckMark.SetActive(true);
        }
        else
        {
            _defaultSkinCheckMark.SetActive(true);
        }

    }


    private void UpdateMedal()
    {
        _highScore = Progress.Instance.PlayerInfo.BestScore;
        _scoreText.text = _highScore.ToString();

        _bronseMedal.SetActive(false);
        _silverMedal.SetActive(false); 
        _goldMedal.SetActive(false);
        if (_highScore >= 1000)
        {
            _goldMedal.SetActive(true);
        }
        else if (_highScore <1000 && _highScore > 500)
        {
            _silverMedal.SetActive(true);
        }
        else 
        {
            _bronseMedal.SetActive(true);
        }
    }

    private void FullTrophyUpdate()
    {
        UpdateMedal();
        CheckUnlock();
        UpdateSkins();
    }
}
