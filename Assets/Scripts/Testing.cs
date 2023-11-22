using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
using System.Threading.Tasks;

public class Testing : MonoBehaviour
{
    [SerializeField]
    public int gridSize = 0;
    [SerializeField]
    public float cellSize = 0;
    private Pathfinding pathfinding;
    private Vector3 instanceGrid;
    private CompositeCollider2D cc2d;
    private GameObject enemy;
    private Rigidbody2D body;
    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        if (enemy != null)
        {
            body = enemy.GetComponent<Rigidbody2D>();
        }
        cc2d = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<CompositeCollider2D>();
        instanceGrid = cc2d.bounds.min;
        pathfinding = new Pathfinding(gridSize, cellSize, instanceGrid);

        StartCoroutine(FindVoidPath());
    }
    IEnumerator FindVoidPath()
    {
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 voidPosition = GameObject.Find("PortalSaida").transform.position;

        List<Vector3> path = pathfinding.FindPath(enemyPosition, voidPosition);
        float step = 1.0f * Time.fixedDeltaTime;

        if (pathfinding != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                yield return new WaitForSeconds(1f);
                enemy.transform.position = path[i];

                // Vector3 target = (enemy.transform.position - path[i]).normalized;
                // body.MovePosition(enemy.transform.position + target * step);
                // print(i + " " + path[i]);
                // print(i + " " + enemy.transform.position);
                // Task.Delay(5000);
                // enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, path[i], 2.0f);
                // enemy.transform.position = Vector3.Lerp(enemy.transform.position, path[i], step);
                // Vector3 move = path[i] - enemy.transform.position;
                // enemy.transform.Translate(move * Time.deltaTime);
            }
        }
    }
}
