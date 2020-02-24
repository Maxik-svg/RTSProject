using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathFinder
{
    public List<Vector2> PathToTarget = new List<Vector2>();

    List<CellScript> GameField;
    Vector2 TargetPosition;
    Vector2 StartPosition;
    List<Node> OpenList = new List<Node>(); //Unvisited Nodes 
    List<Node> ClosedList = new List<Node>(); //Visited Nodes

    public PathFinder() // defaultConstructor
    {
        GameField = GameController.gameField;
    }
    public PathFinder(Vector2 start, Vector2 target)
    {
        TargetPosition = target;
        StartPosition = start;
        GameField = GameController.gameField;
    }

    public List<Vector2> GetPath()
    {
        Node startNode = new Node(0, StartPosition, TargetPosition, null);
        OpenList.Add(startNode);

        while (true)
        {
            Node currentNode = OpenList.Where(x => x.F == OpenList.Min(y => y.F)).FirstOrDefault(); //returns only 1 element
            
            OpenList.Remove(currentNode);
            ClosedList.Add(currentNode);

            if (currentNode.Position == TargetPosition)
            {
                OpenList.Clear();
                ClosedList.Clear();
                return FindPath(currentNode);
            }

            List<Node> neighbourList = GetNeighbourNodes(currentNode);

            foreach (Node neighbour in neighbourList)
            {
                if ((Contains(ClosedList,neighbour) || //change wtite own contains----------------------------------------------------------------------------------------------------
                    NotWalkable(neighbour)) && // whether the cell is walkable
                    neighbour.Position != TargetPosition) // target is base only
                    continue;
                if (currentNode.G + 1 < neighbour.G || !Contains(OpenList, neighbour))
                {
                    neighbour.ParentNode = currentNode;
                    if (!Contains(OpenList, neighbour))
                        OpenList.Add(neighbour);
                }
            }
        }
    }

    public List<Vector2> GetPath(Vector2 start, Vector2 target) // overload of GetPath with changable positions
    {
        StartPosition = start;
        TargetPosition = target;
        return GetPath();
    }

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

    List<Vector2> FindPath(Node node)
    {
        List<Vector2> path = new List<Vector2>();

        while(node.ParentNode != null)
        {
            path.Add(new Vector2(node.Position.x, node.Position.y));
            node = node.ParentNode;
        }

        path.Reverse();
        return path;
    }

    bool Contains(List<Node> list, Node node)
    {
        foreach (Node item in list)
        {
            if (item.Position == node.Position)
                return true;
        }

        return false;
    }

    bool NotWalkable(Node node)
    {
        if (GameField == null)
            GameField = GameController.gameField;
        foreach (var item in GameField)
        {
            //if (node.Position == new Vector2(7, -7))
            //    return true;
            if(item.Position == node.Position)
            {
                return item.IsBaseCell;
            }
        }
        return false;
    }

}

public class Node
{
    public Vector2 Position;
    public Vector2 TargetPosition;
    public int F; // F = G + H
    public int G; // distance from the start
    public int H; // distance to the end
    public Node ParentNode;
    
    public Node(int g, Vector2 nodePosition, Vector2 targetPosition, Node parentNode)
    {
        Position = nodePosition;
        TargetPosition = targetPosition;
        ParentNode = parentNode;

        G = g;
        H = (int)Mathf.Abs(targetPosition.x - Position.x) + (int)Mathf.Abs(targetPosition.y - Position.y);
        F = G + H;
    }

    /*public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        Node other = obj as Node;
        if (other == null)
            return false;
        return this.Position.x == other.Position.x &&
                    this.Position.y == other.Position.y &&
                    this.TargetPosition.x == other.TargetPosition.x &&
                    this.TargetPosition.y == other.TargetPosition.x;
    }

    public override int GetHashCode()
    {
        return (int)(this.Position.x + this.Position.y + 
            this.TargetPosition.x + this.TargetPosition.y);
    }*/
}
