using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /*[SerializeField]
    private Workshop workshop;*/
    [SerializeField]
    private GameLoop gameLoop;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
