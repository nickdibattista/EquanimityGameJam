using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject, meleeObject, rangedObject, armorObject, mapCover, workshopCover;

    private Player playerScript;
    private Upgrader upgraderScript;

    private Item[] allItems;
    private Item[] equippedItems = new Item[2];

    private bool inWorkshop = true;
    private bool upgraderItemSwapped = false;

    void Start()
    {
        Melee meleeWeapon = new Melee();
        Ranged rangedWeapon = new Ranged(10);
        Armor armor = new Armor(0.7f, 0.1f);
        //allItems = { meleeWeapon, rangedWeapon, armor};


        // TEMPORARY \/
        //upgraderScript.InsertItem(rangedScript);
        equippedItems[0] = meleeScript;
        equippedItems[1] = armorScript;
        // TEMPORARY /\
    }

    public bool InWorkshop()
    {
        return inWorkshop;
    }
    public void EnterWorkshop()
    {
        Debug.Log("enter");
        playerObject.transform.position = new Vector2(0, 27.5f);
        inWorkshop = true;
        mapCover.SetActive(true);
        workshopCover.SetActive(false);
    }
    public void ExitWorkshop()
    {
        Debug.Log("exit");
        playerObject.transform.position = new Vector2(0, 30);
        inWorkshop = false;
        workshopCover.SetActive(true);
        mapCover.SetActive(false);
    }

    void Update()
    {
        
    }
}
