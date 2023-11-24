using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fragment : MonoBehaviour
{
    public UnityEvent fragmentCollect;
    private GameManager game;

    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        fragmentCollect.AddListener(GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>().UpdateProgress);
        game = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            audioPlayer.Play();
            fragmentCollect.Invoke();

            //call player animation
            collision.GetComponent<Animator>()?.Play("Blink");
            game.AddFragmentToPlayer();

            StartCoroutine(Kill());
        }
    }

    private IEnumerator Kill()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
