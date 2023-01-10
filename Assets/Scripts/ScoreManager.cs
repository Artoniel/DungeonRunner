using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard();

    [SerializeField] public int PlayerScore;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _textFinish;
    [SerializeField] TextMeshProUGUI _textLose;

    private void Start()
    {
        PlayerScore = Progress.Instance.PlayerInfo.Score;
        UpdateScoreText();
    }

    public void IncreaseScore(int value)
    {
        PlayerScore+= value;
        UpdateScoreText();
    }

    public void SaveToProgress()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        SetToLeaderboard();
#endif
        Progress.Instance.PlayerInfo.Score = PlayerScore;
    }

    private void UpdateScoreText()
    {
        _text.text = PlayerScore.ToString();
        _textLose.text = _text.text;

        if (_textFinish != null)
        {
            _textFinish.text = _text.text;
        }

    }
}
