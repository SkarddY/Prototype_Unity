using System;
using UnityEngine;

public class DragDropCable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Transform transform); public delegate void DragStartedDelegate(Transform transform);
    public DragEndedDelegate dragEndedDelegate; public DragStartedDelegate dragStartedDelegate;
    Camera cam; Vector2 pos;
    private bool isHolding;

    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        if (isHolding) {
            pos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = pos;
        }
    }

    private void OnMouseDown()
    {
        isHolding = true;
        dragStartedDelegate(this.transform);
    }
    private void OnMouseUp()
    {
        isHolding = false;
        dragEndedDelegate(this.transform);
    }

}
