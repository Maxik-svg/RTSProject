using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    List<Vector2> PathToTarget;
    List<Node> OpenList = new List<Node>(); //Unvisited Nodes 
    List<Node> ClosedList = new List<Node>(); //Visited Nodes

    List<Node> GetNeighbourNodes(Node node)
    {
        var Neighbours = new List<Node>();

        Neighbours.Add(new Node(node.G + 1,
            new Vector2(node.Position.x - 1, node.Position.y),
            node.TargetPosition,
            node)); //left

        Neighbours.Add(new Node(node.G + 1,
            new Vector2(node.Position.x + 1, node.Position.y),
            node.TargetPosition,
            node)); //right

        Neighbours.Add(new Node(node.G + 1, new Vector2(
            node.Position.x, node.Position.y - 1),
            node.TargetPosition,
            node)); //bottom

        Neighbours.Add(new Node(node.G + 1,
            new Vector2(node.Position.x, node.Position.y + 1),
            node.TargetPosition,
            node)); //top

        return Neighbours;
    }


}

public class Node
{
    public Vector2 Position;
    public Vector2 TargetPosition;
    public int F; // F = G + H
    public int G; // distance from the start
    public int H; // distance to the end
    public Node PreviousNode;
    
    public Node(int g, Vector2 nodePosition, Vector2 targetPosition, Node previousNode)
    {
        Position = nodePosition;
        TargetPosition = targetPosition;
        PreviousNode = previousNode;

        G = g;
        H = (int)Mathf.Abs(targetPosition.x - Position.x) + (int)Mathf.Abs(targetPosition.y - Position.y);
        F = G + H;
    }
}
