using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject, meleeObject, rangedObject, armorObject, mapCover, workshopCover, itemSwapButtons;

    private Player playerScript;
    private Upgrader upgraderScript = new Upgrader();

    private Item[] allItems;
    private Item[] equippedItems = new Item[2];

    private bool inWorkshop = true;
    private bool upgraderItemSwapped = false;

    void Start()
    {
        Melee meleeWeapon = new Melee();
        Ranged rangedWeapon = new Ranged(10);
        Armor armor = new Armor(0.7f, 0.1f);
        allItems = new Item[] { meleeWeapon, rangedWeapon, armor};


        // TEMPORARY \/
        //upgraderScript.InsertItem(rangedScript);
       // equippedItems[0] = meleeScript;
        //equippedItems[1] = armorScript;
        // TEMPORARY /\
    }

    public bool InWorkshop()
    {
        return inWorkshop;
    }
    public void EnterWorkshop()
    {
        upgraderItemSwapped = false;
        playerObject.transform.position = new Vector2(0, 27.5f);
        inWorkshop = true;
        mapCover.SetActive(true);
        workshopCover.SetActive(false);
    }
    public void ExitWorkshop()
    {
        if (upgraderItemSwapped)
        {
            playerObject.transform.position = new Vector2(0, 30);
            inWorkshop = false;
            workshopCover.SetActive(true);
            mapCover.SetActive(false);
        }
    }

    public void PutInUpgrader(String type)
    {
        itemSwapButtons.SetActive(false);

        Item itemScript = FindItemScript(type);

        if (!upgraderScript.HasItem())
        {
            upgraderScript.InsertItem(itemScript);
        }
        else
        {
            upgraderScript.SwapItem(itemScript);
        }

        upgraderItemSwapped = true;
        UpdateEquippedItems();

        if (itemScript is Melee)
        {
            playerObject.transform.Find("Melee").gameObject.SetActive(false);
            playerObject.transform.Find("Ranged").gameObject.SetActive(true);
            playerObject.transform.Find("Armor").gameObject.SetActive(true);
        }
        else if (itemScript is Ranged)
        {
            playerObject.transform.Find("Melee").gameObject.SetActive(true);
            playerObject.transform.Find("Ranged").gameObject.SetActive(false);
            playerObject.transform.Find("Armor").gameObject.SetActive(true);
        }
        else if (itemScript is Armor)
        {
            playerObject.transform.Find("Melee").gameObject.SetActive(true);
            playerObject.transform.Find("Ranged").gameObject.SetActive(true);
            playerObject.transform.Find("Armor").gameObject.SetActive(false);
        }

    }

    public Item FindItemScript(String type)
    {
        Item script = new Item();
        switch (type)
        {
            case "melee":
                for (int i = 0; i < allItems.Length; i++)
                {
                    if (allItems[i] is Melee)
                    {
                        script = allItems[i];
                        break;
                    }
                }
                break;
            case "ranged":
                for (int i = 0; i < allItems.Length; i++)
                {
                    if (allItems[i] is Ranged)
                    {
                        script = allItems[i];
                        break;
                    }
                }
                break;
            case "armor":
                for (int i = 0; i < allItems.Length; i++)
                {
                    if (allItems[i] is Armor)
                    {
                        script = allItems[i];
                        break;
                    }
                }
                break;

        }
        return script;

    }

    private void UpdateEquippedItems()
    {
        Item[] newEquippedItems = new Item[2];
        int insertedItems = 0;

        for (int i = 0; i < allItems.Length; i++)
        {
            if (!allItems[i].InUpgrader())
            {
                newEquippedItems[insertedItems] = allItems[i];
                insertedItems++;
            }
        }

        equippedItems = newEquippedItems;
    }

    public bool UpgraderItemSwapped()
    {
        return upgraderItemSwapped;
    }

    public void ShowItemSwapButtons()
    {
        Item itemInUpgrader = upgraderScript.GetItem();

        if (itemInUpgrader is Melee)
        {
            itemSwapButtons.transform.Find("Swap Melee").gameObject.SetActive(false);
            itemSwapButtons.transform.Find("Swap Ranged").gameObject.SetActive(true);
            itemSwapButtons.transform.Find("Swap Armor").gameObject.SetActive(true);
        }
        else if (itemInUpgrader is Ranged)
        {
            itemSwapButtons.transform.Find("Swap Melee").gameObject.SetActive(true);
            itemSwapButtons.transform.Find("Swap Ranged").gameObject.SetActive(false);
            itemSwapButtons.transform.Find("Swap Armor").gameObject.SetActive(true);
        }
        else if (itemInUpgrader is Armor)
        {
            itemSwapButtons.transform.Find("Swap Melee").gameObject.SetActive(true);
            itemSwapButtons.transform.Find("Swap Ranged").gameObject.SetActive(true);
            itemSwapButtons.transform.Find("Swap Armor").gameObject.SetActive(false);
        }

        itemSwapButtons.SetActive(true);
    }

    void Update()
    {
        
    }
}
