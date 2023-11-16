using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private Grid<PathNode> grid;
    public int x;
    public int y;
    public int gCost;
    public int hCost;
    public int fCost;

    //public bool isWalkable;
    public PathNode parent;
    // true -> wall
    // [UP, RIGHT, DOWN, LEFT]
    public bool[] flag = {false, false, false, false};
    public PathNode(Grid<PathNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString() 
    {
        return x + ", " + y;
    } 

    public void SetWallActive(int wall, bool b) {
        flag[wall] = b;
    }
}
