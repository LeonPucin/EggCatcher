using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TipBanner : MonoBehaviour
{
    [SerializeField] private GameObject continueText;

    public Button button;
    public TextMeshProUGUI tipName;
    public TextMeshProUGUI tipText;
    public TextMeshProUGUI indexTip;


    public void SetActiveContinueText(bool isActive)
    {
        continueText.SetActive(isActive);
    }
}
