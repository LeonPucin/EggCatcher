using System;
using System.Collections.Generic;
using UnityEngine;

public class EggConveyor : MonoBehaviour
{
    [SerializeField] private List<GameObject> eggs;
    [SerializeField] private Level level;
    [SerializeField] private ReactionTimer reactionTimer;

    private int _amountEggs;
    private readonly List<Egg> _eggs = new();

    [HideInInspector] public float fixedBasketTime;

    public int AmountEggs
    {
        get => _amountEggs;
        private set
        {
            _amountEggs = value;
            HasEggs = _amountEggs > 0;
        }
    }

    public bool HasEggs { get; private set; }

    public event Action<EggConveyor> OnEggFell;

    private void Awake()
    {
        AmountEggs = 0;

        foreach (var egg in eggs)
        {
            egg.SetActive(false);
        }
    }

    private void Update()
    {
        foreach (var egg in _eggs)
        {
            egg.UpdateFallTime(((eggs.Count - egg.Index) * level.rateUpdateGameState) - level.lifeTimeCurrentUpdate);
        }
    }

    public void SpawnNewEgg()
    {
        eggs[0].SetActive(true);
        AmountEggs += 1;
        _eggs.Add(new Egg(level.rateUpdateGameState * eggs.Count, 0));
    }

    public void UpdateEggs()
    {
        for (int i = eggs.Count - 1; i >= 0; i--)
        {
            if (eggs[i].activeSelf)
            {
                eggs[i].SetActive(false);
                if (i == eggs.Count - 1)
                {
                    OnEggFell?.Invoke(this);
                    AmountEggs -= 1;

                    _eggs.Remove(FindEgg(_eggs, i));
                    FixBasketTime();
                }
                else
                {
                    eggs[i + 1].SetActive(true);
                    FindEgg(_eggs, i).Index += 1;
                }
            }
        }
    }

    private Egg FindEgg(List<Egg> container, int index)
    {
        foreach (var egg in container)
        {
            if (egg.Index == index)
                return egg;
        }

        throw new Exception();
    }

    public void FixBasketTime()
    {
        if (_eggs.Count > 0)
        {
            fixedBasketTime = _eggs[0].TimeToFall;
        }
    }

    public float TurnFixedBasketTime()
    {
        reactionTimer.TurnOnTimer(Math.Round(fixedBasketTime, 3).ToString());
        return fixedBasketTime;
    }
}