using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject, meleeObject, rangedObject, armorObject;

    private Player playerScript;
    private Upgrader upgraderScript;

    private Item[] allItems;
    private Item[] equippedItems = new Item[2];

    private 

    void Start()
    {
        Melee meleeScript = new Melee();
        Ranged rangedScript = new Ranged(10);
        Armor armorScript = new Armor(0.7f, 0.1f);
        allItems = new Item[] { meleeScript, rangedScript, armorScript };


        // TEMPORARY \/
        upgraderScript.InsertItem(rangedScript);
        equippedItems[0] = meleeScript;
        equippedItems[1] = armorScript;
        // TEMPORARY /\
    }

    void Update()
    {
        
    }
}
