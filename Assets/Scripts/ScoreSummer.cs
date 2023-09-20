using TMPro;
using UnityEngine;

public class ScoreSummer : MonoBehaviour
{
    [SerializeField] private ScoresViewer scoresViewer;
    [SerializeField] private TextMeshProUGUI addedScoreText;
    [SerializeField] private Animator addedTextAnimator;
    
    public readonly Score Score = new Score(0);
    private int _addedScore;
    private static readonly int ScoreAdded = Animator.StringToHash("AddText");

    private void Start()
    {
        scoresViewer.UpdateScore(Score);
    }

    public void UpdateScore(float modificator, float timeReaction)
    {
        int timeModificator = timeReaction >= 1 ? 1 : (int)((1 - timeReaction) * 10);
        _addedScore = (int)(modificator * timeModificator);

        addedScoreText.text = $"+ {_addedScore}";
        addedTextAnimator.SetTrigger(ScoreAdded);
    }

    public void OnAnimationEnd()
    {
        Score.Amount += _addedScore;
        scoresViewer.UpdateScore(Score);
    }
}
