using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ID", menuName = "Inventory/ID")]
public class ID : ScriptableObject
{
    public string charName;
    public string idNr;
    public Sprite idPicture;
    public string idDescription;
}
