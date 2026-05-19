using System;
using System.Collections.Generic;

namespace ClassicBoat.Drawings;

// Сравнение по типу, скорости, весу
public class DrawingBoatCompareByType : IComparer<DrawingBoat?>
{
    public int Compare(DrawingBoat? x, DrawingBoat? y)
    {
        if (x is null && y is null)
        {
            return 0;
        }
        if (x is null || x.CarSpeed is null || x.CarWeight is null)
        {
            return 1;
        }
        if (y is null || y.CarSpeed is null || y.CarWeight is null)
        {
            return -1;
        }

        // Сравнение по типу (простая или продвинутая)
        int typeCompare = x.GetType().Name.CompareTo(y.GetType().Name);
        if (typeCompare != 0)
        {
            return typeCompare;
        }

        // Сравнение по скорости
        int speedCompare = x.CarSpeed.Value.CompareTo(y.CarSpeed.Value);
        if (speedCompare != 0)
        {
            return speedCompare;
        }

        // Сравнение по весу
        return x.CarWeight.Value.CompareTo(y.CarWeight.Value);
    }
}