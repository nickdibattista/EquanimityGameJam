using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class GameLoop : MonoBehaviour
{
    [SerializeField]
    private GameObject camera, playerObject, itemSwapButtons, playerPrefab, evilEyePrefab, batPrefab, molotovPrefab, chestProtectorPrefab, punchPrefab;
    [SerializeField]
    private List<GameObject> spawnPoints = new List<GameObject>();


    private Player playerScript;
    private PlayerController playerController;
    private Upgrader upgraderScript = new Upgrader();

    private List<Item> allItems = new List<Item>();
    private List<GameObject> itemGameobjects = new List<GameObject>();
    private Item[] equippedItems = new Item[2];

    private bool inWorkshop = true;
    private bool upgraderItemSwapped = false;

    private List<Enemy> activeEnemies = new List<Enemy>();
    protected int currentEnemyId = 0;

    void Start()
    {
        playerObject = Instantiate(playerPrefab, new Vector2(-4, 22), Quaternion.identity);
        playerScript = new Player();

        playerController = playerObject.GetComponent<PlayerController>();
        playerController.SetCamera(camera);
        playerController.SetPlayer(playerScript);
        playerController.SetGameLoop(this);
        camera.GetComponent<CameraController>().SetPlayer(playerObject);




        /*Melee meleeWeapon = new Melee(10, 10, 1);
        Ranged rangedWeapon = new Ranged(10);
        Armor armor = new Armor(0.7f, 0.1f);*/
        //allItems = new Item[] { meleeWeapon, rangedWeapon, armor};

        SpawnItem("bat");
        SpawnItem("molotov");
        SpawnItem("chestProtector");
        SpawnItem("punch");
        SpawnEnemy("evilEye");
        /*SpawnEnemy("evilEye");
        SpawnEnemy("evilEye");*/

        playerScript.SetItems(allItems);




        // TEMPORARY \/
        // upgraderScript.InsertItem(rangedScript);
        //  equippedItems[0] = meleeScript;
        // equippedItems[1] = armorScript;
        // TEMPORARY /\
    }

    public void SpawnItem(String type)
    {

        switch (type)
        {
            case "bat":
                GameObject melee = Instantiate(batPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerObject.transform);
                itemGameobjects.Add(melee);
                melee.transform.localPosition = new Vector3(0, 0.3f, -1);
                Melee meleeScript = new Melee(10, 1, 0.5f, 1f);
                melee.GetComponent<MeleeBehaviour>().SetMeleeScript(meleeScript);
                playerController.SetMelee(melee);
                allItems.Add(meleeScript);
                break;
            case "molotov":
                GameObject ranged = Instantiate(molotovPrefab, new Vector3(0, 0.2f, 0), Quaternion.identity, playerObject.transform);
                itemGameobjects.Add(ranged);
                ranged.transform.localPosition = new Vector3(0, 0.2f, -1);
                Ranged rangedScript = new Ranged(30, 2, 3, 0.75f);
                ranged.GetComponent<RangedBehaviour>().SetRangedScript(rangedScript);
                playerController.SetRanged(ranged);
                allItems.Add(rangedScript);
                break;
            case "chestProtector":
                GameObject armor = Instantiate(chestProtectorPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerObject.transform);
                itemGameobjects.Add(armor);
                Armor armorScript = new Armor(0.7f, 0.2f);
                allItems.Add(armorScript);
                break;
            case "punch":
                GameObject punch = Instantiate(punchPrefab, new Vector3(0, 0, 0), Quaternion.identity, playerObject.transform);
                itemGameobjects.Add(punch);
                punch.transform.localPosition = new Vector3(0, 0.3f, -1);
                Melee punchScript = new Melee(5, 1, 0.5f, 0.5f);
                punch.GetComponent<MeleeBehaviour>().SetMeleeScript(punchScript);
                playerController.SetPunch(punch);
                //allItems.Add(punchScript);
                break;
        }


    }

    public void SpawnEnemy(String type)
    {
        GameObject spawnPoint = spawnPoints[0];
        switch (activeEnemies.Count)
        { 
            case 0:
                spawnPoint = spawnPoints[0];
                break;
            case 1:
                spawnPoint = spawnPoints[1];
                break;
            case 2:
                spawnPoint = spawnPoints[2];
                break;
        } 
        if (type == "evilEye")
        {
            GameObject enemy = Instantiate(evilEyePrefab, spawnPoint.transform.position, Quaternion.identity);
            Enemy enemyScript = new Enemy(50, 15, 10, this, currentEnemyId++);
            enemy.GetComponent<EnemyBehaviour>().SetEnemyScript(enemyScript);
            activeEnemies.Add(enemyScript);
            enemy.GetComponent<AIDestinationSetter>().target = playerObject.transform;
        }
    }

    public void KillEnemy(int id)
    {
        foreach(Enemy enemy in activeEnemies)
        {
            if (enemy.GetId() == id)
            {
                activeEnemies.Remove(enemy);
                break;
            }
        }
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
        //mapCover.SetActive(true);
        //workshopCover.SetActive(false);
    }
    public void ExitWorkshop()
    {
        if (upgraderItemSwapped)
        {
            playerObject.transform.position = new Vector2(71.5f, 21);
            inWorkshop = false;
            //workshopCover.SetActive(true);
            //mapCover.SetActive(false);
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
            itemGameobjects[0].SetActive(false);
            itemGameobjects[1].SetActive(true);
            itemGameobjects[2].SetActive(true);
            allItems[0].SetEquipped(false);
            allItems[1].SetEquipped(true);
            allItems[2].SetEquipped(true);
            /*playerObject.transform.Find("Melee").gameObject.SetActive(false);
            playerObject.transform.Find("Ranged").gameObject.SetActive(true);
            playerObject.transform.Find("Armor").gameObject.SetActive(true);*/
        }
        else if (itemScript is Ranged)
        {
            itemGameobjects[0].SetActive(true);
            itemGameobjects[1].SetActive(false);
            itemGameobjects[2].SetActive(true);
            allItems[0].SetEquipped(true);
            allItems[1].SetEquipped(false);
            allItems[2].SetEquipped(true);
        }
        else if (itemScript is Armor)
        {
            itemGameobjects[0].SetActive(true);
            itemGameobjects[1].SetActive(true);
            itemGameobjects[2].SetActive(false);
            allItems[0].SetEquipped(true);
            allItems[1].SetEquipped(true);
            allItems[2].SetEquipped(false);
        }

    }

    public Item FindItemScript(String type)
    {
        Item script = new Item();
        switch (type)
        {
            case "melee":
                foreach(Item item in allItems)
                {
                    if (item is Melee)
                    {
                        script = item;
                        break;
                    }
                }
                break;
            case "ranged":
                foreach (Item item in allItems)
                {
                    if (item is Ranged)
                    {
                        script = item;
                        break;
                    }
                }
                break;
            case "armor":
                foreach (Item item in allItems)
                {
                    if (item is Armor)
                    {
                        script = item;
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

        foreach (Item item in allItems)
        {
            if (!item.InUpgrader())
            {
                newEquippedItems[insertedItems] = item;
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
