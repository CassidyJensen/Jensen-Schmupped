using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject projectile;

    private GameObject enemyManager;
    private EnemyManagerScript enemyManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        InvokeRepeating("Fire", delay, rate);

        enemyManager = GameObject.Find("EnemyManager");
        enemyManagerScript = enemyManager.GetComponent<EnemyManagerScript>();
    }

    // Update is called once per frame
    private void Fire()
    {
        int i = Random.Range(0, 100);
        if(i > 80)
        {
            Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

            if (enemyManagerScript.roundLength > 20)
            {
                var proj = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                proj.GetComponent<ProjectileScript>().ReceiveParameter(-1);
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
