using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponManager : ObjectManager
{
    public static WeaponManager Instance;
    [SerializeField] private float _moveSpeed = 0.7f;
    [Header("ºÒ¥ı∫‰")]
    [SerializeField] private Vector3 _toSoulderPos = new Vector3(3.3f, 4, -3f);
    [SerializeField] private Vector3 _toSoulderRot = new Vector3(26.5f, -44f, 0);
    [Header("ƒı≈Õ∫‰")]
    [SerializeField] private Vector3 _toQuatPos = new Vector3(54.7f, 85.8f, -61.2f);
    [SerializeField] private Vector3 _toQuatRot = new Vector3(50.9f, -44f, 0);

    public WeaponBase SelectWeapon;
    [SerializeField] private List<WeaponInfo> _weaponInfos = new List<WeaponInfo>();

    public Camera MainCam;

    private bool _isActiveShoulderView;

    public override void SetInstance()
    {
        Instance = this;
        MainCam = Camera.main;
    }

    public void ActiveShoulderView()
    {
        if(!_isActiveShoulderView)
        {
            MainCam.transform.parent = WareManager.Instance.SelectWare.transform;
            MainCam.transform.DOLocalMove(_toSoulderPos, _moveSpeed);
            MainCam.transform.DOLocalRotate(_toSoulderRot, _moveSpeed);
            ScreenManager.Instance.CanDrag = true;
        }
        else
        {
            MainCam.transform.parent = null;
            MainCam.transform.DOMove(_toQuatPos, _moveSpeed);
            MainCam.transform.DORotate(_toQuatRot, _moveSpeed);
        }
        _isActiveShoulderView = !_isActiveShoulderView;
    }

    public void EquipWeapon(WeaponType wType, Transform parent)
    {
        GameObject weapon = Instantiate(_weaponInfos[(int)wType].WeaponPrefab.gameObject);
        SelectWeapon = weapon.GetComponent<WeaponBase>();
        weapon.transform.position = parent.position;
        weapon.transform.parent = parent;

        WareManager.Instance.SelectWare.EquipWeapon = SelectWeapon;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            WareManager.Instance.ReadyToAttack();
            ActiveShoulderView();
            WareManager.Instance.SelectWare.RemoveCanMoveBlock();
            WareManager.Instance.SelectWare.LookOutLine(true);
        }
    }
}
