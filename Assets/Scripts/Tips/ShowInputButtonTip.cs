using System.Collections.Generic;
using UnityEngine;

public class ShowInputButtonTip : Tip
{
    [SerializeField] private GameObject buttonsArea;
    [SerializeField] private GameObject splash;
    [SerializeField] private List<ButtonPrinter> buttons;
    [SerializeField] private ButtonsInput buttonsInput;

    private bool _isAllButtonsPressed = false;
    private TipBanner _banner;

    private void OnEnable()
    {
        buttons.ForEach(x => x.OnClicked += OnButtonClicked);
    }

    private void OnButtonClicked(ButtonPrinter obj)
    {
        buttons.Remove(obj);
        if (buttons.Count <= 0)
        {
            _isAllButtonsPressed = true;
            _banner.SetActiveContinueText(true);
        }
    }

    public override void Play(TipBanner banner)
    {
        _banner = banner;
        
        base.Play(banner);
        splash.SetActive(true);
        buttonsArea.SetActive(true);
        buttonsInput.onEnable = true;
        banner.SetActiveContinueText(false);
    }

    public override bool Close(TipBanner banner)
    {
        if (_isAllButtonsPressed == false)
            return false;
        
        splash.SetActive(false);
        buttonsArea.SetActive(false);
        buttonsInput.onEnable = false;

        return base.Close(banner);
    }
}
