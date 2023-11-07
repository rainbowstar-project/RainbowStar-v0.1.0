using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fragment : MonoBehaviour
{
    public UnityEvent fragmentCollect;

    private void Start()
    {
        fragmentCollect.AddListener(GameObject.FindGameObjectWithTag("ProgressBar").GetComponent<ProgressBar>().UpdateProgress);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            fragmentCollect.Invoke();
            Destroy(gameObject);
        }
    }
}
