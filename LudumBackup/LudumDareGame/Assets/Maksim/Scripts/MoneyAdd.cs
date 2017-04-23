using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;



public class MoneyAdd : MonoBehaviour
{
    float moneyGainedDelta = 0f;
    public int moneyTotal;
    void Start(){}
    void Update()
    {
        moneyGainedDelta += Time.deltaTime;
        if(moneyGainedDelta >= 1)
        {
            moneyGainedDelta--;
            moneyTotal++;
            Debug.Log(moneyTotal);
        }

    }
}
