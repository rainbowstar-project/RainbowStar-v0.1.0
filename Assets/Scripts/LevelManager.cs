using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public Animator transition;
    public static LevelManager instance;

    public float transitionTime = 1F;

    private void Awake()
    {
        instance = this;
    }

    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)) ;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation.
        if (levelIndex != 1) {
            transition.SetTrigger("Start");
        }
        // Wait for animation to stop playing.
        yield return new WaitForSeconds(transitionTime);

        // Load scene.
        SceneManager.LoadScene(levelIndex);
    }
}
