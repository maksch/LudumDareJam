using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class SoldierStats : MonoBehaviour
{
    static float AiHealth = 100f;
    //static float BulletDamage = 10f;



    bool isDead() //returns if soldier is dead
    {
        if (AiHealth <= 0)
        {
            //Destroy soldier
            return true;
        }
        else
            return false;

    }
}
