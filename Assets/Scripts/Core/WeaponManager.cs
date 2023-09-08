using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : ObjectManager
{
    public static WeaponManager Instance;
    public WeaponBase SelectWeapon;
    [SerializeField] private List<WeaponInfo> _weaponInfos = new List<WeaponInfo>();

    public override void SetInstance()
    {
        Instance = this;
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
        }
    }
}
