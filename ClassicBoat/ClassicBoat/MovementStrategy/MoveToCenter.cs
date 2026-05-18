using System;

namespace ClassicBoat.MovementStrategy;

// Перемещение в центр
public class MoveToCenter : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return false;

        return Math.Abs(obj.ObjectMiddleHorizontal - FieldWidth / 2) <= GetStep() &&
               Math.Abs(obj.ObjectMiddleVertical - FieldHeight / 2) <= GetStep();
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return;

        int diffX = obj.ObjectMiddleHorizontal - FieldWidth / 2;
        if (Math.Abs(diffX) > GetStep())
        {
            if (diffX > 0) MoveLeft();
            else MoveRight();
        }

        int diffY = obj.ObjectMiddleVertical - FieldHeight / 2;
        if (Math.Abs(diffY) > GetStep())
        {
            if (diffY > 0) MoveUp();
            else MoveDown();
        }
    }
}