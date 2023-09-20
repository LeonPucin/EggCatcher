using TMPro;
using UnityEngine;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TextMeshProUGUI scoresText;
    
    private static readonly int ShowPanel = Animator.StringToHash("ShowPanel");

    public void Show(Score score)
    {
        animator.SetTrigger(ShowPanel);
        ResetScore(score);
    }

    private void ResetScore(Score score)
    {
        scoresText.text = $"Очки: {score.Amount}";
    }
}
