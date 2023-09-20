using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int indexScene;

    private void Start()
    {
        SceneManager.LoadScene(indexScene);
    }
}
