using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform m_rectTransform;
    [SerializeField]
    private CanvasGroup m_canvasGroup;

    [HideInInspector]
    public Transform originalParent;

    private void Awake()
    {
        originalParent = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = false;
        transform.parent = originalParent.parent.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        m_canvasGroup.blocksRaycasts = true;
        transform.parent = originalParent;
    }
}
