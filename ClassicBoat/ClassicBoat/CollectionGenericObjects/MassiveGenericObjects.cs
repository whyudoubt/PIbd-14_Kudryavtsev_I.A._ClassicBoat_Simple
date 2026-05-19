using System;
using System.Collections.Generic;
using ClassicBoat.Exceptions;

namespace ClassicBoat.CollectionGenericObjects;

// Параметризованный набор объектов на массиве
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T> where T : class
{
    private T?[] _collection;

    public int CountObjects
    {
        get
        {
            int count = 0;
            for (int i = 0; i < _collection.Length; i++)
            {
                if (_collection[i] is not null) count++;
            }
            return count;
        }
    }

    public int MaxCount
    {
        get => _collection.Length;
        set
        {
            if (value > 0)
            {
                Array.Resize(ref _collection, value);
            }
        }
    }

    public CollectionType CollectionType => CollectionType.Massive;

    public MassiveGenericObjects()
    {
        _collection = Array.Empty<T?>();
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Length)
        {
            throw new PositionOutOfCollectionException(position);
        }
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        return InsertObject(obj, 0);
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null) return false;

        if (position < 0)
        {
            throw new PositionOutOfCollectionException(position);
        }

        if (position >= _collection.Length)
        {
            int newSize = position + 1;
            Array.Resize(ref _collection, newSize);
        }

        if (_collection[position] is null)
        {
            _collection[position] = obj;
            return true;
        }

        for (int i = position + 1; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        for (int i = position - 1; i >= 0; i--)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        throw new CollectionOverflowException(_collection.Length);
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Length)
        {
            throw new PositionOutOfCollectionException(position);
        }

        if (_collection[position] is null)
        {
            throw new ObjectNotFoundException(position);
        }

        _collection[position] = null;
        return true;
    }

    public IEnumerable<T> GetItems()
    {
        for (int i = 0; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                continue;
            }
            yield return _collection[i]!;
        }
    }
}