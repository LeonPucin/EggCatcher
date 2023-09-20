using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThemeChanger : MonoBehaviour
{
    private List<IThematicObject> _thematicObjects;

    private void Awake()
    {
        _thematicObjects = FindObjectsOfType<GameObject>()
            .Select(t => t.GetComponent<IThematicObject>())
            .Where(t => t != null).ToList();
    }

    public void ChangeTheme(TypesThemes newTheme)
    {
        _thematicObjects.ForEach(o => o.ChangeTheme(newTheme));
    }
}