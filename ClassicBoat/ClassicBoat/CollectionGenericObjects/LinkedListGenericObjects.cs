using System;
using System.Collections.Generic;

namespace ClassicBoat.CollectionGenericObjects;

// Параметризованный набор объектов на LinkedList<T>
public class LinkedListGenericObjects<T> : ICollectionGenericObjects<T> where T : class
{
    private readonly LinkedList<T> _collection;
    private int _maxCount = 100;

    public int CountObjects => _collection.Count;

    public int MaxCount
    {
        get => _maxCount;
        set
        {
            if (value > 0)
            {
                _maxCount = value;
                while (_collection.Count > _maxCount)
                {
                    _collection.RemoveLast();
                }
            }
        }
    }

    public CollectionType CollectionType => CollectionType.LinkedList;

    public LinkedListGenericObjects()
    {
        _collection = new LinkedList<T>();
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return null;

        var current = _collection.First;
        for (int i = 0; i < position; i++)
        {
            current = current?.Next;
        }
        return current is not null ? current.Value : null;
    }

    public bool InsertObject(T obj)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount) return false;

        _collection.AddLast(obj);
        return true;
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount) return false;
        if (position < 0) position = 0;

        if (position == 0)
        {
            _collection.AddFirst(obj);
            return true;
        }

        if (position >= _collection.Count)
        {
            _collection.AddLast(obj);
            return true;
        }

        var current = _collection.First;
        for (int i = 0; i < position - 1; i++)
        {
            current = current?.Next;
        }

        if (current is not null)
        {
            _collection.AddAfter(current, obj);
            return true;
        }

        return false;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return false;

        var current = _collection.First;
        for (int i = 0; i < position; i++)
        {
            current = current?.Next;
        }

        if (current is not null)
        {
            _collection.Remove(current);
            return true;
        }

        return false;
    }

    public IEnumerable<T> GetItems()
    {
        foreach (var item in _collection)
        {
            yield return item;
        }
    }
}