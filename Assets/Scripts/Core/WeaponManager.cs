using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponManager : ObjectManager
{
    public static WeaponManager Instance;
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
            MainCam.transform.DOLocalMove(new Vector3(2.7f, 4, -3.5f), 0.7f);
            MainCam.transform.DOLocalRotate(new Vector3(26.5f, -44f, 0), 0.7f);
        }
        else
        {
            MainCam.transform.parent = null;
            MainCam.transform.DOMove(new Vector3(54.7f, 85.8f, -61.2f), 0.7f);
            MainCam.transform.DORotate(new Vector3(50.9f, -44f, 0), 0.7f);
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
        }
    }
}
