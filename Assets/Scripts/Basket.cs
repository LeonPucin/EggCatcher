using System;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private List<Vector3> positions;
    [SerializeField] private AudioClip soundMove;
    [SerializeField] private EggConveyorController eggConveyors;

    private AudioSource _audioSource;
    private int _currentPosition = -1;
    
    public int CurrentPosition => _currentPosition;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = soundMove;
        
        ChangePosition(Vector2Int.left + Vector2Int.down);
        _currentPosition = 1;
    }

    public void ChangePosition(Vector2Int direction)
    {
        if (Math.Abs(direction.x) > 1 || Math.Abs(direction.y) > 1)
            throw new ArgumentException();

        int indexPosition = _currentPosition;

        indexPosition += 2 * direction.x;

        if (_currentPosition % 2 == 0)
            indexPosition = Math.Clamp(indexPosition, 0, 2);
        else
            indexPosition = Math.Clamp(indexPosition, 1, 3);

        if (direction.y < 0 && _currentPosition % 2 == 0 || direction.y > 0 && _currentPosition % 2 != 0)
            indexPosition -= direction.y;
        
        if (_currentPosition == indexPosition)
            return;
        
        transform.position = positions[indexPosition];
        eggConveyors.UpdateBasketPosition(indexPosition);
        
        _currentPosition = indexPosition;
        _audioSource.Play();
    }
}