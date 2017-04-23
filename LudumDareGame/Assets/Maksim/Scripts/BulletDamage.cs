using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class BulletDamage : MonoBehaviour
{

    public float Bdmg = 10f;
    //private GameObject tgtR;
    //private GameObject tgtG;
    //private GameObject tgtB;
    public SoldierStats SS;
    public Collider MyCollider;
    private GameObject target;
    BulletMovement bm;

    private void Start()
    {
        MyCollider = gameObject.GetComponent<BoxCollider>();
        target = MyCollider.gameObject;
        bm = GetComponent<BulletMovement>();
    }
    private void Update() { }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetInstanceID() != bm.shooterId &&
            (collision.gameObject.tag == "GreenPlayer" ||
            collision.gameObject.tag == "RedPlayer" ||
            collision.gameObject.tag == "BluePlayer"))
        {
            if (collision.gameObject.GetComponent<SoldierStats>() != null)
            {
                SS = collision.gameObject.GetComponent<SoldierStats>();
                SS.SendMessage("ApplyDamage", Bdmg, SendMessageOptions.DontRequireReceiver);
                SS.ApplyDamage(Bdmg);
                Destroy(gameObject);
            }
        }
    }
}








