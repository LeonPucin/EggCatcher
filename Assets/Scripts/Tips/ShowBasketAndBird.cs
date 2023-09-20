using UnityEngine;

public class ShowBasketAndBird : Tip
{
    [SerializeField] private GameObject splash;
    
    public override void Play(TipBanner banner)
    {
        base.Play(banner);

        splash.SetActive(true);
    }

    public override bool Close(TipBanner banner)
    {
        splash.SetActive(false);
        return base.Close(banner);
    }
}
