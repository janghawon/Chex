using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponManager : ObjectManager
{
    public static WeaponManager Instance;
    [SerializeField] private float _moveSpeed = 0.7f;
    
    public WeaponBase SelectWeapon;
    [SerializeField] private List<WeaponInfo> _weaponInfos = new List<WeaponInfo>();

    public Camera MainCam;

    public override void SetInstance()
    {
        Instance = this;
        MainCam = Camera.main;
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
            ScreenManager.Instance.CanDrag = true;
            WareManager.Instance.ReadyToAttack();
            WareManager.Instance.SelectWare.RemoveCanMoveBlock();
            WareManager.Instance.SelectWare.LookOutLine(true);
        }
    }
}
