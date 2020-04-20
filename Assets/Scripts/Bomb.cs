using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public GameObject explosion;
    public GameObject explosionCircle;
    public GameObject explosionSound;

    public void Explode()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(explosionCircle, transform.position, Quaternion.identity);
        Instantiate(explosionSound, transform.position, Quaternion.identity);


        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Explode();
    }


}
