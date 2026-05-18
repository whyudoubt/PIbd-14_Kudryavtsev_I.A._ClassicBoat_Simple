using System;
using System.Drawing;
using ClassicBoat.Entities;

namespace ClassicBoat.Drawings;

// Продвинутая лодка (только парус)
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

    public override void DrawTransport(Graphics g)
    {
        if (_entityBoat is null || _entityBoat is not EntityImprovedBoat improvedBoat ||
            !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        // Рисуем базовую часть лодки
        base.DrawTransport(g);

        using Pen blackPen = new Pen(Color.Black, 2);
        using Brush additionalBrush = new SolidBrush(improvedBoat.AdditionalColor);

        // ===== ПАРУС =====
        if (improvedBoat.HasSail)
        {
            // Парус в виде ромба
            Point[] sailPoints = {
            new Point(x + 50, y + 5),   // верхняя точка
            new Point(x + 75, y + 20),  // правая точка
            new Point(x + 50, y + 35),  // нижняя точка
            new Point(x + 25, y + 20)   // левая точка
        };
            g.FillPolygon(additionalBrush, sailPoints);
            g.DrawPolygon(blackPen, sailPoints);

            // Линии паруса (складки)
            g.DrawLine(blackPen, x + 50, y + 5, x + 50, y + 35);   // вертикаль
            g.DrawLine(blackPen, x + 25, y + 20, x + 75, y + 20); // горизонталь

            // Мачта (точка в центре)
            g.FillEllipse(Brushes.Brown, x + 47, y + 17, 6, 6);
        }
    }
}