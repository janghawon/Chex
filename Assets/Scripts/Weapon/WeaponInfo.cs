using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponSo")]
public class WeaponInfo : ScriptableObject
{
    public string WeaponName;
    public float AttackValue;
    public float MaxRange;
    public WeaponBase WeaponPrefab;
}
