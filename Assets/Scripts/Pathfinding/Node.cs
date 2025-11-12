using System;
using System.Collections.Generic;
using UnityEngine;

namespace MyPathfinding
{
    [ExecuteInEditMode]
    public class Node : MonoBehaviour
    {
        public List<Node> Neighbours;

        private float pathWeight;

        public float PathWeight
        {
            get { return pathWeight; }

            set { pathWeight = value; }
        }

        public float Heuristic { get; set; }

        public float heuristicPathWeight
        {
            get => Heuristic + pathWeight;
        }

        public float SetHeuristic(Vector3 goal)
        {
            Heuristic = Vector3.Distance(transform.position, goal);
            return Heuristic;
        }

        private Node previousNode;

        public Node PreviousNode
        {
            get => previousNode;
            set => previousNode = value;
        }

        // public int X { get; private set; }

        public void Reset()
        {
            pathWeight = float.PositiveInfinity;
            previousNode = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, radius: 0.2f);

            Gizmos.color = Color.grey;
            foreach (var node in Neighbours)
            {
                if (node == null) continue;
                Vector3 direction = node.transform.position - transform.position;
                Vector3 right = Vector3.Cross(direction, Vector3.up).normalized * 0.03f;

                Gizmos.DrawRay(transform.position + right, direction);
            }
        }

        private void OnValidate() => ValidateNeighbours();

        private void ValidateNeighbours()
        {
            foreach (var node in Neighbours)
            {
                if (node == null) continue;

                if (!node.Neighbours.Contains(this))
                {
                    node.Neighbours.Add(this);
                }
            }
        }

        private void OnDestroy() => RemoveFromNeighbours();
        private void RemoveFromNeighbours()
        {
            foreach (var node in Neighbours)
            {
                if (node == null) continue;
                node.Neighbours.Remove(this);
                node.Neighbours.Remove(null);
            }
        }
    }
}