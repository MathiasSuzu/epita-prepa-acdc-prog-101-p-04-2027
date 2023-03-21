using System;
namespace Metamorphoses;

public class TList<T>
{
    public class OutOfRangeIndexException : Exception
    {
    }

    public class ElementNotFoundException : Exception
    {
    }

    public class Element<T>
    {
        public T Data { get; set; }

        public Element<T>? Next { get; set; }

        public Element(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Element<T>? _head;
    private uint _size;

    public Element<T> Head
    {
        get => _head!;
        set => _head = value;
    }

    public uint Size
    {
        get => _size;
        set => _size = value;
    }

    //Instantiates an empty list, head should be null and size should be 0
    public TList()
    {
        Head = null;
        Size = 0;
    }

    //Instantiates a new TList from an element, size should be 1
    public TList(T e)
    {
        Head = new Element<T>(e);
        Size = 1;

    }

    //Add the element e at the end of the list, size should be updated
    public void Add(T e)
    {
        Size += 1;
        if (Size == 1)
            Head = new Element<T>(e);
        else
        {
            Element<T> header = Head;

            while (header.Next != null)
            {
                header = header.Next;
            }

            header.Next = new Element<T>(e);
        }
    }

    //Insert the element e at the position n in our list then return the list thus created
    public void Insert(T e, int n)
    {
        if (n < 0 || n > Size)
            throw new OutOfRangeIndexException();

        Element<T> header = Head;
        Size += 1;
        
        /*if (n == Size)
        {
            Add(e);
        }*/
        /*else*/ if (n == 0)
        {
            Element<T> h = Head;
            Head = new Element<T>(e);
            Head.Next = h;
        }
        else
        {
            for (; n > 1; n--)
            {
                header = header!.Next;
            }

            Element<T> h = header!.Next;
            header.Next = new Element<T>(e);
            header.Next.Next = h;
        }
    }

    //Returns the string representing the TList graphically
    public override string ToString()
    {
        string acc = "{ ";
        Element<T> header = Head;
        while (header != null)
        {
            acc += header.Data;
            header = header.Next;
            if(header != null)
                acc += ", ";
            
        }
        
        acc += " }";
        return acc;
    }

    //Returns true if both lists are equals
    public static bool operator ==(TList<T> l1, TList<T> l2)
    {
        if (l1!.Size != l2!.Size)
            return false;
        
        int i = 0;
        (Element<T> headL1, Element<T> headL2) = (l1.Head,l2.Head);
        
        while (headL1 != null && Equals(headL1.Data, headL2!.Data) )
        {
            (headL1, headL2) = (headL1.Next, headL2.Next);
            i += 1;
        }
        
        
        return i == l1.Size;
    }

    //Returns false if both lists are equals
    public static bool operator !=(TList<T> l1, TList<T> l2)
    {
        return !(l1 == l2);
    }

    //Creates a new list that is the result of the concat of l1 l2
    public static TList<T> operator +(TList<T> l1, TList<T> l2)
    {
        TList<T> result = new TList<T>();
        
        Element<T> u = l1.Head;
        Element<T> v = l2.Head;
        //Element<T> rCurrent = result.Head;
        while (u != null && u.Data != null)
        {
            result.Add(u.Data);
            u = u.Next;
            result.Size += 1;
        }

        while (v != null && v.Data != null)
        {
            result.Add(v.Data);
            v = v.Next;
            result.Size += 1;
        }
        return result;
    }

    //Removes the first occurence of element from l1 if it exits
    public static TList<T> operator -(TList<T> l1, T e)
    {
        TList<T> result = new TList<T>();
        Element<T> u = l1.Head;

        while (u != null && !Equals(u!.Data, e))
        {
            result.Add(u.Data);
            u = u.Next;
        }

        if (u is null)
            throw new ElementNotFoundException();
        
        u = u.Next;
        while (u != null)
        {
            result.Add(u.Data);
            u = u.Next;
        }
        result.Size -= 1;
        return result;
    }

    //Reverse a TList<T>
    public void Reverse()
    {
        if (Size > 1)
        {
            Element<T> current = Head;
            Element<T> prev = null;
            Element<T> save = null;


            for (int i = 0; i < Size; i++)
            {
                save = current!.Next;
                current.Next = prev;
                prev = current;
                current = save;
            }

            Head = prev;

        }

    }
}