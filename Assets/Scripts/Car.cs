using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float destroyTime;


    public float friction;

    public bool isBroken;
    public Sprite brokenSprite;

    public float brokenMass;

    public Color[] carColour;

    private float rbMass;
    SpriteRenderer spriteRend;
    public float speed;
    Rigidbody2D rb;

    int damageTaken;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        int index = Random.Range(0, carColour.Length);
        spriteRend.color = carColour[index];
        rb.velocity = transform.right * speed;
        rbMass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBroken)
        {
            spriteRend.sprite = brokenSprite;
            transform.rotation = transform.rotation;

            if (rb.velocity.x > 0 || rb.velocity.y > 0)
            {
                rb.mass = rbMass;

                rb.velocity = rb.velocity * friction * Time.deltaTime;

            }
            else
            {
                rb.mass = brokenMass;
                rb.velocity = Vector2.zero;

            }
        }else
        {
            rb.velocity = transform.right * speed;

        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bomb") || other.CompareTag("Wall"))
        {
            if (damageTaken > 2)
            {
                GameHandler.score += 1;
                Destroy(gameObject);
            }
            isBroken = true;
            Destroy(gameObject, destroyTime);
            damageTaken++;

        }
    }

    
}
