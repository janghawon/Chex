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

    Vector3 mousePos, dir;
    Transform ware;
    Camera maincam = Camera.main;
    protected override void LookAttackRange()
    {
        if (_lineRenderer.enabled == false)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _firePos.position);
        }
        if(Time.frameCount % 2 == 0)
        {
            mousePos = maincam.ScreenToWorldPoint(Input.mousePosition);
            ware = WareManager.Instance.SelectWare.transform;
            dir = mousePos - ware.position;
            Quaternion targetRot = Quaternion.LookRotation(dir);
            targetRot.eulerAngles = new Vector3(0, 0, targetRot.eulerAngles.z);
            ware.rotation = Quaternion.Slerp(ware.rotation, targetRot, _rotSpeed * Time.deltaTime);
        }
    }
}
