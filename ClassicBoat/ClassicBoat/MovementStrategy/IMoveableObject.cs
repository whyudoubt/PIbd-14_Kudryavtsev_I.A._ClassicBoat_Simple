using System.Drawing;

namespace ClassicBoat.MovementStrategy;

// Интерфейс для работы с перемещаемым объектом
public interface IMoveableObject
{
    ObjectCoordinates? ObjectCoordinates { get; }
    int ObjectStep { get; }
    void SetObjectPosition(int x, int y);
    void MoveObject(MovementDirection direction);
    void DrawObject(Graphics graphics);
}