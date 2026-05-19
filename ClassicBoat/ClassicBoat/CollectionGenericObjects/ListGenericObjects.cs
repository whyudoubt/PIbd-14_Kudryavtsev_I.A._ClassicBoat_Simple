using System;
using System.Collections.Generic;
using ClassicBoat.Exceptions;

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
                while (_collection.Count > _maxCount)
                {
                    _collection.RemoveAt(_collection.Count - 1);
                }
            }
        }
    }

    public CollectionType CollectionType => CollectionType.List;

    public ListGenericObjects()
    {
        _collection = new List<T>();
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
        {
            throw new PositionOutOfCollectionException(position);
        }
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount)
        {
            throw new CollectionOverflowException(_maxCount);
        }

        _collection.Add(obj);
        return true;
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null) return false;
        if (_collection.Count >= _maxCount)
        {
            throw new CollectionOverflowException(_maxCount);
        }
        if (position < 0)
        {
            throw new PositionOutOfCollectionException(position);
        }
        if (position > _collection.Count)
        {
            throw new PositionOutOfCollectionException(position);
        }

        _collection.Insert(position, obj);
        return true;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Count)
        {
            throw new PositionOutOfCollectionException(position);
        }

        _collection.RemoveAt(position);
        return true;
    }

    public IEnumerable<T> GetItems()
    {
        foreach (var item in _collection)
        {
            yield return item;
        }
    }

    public void CollectionSort(IComparer<T?> comparer)
    {
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }
        _collection.Sort(comparer);
    }
}