using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField]
    private GameLoop gameLoop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player(Clone)")
        {
            if (!gameLoop.UpgraderItemSwapped())
            {
                gameLoop.ShowItemSwapButtons();
            }

        }
    }
}
