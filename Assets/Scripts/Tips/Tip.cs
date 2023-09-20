using UnityEngine;

public class Tip : MonoBehaviour
{
    public string nameTip;
    public string textOfTip;

    public virtual void Play(TipBanner banner)
    {
        banner.tipName.text = nameTip;
        banner.tipText.text = textOfTip;
    }

    public virtual bool Close(TipBanner banner)
    {
        return true;
    }
}