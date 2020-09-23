using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float               speed = 2f;
    public int direction;
    
    private Rigidbody2D        rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }

    
    private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        rb.AddForce(transform.up * speed * direction);
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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
