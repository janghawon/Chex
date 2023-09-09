using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : WeaponBase
{
    [SerializeField] private float _rotSpeed;
    [SerializeField] private Transform _firePos;
    private LineRenderer _lineRenderer;

    Vector3 mousePos, dir;
    Transform ware;
    Camera maincam;

    private void Awake()
    {
        maincam = Camera.main;
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
    }

    public override void Attack()
    {
        Debug.Log(_attackVal);
    }

    
    protected override void LookAttackRange()
    {
        if (_lineRenderer.enabled == false)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _firePos.position);
        }
        mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
        ware = WareManager.Instance.SelectWare.transform;
        dir = mousePos - ware.position;
        Quaternion targetRot = Quaternion.LookRotation(dir);
        targetRot.eulerAngles = new Vector3(0, 0, targetRot.eulerAngles.z);
        ware.rotation = Quaternion.Slerp(ware.rotation, targetRot, _rotSpeed * Time.deltaTime);
        
    }
}
