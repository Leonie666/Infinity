using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Mission", menuName = "Inventory/Mission")]
public class Mission : ScriptableObject
{
    public string missionText;
    public bool completed;
}
