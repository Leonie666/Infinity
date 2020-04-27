using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryDisplayer : MonoBehaviour
{
    Transform selectedChar;
    public GameObject InventoryCanvas;
    public Image[] inventorySlots;
    public TMP_Text missionText;
    public TMP_Text IdName;
    public TMP_Text IdNr;
    public Image IdPicture;
    public TMP_Text IdDescription;

    // Update is called once per frame

    private void Start()
    {
        InventoryCanvas.gameObject.SetActive(false);
    }
    void Update()
    {
        HandleRaycast();
        HandleInventoryVisibility();
    }

    public void HandleRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedChar != null)
            {
                selectedChar.GetChild(0).gameObject.SetActive(false);
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.transform.tag.Equals("Character"))
                {
                    selectedChar = hit.collider.transform;
                    selectedChar.GetChild(0).gameObject.SetActive(true);
                    LoadCanvas();
                }
            }
        }
    }

    public void HandleInventoryVisibility()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InventoryCanvas.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InventoryCanvas.SetActive(false);
        }
    }

    public void LoadCanvas()
    {
        CharInventory CharInv = selectedChar.GetComponent<CharInventory>();
        Inventory inv = CharInv.inv;
        ID id = CharInv.id;
        Mission mission = CharInv.mission;

        if (inv.inventorySize == inv.itemList.Length)
        {
            if (inv.itemList.Length != inventorySlots.Length)
            {
                Debug.LogError("itemList is not as big as inventorySlots");
            }
        }
        else
        {
            Debug.LogError("inventorySize is not as bis as itemList");
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inv.itemList[i] != null)
            {
                inventorySlots[i].sprite = inv.itemList[i].itemSprite;
            }
            else
            {
                inventorySlots[i].sprite = inv.defaultSprite;
            }
        }

        missionText.text = mission.missionText;
        IdName.text = id.charName;
        IdNr.text = id.idNr;
        IdDescription.text = id.idDescription;
        IdPicture.sprite = id.idPicture;
    }

}
