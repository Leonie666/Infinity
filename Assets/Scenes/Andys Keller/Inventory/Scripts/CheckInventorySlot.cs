using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System.Linq;
using UnityEngine.EventSystems;

public class CheckInventorySlot : MonoBehaviour
{
    public Item itemNeeded;
    public InventoryDisplayer InvDis;
    public MMFeedbacks positivFB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSlot()
    {
        Inventory curCharInv = InvDis.selectedChar.GetComponent<CharInventory>().inv;
        GameObject panel = EventSystem.current.currentSelectedGameObject;
        Item panelItem = panel.GetComponent<PanelInfo>().item;
        if (CheckItem(curCharInv.itemList, panelItem))
        {
            foreach(MMFeedback feedback in positivFB.Feedbacks)
            {
                if (feedback.Label.Equals("Wiggle"))
                {

                }
                panel.GetComponent<MMWiggle>();
            }
        }
        else
        {

        }
    }

    public bool CheckItem(Item[] items, Item panelItem )
    {
        if (items.Contains<Item>(panelItem))
        {
            return true;
            print("true");
        }
        else
        {
            return false;
            print("false");
        }
    }
}
