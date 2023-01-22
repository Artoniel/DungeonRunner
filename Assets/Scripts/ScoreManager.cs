using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [SerializeField] public int PlayerScore;
    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] TextMeshProUGUI _textScoreFinish;
    [SerializeField] TextMeshProUGUI _textScoreLose;
    [SerializeField] TextMeshProUGUI _textBestScoreLose;
    [SerializeField] TextMeshProUGUI _textBestScoreFinish;

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
        CheckBestScore();

#if UNITY_WEBGL && !UNITY_EDITOR
        SetToLeaderboard(Progress.Instance.PlayerInfo.BestScore);
#endif


        Progress.Instance.PlayerInfo.Score = PlayerScore;
    }

    private void UpdateScoreText()
    {

        _textScore.text = PlayerScore.ToString();
        _textScoreLose.text = _textScore.text;
        _textBestScoreLose.text = Progress.Instance.PlayerInfo.BestScore.ToString();

        if (_textScoreFinish != null)
        {
            _textScoreFinish.text = _textScore.text;
            _textBestScoreFinish.text = _textBestScoreLose.text;
        }
    }

    private void CheckBestScore()
    {
        if (PlayerScore > Progress.Instance.PlayerInfo.BestScore)
        {
            Progress.Instance.PlayerInfo.BestScore = PlayerScore;
        }
    }
}
