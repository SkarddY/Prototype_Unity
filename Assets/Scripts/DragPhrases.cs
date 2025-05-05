using UnityEngine;
using UnityEngine.EventSystems;

public class DragPhrases : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        startPos = transform.position;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData) {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
    }
}
