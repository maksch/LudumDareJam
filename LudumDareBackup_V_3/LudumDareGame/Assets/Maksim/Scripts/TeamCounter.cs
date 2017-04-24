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
    public static bool isGameOver;
    public GameObject gameOverSprite;
    float timePassed;
    void Start() {
        totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;
        totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
        totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;
    }

    public void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 2)
        {
            timePassed = 0;

            totalRed = GameObject.FindGameObjectsWithTag("RedPlayer").Length;
            totalBlue = GameObject.FindGameObjectsWithTag("BluePlayer").Length;
            totalGreen = GameObject.FindGameObjectsWithTag("GreenPlayer").Length;
            print("checked");
        }
        print(totalGreen);
        if(totalRed <= 0 || totalBlue <= 0 || totalGreen <= 0)
        {
            isGameOver = true;
        }
        if (TeamCounter.isGameOver)
        {
            gameOverSprite.active = true;
        }
    }
}

