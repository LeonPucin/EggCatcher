using System.ComponentModel;
using UnityEngine;

public class SpriteThemeChanger : MonoBehaviour, IThematicObject
{
    [SerializeField] private Color lightTheme;
    [SerializeField] private Color darkTheme;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeTheme(TypesThemes newTheme)
    {
        switch (newTheme)
        {
            case TypesThemes.Light:
                _spriteRenderer.color = lightTheme;
                break;
            case TypesThemes.Dark:
                _spriteRenderer.color = darkTheme;
                break;
            default:
                throw new InvalidEnumArgumentException();
        }
    }
}
