using MyBinaryTree;
using UnityEngine;

namespace MyPathfinding
{
    // [ExecuteInEditMode]
    public class GridGenerator : MonoBehaviour
    {
        public Node prefab;

        private int rows = 25, columns = 25;
        private float gap = 1f;

        [ContextMenu("Generate Grid")]
        public void GenerateGrid()
        {
            Vector3 startPos = transform.position;

            Node prev = null;
            Node[] prevColumn = new Node[columns];

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    Vector3 newPosition = new Vector3(
                        startPos.x + gap * x,
                        0f,
                        startPos.z + gap * y);

                    Node node = Instantiate(prefab, newPosition, Quaternion.identity,transform);
                    node.name = node.name + x + " " + y;
                    if (prev != null)
                    {
                        node.Neighbours.Add(prev);
                        prev.Neighbours.Add(node);
                    }

                    if (prevColumn[y] != null)
                    {
                        prevColumn[y].Neighbours.Add(node);
                        node.Neighbours.Add(prevColumn[y]);
                    }

                    prev = node;
                    prevColumn[y] = node;
                }

                prev = null;
            }
        }

        [ContextMenu("MAO")]
        public void KillAllOrphans()
        {
            Node[] nodesInScene = FindObjectsByType<Node>(FindObjectsSortMode.None);

            foreach (var orphan in nodesInScene)
            {
                if (orphan.Neighbours.Count == 0)
                {
                    DestroyImmediate(orphan.gameObject);
                }
            }
        }
    }
}