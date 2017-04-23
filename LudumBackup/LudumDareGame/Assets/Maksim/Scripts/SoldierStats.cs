using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class SoldierStats : MonoBehaviour
{
    public float AiHealth = 100f;

    Transform healthBar;
    float initXScale;
    void Start()
    {
        healthBar = transform.parent.Find("Health");
        initXScale = healthBar.localScale.x;
    }
    public void ApplyDamage(float Bdmg)
    {
        AiHealth -= Bdmg;
        healthBar.localScale = new Vector3(initXScale * (AiHealth / 100f), healthBar.localScale.y, healthBar.localScale.z);
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
