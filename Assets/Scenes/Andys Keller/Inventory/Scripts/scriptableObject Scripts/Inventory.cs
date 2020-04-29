using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Invenoty", menuName = "Inventory/CharInventory")]
public class Inventory : ScriptableObject
{
    public int inventorySize = 9;
    public string charName;
    public Item[] itemList = new Item[9];
    public Sprite defaultSprite;
}
