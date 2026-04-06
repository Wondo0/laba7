using System.Collections;

namespace Lab7Node;

public class Node
{
    public short Data { get; set; }

    public Node? Next { get; set; }

    public Node(short data)
    {
        ArgumentNullException.ThrowIfNull(data);
        this.Data = data;
        this.Next = null;
    }
}

public class NodeList : IEnumerable<short>
{
    private Node? head;
    private Node? tail;

    public void addNext(short data)
    {
        Node newNode = new Node(data);

        if (this.head == null)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            this.tail.Next = newNode;
            this.tail = newNode;
        }
    }

    public short? findMultipleBy(short dividedBy)
    {
        if (dividedBy == 0)
        {
            throw new ArgumentException("Ділення на нуль неможливе.");
        }

        Node? current = this.head;

        while (current != null)
        {
            if (current.Data % dividedBy == 0)
            {
                return current.Data;
            }
            current = current.Next;
        }

        return null;
    }

    public void replaceEvenNodesToArgument(short argument = 0)
    {
        Node? current = this.head;
        int position = 0;
        while (current != null)
        {
            if (position % 2 == 0)
            {
                current.Data = argument;
            }
            current = current.Next;
            position++;
        }
    }

    public NodeList? getNewListWithElementsGreaterThan(short data)
    {
        Node? current = this.head;
        NodeList newList = new NodeList();
        while (current != null)
        {
            if (current.Data > data)
            {
                newList.addNext(data);
            }
            current = current.Next;
        }

        return newList;
    }

    public void deleteOddNodes()
    {
        Node? current = this.head;

        while (current != null && current.Next != null)
        {
            Node nodeToRemove = current.Next;
            
            current.Next = nodeToRemove.Next;

            if (current.Next == null)
            {
                this.tail = current;
            }

            current = current.Next;
        }
    }

    public short this[int index]
    {
        get
        {
            if (index < 0)
            {
                throw new ArgumentException("Індекс не може бути від'ємним");
            }

            Node? current = head;
            int currentIndex = 0;

            while (current != null)
            {
                if (currentIndex == index)
                {
                    return current.Data;
                }
                current = current.Next;
                currentIndex++;
            }

            throw new IndexOutOfRangeException("Індекс більше ніж розмір списку");
        }
    }

    public void RemoveElement(int index)
    {
        if (index < 0 || head == null)
            throw new IndexOutOfRangeException("Індекс виходить за межі списку або список порожній.");

        if (index == 0)
        {
            head = head.Next;
            if (head == null)
                tail = null;
            return;
        }

        Node current = head;
        int currentIndex = 0;

        while (current != null && currentIndex < index - 1)
        {
            current = current.Next;
            currentIndex++;
        }

        if (current == null || current.Next == null)
            throw new IndexOutOfRangeException("Індекс виходить за межі списку.");

        current.Next = current.Next.Next;

        if (current.Next == null)
        {
            tail = current;
        }
    }

    public IEnumerator<short> GetEnumerator()
    {
        Node? current = head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}