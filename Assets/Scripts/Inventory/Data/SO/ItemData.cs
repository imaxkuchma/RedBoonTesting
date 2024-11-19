using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/ItemData", fileName = "ItemData")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private ItemType m_type;

    [SerializeField]
    private string m_name;

    [SerializeField]
    private Sprite m_icon;

    [SerializeField]
    private int m_price;

    public ItemType Type => m_type;
    public string Name => m_name;
    public Sprite Icon => m_icon; 
    public int Price => m_price; 
}
