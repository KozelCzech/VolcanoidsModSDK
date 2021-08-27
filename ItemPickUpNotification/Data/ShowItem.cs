using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{
    struct itemInfo
    {
        public ItemDefinition item;
        public int amount;
        public float time;
    }


    
    //private Inventory m_items = new Inventory();

    //float usedSlotAmount, nextEmptySlot;

    public Image itemSprite;
    public Text itemName;

    public GameObject container;


    public bool timerRunning = false;

    
    public float remainingTime;
    public int slots = 5;

    

    Dictionary<ItemDefinition, int> m_items = new Dictionary<ItemDefinition, int>();
    Dictionary<ItemDefinition, int> m_previousItems = new Dictionary<ItemDefinition, int>();
    List<itemInfo> m_addedItems = new List<itemInfo>();
    Inventory m_playerInventory;
    int m_version = -1;

    bool UpdateItems()
    {
        if (Player.Local.TryCacheComponentSafe(ref m_playerInventory) && m_version != m_playerInventory.Version)
        {
            //m_addedItems.Clear();
            m_items.Clear();
            m_version = m_playerInventory.Version;
            foreach (var slot in m_playerInventory.Slots)
            {
                if (slot.IsValid)
                {
                    m_items[slot.Item] = m_items.GetValueOrDefault(slot.Item) + slot.Amount;
                }
            }

            foreach (var item in m_items)
            {
                if (!m_previousItems.TryGetValue(item.Key, out int amount) || amount < item.Value)
                {
                    // This item was added
                    itemInfo info;
                    info.item = item.Key;
                    info.amount = item.Value - amount;
                    info.time = 2f;
                    m_addedItems.Add(info);
                }
            }
            m_previousItems.Clear();

            // Swap previous items and items
            var tmp = m_previousItems;
            m_previousItems = m_items;
            m_items = tmp;
            return true;
        }
        return false;
    }
    int amountOfItem = 0;
    void Update()
    {
        //    //Amount of slots used changes
        //    //if (usedSlotAmount != nextEmptySlot - 1)
        //    //{
        //    //    isShown = true;

        //    //}

        TemplateCollection.Ensure(container, container.transform.GetChild(0).gameObject, slots);
        
        
        if (UpdateItems())
        {
            StartTimer();
            
            
            foreach (var item in m_addedItems)
            {
                if (amountOfItem == 5)
                {
                    amountOfItem = 1;
                }
                var img = container.transform.GetChild(amountOfItem).GetComponentInChildren<Image>();
                img.sprite = item.item.Icon;
                var text = container.transform.GetChild(amountOfItem).GetComponentInChildren<TMPro.TMP_Text>();
                text.text = item.item.Name + " x" + item.amount;
                Debug.Log(item.item.Name + "     " + item.amount);
                amountOfItem++;
                slots++;
                remainingTime = item.time;
                
            }
            //for(int i = -1; i < amountOfItem; i++)
            //{
            //    var img = container.transform.GetChild(i).GetComponentInChildren<Image>();
            //    img.sprite = item.item.Icon;
            //    var text = container.transform.GetChild(i).GetComponentInChildren<TMPro.TMP_Text>();
            //    text.text = item.item.Name + " " + item.amount;
            //}
            
        }
        if(timerRunning)
        {
            
            if (remainingTime > 0)
            {
                remainingTime = remainingTime - Time.deltaTime;
                Debug.Log(remainingTime);
            }
            else
            {
                Debug.Log("Timer ran out!");
                //for(int i = -1; i < amountOfItem; i++)
                //{
                //    var itembox = container.transform.GetChild(i).gameObject;
                //    itembox.SetActive(false);
                //}
                slots = 0;
                amountOfItem = 0;
                m_addedItems.Clear();
                timerRunning = false;
            }

        }
        

        


    }
    private void StartTimer()
    {
        timerRunning = true;
        
    }


//shows the sprite and name of item on screen

    //private void OnEnable()
    //{
    //    DepositLocation.DepositMined += OnDepositMined;
    //}

    //private void OnDisable()
    //{
    //    DepositLocation.DepositMined -= OnDepositMined;
    //}

    //private void OnDepositMined(GameObject minedBy, ItemDefinition minedItem, float mineAmount)
    //{
    //    // Tohle se zavolá když hráč něco natěží
    //    container.SetActive(true);
    //    remainingTime = time;
    //    isShown = true;
    //    item = minedItem;
    //    Debug.Log("object mined");
        

    //}




}
