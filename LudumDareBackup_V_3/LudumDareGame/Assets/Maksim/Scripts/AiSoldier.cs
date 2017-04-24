using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSoldier : MonoBehaviour {
    
    string myColorType;
    public bool isFighting;
    Vector3 enemyLocation = new Vector3(0, 0, 0);
    float timePassed;
    float bulletTimeLimit = 1.9f;
    GameObject bullet;
    GameObject newBullet;
    BulletMovement bulletMovement;
    AiMovement myMovement;
    Vector3 dirVect;
    // Use this for initialization
    void Start () {
        myColorType = gameObject.tag;
        myMovement = transform.parent.gameObject.GetComponent<AiMovement>();
        bullet = (GameObject)Resources.Load("Bullet");
	}
	
	// Update is called once per frame
	void Update () {
        if (isFighting && !TeamCounter.isGameOver)
        {
            timePassed += Time.deltaTime;
            if(timePassed > bulletTimeLimit)
            {
                dirVect = (enemyLocation - transform.position).normalized;
                newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletMovement = newBullet.GetComponent<BulletMovement>();
                bulletMovement.xMove = Random.Range(dirVect.x - 0.001f, dirVect.x + 0.001f) * 0.01f;
                bulletMovement.yMove = Random.Range(dirVect.y - 0.001f, dirVect.y + 0.001f) * 0.01f;
                bulletMovement.shooterId = transform.parent.gameObject.GetInstanceID();
                timePassed = 0;
                isFighting = false;
                myMovement.allowMovement = true;
            }
        }
	}
    void OnTriggerEnter(Collider c)
    {
        if (myColorType != c.gameObject.tag)
        {
            isFighting = true;
            //Vector3 difference = c.gameObject.transform.position - transform.parent.transform.position;
            //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            enemyLocation = c.gameObject.transform.position;
            myMovement.allowMovement = false;
        }
    }
    void OnTriggerStay(Collider c)
    {
        if (myColorType != c.gameObject.tag)
        {
            isFighting = true;
            //Vector3 difference = c.gameObject.transform.position - transform.parent.transform.position;
            //float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.parent.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            enemyLocation = c.gameObject.transform.position;
            myMovement.allowMovement = false;
        }
    }
    void OnTriggerExit(Collider c)
    {
        if (myColorType != c.gameObject.tag)
        {
            isFighting = false;
            myMovement.allowMovement = true;
        }
    }
}
