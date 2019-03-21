// Double linked list

using System;
public class List<T>
{
    static readonly string emptyMsg = "List is empty.";
    static readonly string indexErrorMsg = "Invalid index.";
    private Node head, tail;
    private int size;
    public class Node
    {
        public T val;
        public Node prev, next;

        public Node(T val) { this.val = val; }
    }

    public class Iterator
    {

        internal Node node;
        public Iterator(Node node) { this.node = node; }

        public T Value() { return node.val; }
        public bool HasNext() { return IsValid() && node.next != null; }
        public bool HasPrev() { return IsValid() && node.prev != null; }

        // returns true if iterator is broken and no further operation can be performed with it
        public bool IsValid() { return node != null;}
        public T Next()
        {
            if (!HasNext())
                node = null; // invalidate the iterator
            node = node.next;
            return node.prev.val;
        }

        public T Prev()
        {
            if (!HasPrev())
                node = null; // invalidate the iterator
            node = node.prev;
            return node.next.val;
        }

    }

    public List(int size = 0)
    {
        this.size = size;
        for (int i = 0; i < size; i++)
            PushBack(default(T));
    }

    public int Size() { return size; }
    public bool Empty() { return size == 0; }
    public void Clear()
    {
        head = tail = null;
        size = 0;
    }

    public T Front()
    {
        if (size == 0)
            throw new Exception(emptyMsg);
        return head.val;
    }
    public T Back()
    {
        if (size == 0)
            throw new Exception(emptyMsg);
        return tail.val;
    }
    public void PushFront(T val)
    {
        Node newNode = new Node(val);
        if (size == 0)
            head = tail = newNode;
        else
        {
            head.prev = new Node(val);
            head.prev.next = head;
            head = head.prev;
        }
        ++size;
    }
    public void PushBack(T val)
    {
        if (size == 0)
            head = tail = new Node(val);
        else
        {
            tail.next = new Node(val);
            tail.next.prev = tail;
            tail = tail.next;
        }
        ++size;
    }

    public T PopFront()
    {
        if (size == 0)
            throw new Exception(emptyMsg);
        T val = head.val;
        if (size == 1)
        {
            head = tail = null;
        }
        else
        {
            head = head.next;
            head.prev = null;
        }
        --size;

        return val;
    }
    public T PopBack()
    {
        if (size == 0)
            throw new Exception(emptyMsg);
        T val = tail.val;
        if (size == 1)
        {
            head = tail = null;
        }
        else
        {
            tail = tail.prev;
            tail.next = null;
        }
        --size;

        return val;
    }

    public void Set(int index, T val)
    {
        if (index < 0 || index >= this.size)
            throw new ArgumentOutOfRangeException(indexErrorMsg);
        int it = -1;
        Node node = this.head;
        while (++it < index)
            node = node.next;

        node.val = val;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= this.size)
            throw new ArgumentOutOfRangeException(indexErrorMsg);
        int it = -1;
        Node node = this.head;
        while (++it < index)
            node = node.next;

        return node.val;
    }

    // iterator will point to next, or prev if next doesn't exist
    public void Remove(Iterator it)
    {
        if(!it.IsValid())
            return;
        
        if(it.node == head) {
            PopFront();
            it.Next(); // advance iterator to next; might invalidate
        }
        else if (it.node == tail){
             PopBack();
            it.Prev(); // advance iterator to prev; might invalidate
        }
        else{
            Node node = it.node;
            node.prev.next = node.next;
            node.next.prev = node.prev;
            it.Next(); // point iterator to next of removed
        }
    }

    public Iterator Head() { return new Iterator(head); }
    public Iterator Tail() { return new Iterator(tail); }

}