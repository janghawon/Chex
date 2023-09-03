using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WareBase : MonoBehaviour
{
    protected bool isSelected;
    public string _currentPos;
    [SerializeField] protected WareType _wareType;
    [SerializeField] protected bool _isBlack;
    [SerializeField] protected GameObject _mapMarkPrefab;

    protected string _mapMarkCharData = "ABCDEFGH";
    protected int[] _mapMarkIntData = { 1,2,3,4,5,6,7,8 };
    private Transform _mapDataParent;

    public abstract void SelectThisWare();
}
