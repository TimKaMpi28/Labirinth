using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
     private void Awake()
    {
        Destroy(gameObject, 1f);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.layer == LayerMask.GetMask("Default"))
            Destroy(gameObject);
    }
}
