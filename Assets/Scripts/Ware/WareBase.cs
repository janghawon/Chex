using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class WareBase : MonoBehaviour
{
    private Transform _weaponSpawnTrm;
    public WeaponBase EquipWeapon;
    private ClickObserver _wareClickObserver;
    public bool isSelected; 
    public string CurrentPos;
    [SerializeField] protected WareType _wareType;
    [SerializeField] protected bool _isBlack;
    protected BlockMarkSpawner _blockMarkSpawner;

    protected string _mapMarkCharData = "ABCDEFGHXXXXXX";
    protected int[] _mapMarkIntData = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    [SerializeField] private Material[] _activeMatArr = new Material[2];
    [SerializeField] private Material[] _removeMatArr = new Material[2];

    public UnityAction ClickThisWareActiveEvent;
    public UnityAction ClickThisWareRemoveEvent;

    private void Awake()
    {
        _blockMarkSpawner = GameObject.Find("BlockMarkSpawner").GetComponent<BlockMarkSpawner>();
        _wareClickObserver = GameObject.Find("WareClickObserver").GetComponent<ClickObserver>();

        _weaponSpawnTrm = transform.Find("WeaponTrm");
    }

    private void Start()
    {
        ClickThisWareActiveEvent += LookCanMoveBlock;
        ClickThisWareActiveEvent += () => LookOutLine(false);

        ClickThisWareRemoveEvent += RemoveCanMoveBlock;
        ClickThisWareRemoveEvent += () => LookOutLine(true);

        SetEquipWeapon(WeaponType.RIfle);
    }

    public void SetEquipWeapon(WeaponType wType)
    {
        WeaponManager.Instance.EquipWeapon(wType, _weaponSpawnTrm);
        
    }

    public void ClickEvent()
    {
        if (!isSelected)
            ClickThisWareActiveEvent?.Invoke();
        else
            ClickThisWareRemoveEvent?.Invoke();

        isSelected = !isSelected;
        _wareClickObserver.IsMoveWare = true;
    }

    public void LookOutLine(bool isRemove)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).TryGetComponent<MeshRenderer>(out MeshRenderer m))
            {
                m = (MeshRenderer)transform.GetChild(i).GetComponent("MeshRenderer");
                m.materials = isRemove ? _removeMatArr : _activeMatArr;
            }
        }
    }
    public abstract void LookCanMoveBlock();

    public void RemoveCanMoveBlock()
    {
        _blockMarkSpawner.RemoveCanMoveBlockMark(transform.position);
    }
}
