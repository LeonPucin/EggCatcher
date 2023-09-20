using TMPro;
using UnityEngine;

public class ReactionTimer : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private TextMeshProUGUI _text;
    private static readonly int TurnOnAnimationText = Animator.StringToHash("TurnText");

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void TurnOnTimer(string text)
    {
        _text.text = text;
        animator.SetTrigger(TurnOnAnimationText);
    }
}
