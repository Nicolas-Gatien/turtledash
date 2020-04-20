using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{

    public int gameSceneIndex;
    public int tutorialSceneIndex;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

    }
    public void Play()
    {
        FindObjectOfType<LevelLoader>().LoadSpecificScene(gameSceneIndex);
    }

    public void Tutorial()
    {
        FindObjectOfType<LevelLoader>().LoadSpecificScene(tutorialSceneIndex);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
