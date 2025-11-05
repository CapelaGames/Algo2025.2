using UnityEngine;

namespace MyBinaryTree
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;


        public Node(int value)
        {
            this.value = value;
            left = null;
            right = null;
        }
    }

    public class BinaryTree : MonoBehaviour
    {
        private Node root;

        [ContextMenu("Test Binary Tree")]
        void Start()
        {
            root = new Node(50);
            Insert(10, root);
            Insert(70, root);
            Insert(7, root);
            Insert(8, root);
            Insert(90, root);
            Insert(20, root);
            Insert(1, root);
            Insert(9, root);
            Insert(2, root);

            PrintInOrder(root);

            Delete(20, root);

            PrintInOrder(root);
        }

        public void Insert(int value, Node current)
        {
            if (value < current.value)
            {
                //left branch
                if(current.left == null)
                {
                    current.left = new Node(value);
                }
                else
                {
                    Insert(value, current.left);
                }
            }

            if(value >= current.value)
            {
                //right branch
                if (current.right == null)
                {
                    current.right = new Node(value);
                }
                else
                {
                    Insert(value, current.right);
                }
            }
        }

        void PrintInOrder(Node node)
        {
            if (node == null) return;
            PrintInOrder(node.left);
            Debug.Log(node.value);
            PrintInOrder(node.right);
        }

        void PrintPreOrder(Node node)
        {
            if (node == null) return;
            Debug.Log(node.value);
            PrintPreOrder(node.left);
            PrintPreOrder(node.right);
        }

        void PrintPostOrder(Node node)
        {
            if (node == null) return;
            PrintPostOrder(node.left);
            PrintPostOrder(node.right);
            Debug.Log(node.value);
        }


        public Node GetSuccessor(Node current)
        {
            current = current.right;

            while(current != null && current.left != null)
            {
                current = current.left;
            }

            return current;
        }

        public Node Delete(int value, Node current)
        {
            if(current == null) return null;

            // searching for the correct value
            if (value < current.value)
            {
                current.left = Delete(value, current.left);
            }
            // searching for the correct value
            else if (value > current.value)
            {
                 current.right = Delete(value, current.right);
            }
            else // if found the value to delete
            {
                if(current.left == null)
                {
                    return current.right;
                }

                if(current.right == null)
                {
                    return current.left;
                }

                Node successor = GetSuccessor(current);
                current.value = successor.value;
                current.right = Delete(successor.value, current.right);
            }
            return current;
        }

    }

}