using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WareBase : MonoBehaviour
{
    protected bool isSelected;
    public string _currentPos;
    [SerializeField] protected WareType _wareType;
    [SerializeField] protected bool _isBlack;
    [SerializeField] protected GameObject _mapMarkPrefab;

    protected string _mapMarkCharData = "ABCDEFGH";
    protected int[] _mapMarkIntData = { 1, 2, 3, 4, 5, 6, 7, 8 };

    [SerializeField] private Material[] _matArr = new Material[2];

    public UnityAction ClickThisWareEvent;

    private void Start()
    {
        ClickThisWareEvent += LookCanMoveBlock;
        ClickThisWareEvent += () => LookOutLine(false);
    }

    public void ActiveClick()
    {
        ClickThisWareEvent?.Invoke();
    }

    public void LookOutLine(bool isRemove)
    {
        MeshRenderer _selectMR;
        for(int i = 0; i < transform.childCount; i++)
        {
            _selectMR = (MeshRenderer)transform.GetChild(i).GetComponent("MeshRenderer");
            Debug.Log(_selectMR);
            _selectMR.materials = isRemove ? null : _matArr;
        }
    }
    public abstract void LookCanMoveBlock();
}
