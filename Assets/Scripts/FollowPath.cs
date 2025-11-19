using UnityEngine;
using MyPathfinding;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour
{
    public Dijkstra pathFinder;
    private int currentNodeIndex = 0;
    private List<Node> path;
    void Start()
    {
        pathFinder.GetAllNodes();
        
        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
        int startNode = nodes.Length - 1;
        int goalNode = Random.Range(0, nodes.Length -1);
        
        path = pathFinder.FindShortestPath
            (nodes[startNode],
            nodes[goalNode]);
        pathFinder.DebugPath(path);
    }
    void Update()
    {
        if (currentNodeIndex < path.Count)
        {
            transform.position = Vector3.MoveTowards(transform.position, path[currentNodeIndex].transform.position, 0.01f);
            if (Vector3.Distance(transform.position, path[currentNodeIndex].transform.position) < 0.01f)
            {
                currentNodeIndex++;
            }
        }
    }
}
