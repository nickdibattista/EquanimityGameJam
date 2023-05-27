using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject;

    private Player playerScript;
    private Item[] allItems;
    private Item[] equippedItems;

    void Start()
    {
        Melee meleeWeapon = new Melee();
        Ranged rangedWeapon = new Ranged(10);
        Armor armor = new Armor(0.7f, 0.1f);
        //allItems = { meleeWeapon, rangedWeapon, armor};

    }

    void Update()
    {
        
    }
}
