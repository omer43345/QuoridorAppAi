using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using static QuoridorApp.Constants;


namespace QuoridorApp.Model;

// class that representing the node of the graph
public class Node
{
    private Point _point;
    private List<Node> _neighbors;
    private bool _isVisited;
    private Node _parent;
    private int _distance;
    private Node _removedNeighbor;

    public Node(Point point)
    {
        _point = point;
        _neighbors = new List<Node>();
        _isVisited = false;
        _parent = null;
        _distance = 0;
    }

    public void AddNeighbor(Node node)
    {
        _neighbors.Add(node);
    }

    public void RemoveNeighbor(string side)
    {
        Node leftNeighbor = null;
        Node rightNeighbor = null;
        Node upNeighbor = null;
        Node downNeighbor = null;
        foreach (var neighbor in _neighbors)
        {
            leftNeighbor = neighbor._point.X < this._point.X ? neighbor : leftNeighbor;
            rightNeighbor = neighbor._point.X > this._point.X ? neighbor : rightNeighbor;
            upNeighbor = neighbor._point.Y < this._point.Y ? neighbor : upNeighbor;
            downNeighbor = neighbor._point.Y > this._point.Y ? neighbor : downNeighbor;
        }

        if (side == Left)
            _removedNeighbor = leftNeighbor;
        else if (side == Right)
            _removedNeighbor = rightNeighbor;
        else if (side == Up)
            _removedNeighbor = upNeighbor;
        else if (side == Down)
            _removedNeighbor = downNeighbor;
        _neighbors.Remove(_removedNeighbor);
    }

    public void AddRemovedNeighbor()
    {
        Node nodeToAdd = _removedNeighbor;
        _neighbors.Add(nodeToAdd);
        _removedNeighbor = null;
    }

    public List<Node> GetNeighbors()
    {
        return _neighbors;
    }

    public int GetDistance()
    {
        return _distance;
    }

    public void SetDistance(int distance)
    {
        _distance = distance;
    }

    public Point GetPoint()
    {
        return _point;
    }


    public void SetParent(Node current)
    {
        _parent = current;
    }

    public void NotVisited()
    {
        _isVisited = false;
    }
}

// class that creating the graph of the board and contains some graph algorithms
public class Graph
{
    private Board _board;
    private List<Node> _nodes;
    private int _count;

    public Graph(Board board)
    {
        _count = 0;
        _board = board;
        _nodes = new List<Node>();
        CreateGraph();
    }

    private void CreateGraph()
    {
        List<Point>[,] boardCopy = _board.GetBoardCopy();
        // create nodes for the graph, every node represents a point on the board
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                Node node = new Node(new Point(j, i));
                _nodes.Add(node);
            }
        }

        // add neighbors to each node in the graph according to the board
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                Node node = _nodes[i * BoardSize + j];
                foreach (var point in boardCopy[i, j])
                {
                    node.AddNeighbor(_nodes[point.X + point.Y * BoardSize]);
                }
            }
        }
    }
    
    public int CountPathsToY(Point point, int y)
    {
        ResetGraph();
        // Find the starting node based on its coordinates
        Node start = _nodes[point.X + point.Y * BoardSize];

        // Initialize DFS variables
        Stack<Node> stack = new Stack<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        int pathCount = 0;

        // Push the starting node onto the stack and mark it as visited
        stack.Push(start);
        visited.Add(start);

        // DFS algorithm
        while (stack.Count > 0)
        {
            Node current = stack.Pop();

            // Check if the current node has Y-coordinate equal to y
            if (current.GetPoint().Y == y)
            {
                pathCount++;
                continue;
            }

            // Visit each neighbor of the current node that hasn't been visited yet
            foreach (Node neighbor in current.GetNeighbors())
            {
                if (!visited.Contains(neighbor))
                {
                    stack.Push(neighbor);
                    visited.Add(neighbor);
                    neighbor.SetParent(current);
                }
            }
        }

        return pathCount;
    }


    // BFS algorithm that returns the minimum distance between starting point and the point with Y-coordinate equal to y
    public int GetMinimumDistanceToY(Point point, int y)
    {
        ResetGraph();
        // Find the starting node based on its coordinates
        Node start = _nodes[point.X + point.Y * BoardSize];

        // Initialize BFS variables
        Queue<Node> queue = new Queue<Node>();
        HashSet<Node> visited = new HashSet<Node>();
        int minDistance = -1;
        // Enqueue the starting node and mark it as visited
        queue.Enqueue(start);
        visited.Add(start);

        // BFS algorithm
        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();

            // Check if the current node has Y-coordinate equal to y
            if (current.GetPoint().Y == y)
            {
                if (minDistance == -1 || current.GetDistance() == minDistance)
                {
                    minDistance = current.GetDistance();
                    _count++;
                }
            }

            // Visit each neighbor of the current node that hasn't been visited yet
            foreach (Node neighbor in current.GetNeighbors())
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                    neighbor.SetDistance(current.GetDistance() + 1);
                    neighbor.SetParent(current);
                }
            }
        }

        // If no node with Y-coordinate equal to y was found, return -1
        return minDistance;

    }
    
    public bool IsPathsExist(Point point1, int y1, Point point2, int y2)
    {
        int distance1 = GetMinimumDistanceToY(point1, y1);
        int distance2 = GetMinimumDistanceToY(point2, y2);
        return distance1 != -1 && distance2 != -1;
    }
    public int GetMinimumPathsCount()
    {
        return _count;
    }
    // reset the nodes of the graph
    private void ResetGraph()
    {
        _count = 0;
        foreach (Node node in _nodes)
        {
            node.SetDistance(0);
            node.SetParent(null);
            node.NotVisited();
        }
    }

    public void RemoveBoundary(Wall wall)
    {
        _nodes[wall.X + wall.Y * BoardSize].AddRemovedNeighbor();
        _nodes[wall.X + 1 + wall.Y * BoardSize].AddRemovedNeighbor();
        _nodes[wall.X + (wall.Y + 1) * BoardSize].AddRemovedNeighbor();
        _nodes[wall.X + 1 + (wall.Y + 1) * BoardSize].AddRemovedNeighbor();
    }

    public void AddBoundary(Wall wall)
    {
        if (wall.Orientation)
        {
            _nodes[wall.X + wall.Y * BoardSize].RemoveNeighbor(Right);
            _nodes[wall.X + 1 + wall.Y * BoardSize].RemoveNeighbor(Left);
            _nodes[wall.X + (wall.Y + 1) * BoardSize].RemoveNeighbor(Right);
            _nodes[wall.X + 1 + (wall.Y + 1) * BoardSize].RemoveNeighbor(Left);
        }
        else
        {
            _nodes[wall.X + wall.Y * BoardSize].RemoveNeighbor(Down);
            _nodes[wall.X + 1 + wall.Y * BoardSize].RemoveNeighbor(Down);
            _nodes[wall.X + (wall.Y + 1) * BoardSize].RemoveNeighbor(Up);
            _nodes[wall.X + 1 + (wall.Y + 1) * BoardSize].RemoveNeighbor(Up);
        }
    }
}