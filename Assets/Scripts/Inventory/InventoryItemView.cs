using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItemView : MonoBehaviour
{ 
    [SerializeField]
    private Image m_icon;
    [SerializeField]
    private TextMeshProUGUI m_priceText;

    private ItemData m_itemData;
    
    public ItemData ItemData => m_itemData;

    public void Initialize(ItemData itemData)
    {
        m_itemData = itemData;
        m_icon.sprite = itemData.Icon;
        m_priceText.text = $"{itemData.Price} $";   
    }
}
