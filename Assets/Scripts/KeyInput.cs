using UnityEngine;

public class KeyInput : InputController
{
    private void Update()
    {
        if (onEnable)
            UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            bird.Flip(DirectionsTypes.Right);
            basket.ChangePosition(Vector2Int.right);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bird.Flip(DirectionsTypes.Left);
            basket.ChangePosition(Vector2Int.left);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            basket.ChangePosition(Vector2Int.up);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            basket.ChangePosition(Vector2Int.down);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangePlayerPosition(DirectionsTypes.UpLeft);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangePlayerPosition(DirectionsTypes.UpRight);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangePlayerPosition(DirectionsTypes.DownLeft);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangePlayerPosition(DirectionsTypes.DownRight);
        }
    }
}
