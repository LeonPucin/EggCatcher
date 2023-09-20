using System.Collections.Generic;
using UnityEngine;

public class TipPlayer : MonoBehaviour
{
    [SerializeField] private TipBanner banner;
    [SerializeField] private List<Tip> tips;

    private int _indexCurrentTip = 0;

    private void OnEnable()
    {
        banner.button.onClick.AddListener(TryShowNextTip);
    }
    
    private void Start()
    {
        ShowNextTip(tips[_indexCurrentTip], banner);
    }

    private void ShowNextTip(Tip tip, TipBanner tipBanner)
    {
        tipBanner.indexTip.text = $"{_indexCurrentTip + 1} / {tips.Count}";
        tip.Play(tipBanner);
    }

    private void TryShowNextTip()
    {
        bool result = tips[_indexCurrentTip].Close(banner);
        if (result == false)
            return;

        _indexCurrentTip += 1;
        if (_indexCurrentTip < tips.Count)
        {
            ShowNextTip(tips[_indexCurrentTip], banner);
        }
    }
}