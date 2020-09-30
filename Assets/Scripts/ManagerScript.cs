using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Text score, ammo;
    public int scoreVal, ammoVal;

    public static ManagerScript S;

    void Awake()
    {
        S = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ammo.text = ammoVal.ToString();
        score.text = scoreVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreVal += 100;
         score.text = scoreVal.ToString();
    }
    public void UpdateAmmo()
    {
        ammoVal--;
        ammo.text = ammoVal.ToString();
    }
}
