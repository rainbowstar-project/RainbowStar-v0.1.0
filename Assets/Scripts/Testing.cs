using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class Testing : MonoBehaviour
{
    private Pathfinding pathfinding;
    private Vector3 instanceGrid;
    private int gridSize;
    private void Start()
    {
        instanceGrid = Vector3.zero; // aqui e pra pegar a posicao do canto interior esquerdo do mapa
        gridSize = 5; // aqui e pra pegar as dimencoes do mapa (width/height)
        pathfinding = new Pathfinding(gridSize, instanceGrid);
    }
    private void Update()
    {
        List<PathNode> path;

        if(Input.GetMouseButtonDown(0)) {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            path = pathfinding.FindPath(0, 0, x, y);
            if(pathfinding != null) {
                print(x + ", " + y);
                for(int i = 0; i < path.Count -1; i++) {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.red);
                }
            }
        }
    }
}
