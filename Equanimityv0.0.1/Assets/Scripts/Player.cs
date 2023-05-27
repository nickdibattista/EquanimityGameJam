using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    protected Equipment[] equipment;
    public Player() : base(100, 10, 10)
    {
        equipment = new Equipment[2];
    }

    public Equipment[] GetEquipment()
    {
        return equipment;
    }


}
