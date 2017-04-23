using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class MoneyAdd : MonoBehaviour
{
    public int moneyTotal;
    public int totalPlayers;
    public int newPlayerCount;
    public float timePassed;
    public TeamCounter moneyTC;




    void Start()
    {
        moneyTC = gameObject.GetComponent<TeamCounter>();
        if (moneyTC != null)
        {
            totalPlayers = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;
        }
    }




    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= 2)
        {
            
            newPlayerCount = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;
            
            if (newPlayerCount < totalPlayers)
            {
                totalPlayers = newPlayerCount;
                moneyTotal += 3;
            }
            moneyTotal +=2;
            timePassed = 0;
        }
    }
}
