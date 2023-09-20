using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class EggConveyorController : MonoBehaviour
{
    [SerializeField] private List<EggConveyor> eggConveyors;
    [SerializeField] private AudioClip soundUpdate;

    private readonly Random _random = new();
    private AudioSource _audioSource;

    private int _indexBasketPosition;

    public event Action<int> OnEggFell;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        foreach (var eggConveyor in eggConveyors)
        {
            eggConveyor.OnEggFell += EggFell;
        }
    }

    private void OnDisable()
    {
        foreach (var eggConveyor in eggConveyors)
        {
            eggConveyor.OnEggFell -= EggFell;
        }
    }

    private void EggFell(EggConveyor conveyor)
    {
        OnEggFell?.Invoke(eggConveyors.IndexOf(conveyor));
    }

    public void UpdateState()
    {
        bool conveyorsHasEggs = ConveyorsHasEggs();
        if (conveyorsHasEggs)
        {
            _audioSource.clip = soundUpdate;
            _audioSource.Play();
        }

        foreach (var eggConveyor in eggConveyors)
        {
            eggConveyor.UpdateEggs();
        }
    }

    private bool ConveyorsHasEggs()
    {
        return eggConveyors.Any(x => x.HasEggs);
    }

    public void SpawnRandomEgg()
    {
        eggConveyors[_random.Next(0, eggConveyors.Count)].SpawnNewEgg();
    }

    public void UpdateBasketPosition(int indexPosition)
    {
        eggConveyors[indexPosition].FixBasketTime();
    }

    public float TurnReactionTime(int conveyorIndex)
    {
        float reactionTime = eggConveyors[conveyorIndex].TurnFixedBasketTime();
        return reactionTime;
    }
}