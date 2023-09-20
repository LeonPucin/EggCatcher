using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;

    private void Awake()
    {
        gameObjects.ForEach(DontDestroyOnLoad);
    }
}
