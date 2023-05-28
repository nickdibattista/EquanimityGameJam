using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameLoop gameLoop;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameLoop.InWorkshop())
        {
            gameLoop.ExitWorkshop();
        }
        else
        {
            gameLoop.EnterWorkshop();
        }
    }
}
