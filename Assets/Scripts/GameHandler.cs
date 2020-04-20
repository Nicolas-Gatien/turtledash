using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameHandler : MonoBehaviour
{

    public bool gameOver;

    public static int turtlesInGame;
    public static int score;

    public TextMeshProUGUI scoreText;

    public GameObject[] objects;

    public int startingTurtles;

    public GameObject turtle;
    public float xSpawnPos;
    public float minYSpawnPos;
    public float maxYSpawnPos;

    private void Awake()
    {
        Screen.fullScreen = true;

        score = 0;
        turtlesInGame = 0;
    }
    private void Start()
    {
        Screen.fullScreen = true;


        while (startingTurtles > 0)
        {
            var spawnPos = new Vector2(xSpawnPos, Random.Range(minYSpawnPos, maxYSpawnPos));
            Instantiate(turtle, spawnPos, Quaternion.identity);
            startingTurtles--;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

    
        if (scoreText != null)
        {
            if (!gameOver)
            {
                scoreText.text = score.ToString();

            }else
            {
                scoreText.text = "Score: " + score.ToString();

            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            Instantiate(objects[0], mousePos2D, Quaternion.identity);



        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);


            Instantiate(objects[1], mousePos2D, Quaternion.identity);



        }

    }

    private void LateUpdate()
    {
        if (turtlesInGame < 1)
        {

            if (SceneManager.GetActiveScene().name == "Tutorial")
            {

                FindObjectOfType<LevelLoader>().ReloadLevel();
            }else
            {
                FindObjectOfType<LevelLoader>().LoadNextLevel();

            }

        }
    }


}
