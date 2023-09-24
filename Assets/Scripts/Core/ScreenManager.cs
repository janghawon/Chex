using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenManager : ObjectManager
{
    public static ScreenManager Instance;
    public Camera MainCam;
    public bool CanDrag;
    public bool isDragging;

    private Vector3 mouseStartPosition;
    private Vector3 mouseCurrentPosition;
    private Vector3 mouseDelta;
    private float rotationAmount;

    [SerializeField] private UnityEvent<bool> _dragEvent;

    public override void SetInstance()
    {
        Instance = this;
        MainCam = Camera.main;
    }

    private void Update()
    {
        if (!CanDrag)
            return;
        DragOnScreen();
    }

    private void DragOnScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
            isDragging = true;
            _dragEvent?.Invoke(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if(isDragging)
        {
            mouseCurrentPosition = Input.mousePosition;
            mouseDelta = mouseCurrentPosition - mouseStartPosition;

            rotationAmount = -mouseDelta.x * 0.1f;

            WareManager.Instance.SelectWare.transform.Rotate(Vector3.up, rotationAmount, Space.World);

            mouseStartPosition = mouseCurrentPosition;
        }
    }
}
