using System.Collections.Generic;
using UnityEngine;

namespace MyPathfinding
{
    public class AStar : Dijkstra
    {
        protected override bool RunAlgorithm(Node start, Node goal)
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
    }
}
