using System.ComponentModel;
using TMPro;
using UnityEngine;

public class TextThemeChanger : MonoBehaviour, IThematicObject
{
    [SerializeField] private Color lightTheme;
    [SerializeField] private Color darkTheme;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeTheme(TypesThemes newTheme)
    {
        switch (newTheme)
        {
            case TypesThemes.Light:
                _text.color = lightTheme;
                break;
            case TypesThemes.Dark:
                _text.color = darkTheme;
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}