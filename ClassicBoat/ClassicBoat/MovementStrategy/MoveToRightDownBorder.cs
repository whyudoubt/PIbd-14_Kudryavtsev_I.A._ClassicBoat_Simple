using System;

namespace ClassicBoat.MovementStrategy;

// Перемещение в правый нижний угол
public class MoveToRightDownBorder : BaseTemplateMovement
{
    protected override bool IsTargetDestination()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return false;

        return Math.Abs(obj.RightBorder - FieldWidth) <= GetStep() &&
               Math.Abs(obj.DownBorder - FieldHeight) <= GetStep();
    }

    protected override void MoveToTarget()
    {
        ObjectCoordinates? obj = GetObjectCoordinates();
        if (obj is null) return;

        int diffX = obj.RightBorder - FieldWidth;
        if (Math.Abs(diffX) > GetStep())
        {
            if (diffX > 0) MoveLeft();
            else MoveRight();
        }

        int diffY = obj.DownBorder - FieldHeight;
        if (Math.Abs(diffY) > GetStep())
        {
            if (diffY > 0) MoveUp();
            else MoveDown();
        }
    }
}