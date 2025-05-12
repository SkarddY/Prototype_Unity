using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragPhrases : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private CanvasGroup canvasGroup;

    public Transform[] snapPoints;
    public float snapThreshold = 0.5f;

    public PhraseSpawn phraseSpawn;
    private static Dictionary<Transform, GameObject> occupiedPositions = new Dictionary<Transform, GameObject>();

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup == null) canvasGroup = gameObject.AddComponent<CanvasGroup>();
        startPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;

        foreach (var entry in occupiedPositions) {
            if (entry.Value == gameObject) {
                occupiedPositions.Remove(entry.Key);
                break;
            }
        }
    }
    public void OnDrag(PointerEventData eventData) {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
    }

    public void OnEndDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = true;
        SnapToClosestPoint();
    }

    private void SnapToClosestPoint()
    {
        Transform closestPoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform snapPoint in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.position);
            if (distance < closestDistance && distance <= snapThreshold)
            {
                closestDistance = distance;
                closestPoint = snapPoint;
            }
        }
        if (closestPoint != null)
        {
            if (occupiedPositions.ContainsKey(closestPoint))
            {
                if (phraseSpawn != null) phraseSpawn.ResetPhrasePosition(gameObject);
            }
            else
            {
                transform.position = closestPoint.position;
                occupiedPositions[closestPoint] = gameObject;
            }
        }
        else
        {
            if (phraseSpawn != null) phraseSpawn.ResetPhrasePosition(gameObject);
        }
    }
}
