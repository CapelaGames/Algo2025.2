using UnityEngine;

namespace OurLinkedList
{
    public class Node
    {
        public string name = "Test Name";
        public int age = 0;

        public Node next;

        public Node(string name, int age)
        {
            this.name = name;
            this.age = age;

            next = null;
        }
    }
    
    public class MyLinkedList : MonoBehaviour
    {
        void Start()
        {
            Node Andrew = new Node("Andrew", 300);
            Node Steve = new Node("Steve", 56);
            Node Tom = new Node("Tom", 40);

            LinkedList linkedList = new LinkedList(Andrew);
        }
    }

    public class LinkedList
    {
        private Node current;
        private Node header;

        public LinkedList(Node node)
        {
            header = node;
            current = node;
            header.next = null;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                current.next = newNode;
                newNode.next = null;
            }

            current = newNode; // Optional
        }
    }
}