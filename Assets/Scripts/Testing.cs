using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour
{
    [SerializeField]
    public int gridSize = 0;  
    [SerializeField]
    public float cellSize = 0;
    private Pathfinding pathfinding;
    private Vector3 instanceGrid;
    private CompositeCollider2D collider; 
    private GameObject enemy;
    private void Start()
    {
        collider = GameObject.FindGameObjectWithTag("Tilemap").GetComponent<CompositeCollider2D>();
        instanceGrid = collider.bounds.min;
        pathfinding = new Pathfinding(gridSize, cellSize, instanceGrid);

        enemy = GameObject.Find("Enemy");
        FindVoid();
    }
    // private void Update()
    // {
    //     List<PathNode> path;

    //     if(Input.GetMouseButtonDown(0)) {
    //         Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
    //         pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
    //         path = pathfinding.FindPath(0, 0, x, y);
    //         if(pathfinding != null) {
    //             print(x + ", " + y);
    //             for(int i = 0; i < path.Count -1; i++) {
    //                 Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.red);
    //             }
    //         }
    //     }
    // }

    private void FindVoid()
    {
        List<PathNode> path;

        Vector3 voidPosition = GameObject.Find("PortalSaida").transform.position;
        Vector3 enemyPosition = enemy.transform.position;
        pathfinding.GetGrid().GetXY(voidPosition, out int voidx, out int voidy);
        pathfinding.GetGrid().GetXY(enemyPosition, out int enemyx, out int enemyy);
        path = pathfinding.FindPath(enemyx, enemyy, voidx, voidy);
        List<Vector3> pathVector = pathfinding.ToVector3(path);

        if(pathfinding != null) {
            // vilao vai ate o void
            for(int i = 0; i < pathVector.Count -1; i++) {
                enemy.transform.position += pathVector[i];
            }
        }
    }
}
