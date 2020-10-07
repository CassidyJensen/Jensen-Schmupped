using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private IEnumerator KillOnAnimationEnd()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    void Update()
    {
        StartCoroutine(KillOnAnimationEnd());
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

}
