using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public Text score, ammo, status;
    public int scoreVal, ammoVal, ammoTimer, rumTimer;

    public float health = 1f;
    public Image healthBar;

    public GameObject ammoBox, rumBox;

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
        UpdateStatus("");

        healthBar.fillAmount = health;


        StartCoroutine(AmmoSpawner());
        StartCoroutine(RumSpawner());

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
        while (ammoTimer > 0)
        {
            ammoTimer = Random.Range(20, 50);
            WaitForSeconds wait = new WaitForSeconds(ammoTimer);

            Instantiate(ammoBox);
            yield return wait;
        }

    }

    private IEnumerator RumSpawner()
    {
        while (rumTimer > 0)
        {
            rumTimer = Random.Range(20, 50);
            WaitForSeconds wait = new WaitForSeconds(rumTimer);

            Instantiate(rumBox);
            yield return wait;
        }

    }

    public void UpdateStatus(string updateText)
    {
        status.text = updateText;
    }
}
