using UnityEngine;
using UnityEngine.UI;

public class ButtonsInput : InputController
{
    [SerializeField] private Button upLeft;
    [SerializeField] private Button upRight;
    [SerializeField] private Button downLeft;
    [SerializeField] private Button downRight;

    private void Awake()
    {
        upLeft.onClick.AddListener(UpLeftHandler);
        upRight.onClick.AddListener(UpRightHandler);
        downLeft.onClick.AddListener(DownLeftHandler);
        downRight.onClick.AddListener(DownRightHandler);
    }

    private void UpLeftHandler() => ChangePlayerPosition(DirectionsTypes.UpLeft);
    private void UpRightHandler() => ChangePlayerPosition(DirectionsTypes.UpRight);
    private void DownLeftHandler() => ChangePlayerPosition(DirectionsTypes.DownLeft);
    private void DownRightHandler() => ChangePlayerPosition(DirectionsTypes.DownRight);
}