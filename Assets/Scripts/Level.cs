using System.Collections;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private Animator birdAnimator;
    [SerializeField] private Basket basket;

    [SerializeField] private InputController controller;
    [SerializeField] private GameObject buttonArea;

    [SerializeField] private LosePanel losePanel;
    [SerializeField] private LoseStreakViewer loseStreakViewer;

    [SerializeField] private EggConveyorController eggController;
    [SerializeField] private ThemeChanger themeChanger;
    [SerializeField] private TypesThemes startTheme;

    [SerializeField] private int amountSpawnEggPerUpdate;
    public float rateUpdateGameState;

    [SerializeField] private AudioClip eggCatch;
    [SerializeField] private AudioClip eggCrushed;

    [SerializeField] private ScoreSummer scoreSummer;
    [SerializeField] private float scoreModificator = 1f;

    private readonly LoseStreak _loseStreak = new LoseStreak(0);

    private Coroutine _update;
    private AudioSource _audioSource;
    private bool _isGodMod = false;

    [HideInInspector] public float lifeTimeCurrentUpdate = 0f;

    private void Awake()
    {
        controller.onEnable = true;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        eggController.OnEggFell += OnEggFell;
    }

    private void OnDisable()
    {
        eggController.OnEggFell -= OnEggFell;
    }

    private void Start()
    {
        themeChanger.ChangeTheme(startTheme);
        _update = StartCoroutine(StartGameUpdate());
    }

    private float _lifeTimeGame;

    private void UpdateDifficultyOfGame()
    {
        _lifeTimeGame += Time.deltaTime;

        if (_lifeTimeGame is > 10 and <= 80)
        {
            rateUpdateGameState = 1 - _lifeTimeGame / 100;
        }

        if (scoreSummer.Score.Amount > 1000)
        {
            rateUpdateGameState = 0.3f;
            amountSpawnEggPerUpdate = 1;
        }
    }

    private void Update()
    {
        UpdateDifficultyOfGame();

        lifeTimeCurrentUpdate += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Home))
        {
            _isGodMod = !_isGodMod;
        }
    }

    private int _counter;

    private IEnumerator StartGameUpdate()
    {
        while (true)
        {
            eggController.UpdateState();
            if (_counter % amountSpawnEggPerUpdate == 0)
                eggController.SpawnRandomEgg();

            _counter++;

            lifeTimeCurrentUpdate = 0f;
            yield return new WaitForSeconds(rateUpdateGameState);
        }
    }

    private void OnEggFell(int index)
    {
        if (index == basket.CurrentPosition)
            EggCatch(index);
        else
            EggCrashed();
    }

    private void EggCrashed()
    {
        _loseStreak.Amount += 1;
        loseStreakViewer.UpdateState(_loseStreak);

        PlaySound(eggCrushed);

        if (_loseStreak.Amount >= 3 && !_isGodMod)
        {
            EndGame();
            return;
        }

        bird.StartAnimationShock(0.7f);
    }

    private void EggCatch(int conveyorIndex)
    {
        float reactionTime = eggController.TurnReactionTime(conveyorIndex);

        scoreSummer.UpdateScore(scoreModificator, reactionTime);

        PlaySound(eggCatch);
    }

    private static readonly int BirdAnimStart = Animator.StringToHash("BirdAnimStart");

    private void EndGame()
    {
        bird.TurnOnShock();
        losePanel.Show(scoreSummer.Score);
        controller.onEnable = false;
        birdAnimator.SetTrigger(BirdAnimStart);
        buttonArea.SetActive(false);
        StopCoroutine(_update);
    }

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}