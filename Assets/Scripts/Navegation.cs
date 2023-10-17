using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navegation : MonoBehaviour
{
    private string game = "Game";
    private string openScene = "HomePage";
    public void loadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void loadGame() {
        SceneManager.LoadScene(game);
    }

    public void loadOpenScene() {
        SceneManager.LoadScene(openScene);
    }
}
