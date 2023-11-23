using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fragment : MonoBehaviour
{
    public UnityEvent fragmentCollect;
    public GameManager game;

    private void Start()
    {
        fragmentCollect.AddListener(GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>().UpdateProgress);
        game = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            fragmentCollect.Invoke();

            //call player animation
            collision.GetComponent<Animator>()?.Play("Blink");
            game.AddFragmentToPlayer();

            Destroy(gameObject);
        }
    }
}
