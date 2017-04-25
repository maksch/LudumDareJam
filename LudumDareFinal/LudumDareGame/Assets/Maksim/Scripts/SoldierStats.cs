using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class SoldierStats : MonoBehaviour
{
    public float AiHealth = 100f;
    float startHealth;
    Transform healthBar;
    float initXScale;
    public GameObject dyingSound;
    string myTag;
    void Start()
    {
        myTag = gameObject.tag;
        startHealth = AiHealth;
        healthBar = transform.parent.Find("Health");
        initXScale = healthBar.localScale.x;
    }
    public void ApplyDamage(float Bdmg)
    {
        AiHealth -= Bdmg;
        healthBar.localScale = new Vector3(initXScale * (AiHealth / startHealth), healthBar.localScale.y, healthBar.localScale.z);
    }
    bool isDead() //returns if soldier is dead
    {
        if (AiHealth <= 0)
        {
            //Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
    void Update()
    {
        if (!TeamCounter.isGameOver && !ShrineHandler.gameWon)
        {

            if (myTag == "GreenPlayer") { ShrineHandler.greenShrine += 0.01f; }
            if (myTag == "RedPlayer") { ShrineHandler.redShrine += 0.01f; }
            if (myTag == "BluePlayer") { ShrineHandler.blueShrine += 0.01f; }
        }
        if (isDead() == true) {
            MoneyAdd.moneyTotal += 20;
            Instantiate(dyingSound);
            if (myTag == "GreenPlayer") { ShrineHandler.greenShrine -= 1f; }
            if (myTag == "RedPlayer") { ShrineHandler.redShrine -= 1f; }
            if (myTag == "BluePlayer") { ShrineHandler.blueShrine -= 1f; }
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
