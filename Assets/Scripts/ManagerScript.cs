using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Text score, ammo;
    public int scoreVal, ammoVal, ammoTimer;

    public float health = 1f;
    public Image healthBar;

    public GameObject ammoBox;

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

        healthBar.fillAmount = health;


        StartCoroutine(AmmoSpawner());
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
    public void UpdateAmmo(int ammoNum)
    {
        ammoVal = ammoVal + ammoNum;
        ammo.text = ammoVal.ToString();
    }

    public void UpdateHealth()
    {
        health -= .1f;
        if (health <= 0)
        {
            //game over
            SceneManager.LoadScene("GameOver");
        }
        healthBar.fillAmount = health;
    }

    private IEnumerator AmmoSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(ammoTimer);

        while (ammoTimer > 0)
        {
            Instantiate(ammoBox);
            yield return wait;
        }

        yield return wait;
    }
}
