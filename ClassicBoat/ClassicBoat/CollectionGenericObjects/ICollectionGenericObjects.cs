namespace ClassicBoat.CollectionGenericObjects;

// Интерфейс описания действий для набора хранимых объектов
public interface ICollectionGenericObjects<T> where T : class
{
    // Количество объектов в коллекции
    int CountObjects { get; }

    // Установка максимального количества элементов (и получение)
    int MaxCount { get; set; }

    // Получение объекта по позиции
    T? GetObject(int position);

    // Добавление объекта в коллекцию
    bool InsertObject(T obj);

    // Добавление объекта в коллекцию на конкретную позицию
    bool InsertObject(T obj, int position);

    // Удаление объекта из коллекции с конкретной позиции
    bool RemoveObject(int position);
}