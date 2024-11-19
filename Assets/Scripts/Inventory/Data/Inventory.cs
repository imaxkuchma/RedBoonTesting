using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class Inventory
{
    public List<Item> items = new List<Item>();
    
    public void AddItem(ItemType type)
    {
        items.Add(new Item(type));
    }

    public void RemoveItem(ItemType type)
    {
        var item = items.Find(x => x.type == type);
        if(item != null)
        {
            items.Remove(item);
        }
    }
}



