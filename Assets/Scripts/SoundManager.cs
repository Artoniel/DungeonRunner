using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private bool _muted;

    private void Start()
    {
        _muted = Progress.Instance.PlayerInfo.SoundIsMuted;
    }

    public void MutePress()
    {
        _muted = !_muted;

        if (_muted ) AudioListener.volume = 0;
        else AudioListener.volume = 1;

        Progress.Instance.PlayerInfo.SoundIsMuted = _muted;
    }

}
