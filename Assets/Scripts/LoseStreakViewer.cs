using System.Collections.Generic;
using UnityEngine;

public class LoseStreakViewer : MonoBehaviour
{
    [SerializeField] private List<GameObject> crushedEggs;

    private void Awake()
    {
        foreach (var egg in crushedEggs)
        {
            egg.SetActive(false);
        }
    }

    public void UpdateState(LoseStreak loseStreak)
    {
        for (int i = 0; i < crushedEggs.Count; i++)
        {
            crushedEggs[i].SetActive(i <= loseStreak.Amount - 1);
        }
    }
}
