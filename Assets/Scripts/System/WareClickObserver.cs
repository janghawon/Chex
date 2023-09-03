using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WareClickObserver : MonoBehaviour
{
    [SerializeField] private LayerMask _wareMask;
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
                    Debug.Log(1);
                    wb.ClickThisWareEvent?.Invoke();
                }
            }
        }
    }
}
