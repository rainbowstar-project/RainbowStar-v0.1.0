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
    private bool pathCompleted;
    public float speed = 1.0F;
    private float startTime = 1f;
    private List<Vector3> path;
    Coroutine Move;

    private void Start()
    {
        pathCompleted = false;
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

    void Update()
    {
        // pathCompleted = false;
        if (!pathCompleted)
        {
            startTime += Time.deltaTime;
            float percentage = startTime / 100F;
            foreach (Vector3 pos in path)
            {
                enemy.transform.position = Vector3.Lerp(enemy.transform.position, pos, percentage);
            }
            pathCompleted = true;
        }
    }

    IEnumerator FindVoidPath()
    {
        Vector3 enemyPosition = enemy.transform.position;
        Vector3 voidPosition = GameObject.Find("PortalSaida").transform.position;

        path = pathfinding.FindPath(enemyPosition, voidPosition);
        float step = 1.0f / Time.fixedDeltaTime;

        startTime += Time.deltaTime;
        float percentage = startTime / 3f;
        for (int i = 0; i < path.Count; i++)
        {
            // yield return new WaitForSeconds(0.2f);
            Move = StartCoroutine(Moving(i));
            yield return Move;
            // enemy.transform.position = pos;

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
        // yield return null;
    }

    IEnumerator Moving(int pos)
    {
        while (enemy.transform.position != path[pos])
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, path[pos], 8 * Time.deltaTime);
            yield return null;
        }
    }
}
