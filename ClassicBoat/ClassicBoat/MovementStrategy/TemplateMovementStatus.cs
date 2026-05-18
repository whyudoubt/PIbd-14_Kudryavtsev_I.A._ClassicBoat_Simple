namespace ClassicBoat.MovementStrategy;

// Статус выполнения операции перемещения
public enum TemplateMovementStatus
{
    NotInit,     // Все готово к началу
    InProgress,  // Выполняется
    Finish       // Завершено
}