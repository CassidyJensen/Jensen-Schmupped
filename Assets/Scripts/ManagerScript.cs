using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Text score, ammo, status, round, timer;
    public int scoreVal, ammoVal, ammoTimer, rumTimer, roundVal, powerType;

    public float health = 1f;
    public Image healthBar;

    public GameObject ammoBox, rumBox, healthBox;

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
        round.text = roundVal.ToString();
        UpdateStatus("");

        healthBar.fillAmount = health;


        StartCoroutine(AmmoSpawner());
        StartCoroutine(PowerUpSpawner());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreInc)
    {
        scoreVal += scoreInc;
        score.text = scoreVal.ToString();
    }
    public void UpdateAmmo(int ammoNum)
    {

        ammoVal = ammoVal + ammoNum;
        ammo.text = ammoVal.ToString();
    }

    public void UpdateHealth(float healthChange)
    {
        
        health += healthChange;
        if (health > 1)
        {
            health = 1;
        }
        if (health <= 0)
        {
            //game over
            SceneManager.LoadScene("GameOver");
        }
        healthBar.fillAmount = health;
    }

    public void UpdateRound()
    {
        roundVal++;
        round.text = roundVal.ToString();
    }

    private IEnumerator AmmoSpawner()
    {
        while (ammoTimer > 0)
        {
            ammoTimer = Random.Range(20, 50);
            WaitForSeconds wait = new WaitForSeconds(ammoTimer);

            Instantiate(ammoBox);
            yield return wait;
        }

    }

    private IEnumerator PowerUpSpawner()
    {
        while (rumTimer > 0)
        {
            rumTimer = Random.Range(20, 50);
            powerType = Random.Range(0, 100);

            WaitForSeconds wait = new WaitForSeconds(rumTimer);

            if(powerType > 30)
            {
                Instantiate(rumBox);
            }
            else 
            {
                Instantiate(healthBox);
            }
            yield return wait;
        }

    }

    public void UpdateStatus(string updateText)
    {
        status.text = updateText;
    }
}
