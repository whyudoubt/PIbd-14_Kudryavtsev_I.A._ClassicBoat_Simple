using System;
using System.Drawing;
using ClassicBoat.Entities;
using ClassicBoat.Helpers;

namespace ClassicBoat.Drawings;

// Класс-фабрика для создания экземпляра DrawingBoat или DrawingImprovedBoat
public static class DrawingBoatFactory
{
    public static DrawingBoat? CreateDrawingBoat(string info)
    {
        string[] data = info.Split(SeparatorConstants.SeparatorForObject);
        if (data.Length == 0)
        {
            return null;
        }

        return data[0] switch
        {
            nameof(EntityBoat) => new DrawingBoat(Convert.ToInt32(data[1]),
                Convert.ToInt32(data[2]), Color.FromName(data[3])),
            nameof(EntityImprovedBoat) => new DrawingImprovedBoat(Convert.ToInt32(data[1]),
                Convert.ToInt32(data[2]), Color.FromName(data[3]),
                Color.FromName(data[4]), Convert.ToBoolean(data[5])),
            _ => null,
        };
    }
}