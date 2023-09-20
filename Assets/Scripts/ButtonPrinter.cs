using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPrinter : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Color clickedColor;

    [HideInInspector] public bool isPressed = false;

    private Image _image;

    public event Action<ButtonPrinter> OnClicked;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        button.onClick.AddListener(ButtonHandler);
    }

    private void ButtonHandler()
    {
        isPressed = true;
        _image.color = clickedColor;
        OnClicked?.Invoke(this);
    }
}