using Unity.VisualScripting;
using UnityEngine;

namespace OurLinkedList
{
    public class Node
    {
        public string name = "Test Name";
        public int age = 0;

        public Node next;
        public Node prev;

        public Node(string name, int age)
        {
            this.name = name;
            this.age = age;

            next = null;
            prev = null;
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
            
            linkedList.ReturnToHeader();
            linkedList.Next();
            linkedList.Next();
            linkedList.Prev();
            linkedList.PrintCurrent();
            
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            
            Debug.Log("------------------------");
            linkedList.InsertNext(Roger);
            linkedList.PrintAll();
            Debug.Log("------------------------");
            linkedList.DeleteCurr();
            linkedList.PrintAll();
            linkedList.InsertPrev(Roger);
            linkedList.InsertNext(Steve);
            linkedList.InsertPrev(Tom);
            linkedList.PrintAll();
        }
    }

    public class LinkedList
    {
        private Node current;
        private Node header;
        private Node tail;

        public LinkedList(Node node)
        {
            header = node;
            tail = node;
            current = node;
            header.next = null;
            header.prev = null;
        }

        public void InsertNext(Node newNode)
        {
            if (current == null)
            {
                header = newNode;
                tail = newNode;
                newNode.next = null;
                newNode.prev = null;
                // current = newNode;
            }
            else if (current.next == null)
            {
                current.next = newNode;
                newNode.next = null;
                newNode.prev = current;
                tail = newNode;
            }
            else
            {
                newNode.next = current.next;
                current.next = newNode;

                newNode.next.prev = newNode;
                newNode.prev = current;
            }
            current = newNode;
        }

        public void InsertPrev(Node newNode)
        {
            if (current == null)
            {
                header = newNode;
                tail = newNode;
                newNode.next = null;
                newNode.prev = null;
                // current = newNode;
            }
            else if (current.prev == null)
            {
                header = newNode;
                current.prev = newNode;
                newNode.next = current;
                newNode.prev = null;
            }
            else
            {
                newNode.prev = current.prev;
                current.prev = newNode;
                newNode.prev.next = newNode;
                newNode.next = current;
            }
            current = newNode;
        }

        public bool Next()
        {
            if (current == null) return false;
            if (current.next != null)
            {
                current = current.next;
                return true;
            }

            return false;
        }
        public bool Prev()
        {
            if (current == null) return false;
            if (current.prev != null)
            {
                current = current.prev;
                return true;
            }
            return false;
        }
        
        
        public bool DeleteNext()
        {
            if (current.next == null) return false;

            current.next = current.next.next;

            if (current.next == null)
            {
                tail = current;
            }
            else
            {
                current.next.prev = current;
            }
            // if you're using c++ raw pointers
            // you would have delete() here
            return true;
        }
        
        public bool DeletePrev()
        {
            if (current.prev == null) return false;

            current.prev = current.prev.prev;

            if (current.prev == null)
            {
                header = current;
            }
            else
            {
                current.prev.next = current;
            }
            // if you're using c++ raw pointers
            // you would have delete() here
            return true;
        }

        public void DeleteCurr()
        {
            if (Prev())
            {
                DeleteNext();
            }
            else if(Next())
            {
                DeletePrev();
            }
            else
            {
                header = null;
                tail = null;
                current = null;
            }
        }

        public void ReturnToHeader()
        {
            current = header;
        }
        public void ReturnToTail()
        {
            current = tail;
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
        
        public void PrintAllReverse()
        {
            if (tail == null) return;
            Node currentPrint = tail;
            do
            {
                Print(currentPrint);
                currentPrint = currentPrint.prev;
            } while (currentPrint != null);
        }
    }
}