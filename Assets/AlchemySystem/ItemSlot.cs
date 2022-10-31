using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

/// <summary>
/// https://www.youtube.com/watch?v=gZsJ_rG5hdo
/// This video helped give me ideas for what to do with the menu that was given for the midterm
/// 
/// https://www.youtube.com/watch?v=1fbd-yTcMgY
/// This video helped Show me how it should look like
/// </summary>

//Holds reference and count of items, manages their visibility in the Inventory panel
public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item = null;

    //Add Text mesh pro for Effects text
    [SerializeField]
    private TMPro.TextMeshProUGUI effectText;
    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;

    [SerializeField]
    public int count = 0;

    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            UpdateGraphic();
        }
    }

    [SerializeField]
    Image itemIcon;

    [SerializeField]
    TextMeshProUGUI itemCountText;

    public bool MI = false;
    public bool FI = false;

    // Start is called before the first frame update
    void Start()
    {
        UpdateGraphic();
    }

    //Change Icon and count
    void UpdateGraphic()
    {
        if (count < 1)
        {
            item = null;
            itemIcon.gameObject.SetActive(false);
            itemCountText.gameObject.SetActive(false);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.sprite = item.icon;
            itemIcon.gameObject.SetActive(true);
            itemCountText.gameObject.SetActive(true);
            itemCountText.text = count.ToString();
        }
    }

    public void UseItemInSlot()
    {
        if (CanUseItem())
        {
            item.Use();
            if (item.isConsumable)
            {
                Count--;
                //Used for making potions
                HealingPotion();
                ManaPotion();
                LuckPotion();
                StrPotion();
            }
        }
    }

    private bool CanUseItem()
    {
        return (item != null && count > 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            effectText.text = item.effects;
            descriptionText.text = item.description;
            nameText.text = item.name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(item != null)
        {
            effectText.text = "";
            descriptionText.text = "";
            nameText.text = "";
        }
    }

    public void HealingPotion()
    {
        //Checks if the first ingrediant is clicked
        if (item.Id == 0)
        {
            MainIngrediant(true);
        }        
        //Checks if the Second ingrediant is clicked
        else if (item.Id == 1)
        {
            FinaleIngrediant(true);
        }
        //Adds Healing potion
        else if (item.Id == 7 && MainIngrediant(this) == true && FinaleIngrediant(this) == true)
        {
            count += 2;
            //attempted to reset the ingrediants to false
            MainIngrediant(false);
            FinaleIngrediant(false);
        }
    }
    //rest are repeated for the rest of the potions
    public void ManaPotion()
    {
        if (item.Id == 6)
        {
            MainIngrediant(true);
        }
        else if (item.Id == 5)
        {
            FinaleIngrediant(true);
        }
        else if (item.Id == 9 && MainIngrediant(this) == true && FinaleIngrediant(this) == true)
        {
            count += 2;
            MainIngrediant(false);
            FinaleIngrediant(false);
        }
    }

    public void LuckPotion()
    {
        if (item.Id == 4)
        {
            MainIngrediant(true);
        }
        else if (item.Id == 2)
        {
            FinaleIngrediant(true);
        }
        else if (item.Id == 10 && MainIngrediant(this) == true && FinaleIngrediant(this) == true)
        {
            count += 2;
            MainIngrediant(false);
            FinaleIngrediant(false);
        }
    }

    public void StrPotion()
    {
        if (item.Id == 8)
        {
            MainIngrediant(true);
        }
        else if (item.Id == 3)
        {
            FinaleIngrediant(true);
        }
        else if (item.Id == 11 && MainIngrediant(this) == true && FinaleIngrediant(this) == true)
        {
            count += 2;
            MainIngrediant(false);
            FinaleIngrediant(false);
        }
    }
    //used to say if the there is a main ingrediant
    public static bool MainIngrediant(bool answer)
    {
        return answer;
    }
    //used to say if the there is a finale ingrediant
    public static bool FinaleIngrediant(bool answer)
    {
        return answer;
    }
}
