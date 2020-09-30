using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float               speed = 2f;
    public float speedSlow = 1.8f;
    public int direction;

    public GameObject explosion;

    private Rigidbody2D        rb;
    private float projectileXDir;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }

    
    private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
       // rb.AddForce(transform.up * speed * direction);
        if(projectileXDir != 0)
        {
            //slow vertical slightly
            rb.AddForce(transform.up * speedSlow * direction );
            rb.AddForce(transform.right * projectileXDir );
        }
        else
        {
            rb.AddForce(transform.up * speed * direction);

        }

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            return;
        }

        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //award points
            ManagerScript.S.UpdateScore();

            Instantiate(explosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            rb.AddForce(transform.up * speed * direction);
        }

        if(other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }


    public void ReceiveParameter(float xDir)
    {
        projectileXDir = xDir;
    }
}
