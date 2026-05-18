using System.Drawing;
using ClassicBoat.Drawings;

namespace ClassicBoat.MovementStrategy;

// Адаптер для DrawingBoat
public class MoveableAdapterBoat : IMoveableObject
{
    private readonly DrawingBoat _boat;

    public MoveableAdapterBoat(DrawingBoat boat)
    {
        _boat = boat;
    }

    public ObjectCoordinates? ObjectCoordinates
    {
        get
        {
            if (_boat is null || !_boat.PosX.HasValue || !_boat.PosY.HasValue)
                return null;
            return new ObjectCoordinates(_boat.PosX.Value, _boat.PosY.Value,
                _boat.BoatWidth, _boat.BoatHeight);
        }
    }

    public int ObjectStep => (int)(_boat?.BoatStep ?? 5);

    public void MoveObject(MovementDirection direction)
    {
        switch (direction)
        {
            case MovementDirection.Left:
                _boat?.MoveLeft();
                break;
            case MovementDirection.Up:
                _boat?.MoveUp();
                break;
            case MovementDirection.Right:
                _boat?.MoveRight();
                break;
            case MovementDirection.Down:
                _boat?.MoveDown();
                break;
        }
    }

    public void SetObjectPosition(int x, int y) => _boat?.SetPosition(x, y);
    public void DrawObject(Graphics graphics) => _boat?.DrawTransport(graphics);
}