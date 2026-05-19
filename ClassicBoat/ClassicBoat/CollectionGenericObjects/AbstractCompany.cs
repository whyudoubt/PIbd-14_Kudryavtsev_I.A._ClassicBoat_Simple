using System;
using System.Collections.Generic;
using System.Drawing;
using ClassicBoat.Drawings;
using ClassicBoat.Helpers;

namespace ClassicBoat.CollectionGenericObjects;

// Абстракция компании (Гавань для лодок)
public abstract class AbstractCompany
{
    protected readonly int _placeSizeWidth;
    protected readonly int _placeSizeHeight;
    protected readonly int _pictureWidth;
    protected readonly int _pictureHeight;
    protected ICollectionGenericObjects<DrawingBoat> _collection;

    public int GetCountObjects() => _collection.CountObjects;

    protected AbstractCompany(int pictureWidth, int pictureHeight,
        int placeSizeWidth, int placeSizeHeight,
        ICollectionGenericObjects<DrawingBoat> collection)
    {
        _pictureWidth = pictureWidth;
        _pictureHeight = pictureHeight;
        _placeSizeWidth = placeSizeWidth;
        _placeSizeHeight = placeSizeHeight;
        _collection = collection;

        int maxCount = CalcMaxCount();
        _collection.MaxCount = maxCount;
    }

    public static bool operator +(AbstractCompany company, DrawingBoat boat)
    {
        return company._collection.InsertObject(boat);
    }

    public static bool operator -(AbstractCompany company, int position)
    {
        return company._collection.RemoveObject(position);
    }

    public DrawingBoat? GetRandomObject()
    {
        Random random = new Random();
        int maxCount = _collection.CountObjects;
        if (maxCount == 0) return null;

        var indices = new List<int>();
        for (int i = 0; i < _collection.MaxCount; i++)
        {
            if (_collection.GetObject(i) is not null)
                indices.Add(i);
        }

        if (indices.Count == 0) return null;

        int randomIndex = indices[random.Next(indices.Count)];
        return _collection.GetObject(randomIndex);
    }

    public Bitmap? Show()
    {
        Bitmap bitmap = new Bitmap(_pictureWidth, _pictureHeight);
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            DrawBackground(graphics);
            DrawObjects(graphics);
        }
        return bitmap;
    }

    protected abstract void DrawBackground(Graphics g);
    protected abstract void DrawObjects(Graphics g);

    private int CalcMaxCount()
    {
        int cols = (int)Math.Floor((double)_pictureWidth / _placeSizeWidth);
        int rows = (int)Math.Floor((double)_pictureHeight / _placeSizeHeight);
        return cols * rows;
    }

    protected (int x, int y) GetPositionByIndex(int index)
    {
        int cols = (int)Math.Floor((double)_pictureWidth / _placeSizeWidth);
        int row = index / cols;
        int col = index % cols;

        int x = col * _placeSizeWidth;
        int y = row * _placeSizeHeight;

        return (x, y);
    }

    // Получение данных в виде строки для сохранения
    public string GetDataAsString()
    {
        List<string> items = [];
        foreach (DrawingBoat item in _collection.GetItems())
        {
            if (item is null)
            {
                continue;
            }
            items.Add(item.ToString() ?? string.Empty);
        }

        List<string> data = [GetChildTypeName(), _collection.CollectionType.ToString(),
            string.Join(SeparatorConstants.SeparatorForItems, items)];
        return string.Join(SeparatorConstants.SeparatorForCompanyData, data);
    }

    // Получение имени типа класса-наследника
    protected abstract string GetChildTypeName();
}