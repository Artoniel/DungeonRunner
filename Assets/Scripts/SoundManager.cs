using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private bool _muted;

    private void Start()
    {
        _muted = Progress.Instance.PlayerInfo.SoundIsMuted;
        UpdateSound();
    }

    public void MutePress()
    {
        _muted = !_muted;
        UpdateSound();
        Progress.Instance.PlayerInfo.SoundIsMuted = _muted;
    }

    public void UpdateSound()
    {
        if (_muted) AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }

}
