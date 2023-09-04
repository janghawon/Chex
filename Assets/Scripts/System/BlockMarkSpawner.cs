using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockMarkSpawner : MonoBehaviour
{
    [SerializeField] private List<BlockMark> _markList = new List<BlockMark>();
    [SerializeField] private BlockMark _blockMarkPrefab;
    private BlockMark _selectBlockMark;
    private WareInfoRemember _wInfo;
    private WareClickObserver _wareCObserver;

    private void Awake()
    {
        _wInfo = GameObject.Find("WareCollocateMaster").GetComponent<WareInfoRemember>();
        _wareCObserver = GameObject.Find("WareClickObserver").GetComponent<WareClickObserver>();
    }

    public void MarkSpawn(Transform trm, bool isUsingWare, string mapID)
    {
        _selectBlockMark = Instantiate(_blockMarkPrefab);
        _selectBlockMark.MarkingID = mapID;
        _selectBlockMark.transform.position = new Vector3(trm.position.x, 9.5f, trm.position.z);

        _selectBlockMark.MarkCickEvent = null;
        _selectBlockMark.MarkCickEvent += isUsingWare ? MoveWare : SelectCollocationPos;

        _markList.Add(_selectBlockMark);
    }

    public void RemoveALLBlockMark()
    {
        int max = _markList.Count;
        for (int i = 0; i < max; i++)
        {
            BlockMark selectMM = _markList[0];
            _markList.Remove(_markList[0]);
            Destroy(selectMM);
        }
    }

    public void RemoveCanMoveBlockMark(Vector3 wareTrans)
    {
        int max = _markList.Count;
        for (int i = 0; i < max; i++)
        {
            BlockMark selectMM = _markList[0];
            _markList.Remove(_markList[0]);
            selectMM.transform.DOMove(new Vector3(wareTrans.x, 9.5f, wareTrans.z), 0.3f);
            Destroy(selectMM, 0.3f);
        }
    }

    private void MoveWare()
    {
    }

    private void SelectCollocationPos()
    {
        GameObject ware = Instantiate(_wInfo.SelectWareInfo);
        Transform trm = MapManager.Instance.MapDatas[_wareCObserver.SelectID];
        ware.transform.position = new Vector3(trm.position.x, 10,trm.position.z);
    }
}
