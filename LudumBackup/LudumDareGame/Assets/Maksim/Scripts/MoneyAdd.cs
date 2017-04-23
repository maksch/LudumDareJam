using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class MoneyAdd : MonoBehaviour
{

    public int moneyTotal;
    public Text moneyText;
    public int totalPlayers;
    public int newPlayerCount;
    public float timePassed;
    public TeamCounter moneyTC;
    public Vector3 p;
    public GameObject Tree1;


    void Start()
    {
        moneyTotal = 0;
        moneyText.text = "COINS: " + moneyTotal.ToString();
        moneyTC = gameObject.GetComponent<TeamCounter>();
        if (moneyTC != null)
        {
            totalPlayers = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;
        }




        Tree1 = Resources.Load("ObstacleSize1") as GameObject; //TODO ADD OBJECTS

    }





    void PurchaseTree1()
    {
        if (moneyTotal < 10)
        {
            // CANNOT PURCHASE
        }
        else
        {
            //purchase code
            
            Instantiate(Tree1, new Vector3(p.x, p.y, 0f), Quaternion.identity);
            Debug.Log("Purchased");
            moneyTotal -= 10;
        }
    }
//     void PurchaseTree2()
//     {
//         if (moneyTotal < 25)
//         {
//             // CANNOT PURCHASE
//         }
//         else
//         {
//             //purchase code
//             Instantiate(obstacles.Tree2, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
//             moneyTotal -= 25;
//         }
//     }
//     void PurchaseTree3()
//     {
//         if (moneyTotal < 50)
//         {
//             // CANNOT PURCHASE
//         }
//         else
//         {
//             //purchase code
//             Instantiate(obstacles.Tree3, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
//             moneyTotal -= 50;
//         }
//     }
//     void PurchaseMT1()
//     {
//         if (moneyTotal < 10)
//         {
//             // CANNOT PURCHASE
//         }
//         else
//         {
//             //purchase code
//             Instantiate(obstacles.MT1, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
//             moneyTotal -= 10;
//         }
//     }
//     void PurchaseMT2()
//     {
//         if (moneyTotal < 25)
//         {
//             // CANNOT PURCHASE
//         }
//         else
//         {
//             //purchase code
//             Instantiate(obstacles.MT2, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
//             moneyTotal -= 25;
//         }
//     }
//     void PurchaseMT3()
//     {
//         if (moneyTotal < 50)
//         {
//             // RETURN CANNOT PURCHASE
//         }
//         else
//         {
//             //purchase code
//             Instantiate(obstacles.MT3, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
//             moneyTotal -= 50;
//         }
//     }




    public void Update()
    {
        p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        timePassed += Time.deltaTime;

        if (timePassed >= 2)
        {

            newPlayerCount = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;

            if (newPlayerCount < totalPlayers)
            {
                totalPlayers = newPlayerCount;
                moneyTotal += 3;
            }
            moneyTotal += 2;
            timePassed = 0;

            moneyText.text = "COINS: " + moneyTotal.ToString();
        }



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PurchaseTree1();
        }
//         if (Input.GetKeyDown(KeyCode.Alpha2))
//         {
//             PurchaseTree2();
//         }
//         if (Input.GetKeyDown(KeyCode.Alpha3))
//         {
//             PurchaseTree3();
//         }
//         if (Input.GetKeyDown(KeyCode.Alpha4))
//         {
//             PurchaseMT1();
//         }
//         if (Input.GetKeyDown(KeyCode.Alpha5))
//         {
//             PurchaseMT2();
//         }
//         if (Input.GetKeyDown(KeyCode.Alpha6))
//         {
//             PurchaseMT3();
//         }
    }







}
    

