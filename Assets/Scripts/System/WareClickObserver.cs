using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareClickObserver : MonoBehaviour
{
    public string SelectID;
    public bool IsMoveWare;
    private Camera _mainCam;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.TryGetComponent<WareBase>(out WareBase wb))
                {
                    wb.ClickEvent();
                }
            }

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.TryGetComponent<BlockMark>(out BlockMark bm))
                {
                    SelectID = bm.MarkingID;
                    bm.MarkCickEvent?.Invoke();
                }
            }
        }
    }
}
