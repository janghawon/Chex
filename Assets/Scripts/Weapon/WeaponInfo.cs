using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponSo")]
public class WeaponInfo : ScriptableObject
{
    public string WeaponName;
    public float AttackValue;
    public WeaponBase WeaponPrefab;
}
