using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public abstract class WareBase : MonoBehaviour
{
    protected bool isSelected;
    public string _currentPos;
    [SerializeField] protected WareType _wareType;
    [SerializeField] protected bool _isBlack;
    [SerializeField] protected GameObject _mapMarkPrefab;

    protected string _mapMarkCharData = "ABCDEFGH";
    protected int[] _mapMarkIntData = { 1, 2, 3, 4, 5, 6, 7, 8 };

    [SerializeField] private Material[] _activeMatArr = new Material[2];
    [SerializeField] private Material[] _removeMatArr = new Material[2];
    [SerializeField] protected List<GameObject> _mMarkList = new List<GameObject>();

    public UnityAction ClickThisWareActiveEvent;
    public UnityAction ClickThisWareRemoveEvent;

    private void Start()
    {
        ClickThisWareActiveEvent += LookCanMoveBlock;
        ClickThisWareActiveEvent += () => LookOutLine(false);

        ClickThisWareRemoveEvent += RemoveCanMoveBlock;
        ClickThisWareRemoveEvent += () => LookOutLine(true);
    }

    public void ClickEvent()
    {
        if (!isSelected)
            ClickThisWareActiveEvent?.Invoke();
        else
            ClickThisWareRemoveEvent?.Invoke();

        isSelected = !isSelected;
    }

    public void LookOutLine(bool isRemove)
    {
        MeshRenderer _selectMR;
        for(int i = 0; i < transform.childCount; i++)
        {
            _selectMR = (MeshRenderer)transform.GetChild(i).GetComponent("MeshRenderer");
            _selectMR.materials = isRemove ? _removeMatArr : _activeMatArr;
        }
    }
    public abstract void LookCanMoveBlock();

    private void RemoveCanMoveBlock()
    {
        int max = _mMarkList.Count;
        for(int i = 0; i < max; i++)
        {
            GameObject selectMM = _mMarkList[0];
            _mMarkList.Remove(_mMarkList[0]);
            selectMM.transform.DOMove(new Vector3(transform.position.x, 9.5f, transform.position.z), 0.3f);
            Destroy(selectMM, 0.3f);
        }
    }
}
