using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += (scene, mode) =>
        {
            if(scene.buildIndex == 0 || scene.buildIndex > 7)
            {
                if(gameObject is not null)
                {
                    Destroy(gameObject);
                }
            }
        };
    }
}
