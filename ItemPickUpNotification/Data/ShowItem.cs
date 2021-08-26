using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{



    private InventoryItem[] slot = EmptyArray<InventoryItem>.Value;
    //private Inventory m_items = new Inventory();

    //float usedSlotAmount, nextEmptySlot;

    public Image itemSprite;
    public Text itemName;

    public ItemDefinition item;

    public bool isShown;

    public float time = 5f;
    public float remainingTime;
    
    
    //void Start()
    //{
    //    //usedSlotAmount = m_items.SlotCount;
    //    //nextEmptySlot = m_items.SlotCount + 1;
    //    ShowItemOnScreen();
    //    itemSprite = null;
    //    itemName = null;
    //    //DepositLocation.DepositMined
    //    remainingTime = time;
    //}
    //void Update()
    //{
    //    //Amount of slots used changes
    //    //if (usedSlotAmount != nextEmptySlot - 1)
    //    //{
    //    //    isShown = true;
            
    //    //}

    //    //if true displays item on screen
    //    if(isShown)
    //    {
    //        this.gameObject.SetActive(true);
    //        ShowItemOnScreen();
    //        //timer until text on screen disappears
    //        if (remainingTime > 0)
    //        {
    //            remainingTime = remainingTime - Time.deltaTime;
    //        }
    //        if(remainingTime == 0)
    //        {
    //            isShown = false;
    //            remainingTime = time;
    //            this.gameObject.SetActive(false);
    //        }
    //    }

        
    //}
    
    //gets item from inventory
    //private void GetItem(InventoryItem slot)
    //{
    //    item = slot.Item;
    //}
    


    //shows the sprite and name of item on screen
    private void ShowItemOnScreen()
    {
        itemName.text = item.Name;
        itemSprite.sprite = item.Icon;
    }
    private void OnEnable()
    {
        DepositLocation.DepositMined += OnDepositMined;
    }

    private void OnDisable()
    {
        DepositLocation.DepositMined -= OnDepositMined;
    }

    private void OnDepositMined(GameObject minedBy, ItemDefinition minedItem, float mineAmount)
    {
        // Tohle se zavolá když hráč něco natěží
        isShown = true;
        item = minedItem;
        Debug.Log("object mined");

    }




}
