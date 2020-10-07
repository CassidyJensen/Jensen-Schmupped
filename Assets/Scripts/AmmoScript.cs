using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public float speed;
    public float speedFreq = 1f;
    public float amplitude = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move side to side - Sine waves
        float offset = Mathf.Sin(Time.time * speedFreq) * amplitude / 2;

        transform.position = new Vector2(transform.position.x - speed, offset);
    }
}
