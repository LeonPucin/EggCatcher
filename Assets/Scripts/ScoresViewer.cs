using System;
using UnityEngine;
using TMPro;

public class ScoresViewer : MonoBehaviour
{ 
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateScore(Score score)
    {
        scoreText.text = score.Amount.ToString();
    }
}
