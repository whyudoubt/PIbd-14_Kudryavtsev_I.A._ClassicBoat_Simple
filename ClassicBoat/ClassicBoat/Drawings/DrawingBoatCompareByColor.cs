using System;
using System.Collections.Generic;

namespace ClassicBoat.Drawings;

// Сравнение по цвету, скорости, весу
public class DrawingBoatCompareByColor : IComparer<DrawingBoat?>
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

        // Сравнение по цвету (по имени цвета)
        int colorCompare = string.Compare(x.CarColor.Name, y.CarColor.Name, StringComparison.Ordinal);
        if (colorCompare != 0)
        {
            return colorCompare;
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