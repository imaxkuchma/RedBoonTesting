using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] 
    private ItemData[] m_itemsDatas;
    [SerializeField] 
    private InventoryItemView m_inventoryItemViewPrefab;
    [SerializeField] 
    private Transform m_playerInventoryContainer;
    [SerializeField] 
    private Transform m_traderInventoryContainer;
    [SerializeField] 
    private float m_returnSaleDiscount = 0.7f;

    GameData gameData = GameData.Default();

    private void Start()
    {
        gameData.Load();

        GoldWidget.Instance.Init(gameData.gold);

        foreach (var item in gameData.playerInventory.items)
        {
            ItemData itemData = GetItemDataByType(item.type);

            if (itemData == null) continue;

            var inventoryItem = Instantiate(m_inventoryItemViewPrefab, m_playerInventoryContainer);
            inventoryItem.Initialize(itemData);
        }

        foreach (var item in gameData.traderInventory.items)
        {
            ItemData itemData = GetItemDataByType(item.type);

            if (itemData == null) continue;

            var inventoryItem = Instantiate(m_inventoryItemViewPrefab, m_traderInventoryContainer);
            inventoryItem.Initialize(itemData);
        }
    }


    private ItemData GetItemDataByType(ItemType itemType)
    {
        foreach (var itemData in m_itemsDatas)
        {
            if(itemData.Type == itemType)
            {
                return itemData;
            }
        }
        return null;
    }


    public bool TryBuy(BuyerType buyerType, ItemData itemData)
    {
        if (buyerType == BuyerType.Player)
        {
            if (GoldWidget.Instance.TrySpendGold(itemData.Price))
            {
                gameData.playerInventory.AddItem(itemData.Type);
                gameData.traderInventory.RemoveItem(itemData.Type);
                gameData.gold = GoldWidget.Instance.AmountGold;
                gameData.Save();
                return true;
            }
        }
        else
        {
            gameData.traderInventory.AddItem(itemData.Type);
            gameData.playerInventory.RemoveItem(itemData.Type);
            GoldWidget.Instance.AddGold(Mathf.RoundToInt(itemData.Price * m_returnSaleDiscount));
            gameData.gold = GoldWidget.Instance.AmountGold;
            gameData.Save();
            return true;
        }

        return false;
    }
}
