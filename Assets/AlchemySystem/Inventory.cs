using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, ISaveable
{
    public List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;

    [SerializeField]
    ItemTable itemTable;

    void Start()
    {
        itemTable.SetItemIDs();

        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
            );
        GameSaver.OnSaveEvent += OnSave;
        GameSaver.OnLoadEvent += OnLoad;

    }

    void OnDestroy()
    {
        GameSaver.OnSaveEvent -= OnSave;
        GameSaver.OnLoadEvent -= OnLoad;
    }

    public void OnSave()
    {
        Debug.Log("Inventory Saving...");

        
        //let saveString = "";
        //foreach itemSlot
        // if there is an item, then get its ID, and the count
        //     Save String += ID + ":" + count + ","
        // else
        //      saveString += "-1" + ":" + 0 + ","
        //Playerprfs.SetString(inventoryKey, saveString)
    }

    public void OnLoad()
    {
        Debug.Log("Inventory Loading...");

        //let loadString = Playerprefs.GetString(inventoryKey, saveString)
        //string[] itemSlotStrings = loadString.Split(',')
        //for(i = 0; i < itemSlots.Count; i ++)
        //  sring itemSLotString = itemSlotStrings[i]
        //  string[] itemSlotParts = itemSlotString.Split(:)
        //  string id = itemSlotParts[0]
        //  int itemId = int.Parse(id)
        //      if(itemID > -1)
        //          itemSlots[i].item = itemTable.GetItemByIndex(itemId)
        //          itemSLots[i].count = int.Parse(itemSlotParts[1])
    }
}
