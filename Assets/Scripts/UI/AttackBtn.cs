using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AttackBtn : MonoBehaviour
{
    [SerializeField] private float _activeLocYPos;
    [SerializeField] private float _hideLocYPos;
    [SerializeField] private float _moveTime;

    public void ActiveAttackBtn(bool isActive)
    {
        float yPos = isActive ? _activeLocYPos : _hideLocYPos;
        transform.DOLocalMoveY(yPos, _moveTime);
    }
}
