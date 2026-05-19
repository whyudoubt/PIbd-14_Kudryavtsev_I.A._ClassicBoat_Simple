using System;

namespace ClassicBoat.Exceptions;

// Исключение, возникающее при выходе за границы коллекции
[Serializable]
public class PositionOutOfCollectionException : Exception
{
    public PositionOutOfCollectionException() : base() { }

    public PositionOutOfCollectionException(string message) : base(message) { }

    public PositionOutOfCollectionException(int position) : base($"Выход за границы коллекции. Позиция: {position}") { }

    public PositionOutOfCollectionException(string message, Exception innerException) : base(message, innerException) { }
}