using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator anim;




    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelCo(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadNextLevelCo(SceneManager.GetActiveScene().buildIndex));

    }

    public void LoadSpecificScene(int levelIndex)
    {
        StartCoroutine(LoadNextLevelCo(levelIndex));

    }

    IEnumerator LoadNextLevelCo(int levelIndex)
    {
        anim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(levelIndex);
    }
}
