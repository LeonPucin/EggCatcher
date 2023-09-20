using UnityEngine;
using UnityEngine.SceneManagement;

public class ClosedTip : Tip
{
    [SerializeField] private int indexNextScene;
    
    public override bool Close(TipBanner banner)
    {
        SceneManager.LoadScene(indexNextScene);
        return true;
    }
}
