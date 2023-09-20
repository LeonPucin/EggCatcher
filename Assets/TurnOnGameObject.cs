using UnityEngine;

public class TurnOnGameObject : MonoBehaviour
{
    [SerializeField] private GameObject turnedObject;

    private void Start()
    {
        turnedObject.SetActive(true);
    }
}
