using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public BuyerType m_dropType;
    public ShopManager m_shopManager;

    public void OnDrop(PointerEventData eventData)
    {
        var dropItem = eventData.pointerDrag;

        if (dropItem == null) return;

        DragDropHandler dragDropHandler;
        if (dropItem.TryGetComponent(out dragDropHandler))
        {
            if (dragDropHandler.originalParent == transform) return;

            InventoryItemView inventoryItem;
            if (dropItem.TryGetComponent(out inventoryItem))
            {
                if (m_shopManager.TryBuy(m_dropType, inventoryItem.ItemData))
                {
                    dragDropHandler.originalParent = transform;
                }
            }
        } 
    }
}

