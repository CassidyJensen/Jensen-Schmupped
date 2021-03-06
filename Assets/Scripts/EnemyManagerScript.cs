﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour {
    public Transform enemyAbove, enemyBelow;
    public Color[] brickColors;

    public float xSpacing, ySpacing;
    public float xOrigin, yOrigin;
    public int numRows, numColumns;

    public float speedFreq = 2f;
    public float amplitude = .5f;

    //public float roundLength;
    public int spawnMax, spawnMin;

    private float randX;
    private Vector2 loc2, loc;

    private Vector3 enemySize = new Vector3(20, 20);

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    void Update()
    {
        //move side to side - Sine waves
        float offset = Mathf.Sin(Time.time * speedFreq) * amplitude / 2;
        transform.position = new Vector2(transform.position.x, offset + 4);

    }

    private IEnumerator EnemySpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(5);
        //new spawn pseudo code
        //spawn randomly-- 3 at a time? 
        //random number 1-3
        //randomly split between top or bottom enemies
        //choose a location on the screen where enemies are not present. Animate up / down
        //random row??
        //for (int y = 0; y < roundLength; y++) {
        while (ManagerScript.S.roundVal > 0) { 
            if(ManagerScript.S.roundVal == 10)
            {
                spawnMin = 4;
                spawnMax = 7;
            }
            if (ManagerScript.S.roundVal == 40)
            {
                spawnMin = 4;
                spawnMax = 7;
            }
            int r = Random.Range(spawnMin, spawnMax + 1);
           // Debug.Log("Section");
           // Debug.Log(r);

            for (int i = 0; i < r; i++)
            {
                int aOrB = Random.Range(0, 2);
                //Debug.Log(aOrB);
                if (aOrB == 0)
                {
                    //generate enemy above
                    int row = Random.Range(2, 5);
                    Transform go = Instantiate(enemyAbove);
                    go.transform.parent = this.transform;

                    bool check = true;
                    while (check == true)
                    {
                        randX = Random.Range(-5f, 5f);
                        loc = new Vector2(randX, row);
                        check = isObjectHere(loc2);
                    }

                    go.transform.position = loc;

                    SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                }
                else
                {
                    //generate enemy below
                    int row = Random.Range(-4, -1);
                    Transform below = Instantiate(enemyBelow);
                    below.transform.parent = this.transform;

                    bool check = true;
                    while(check == true)
                    {
                        randX = Random.Range(-5f, 5f);
                        loc2 = new Vector3(randX, row, 0);
                        check = isObjectHere(loc2);
                    }


                    below.transform.position = loc2;

                    SpriteRenderer sr = below.GetComponent<SpriteRenderer>();
                }
            }
            yield return wait;
            //roundLength++;
            ManagerScript.S.UpdateRound();

        }
    }

    bool isObjectHere(Vector3 test)
    {
        Collider[] intersecting = Physics.OverlapBox(test, enemySize, Quaternion.identity);

        if (intersecting.Length != 0)
        {
            Debug.Log("Test: " + test);

            return true;
        }
        else
        {

        return false;
        }
    }

    //bool isSomethingHere()
    // {
    //Use the OverlapBox to detect if there are any other colliders within this box area.
    //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
    // Collider[] hitColliders = Physics2D.OverlapBox(gameObject.transform.position, transform.localScale, Quaternion.identity);
    // int i = 0;
    //Check when there is a new collider coming into contact with the box
    // while (i < hitColliders.Length)
    //  {
    //Output all of the collider names
    //  Debug.Log("Hit : " + hitColliders[i].name + i);
    //Increase the number of Colliders in the array
    // i++;
    //  }
    //  }


}
