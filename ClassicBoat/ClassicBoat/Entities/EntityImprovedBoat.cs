using System.Drawing;

namespace ClassicBoat.Entities;

// Продвинутая лодка (только парус)
public class EntityImprovedBoat : EntityBoat
{
    public Color AdditionalColor { get; private set; }  // цвет паруса
    public bool HasSail { get; private set; }   // наличие паруса

    public void Init(int speed, double weight, Color bodyColor,
        Color additionalColor, bool hasSail)
    {
        base.Init(speed, weight, bodyColor);
        AdditionalColor = additionalColor;
        HasSail = hasSail;
    }

    // Метод для изменения дополнительного цвета (цвет паруса)
    public void ChangeAdditionalColor(Color newColor)
    {
        AdditionalColor = newColor;
    }
}