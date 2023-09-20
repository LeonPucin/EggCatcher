using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private int indexGameScene;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private float volume;

    private void Awake()
    {
        startGameButton.onClick.AddListener(StartGameButtonHandler);
    }

    private void StartGameButtonHandler()
    {
        mixer.SetFloat("SoundVolume", volume);
        SceneManager.LoadScene(indexGameScene);
    }
}
