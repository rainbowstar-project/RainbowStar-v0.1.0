using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Testing : MonoBehaviour
{
    [SerializeField]
    public int gridSize = 0;
    [SerializeField]
    public float cellSize = 0;
    public int speed = 10;
    private Pathfinding pathfinding;
    private Vector3 instanceGrid;
    private CompositeCollider2D cc2d;
    private GameObject enemy;
    private Rigidbody2D body;
    private List<Vector3> path;
    Coroutine Move;

    private void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        GameObject star = GameObject.FindWithTag("Player");
        enemy.transform.position = star.transform.position;
        cc2d = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<CompositeCollider2D>();
        instanceGrid = cc2d.bounds.min;
        pathfinding = new Pathfinding(gridSize, cellSize, instanceGrid);

        StartCoroutine(FindVoidPath());
    }

    IEnumerator FindVoidPath()
    {
        yield return new WaitForSeconds(1);
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 voidPosition = GameObject.Find("PortalSaida").transform.position;

        path = pathfinding.FindPath(enemyPosition, voidPosition);

        for (int i = 0; i < path.Count; i++)
        {
            Move = StartCoroutine(Moving(i));
            yield return Move;
        }
        Destroy(enemy);
    }

    IEnumerator Moving(int pos)
    {
        while (enemy.transform.position != path[pos])
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, path[pos], speed * Time.deltaTime);
            yield return null;
        }
    }
}
