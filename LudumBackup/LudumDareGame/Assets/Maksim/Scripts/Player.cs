using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Player : MonoBehaviour
{
    MoneyAdd MA;
    Shop shop;
    public float moneyGained;
    public float moneySpent;
    public float moneyTotal;
    void Update()
    {
        moneyGained = MA.moneyTotal;
        moneySpent = shop.runningTotal;
        moneyTotal = moneyGained - moneySpent;
    }

}

