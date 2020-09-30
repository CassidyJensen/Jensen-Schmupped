using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos;
    public float      speed = .05f;
    public float      leftWall, rightWall;
    //maybe swithc to game manager? 
    public float health = 1f;
    public Image healthBar;
    public float angle1, angle2, angle3;
    public float speedFreq = 2f;
    public float amplitude = .5f;

    public GameObject projectile;
    public GameObject projectileDown;
    public KeyCode fireUpKey, fireDownKey;

    // Start is called before the first frame update
    void Start() {
        healthBar.fillAmount = health;

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }

        if(ManagerScript.S.ammoVal > 0)
        {
            if (Input.GetKeyDown(fireUpKey))
            {
                //Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                ManagerScript.S.UpdateAmmo();

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
                ManagerScript.S.UpdateAmmo();

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

        transform.localPosition = new Vector3(xPos, offset, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            health -= .1f;
            healthBar.fillAmount = health;
        }
    }
}

