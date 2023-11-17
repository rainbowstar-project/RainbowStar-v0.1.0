using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Range(0f, 1f)]
    [SerializeField] private float distance;
    [SerializeField] private SpriteRenderer spriteRef;
    private float xOffset, yOffset;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = target.transform.position;
        xOffset = spriteRef.bounds.size.x;
        yOffset = spriteRef.bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = target.position * distance;
        Vector3 fixedPos = new Vector3(newPos.x, newPos.y, 10f);
        transform.position = fixedPos;

        if(Mathf.Abs(target.transform.position.x - transform.position.x) > xOffset)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
        if (Mathf.Abs(target.transform.position.y - transform.position.y) > yOffset)
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
    }
}
