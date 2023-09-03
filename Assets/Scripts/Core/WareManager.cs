using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareManager : ObjectManager
{
    [SerializeField] private WareType _selectWareType;
    [SerializeField] private List<GameObject> _warePrefabs = new List<GameObject>();

    public override void SetInstance()
    {
        Instance = this;
    }

    public void CreateWare(WareType wType, bool isBlack, Transform mPos)
    {
        GameObject selectWare = Instantiate(isBlack ? _warePrefabs[(int)wType] : _warePrefabs[(int)wType + 6]);
        selectWare.transform.position = mPos.position;
    }

    
}
