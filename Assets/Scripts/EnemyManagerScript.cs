using System.Collections;
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

    public float roundLength;
    public int spawnMax;

    private float randX;
    private Vector2 loc2, loc;

    private Vector2 enemySize = new Vector2(.5f, .3f);

    // Start is called before the first frame update
    void Start()
    {
       // for (int i = 0; i < numRows; i++) {
         //   for (int j = 0; j < numColumns; j++) {
           //     Transform go = Instantiate(enemyAbove);
             //   go.transform.parent = this.transform;
                
              //  Vector2 loc = new Vector2(xOrigin + (i * xSpacing), yOrigin - (j * ySpacing));

                //go.transform.position = loc;

                //generate enemies on bottom at same space for testing
//                Transform below = Instantiate(enemyBelow);
  //              below.transform.parent = this.transform;
    //            Vector2 loc2 = new Vector2(xOrigin + (i * xSpacing), -yOrigin + (j * ySpacing));
      //          below.transform.position = loc2;

        //        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
          //      SpriteRenderer sr2 = below.GetComponent<SpriteRenderer>();
       //     }
       // }

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
        for (int y = 0; y < roundLength; y++) {
            int r = Random.Range(0, spawnMax + 1);
           // Debug.Log("Section");
           // Debug.Log(r);

            for (int i = 0; i < r; i++)
            {
                int aOrB = Random.Range(0, 2);
                //Debug.Log(aOrB);
                if (aOrB == 0)
                {
                    //generate enemy above
                    int row = Random.Range(1, 5);
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
                    int row = Random.Range(-4, 0);
                    Transform below = Instantiate(enemyBelow);
                    below.transform.parent = this.transform;

                    bool check = true;
                    while(check == true)
                    {
                        randX = Random.Range(-5f, 5f);
                        loc2 = new Vector2(randX, row);
                        check = isObjectHere(loc2);
                    }


                    below.transform.position = loc2;

                    SpriteRenderer sr = below.GetComponent<SpriteRenderer>();
                }
            }
            yield return wait;
            
        }
    }

    bool isObjectHere(Vector2 position)
    {
        Collider[] intersecting = Physics.OverlapBox(position, enemySize);
        if (intersecting.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
