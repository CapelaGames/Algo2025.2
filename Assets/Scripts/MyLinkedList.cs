using Unity.VisualScripting;
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
        [ContextMenu("Test Linked List")]
        void Test()
        {
            Node Andrew = new Node("Andrew", 300);
            Node Steve = new Node("Steve", 56);
            Node Tom = new Node("Tom", 40);
            Node Roger = new Node("Roger", 1);
            Node RogerRoger = new Node("RogerRoger", 2);
            Node Tim = new Node("Tim", 22); 
            Node Tam = new Node("Tam", 22);

            LinkedList linkedList = new LinkedList(Andrew);
            linkedList.InsertNext(Steve);
            linkedList.InsertNext(Tom);
            linkedList.ReturnToHeader();
            linkedList.DeleteNext();
            linkedList.InsertNext(Roger);
            linkedList.InsertNext(RogerRoger);
            linkedList.InsertNext(Tim);
            linkedList.InsertNext(Tam);
            linkedList.ReturnToHeader();
            linkedList.Next();
            linkedList.Next();
            linkedList.DeleteNext();

            linkedList.PrintAll();
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
            else
            {
                newNode.next = current.next;
                current.next = newNode;
            }
            current = newNode; // Optional
        }

        public bool Next()
        {
            if (current.next != null)
            {
                current = current.next;
                return true;
            }

            return false;
        }

        public bool DeleteNext()
        {
            if (current.next == null) return false;

            current.next = current.next.next;

            return true;
        }

        public void ReturnToHeader()
        {
            current = header;
        }

        public void PrintCurrent() => Debug.Log(current.name + " aged " + current.age);
        public void Print(Node node) => Debug.Log(node.name + " aged " + node.age);


        public void PrintAll()
        {
            if (header == null) return;
            Node currentPrint = header;
            do
            {
                Print(currentPrint);
                currentPrint = currentPrint.next;
            } while (currentPrint != null);
        }
    }
}