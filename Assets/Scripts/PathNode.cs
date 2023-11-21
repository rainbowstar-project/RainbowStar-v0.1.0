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
    public Vector3 position;

    //public bool isWalkable;
    public PathNode parent;
    // true -> wall
    // [UP, RIGHT, DOWN, LEFT]
    public bool[] flag = { false, false, false, false };
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

    public void SetWallActive(int wall, bool b)
    {
        flag[wall] = b;
    }

    public void SetFlag(float radius)
    {
        int layerMask = 1 << 8;
        RaycastHit2D hitUp = Physics2D.Raycast(position, -Vector3.down, radius, layerMask);
        if (hitUp.collider != null) flag[0] = true;

        RaycastHit2D hitRight = Physics2D.Raycast(position, -Vector3.left, radius, layerMask);
        if (hitRight.collider != null) flag[1] = true;

        RaycastHit2D hitDown = Physics2D.Raycast(position, -Vector3.up, radius, layerMask);
        if (hitDown.collider != null) flag[2] = true;

        RaycastHit2D hitLeft = Physics2D.Raycast(position, -Vector3.right, radius, layerMask);
        if (hitLeft.collider != null) flag[3] = true;

        // Debug.Log(x + ", " + y);
        // Debug.Log(flag[0]);
        // Debug.Log(flag[1]);
        // Debug.Log(flag[2]);
        // Debug.Log(flag[3]);
        // Debug.Log("--------------------------------");
    }
}
