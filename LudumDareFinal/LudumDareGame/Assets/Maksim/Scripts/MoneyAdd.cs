using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class MoneyAdd : MonoBehaviour
{

    public static int moneyTotal;
    public Text moneyText;
    public int totalPlayers;
    public int newPlayerCount;
    public float timePassed;
    public TeamCounter moneyTC;
    public Vector3 p;
    public GameObject TreeLv1;
    public GameObject TreeLv2;
    public GameObject TreeLv3;
    public GameObject MountainLv1;
    public GameObject MountainLv2;
    public GameObject MountainLv3;
    public SpriteRenderer[] numbers = new SpriteRenderer[5];
    public Sprite[] numberSprites = new Sprite[10];
    void Start()
    {
        moneyTotal = 300;

        moneyText.text = "COINS: " + moneyTotal.ToString();

        if(moneyTotal >= 0)
        {
            DisplayCash(moneyTotal.ToString());
        }
        moneyTC = gameObject.GetComponent<TeamCounter>();
        if (moneyTC != null)
        {
            totalPlayers = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;
        }
    }

    void PurchaseTree1()
    {
        if (moneyTotal < 20)
        {
            // CANNOT PURCHASE
        }
        else
        {
            //purchase code

            Instantiate(TreeLv1, new Vector3(p.x, p.y, 0f), Quaternion.identity);
            Debug.Log("Purchased");
            moneyTotal -= 20;
        }
    }
     void PurchaseTree2()
     {
         if (moneyTotal < 40)
         {
             // CANNOT PURCHASE
         }
         else
         {
             //purchase code
             Instantiate(TreeLv2, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
             moneyTotal -= 40;
         }
     }
     void PurchaseTree3()
     {
         if (moneyTotal < 70)
         {
             // CANNOT PURCHASE
         }
         else
         {
             //purchase code
             Instantiate(TreeLv3, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
             moneyTotal -= 70;
         }
     }
     void PurchaseMT1()
     {
         if (moneyTotal < 15)
         {
             // CANNOT PURCHASE
         }
         else
         {
             //purchase code
             Instantiate(MountainLv1, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
             moneyTotal -= 15;
         }
     }
     void PurchaseMT2()
     {
         if (moneyTotal < 50)
         {
             // CANNOT PURCHASE
         }
         else
         {
             //purchase code
             Instantiate(MountainLv2, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
             moneyTotal -= 50;
         }
     }
     void PurchaseMT3()
     {
         if (moneyTotal < 100)
         {
             // RETURN CANNOT PURCHASE
         }
         else
         {
             //purchase code
             Instantiate(MountainLv3, new Vector3(p.x, p.y, 1.0f), Quaternion.identity);
             moneyTotal -= 100;
         }
     }




    public void Update()
    {
        if(!TeamCounter.isGameOver && !ShrineHandler.gameWon)
        {
            p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            timePassed += Time.deltaTime;

            if (timePassed >= 2)
            {

                newPlayerCount = moneyTC.totalRed + moneyTC.totalBlue + moneyTC.totalGreen;

                if (newPlayerCount < totalPlayers)
                {
                    totalPlayers = newPlayerCount;
                    moneyTotal += 5;
                }
                moneyTotal += 5;
                timePassed = 0;

            }


            if (moneyTotal >= 0)
            {
                DisplayCash(moneyTotal.ToString());
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PurchaseTree1();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PurchaseTree2();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PurchaseTree3();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PurchaseMT1();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                PurchaseMT2();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                PurchaseMT3();
            }
        }

    }

    void DisplayCash(string cashAmount)
    {
        for (int i = 0; i < cashAmount.Length; i++)
        {
            numbers[i].sprite = numberSprites[Convert.ToInt32(cashAmount[cashAmount.Length - 1 - i]) - 48];
        }
        for (int i = 5; i > cashAmount.Length; i--)
        {
            numbers[i - 1].sprite = null;
        }
    }





}


