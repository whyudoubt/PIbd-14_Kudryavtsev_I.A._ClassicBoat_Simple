using System;
using System.Collections.Generic;

namespace ClassicBoat.CollectionGenericObjects;

// Параметризованный набор объектов на List<T>
public class ListGenericObjects<T> : ICollectionGenericObjects<T> where T : class
{
    private readonly List<T> _collection;
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
                // Если текущее количество превышает новый лимит, обрезаем
                while (_collection.Count > _maxCount)
                {
                    _collection.RemoveAt(_collection.Count - 1);
                }
            }
        }
    }

    public ListGenericObjects()
    {
        _collection = new List<T>();
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return null;
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount) return false;

        _collection.Add(obj);
        return true;
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount) return false;
        if (position < 0) position = 0;
        if (position > _collection.Count) position = _collection.Count;

        _collection.Insert(position, obj);
        return true;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
            return false;

        _collection.RemoveAt(position);
        return true;
    }
}