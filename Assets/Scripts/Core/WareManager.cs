using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareManager : ObjectManager
{
    public static WareManager Instance;
    public List<GameObject> WarePrefabs = new List<GameObject>();
    public List<Sprite> WareSprites = new List<Sprite>();

    public override void SetInstance()
    {
        Instance = this;
    }

    public void CreateWare(WareType wType, bool isBlack, Transform mPos)
    {
        GameObject selectWare = Instantiate(isBlack ? WarePrefabs[(int)wType] : WarePrefabs[(int)wType + 6]);
        selectWare.transform.position = mPos.position;
    }

    
}
