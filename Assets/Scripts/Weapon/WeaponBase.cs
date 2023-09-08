using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private WeaponInfo _weaponInfo;

    protected string _name => _weaponInfo.WeaponName;
    protected float _attackVal => _weaponInfo.AttackValue;

    public bool IsWaitingAtk;

    public abstract void Attack();
    protected abstract void LookAttackRange();

    private void Update()
    {
        if (IsWaitingAtk)
            LookAttackRange();
    }
}
