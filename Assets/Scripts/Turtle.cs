using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turtle : MonoBehaviour
{

    public float xSpawnPos;
    public float minYSpawnPos;
    public float maxYSpawnPos;

    public GameObject turtle;

    public float maxSpeed;
    public float minSpeed;

    [HideInInspector]
    public float speed;

    [HideInInspector]
    public bool moveBool;

    Rigidbody2D rb;

    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        GameHandler.turtlesInGame++;

        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveBool)
        {
            var movePos = new Vector2(transform.position.x + speed, transform.position.y);
            rb.MovePosition(movePos);
            moveBool = false;
        }   
    }

    public void Move()
    {
        moveBool = true;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End"))
        {
            GameHandler.score += 25;

            var spawnPos = new Vector2(xSpawnPos, Random.Range(minYSpawnPos, maxYSpawnPos));

            Instantiate(turtle, spawnPos, Quaternion.identity);
            spawnPos = new Vector2(xSpawnPos, Random.Range(minYSpawnPos, maxYSpawnPos));

            Instantiate(turtle, spawnPos, Quaternion.identity);
            StartCoroutine(InWater());

        } else if (other.CompareTag("Turtle") || other.CompareTag("Wall"))
        {
            return;
        }
        else if (other.CompareTag("Tutorial"))
        {
            FindObjectOfType<LevelLoader>().LoadNextLevel();
        }else
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);

        }
    }
    

    IEnumerator InWater()
    {
        yield return new WaitForSeconds(1);
        var spriteRend = GetComponent<SpriteRenderer>();

        spriteRend.enabled = false;
        Destroy(gameObject, 3);
    }
    

    private void OnDestroy()
    {

        GameHandler.turtlesInGame--;
        Debug.Log(GameHandler.turtlesInGame);
    }
}
