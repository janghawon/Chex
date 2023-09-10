using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : WeaponBase
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private Transform _firePos;
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    public override void Attack()
    {
        Debug.Log(_attackVal);
    }

    
    protected override void LookAttackRange()
    {
        
    }
}
