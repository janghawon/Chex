using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pawn : WareBase
{
    private bool isFirst = true;

    public override void LookCanMoveBlock()
    {
        int max = 1;
        if (isFirst)
            max = 2;

        int mark = _currentPos[1] - '0';

        for(int i = 0; i < max; i++)
        {
            Transform selectTrm =
            MapManager.Instance.MapDataParent.Find($"{_currentPos[0]}{mark + i + 1}");
            _blockMarkSpawner.MarkSpawn(selectTrm, true, selectTrm.name);
        }
    }
}
