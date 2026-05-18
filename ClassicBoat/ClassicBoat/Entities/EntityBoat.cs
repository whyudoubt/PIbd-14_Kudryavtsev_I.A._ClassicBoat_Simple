using System.Drawing;

namespace ClassicBoat;

// Класс-сущность "Лодка / Парусник"
public class EntityBoat
{
    public int Speed { get; private set; }
    public double Weight { get; private set; }
    public Color BodyColor { get; private set; }

    // Шаг перемещения
    public double Step => Speed * 100 / Weight;

    public void Init(int speed, double weight, Color bodyColor)
    {
        Speed = speed;
        Weight = weight;
        BodyColor = bodyColor;
    }
}