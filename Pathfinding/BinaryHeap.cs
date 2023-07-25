using System.Collections.Generic;
using UnityEngine;
public class BinaryHeap //None of the data structures supported by C# function the way I need them to, so here's my attempt to implement a binary tree data structure for an efficient priority queue for pathfinding.
{
    List<Node> Heap = new List<Node>();

    public bool IsEmpty()
    {
        return (Heap.Count <= 0);
    }
    public void Insert(Node item)
    {
        Heap.Add(item);
        int i = Heap.Count - 1;
        bool done = false;
        while (!done)
        {
            int parentIndex = Mathf.FloorToInt((i - 1) / 2);
            Node parent = Heap[parentIndex];
            Node child = Heap[i];
            if (child.Cost < parent.Cost)
            {
                Heap[i] = parent;
                Heap[parentIndex] = child;
                i = parentIndex;
            }
            else
            {
                done = true;
            }
        }
        MinHeapify(0);
    }
    public Node Pop()
    {
        Node rootNode = Heap[0];
        if (Heap.Count <= 1)
        {
            Heap.Clear();
        }
        else
        {
           
            Node lastNode = Heap[Heap.Count - 1];
            Heap.RemoveAt(Heap.Count - 1);
            Heap[0] = lastNode;
            MinHeapify(0);
        }
        
        return rootNode;
    }
    public void MinHeapify(int i) //Smallest Cost brought to top of binary tree!
    {
        int Left = 2 * i + 1;
        int Right = 2 * i + 2;
        int Smallest = i;
        if (Left < Heap.Count && Heap[Left].Cost < Heap[Smallest].Cost)
        {
            Smallest = Left;
        }
        if (Right < Heap.Count && Heap[Right].Cost < Heap[Smallest].Cost)
        {
            Smallest = Right;
        }
        if (Smallest != i)
        {
            //perform swap
            Node iNode = Heap[i];
            Node SmallestNode = Heap[Smallest];
            Heap[i] = SmallestNode;
            Heap[Smallest] = iNode;

            MinHeapify(Smallest);
        }
    }

    public Node PushPop(Node item)
    {
        if (Heap.Count > 0 && Heap[0].Cost < item.Cost)
        {
            Node firstItem = Heap[0];
            Heap[0] = item;
            item = firstItem;
            MinHeapify(0);
        }
        return item;
    }

    public Node Replace(Node item)
    {
        Node firstItem = Heap[0];
        Heap[0] = item;
        item = firstItem;
        MinHeapify(0);
        return item;
    }

    public bool Contains(Node item)
    {
        foreach (var node in Heap)
        {
            if (node.location == item.location)
            {
                return true;
            }
        }
        return false;
    }
    public void Remove(Node item)
    {
        int index = 0;
        foreach (var node in Heap)
        {
            if (node.location == item.location)
            {
                break;    
            }
            index++;
        }
        Node lastNode = Heap[Heap.Count - 1];
        Heap[index] = lastNode;
        Heap.RemoveAt(Heap.Count - 1);
        MinHeapify(0);
    }
}