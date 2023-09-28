using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class AttackBtn : MonoBehaviour
{
    [SerializeField] private float _activeLocYPos;
    [SerializeField] private float _hideLocYPos;
    [SerializeField] private float _moveTime;

    private bool isReadyToAtk;

    [SerializeField] private AttackSystem _atkSystem;

    public void ActiveAttackBtn(bool isActive)
    {
        if (isReadyToAtk)
            return;
        
        float yPos = isActive ? _activeLocYPos : _hideLocYPos;
        transform.DOLocalMoveY(yPos, _moveTime);
        if(!isActive)
        {
            isReadyToAtk = true;
            ScreenManager.Instance.CanDrag = false;
            _atkSystem.firePos = WeaponManager.Instance.SelectWeapon.firePos;
            _atkSystem.isTargetingStart = true;
        }
    }
}
