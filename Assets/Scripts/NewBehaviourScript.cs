using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Socorro : MonoBehaviour
{
    private Vector2 destination;
    // Start is called before the first frame update

    private Rigidbody2D rigid;
    private Vector2 movement;
    public float movementSpeed = 10f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

    }   

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.acceleration.x*3.5f, Input.acceleration.y*5f) * movementSpeed;
        rigid.AddForce(movement);
    }
}
