using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ClassicBoat;

public class DrawingBoat
{
    protected EntityBoat? _entityBoat;
    protected int? _startPosX;
    protected int? _startPosY;

    protected int _boatWidth = 100;
    protected int _boatHeight = 40;

    public int BoatWidth => _boatWidth;
    public int BoatHeight => _boatHeight;
    public int? PosX => _startPosX;
    public int? PosY => _startPosY;
    public double? BoatStep => _entityBoat?.Step;

    public DrawingBoat(int speed, double weight, Color bodyColor)
    {
        _entityBoat = new EntityBoat();
        _entityBoat.Init(speed, weight, bodyColor);
        _startPosX = null;
        _startPosY = null;
    }

    protected DrawingBoat(int boatWidth, int boatHeight)
    {
        _boatWidth = boatWidth;
        _boatHeight = boatHeight;
        _startPosX = null;
        _startPosY = null;
    }

    public void Init(int speed, double weight, Color bodyColor)
    {
        if (_entityBoat == null)
            _entityBoat = new EntityBoat();
        _entityBoat.Init(speed, weight, bodyColor);
        _startPosX = null;
        _startPosY = null;
    }

    public void SetPosition(int x, int y)
    {
        _startPosX = x;
        _startPosY = y;
    }

    public void MoveLeft()
    {
        if (_entityBoat is null || !_startPosX.HasValue) return;
        _startPosX -= (int)_entityBoat.Step;
    }

    public void MoveRight()
    {
        if (_entityBoat is null || !_startPosX.HasValue) return;
        _startPosX += (int)_entityBoat.Step;
    }

    public void MoveUp()
    {
        if (_entityBoat is null || !_startPosY.HasValue) return;
        _startPosY -= (int)_entityBoat.Step;
    }

    public void MoveDown()
    {
        if (_entityBoat is null || !_startPosY.HasValue) return;
        _startPosY += (int)_entityBoat.Step;
    }

    // Метод для изменения основного цвета у существующего объекта
    public void ChangeBodyColor(Color newColor)
    {
        _entityBoat?.ChangeBodyColor(newColor);
    }

    // Получить текущий цвет корпуса
    public Color GetBodyColor()
    {
        return _entityBoat?.BodyColor ?? Color.White;
    }

    public virtual void DrawTransport(Graphics g)
    {
        if (_entityBoat is null || !_startPosX.HasValue || !_startPosY.HasValue)
            return;

        int x = _startPosX.Value;
        int y = _startPosY.Value;

        using Pen blackPen = new Pen(Color.Black, 2);
        using Brush hullBrush = new SolidBrush(_entityBoat.BodyColor);

        Point[] boatPoints =
        {
            new Point(x, y),
            new Point(x + 70, y),
            new Point(x + _boatWidth, y + 20),
            new Point(x + 70, y + 40),
            new Point(x, y + 40)
        };

        g.FillPolygon(hullBrush, boatPoints);
        g.DrawPolygon(blackPen, boatPoints);

        int innerX = x + 8;
        int innerY = y + 6;
        int innerWidth = 55;
        int innerHeight = 28;
        int radius = 10;

        GraphicsPath path = new GraphicsPath();

        path.AddArc(innerX, innerY, radius, radius, 180, 90);
        path.AddArc(innerX + innerWidth - radius, innerY, radius, radius, 270, 90);
        path.AddArc(innerX + innerWidth - radius, innerY + innerHeight - radius, radius, radius, 0, 90);
        path.AddArc(innerX, innerY + innerHeight - radius, radius, radius, 90, 90);

        path.CloseFigure();

        g.DrawPath(blackPen, path);
    }
}