using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareCollocater : MonoBehaviour
{
    [SerializeField] private GameObject _wsbPrefabs;
    WareSelectionBtn _wareSelectionBtn;
    private Transform _content;
    #region 기물 정보 저장

    [Header("기물 정보")]
    private WareType _wType;
    public WareType WType => _wType;
    
    private bool _isBlack;
    public bool IsBlack => _isBlack;

    public void SelectWare(WareType _wt, bool isBlack)
    {
        _wType = _wt;
        _isBlack = isBlack;
    }
    #endregion

    private void Awake()
    {
        _content = GameObject.Find("UICAN/WareSelectionGroup/SelectionBtnScroll/Viewport/Content").transform;
    }

    private void Start()
    {
        for(int i = 0; i < WareManager.Instance.WarePrefabs.Count; i++)
        {
            _wareSelectionBtn = (WareSelectionBtn)Instantiate(_wsbPrefabs, _content).GetComponent("WareSelectionBtn");
            if(i <= 5)
            {
                _wareSelectionBtn.WType = (WareType)i;
            }
            else
            {
                _wareSelectionBtn.WType = (WareType)i - 5;
                _wareSelectionBtn.IsBlack = true;
            }
        }
    }
}
