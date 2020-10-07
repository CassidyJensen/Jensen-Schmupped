using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos;
    public float      speed = .05f;
    public float      leftWall, rightWall;
    public float angle1, angle2, angle3;
    public float speedFreq = 2f;
    public float amplitude = .5f;
    private float rumVar = 0f;

    public GameObject projectile;
    public GameObject projectileDown;
    public KeyCode fireUpKey, fireDownKey;

    public bool rumActive = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed + rumVar;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed + rumVar;
            }
        }

        if(ManagerScript.S.ammoVal > 0)
        {
            if (Input.GetKeyDown(fireUpKey))
            {
                //Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                ManagerScript.S.UpdateAmmo(-1);

                var proj = (GameObject)Instantiate(projectile, new Vector2(transform.position.x - .25f, transform.position.y + 0.5f), Quaternion.identity);
                proj.GetComponent<ProjectileScript>().ReceiveParameter(angle1);
                var proj1 = (GameObject)Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                proj1.GetComponent<ProjectileScript>().ReceiveParameter(angle2);
                var proj2 = (GameObject)Instantiate(projectile, new Vector2(transform.position.x + .25f, transform.position.y + 0.5f), Quaternion.identity);
                proj2.GetComponent<ProjectileScript>().ReceiveParameter(angle3);
            }

            if (Input.GetKeyDown(fireDownKey))
            {
                //Instantiate(projectileDown, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                ManagerScript.S.UpdateAmmo(-1);

                var proj = (GameObject)Instantiate(projectileDown, new Vector2(transform.position.x - .25f, transform.position.y - 0.5f), Quaternion.identity);
                proj.GetComponent<ProjectileScript>().ReceiveParameter(angle1);
                var proj1 = (GameObject)Instantiate(projectileDown, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                proj1.GetComponent<ProjectileScript>().ReceiveParameter(angle2);
                var proj2 = (GameObject)Instantiate(projectileDown, new Vector2(transform.position.x + .25f, transform.position.y - 0.5f), Quaternion.identity);
                proj2.GetComponent<ProjectileScript>().ReceiveParameter(angle3);


            }
        }

        //move side to side - Sine waves
        float offset = Mathf.Sin(Time.time * speedFreq) * amplitude / 2;

        transform.localPosition = new Vector2(xPos, offset);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            ManagerScript.S.UpdateHealth();
        }

        if (other.gameObject.tag == "AmmoSupply")
        {
            Destroy(other.gameObject);
            ManagerScript.S.UpdateAmmo(10);

        }

        if (other.gameObject.tag == "Rum")
        {
            Destroy(other.gameObject);
            //Start CoRoutine?? 
            //For 10 seconds
            //adjust the player speed with rum variable? 
            //also adjust the offset? 
            StartCoroutine(RumEffects());
        }
    }

    private IEnumerator RumEffects()
    {
        int rumTimer = 20;
        rumActive = true;
        WaitForSeconds wait = new WaitForSeconds(1);
        ManagerScript.S.UpdateStatus("Rum");
        //rum positive effect

        for (int i=0; i < rumTimer; i++)
        {
            //set rum variable negative effect
            rumVar = Random.Range(-.04f, .04f);
            yield return wait;

        }

        rumVar = 0;
        rumActive = false;
        ManagerScript.S.UpdateStatus("");
    }

}

