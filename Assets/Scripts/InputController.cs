using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] protected Bird bird;
    [SerializeField] protected Basket basket;

    [HideInInspector] public bool onEnable = false;

    protected void ChangePlayerPosition(DirectionsTypes types)
    {   
        if (onEnable == false)
            return;
        
        switch (types)
        {
            case DirectionsTypes.UpLeft:
                bird.Flip(DirectionsTypes.Left);
                basket.ChangePosition(Vector2Int.up + Vector2Int.left);
                break;

            case DirectionsTypes.UpRight:
                bird.Flip(DirectionsTypes.Right);
                basket.ChangePosition(Vector2Int.up + Vector2Int.right);
                break;

            case DirectionsTypes.DownLeft:
                bird.Flip(DirectionsTypes.Left);
                basket.ChangePosition(Vector2Int.down + Vector2Int.left);
                break;

            case DirectionsTypes.DownRight:
                bird.Flip(DirectionsTypes.Right);
                basket.ChangePosition(Vector2Int.down + Vector2Int.right);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(types), types, null);
        }
    }
}
