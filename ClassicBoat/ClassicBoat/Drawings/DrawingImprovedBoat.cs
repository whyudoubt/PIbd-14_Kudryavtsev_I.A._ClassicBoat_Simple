using System;
using System.Drawing;
using ClassicBoat.Entities;

namespace ClassicBoat.Drawings;

public class DrawingImprovedBoat : DrawingBoat
{
    public DrawingImprovedBoat(int speed, double weight, Color bodyColor,
        Color additionalColor, bool hasSail)
        : base(110, 40)
    {
        EntityImprovedBoat improvedBoat = new EntityImprovedBoat();
        improvedBoat.Init(speed, weight, bodyColor, additionalColor, hasSail);
        _entityBoat = improvedBoat;
        _startPosX = null;
        _startPosY = null;
    }

    // Метод для изменения дополнительного цвета у существующего объекта
    public void ChangeAdditionalColor(Color newColor)
    {
        if (_entityBoat is EntityImprovedBoat improvedBoat)
        {
            improvedBoat.ChangeAdditionalColor(newColor);
        }
    }

    // Получить текущий цвет паруса
    public Color GetAdditionalColor()
    {
        if (_entityBoat is EntityImprovedBoat improvedBoat)
        {
            return improvedBoat.AdditionalColor;
        }
        return Color.Gray;
    }

    // Получить наличие паруса
    public bool GetHasSail()
    {
        if (_entityBoat is EntityImprovedBoat improvedBoat)
        {
            return improvedBoat.HasSail;
        }
        return false;
    }

    public override void DrawTransport(Graphics g)
    {
        if (_entityBoat is null || _entityBoat is not EntityImprovedBoat improvedBoat ||
            !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        base.DrawTransport(g);

        using Pen blackPen = new Pen(Color.Black, 2);
        using Brush additionalBrush = new SolidBrush(improvedBoat.AdditionalColor);

        if (improvedBoat.HasSail)
        {
            Point[] sailPoints = {
                new Point(x + 50, y + 5),
                new Point(x + 75, y + 20),
                new Point(x + 50, y + 35),
                new Point(x + 25, y + 20)
            };
            g.FillPolygon(additionalBrush, sailPoints);
            g.DrawPolygon(blackPen, sailPoints);

            g.DrawLine(blackPen, x + 50, y + 5, x + 50, y + 35);
            g.DrawLine(blackPen, x + 25, y + 20, x + 75, y + 20);

            g.FillEllipse(Brushes.Brown, x + 47, y + 17, 6, 6);
        }
    }
}