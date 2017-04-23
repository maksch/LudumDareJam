using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class GameConditions : MonoBehaviour
{
    TeamCounter PC; //Player Count
    void Start()
    {
        
    }
    void Update()
    {
        if (PC.totalRed <= 0)
        {
            //ALL OF RED HAS DIED
            //Return to Main Menu
        }
        if (PC.totalBlue <= 0)
        {
            //ALL OF BLUE HAS DIED
            //Return to Main Menu
        }
        if (PC.totalGreen <= 0)
        {
            //ALL OF GREEN HAS DIED
            //Return to Main Menu
        }
    }
    
}


