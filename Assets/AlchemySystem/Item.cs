using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemException : System.Exception
{
    public ItemException(string message) : base(message)
    {

    }
}

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public Sprite icon;
    public string description = "";
    public string effects = "";
    public bool isConsumable = false;

    private int id = 0;
    public int Id
    {
        get { return id; }
        set
        {
            id = value;
            throw new ItemException("Hey You can't do that");
        }
    }

    public void Use()
    {
        Debug.Log("Used item: " + name + " - " + description + " - " + effects);

    }
}
