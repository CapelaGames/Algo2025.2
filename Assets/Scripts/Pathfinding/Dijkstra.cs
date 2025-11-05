using System.Collections.Generic;
using UnityEngine;

namespace MyPathfinding
{
    public class Dijkstra : MonoBehaviour
    {
        protected Node[] nodesInScene;

        public void GetAllNodes()
        {
            nodesInScene = FindObjectsByType<Node>(FindObjectsSortMode.None);
        }

        public void DebugPath(List<Node> path)
        {
            Debug.Log(" debug "+ path.Count);
            for (int i = 0; i < path.Count - 1; i++)
            {
                Debug.Log("TESTTT");
                Debug.DrawLine(path[i].transform.position + Vector3.up * 0.01f,
                                path[i + 1].transform.position + Vector3.up * 0.01f,
                                Color.red, 10f);
            }
        }

        public List<Node> FindShortestPath(Node start, Node goal)
        {
            if(RunAlgorithm(start, goal))
            {
                List<Node> results = new List<Node>();
                Node current = goal;
                do
                {
                    results.Insert(0,current);
                    current = current.PreviousNode;
                } while (current != null);
                Debug.Log(results.Count);
                return results;
            }
            return null;
        }

        protected virtual bool RunAlgorithm(Node start, Node goal)
        {
            List<Node> unexplored = new List<Node>();
            Node sNode = start;
            Node eNode = goal;
            SetUnexplored(unexplored);

            sNode.PathWeight = 0;
            while (unexplored.Count > 0)
            {
                //Sort unexplored list based on path weight
                unexplored.Sort( (a,b) => a.PathWeight.CompareTo(b.PathWeight) );
                Node current = unexplored[0];
                unexplored.RemoveAt(0);

                foreach (var neighbourNode in current.Neighbours)
                {
                    // Ensure that we havn't explored the neighbour
                    if (!unexplored.Contains(neighbourNode)) continue;

                    float neighbourWeight = Vector3.Distance(current.transform.position,
                                                       neighbourNode.transform.position);

                    neighbourWeight += current.PathWeight;

                    if (neighbourWeight < neighbourNode.PathWeight)
                    {
                        neighbourNode.PathWeight = neighbourWeight;
                        neighbourNode.PreviousNode = current;
                    }
                } // return foreach
                if (current == eNode) return true;
            } // end while
            
            return false; // if we don't find the end node
        }

        public void SetUnexplored(List<Node> unexplored)
        {
            foreach (var node in nodesInScene)
            {
                node.Reset();
                unexplored.Add(node);
            }
        }
    }
}
