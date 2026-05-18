using System;

namespace ClassicBoat.MovementStrategy;

// Шаблон стратегии перемещения
public abstract class BaseTemplateMovement
{
    private IMoveableObject? _moveableObject;
    private TemplateMovementStatus _state = TemplateMovementStatus.NotInit;

    protected int FieldWidth { get; private set; }
    protected int FieldHeight { get; private set; }

    public bool IsFinishReached => _state == TemplateMovementStatus.Finish;

    public void SetData(IMoveableObject moveableObject, int width, int height)
    {
        if (moveableObject is null)
        {
            _state = TemplateMovementStatus.NotInit;
            return;
        }
        _state = TemplateMovementStatus.InProgress;
        _moveableObject = moveableObject;
        FieldWidth = width;
        FieldHeight = height;
    }

    public void MakeStep()
    {
        if (_state != TemplateMovementStatus.InProgress) return;

        if (IsTargetDestination())
        {
            _state = TemplateMovementStatus.Finish;
            return;
        }
        MoveToTarget();
    }

    protected void MoveLeft() => MoveTo(MovementDirection.Left);
    protected void MoveRight() => MoveTo(MovementDirection.Right);
    protected void MoveUp() => MoveTo(MovementDirection.Up);
    protected void MoveDown() => MoveTo(MovementDirection.Down);

    protected ObjectCoordinates? GetObjectCoordinates() => _moveableObject?.ObjectCoordinates;
    protected int GetStep() => _moveableObject?.ObjectStep ?? 5;

    protected abstract void MoveToTarget();
    protected abstract bool IsTargetDestination();

    private void MoveTo(MovementDirection direction)
    {
        if (_state != TemplateMovementStatus.InProgress || _moveableObject is null) return;
        _moveableObject.MoveObject(direction);
    }
}