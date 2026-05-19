using System;

namespace ClassicBoat.Exceptions;

// Исключение, возникающее при переполнении коллекции
[Serializable]
public class CollectionOverflowException : Exception
{
    public CollectionOverflowException() : base() { }

    public CollectionOverflowException(string message) : base(message) { }

    public CollectionOverflowException(int maxCount) : base($"В коллекции превышено допустимое количество элементов: {maxCount}") { }

    public CollectionOverflowException(string message, Exception innerException) : base(message, innerException) { }
}