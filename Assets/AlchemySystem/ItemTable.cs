using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item Table", menuName = "Items/New Item Table")]
public class ItemTable : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    private List<Item> m_Items;

    public void SetItemIDs()
    { 
        for(int i = 0; i<m_Items.Count; i++)
        {
            try
            {
                m_Items[i].Id = i;
            }
            catch(ItemException ex)
            {

            }
        }
    }

    public Item GetItemByIndex(int id)
    {
        return m_Items[id];
    }
}
