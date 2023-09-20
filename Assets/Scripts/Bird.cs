using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Sprite idleBird;
    [SerializeField] private Sprite shockBird;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        TurnOnIdleBird();
    }

    public void Flip(DirectionsTypes direction)
    {
        switch (direction)
        {
            case DirectionsTypes.Right:
                _spriteRenderer.flipX = false;
                break;
            case DirectionsTypes.Left:
                _spriteRenderer.flipX = true;
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
    }

    public void StartAnimationShock(float animDuration)
    {
        StartCoroutine(ShockAnimation(animDuration));
    }

    public void TurnOnShock() => TurnOnShockBird();

    private IEnumerator ShockAnimation(float animDuration)
    {
        TurnOnShockBird();
        yield return new WaitForSeconds(animDuration);
        TurnOnIdleBird();
    }

    private void TurnOnIdleBird() => _spriteRenderer.sprite = idleBird;
    private void TurnOnShockBird() => _spriteRenderer.sprite = shockBird;
}
