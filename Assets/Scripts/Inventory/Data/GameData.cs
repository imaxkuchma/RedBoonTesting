using UnityEngine;

[System.Serializable]
public class GameData
{
    public int gold;
    public Inventory playerInventory = new Inventory();
    public Inventory traderInventory = new Inventory();

    public void Load()
    {
        if (PlayerPrefs.HasKey("GameData"))
        {
            var jsonData = PlayerPrefs.GetString("GameData");
            var data = JsonUtility.FromJson<GameData>(jsonData);

            gold = data.gold;
            playerInventory = data.playerInventory;
            traderInventory = data.traderInventory;
        }
    }

    public void Save()
    {
        var jsonData = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("GameData", jsonData);
    }

    public static GameData Default()
    {
        var gameData = new GameData();
        gameData.gold = 50;

        gameData.traderInventory.AddItem(ItemType.Apple);
        gameData.traderInventory.AddItem(ItemType.Banana);
        gameData.traderInventory.AddItem(ItemType.Kiwi);
        gameData.traderInventory.AddItem(ItemType.Lime);
        gameData.traderInventory.AddItem(ItemType.Pear);
        gameData.traderInventory.AddItem(ItemType.Pineapple);

        return gameData;
    }
}



