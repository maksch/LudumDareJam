using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class SoldierStats : MonoBehaviour
{
    public float AiHealth = 100f;

    public void ApplyDamage(float Bdmg)
    {
        AiHealth -= Bdmg;
    }
    bool isDead() //returns if soldier is dead
    {
        if (AiHealth <= 0)
        {
            //Destroy(gameObject);
            return true;
        }
        else
            return false;
    }
    void Update()
    {
        if (isDead() == true) { Destroy(gameObject.transform.parent.gameObject); }
    }
}