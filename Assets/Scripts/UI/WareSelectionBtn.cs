using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class WareSelectionBtn : MonoBehaviour
{
    [SerializeField] private Image _wareImage;
    [SerializeField] private TextMeshProUGUI _wareName;
    public WareType WType;
    public bool IsBlack
    {
        get
        {
            return IsBlack;
        }
        set
        {
            if(!value)
            {
                _wareImage.sprite = WareManager.Instance.WareSprites[(int)WType];
                _wareName.text = $"White {WType}";
            }
            else
            {
                _wareImage.sprite = WareManager.Instance.WareSprites[(int)WType + 6];
                _wareName.text = $"Black {WType}";
            }
        }
    }

    public void DetectRangeConnector()
    {
        GameObject wcm = GameObject.Find("WareCollocateMaster");
        RangeSelecter rs = wcm.GetComponent<RangeSelecter>();
        WareCollocater wc = wcm.GetComponent<WareCollocater>();

        rs.DetectRange();
        wc.SelectWare(WType, IsBlack);
    }
}
