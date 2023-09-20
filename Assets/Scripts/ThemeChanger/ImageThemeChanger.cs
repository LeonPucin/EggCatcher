using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ImageThemeChanger : MonoBehaviour, IThematicObject
{
    [SerializeField] private Color lightTheme;
    [SerializeField] private Color darkTheme;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeTheme(TypesThemes newTheme)
    {
        switch (newTheme)
        {
            case TypesThemes.Light:
                _image.color = lightTheme;
                break;
            case TypesThemes.Dark:
                _image.color = darkTheme;
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}
