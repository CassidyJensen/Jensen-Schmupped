﻿using System.Collections;
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

    public GameObject projectile;
    public GameObject projectileDown;
    public KeyCode fireUpKey, fireDownKey;

    public int ammo;

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

        if(ammo > 0)
        {
            if (Input.GetKeyDown(fireUpKey))
            {
                Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                ammo--;
            }

            if (Input.GetKeyDown(fireDownKey))
            {
                Instantiate(projectileDown, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                ammo--;
            }
        }

        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
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

