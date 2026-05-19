using System.Collections.Generic;
using System.Linq;

namespace ClassicBoat.CollectionGenericObjects;

// Класс-хранилище компаний
public class StorageCompanies
{
    private readonly Dictionary<string, AbstractCompany> _companies;

    public List<string> StorageKeys => [.. _companies.Keys];

    public StorageCompanies()
    {
        _companies = new Dictionary<string, AbstractCompany>();
    }

    public void AddCompany(string name, CollectionType collectionType,
        int pictureWidth, int pictureHeight)
    {
        if (string.IsNullOrWhiteSpace(name)) return;

        // Генерируем уникальное имя
        string companyName = $"{name}_{collectionType}";

        // Проверяем, что записи с таким именем нет
        if (_companies.ContainsKey(companyName)) return;

        // Создаём компанию на основе типа коллекции
        ICollectionGenericObjects<DrawingBoat> collection = collectionType switch
        {
            CollectionType.Massive => new MassiveGenericObjects<DrawingBoat>(),
            CollectionType.List => new ListGenericObjects<DrawingBoat>(),
            CollectionType.LinkedList => new LinkedListGenericObjects<DrawingBoat>(),
            _ => new MassiveGenericObjects<DrawingBoat>()
        };

        var company = new HarborCompany(pictureWidth, pictureHeight, collection);
        _companies.Add(companyName, company);
    }

    public void DelCompany(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return;
        if (_companies.ContainsKey(name))
        {
            _companies.Remove(name);
        }
    }

    public AbstractCompany? GetCompany(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;

        _companies.TryGetValue(name, out var company);
        return company;
    }

    // Индексатор для доступа к компании по имени
    public AbstractCompany? this[string name]
    {
        get
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            _companies.TryGetValue(name, out var company);
            return company;
        }
    }
}