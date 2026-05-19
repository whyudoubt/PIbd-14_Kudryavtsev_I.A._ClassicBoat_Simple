using System;
using ClassicBoat.Helpers;

namespace ClassicBoat.CollectionGenericObjects;

// Класс, хранящий информацию по компании (используется как ключ словаря)
public class CompanyInfo : IEquatable<CompanyInfo>
{
    public string Name { get; init; }
    public CollectionType CollectionType { get; init; }
    public string Description { get; init; }

    public CompanyInfo(string name, CollectionType collectionType, string description)
    {
        Name = name;
        CollectionType = collectionType;
        Description = description;
    }

    // Создание объекта из строки
    public static CompanyInfo? CreateCompanyInfo(string info)
    {
        string[] data = info.Split(SeparatorConstants.SeparatorForCompanyData, StringSplitOptions.RemoveEmptyEntries);
        if (data.Length < 2)
        {
            return null;
        }
        return new CompanyInfo(data[0], Enum.Parse<CollectionType>(data[1]), data.Length > 2 ? data[2] : string.Empty);
    }

    public override string ToString()
    {
        string collectionTypeName = CollectionType switch
        {
            CollectionType.Massive => "массив",
            CollectionType.List => "список",
            CollectionType.LinkedList => "связный список",
            _ => CollectionType.ToString()
        };

        return $"{Name} - {collectionTypeName}";
    }

    // Сравнение по имени и типу коллекции
    public bool Equals(CompanyInfo? other)
    {
        if (other is null) return false;
        return Name == other.Name && CollectionType == other.CollectionType;
    }

    public override bool Equals(object? obj)
    {
        return obj is CompanyInfo info && Equals(info);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, CollectionType);
    }
}