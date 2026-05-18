using System;
using System.Drawing;

namespace ClassicBoat;

public class CanvasForBoat
{
    private DrawingBoat? _drawingBoat;
    private int? _canvasWidth;
    private int? _canvasHeight;

    public void SetPictureSize(int width, int height)
    {
        _canvasWidth = width;
        _canvasHeight = height;
    }

    public bool InsertBoat(DrawingBoat boat)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue)
            return false;

        if (boat.BoatWidth > _canvasWidth.Value || boat.BoatHeight > _canvasHeight.Value)
            return false;

        _drawingBoat = boat;
        return true;
    }

    public void SetBoatPosition(int x, int y)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawingBoat is null)
            return;

        int finalX = x;
        int finalY = y;

        // Левая граница
        if (finalX < 0)
            finalX = 0;

        // Правая граница
        if (finalX + _drawingBoat.BoatWidth > _canvasWidth.Value)
            finalX = _canvasWidth.Value - _drawingBoat.BoatWidth;

        // Верхняя граница
        if (finalY < 0)
            finalY = 0;

        // Нижняя граница
        if (finalY + _drawingBoat.BoatHeight > _canvasHeight.Value)
            finalY = _canvasHeight.Value - _drawingBoat.BoatHeight;

        _drawingBoat.SetPosition(finalX, finalY);
    }

    public bool MoveTransport(DirectionType direction)
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue ||
            _drawingBoat is null || !_drawingBoat.PosX.HasValue ||
            !_drawingBoat.PosY.HasValue || !_drawingBoat.BoatStep.HasValue)
        {
            return false;
        }

        int step = (int)_drawingBoat.BoatStep.Value;
        if (step <= 0) step = 5;

        switch (direction)
        {
            case DirectionType.Left:
                if (_drawingBoat.PosX.Value - step >= 0)
                {
                    _drawingBoat.MoveLeft();
                    return true;
                }
                break;

            case DirectionType.Up:
                if (_drawingBoat.PosY.Value - step >= 0)
                {
                    _drawingBoat.MoveUp();
                    return true;
                }
                break;

            case DirectionType.Right:
                if (_drawingBoat.PosX.Value + step + _drawingBoat.BoatWidth <= _canvasWidth.Value)
                {
                    _drawingBoat.MoveRight();
                    return true;
                }
                break;

            case DirectionType.Down:
                if (_drawingBoat.PosY.Value + step + _drawingBoat.BoatHeight <= _canvasHeight.Value)
                {
                    _drawingBoat.MoveDown();
                    return true;
                }
                break;
        }
        return false;
    }

    public Bitmap? DrawCanvas()
    {
        if (!_canvasWidth.HasValue || !_canvasHeight.HasValue || _drawingBoat is null)
            return null;

        Bitmap bmp = new Bitmap(_canvasWidth.Value, _canvasHeight.Value);
        using (Graphics graphics = Graphics.FromImage(bmp))
        {
            graphics.Clear(Color.White);
            _drawingBoat.DrawTransport(graphics);
        }
        return bmp;
    }
}