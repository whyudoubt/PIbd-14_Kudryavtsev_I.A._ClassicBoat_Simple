using System;
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

    // Переопределение метода получения строк с данными
    public override string[] GetStringRepresentation()
    {
        string[] baseData = base.GetStringRepresentation();
        return [nameof(EntityImprovedBoat), baseData[1], baseData[2], baseData[3],
                AdditionalColor.Name, HasSail.ToString()];
    }

    // Поверхностное клонирование
    public new object Clone()
    {
        return MemberwiseClone();
    }
}