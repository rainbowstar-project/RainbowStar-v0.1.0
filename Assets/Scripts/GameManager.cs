using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int fragmentAmount;
    private int playerCollected;

    [SerializeField] private GameObject portal;
    private bool levelFinalized;

    // Start is called before the first frame update
    void Start()
    {
        playerCollected = 0;
        levelFinalized = false;
    }

    public void AddFragmentToPlayer()
    {
        playerCollected++;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerCollected >= fragmentAmount && !levelFinalized)
        {
            portal.GetComponent<Portal>()?.UpdatePortal();
            levelFinalized = true;
        }
    }
}
