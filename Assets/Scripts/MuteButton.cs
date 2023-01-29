using System.Threading;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    [SerializeField] GameObject _muteIcon;
    private bool _isMuted = false;
    private bool _AdvPlaying;


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

    public void AdvMute()
    {
        _isMuted = Progress.Instance.PlayerInfo.SoundIsMuted;
        if (!_isMuted)
        {
            MuteButtonPush();
            _AdvPlaying= true;
        }

    }
    public void AdvUnmute()
    {
        if (_AdvPlaying)
        {
            MuteButtonPush();
            _AdvPlaying = false;
        }
    }
}
