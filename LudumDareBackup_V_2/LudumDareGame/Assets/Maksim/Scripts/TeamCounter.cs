using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class TeamCounter : MonoBehaviour
{
    public int totalRed;
    public int totalBlue;
    public int totalGreen;

    float timePassed;
    void Start()
    {
        totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;
        totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
        totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;
    }

    public void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 1)
        {
            if (timePassed > 3)
            {
                totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
                timePassed = 0;
            }
            else if (timePassed > 2)
            {
                totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;

            }
            else if (timePassed > 1)
            {
                totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;

            }
        }
    }
}

