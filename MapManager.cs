using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private string _mapMarkCharData = "ABCDEFGH";
    private string _mapMarkIntData = "12345678";

    private Transform _mapDataParent;
    private Dictionary<string, Transform> _mapDatas = new Dictionary<string, Transform>();

    private void Awake()
    {
        _mapDataParent = GameObject.Find("Chess Battlefield").transform;
    }

    private void Start()
    {
        Transform selectMapData;
        for(int i = 0; i < _mapMarkCharData.Length; i++)
        {
            for(int j = 0; j < _mapMarkIntData.Length; j++)
            {
                selectMapData = _mapDataParent.transform.Find($"{_mapMarkCharData[i]}{_mapMarkIntData[j]}");
                _mapDatas.Add(selectMapData.name, selectMapData);
            }
        }    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(_mapDatas["A2"].position);
        }
    }
}
