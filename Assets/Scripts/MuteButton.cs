using UnityEngine;

public class MuteButton : MonoBehaviour
{
    [SerializeField] GameObject _muteIcon;
    private bool _isMuted = false;

    private void Start()
    {
        _isMuted = Progress.Instance.PlayerInfo.SoundIsMuted;
        MuteButtonIcon();
    }

    public void MuteButtonPush()
    {
        FindObjectOfType<SoundManager>().MutePress();
        _isMuted = !_isMuted;
        MuteButtonIcon();
    }

    private void MuteButtonIcon()
    {
        if (_isMuted)
        {
            _muteIcon.SetActive(true);
        }
        else
        {
            _muteIcon.SetActive(false);
        }
    }
}
