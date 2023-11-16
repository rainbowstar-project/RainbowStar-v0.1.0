using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding
{
    private const int MOVE_STRAIGHT_COST = 10;
    private const int MOVE_DIAGNAL_COST = 1; // sqrt.(200)
    private Grid<PathNode> grid;
    // nodes up to search
    private List<PathNode> openList;
    // nodes already searched
    private List<PathNode> closedList;
    public Pathfinding(int gridSize, Vector3 intanceGrid)
    {
        //grid = new Grid<PathNode>(width, height, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
        grid = new Grid<PathNode>(gridSize, gridSize, 5f, intanceGrid, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
    }
    public Grid<PathNode> GetGrid()
    {
        return grid;
    }
    public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
    {
        PathNode startNode = grid.GetGridObject(startX, startY);
        PathNode endNode = grid.GetGridObject(endX, endY);
        openList = new List<PathNode> {startNode};
        closedList = new List<PathNode>();

        for(int x = 0; x < grid.GetWidth(); x++) {
            for(int y = 0; y < grid.GetHeight(); y++) {
                PathNode pathNode = grid.GetGridObject(x, y);
                pathNode.gCost = int.MaxValue;
                pathNode.CalculateFCost();
                pathNode.parent = null;
                // initialize flag -> discover how verify colider
            }
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0) {
            PathNode currentNode = GetLowestFCostNode(openList);
            if(currentNode == endNode) {
                // reached final node
                return CalculatePath(endNode);
            }
            // if it's not the end node
            openList.Remove(currentNode);
            closedList.Add(currentNode);

            int count = 0;
            int aux = 2;
            foreach (PathNode neighborNode in GetNeighborList(currentNode)) {
                switch (count) {
                    case 0: aux = 2;
                        break;
                    case 1: aux = 3;
                        break;
                    case 2: aux = 0;
                        break;
                    case 3: aux = 1;
                        break;
                }

                if (neighborNode != null && !closedList.Contains(neighborNode)) {
                    // if both dont't have walls
                    if (!currentNode.flag[count] && !neighborNode.flag[aux]) {
                        // trying to find a faster path
                        int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
                        if(tentativeGCost < neighborNode.gCost) {
                            neighborNode.parent = currentNode;
                            neighborNode.gCost = tentativeGCost;
                            neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
                            neighborNode.CalculateFCost();

                            if (!openList.Contains(neighborNode)) openList.Add(neighborNode);
                        }       
                    }
                    //else closedList.Add(neighborNode);
                }

                if (count < 4) count++;
                else count = 0;
            }
        }

        // out of nodes in openList
        return null;
    }

    /// <summary>
    /// return [UP, RIGHT, DOWN, LEFT] neighbors
    /// </summary>
    /// <param name="currentNode"></param>
    /// <returns></returns>
    private List<PathNode> GetNeighborList(PathNode currentNode)
    {
        List<PathNode> neighborList = new List<PathNode>();

        // the if's are only to check if the node is valid
        if(currentNode.y + 1 < grid.GetHeight()) neighborList.Add(GetNode(currentNode.x, currentNode.y + 1)); // up
        else neighborList.Add(null);

        if(currentNode.x + 1 < grid.GetWidth()) neighborList.Add(GetNode(currentNode.x + 1, currentNode.y)); // right
        else neighborList.Add(null);

        if(currentNode.y - 1 >= 0) neighborList.Add(GetNode(currentNode.x, currentNode.y - 1)); // down
        else neighborList.Add(null);

        if(currentNode.x - 1 >= 0) neighborList.Add(GetNode(currentNode.x - 1, currentNode.y)); // left
        else neighborList.Add(null);

        return neighborList;
    }

    private PathNode GetNode(int x, int y)
    {
        PathNode node = grid.GetGridObject(x, y);
        return node;
    }

    private void SetNodeWallActive(int x, int y, int wall, bool b)
    {
        PathNode node = grid.GetGridObject(x, y);
        node.SetWallActive(wall, b);
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;

        while(currentNode.parent != null) {
            path.Add(currentNode.parent);
            currentNode = currentNode.parent;
        }

        path.Reverse();
        return path;
    }

    private int CalculateDistanceCost(PathNode a, PathNode b)
    {
        // int xDistance = Mathf.Abs(a.x - b.x);
        // int yDistance = Mathf.Abs(a.y - b.y);
        // int remaining = Mathf.Abs(xDistance - yDistance);
        // return MOVE_DIAGNAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;

        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int remaining = Mathf.Abs(xDistance + yDistance);
        return remaining;
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList) 
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for(int i = 1; i < pathNodeList.Count; i++) {
            if(pathNodeList[i].fCost < lowestFCostNode.fCost) lowestFCostNode = pathNodeList[i];
        }
        return lowestFCostNode;
    }
}
