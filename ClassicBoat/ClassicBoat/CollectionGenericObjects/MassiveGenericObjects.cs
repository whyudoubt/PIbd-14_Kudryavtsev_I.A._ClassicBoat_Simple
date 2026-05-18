namespace ClassicBoat.CollectionGenericObjects;

// Параметризованный набор объектов на массиве
public class MassiveGenericObjects<T> : ICollectionGenericObjects<T> where T : class
{
    private T?[] _collection = Array.Empty<T?>();

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

    public MassiveGenericObjects()
    {
        _collection = Array.Empty<T?>();
    }

    public T? GetObject(int position)
    {
        if (position < 0 || position >= _collection.Length)
            return null;
        return _collection[position];
    }

    public bool InsertObject(T obj)
    {
        return InsertObject(obj, 0);
    }

    public bool InsertObject(T obj, int position)
    {
        if (obj is null) return false;

        if (position < 0) position = 0;

        // Расширяем массив если нужно
        if (position >= _collection.Length)
        {
            int newSize = position + 1;
            Array.Resize(ref _collection, newSize);
        }

        // Если место свободно - вставляем
        if (_collection[position] is null)
        {
            _collection[position] = obj;
            return true;
        }

        // Ищем свободное место справа
        for (int i = position + 1; i < _collection.Length; i++)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        // Ищем свободное место слева
        for (int i = position - 1; i >= 0; i--)
        {
            if (_collection[i] is null)
            {
                _collection[i] = obj;
                return true;
            }
        }

        // Нет свободных мест - расширяем массив
        int newSize2 = _collection.Length + 1;
        Array.Resize(ref _collection, newSize2);
        _collection[newSize2 - 1] = obj;
        return true;
    }

    public bool RemoveObject(int position)
    {
        if (position < 0 || position >= _collection.Length)
            return false;

        if (_collection[position] is null)
            return false;

        _collection[position] = null;
        return true;
    }
}