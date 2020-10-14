using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject projectile;

    private float delay, rate;
    public int chance;
    private int chanceVal;

    // Start is called before the first frame update
    void Start()
    {
        delay = Random.Range(2f, 10f);
        rate = Random.Range(2f, 8f);

        chance = 80;
        //chance increase
        if (ManagerScript.S.roundVal > 50)
        {
            chance = 40;
        }
        else if (ManagerScript.S.roundVal > 20)
        {
            chance = 60;
        }
        InvokeRepeating("Fire", delay, rate);

    }


    private void Fire()
    {
        int i = Random.Range(0, 100);

        if(i > chance)
        {
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            if (ManagerScript.S.roundVal > 30)
            {
                var proj = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                proj.GetComponent<ProjectileScript>().ReceiveParameter(-1);
            }
            if (ManagerScript.S.roundVal > 60)
            {
                var proj2 = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                proj2.GetComponent<ProjectileScript>().ReceiveParameter(1);
            }
            //add a bunch of projectiles (make it harder??? round 2??
            //var proj = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //proj.GetComponent<ProjectileScript>().ReceiveParameter(-1);
            //var proj1 = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //proj1.GetComponent<ProjectileScript>().ReceiveParameter(0);
            //var proj2 = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            //proj2.GetComponent<ProjectileScript>().ReceiveParameter(1);
        }
    }
}
