using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class TeamCounter : MonoBehaviour
{

    public static int totalRedStatic;
    public static int totalBlueStatic;
    public static int totalGreenStatic;
    public int totalRed;
    public int totalBlue;
    public int totalGreen;
    public static bool isGameOver;
    public GameObject gameOverSprite;
    float timePassed;
    void Start() {
        isGameOver = false;
        totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;
        totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
        totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;
    }

    public void Update()
    {
        totalBlueStatic = totalBlue;

        totalRedStatic = totalRed;
        totalGreenStatic = totalGreen;
        timePassed += Time.deltaTime;
        if (timePassed > 2)
        {
            timePassed = 0;

            totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;
            totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
            totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;
            print("checked");
        }

        if(totalRed <= 1 || totalBlue <= 1 || totalGreen <= 1)
        {
            isGameOver = true;
        }
        if (TeamCounter.isGameOver)
        {
            gameOverSprite.active = true;
        }
    }
}

