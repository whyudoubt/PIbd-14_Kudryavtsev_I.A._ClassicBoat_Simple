using System;

namespace ClassicBoat.Exceptions;

// Исключение, возникающее когда по указанной позиции нет элемента
[Serializable]
public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException() : base() { }

    public ObjectNotFoundException(string message) : base(message) { }

    public ObjectNotFoundException(int position) : base($"Не найден объект по позиции {position}") { }

    public ObjectNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}