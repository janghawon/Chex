using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    private LineRenderer _lineRenderer;
    public Vector3 firePos
    {
        get
        {
            return firePos;
        }
        set
        {
            _lineRenderer.SetPosition(0, value);
        }
    }
    public Vector3 targetPos;

    public bool isTargetingStart;
    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(isTargetingStart)
        {
            if(Physics.Raycast(firePos, Vector3.forward, out hit, 
                               WeaponManager.Instance.SelectWeapon.maxRange, _enemyLayer))
            {
                targetPos = hit.point;
            }
            

            _lineRenderer.SetPosition(0, targetPos);
        }
    }
}
