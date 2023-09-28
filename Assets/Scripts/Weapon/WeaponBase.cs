using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public WeaponInfo weaponInfo;
    public Vector3 firePos;

    protected string _name => weaponInfo.WeaponName;
    protected float _attackVal => weaponInfo.AttackValue;
    public float maxRange => weaponInfo.MaxRange;

    public bool IsWaitingAtk;

    public abstract void Attack();
    protected abstract void LookAttackRange();

    private void Update()
    {
        if (IsWaitingAtk)
            LookAttackRange();
    }
}
