using System;
using System.Collections.Generic;
using System.IO;
using ClassicBoat.Drawings;
using ClassicBoat.Helpers;

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

        string companyName = $"{name}_{collectionType}";

        if (_companies.ContainsKey(companyName)) return;

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

    // Сохранение информации в файл
    public void SaveData(string filename)
    {
        if (_companies.Count == 0)
        {
            throw new InvalidOperationException("В хранилище отсутствуют коллекции для сохранения");
        }

        try
        {
            using StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine(nameof(StorageCompanies));

            foreach (KeyValuePair<string, AbstractCompany> pair in _companies)
            {
                string line = pair.Key + SeparatorConstants.SeparatorForKeyValue + pair.Value.GetDataAsString();
                writer.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            throw new IOException($"Ошибка при сохранении в файл {filename}: {ex.Message}", ex);
        }
    }

    // Загрузка информации из файла
    public void LoadData(string filename, int pictureWidth, int pictureHeight)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException($"Файл {filename} не найден");
        }

        try
        {
            using StreamReader reader = new StreamReader(filename);

            string? firstLine = reader.ReadLine();
            if (firstLine != nameof(StorageCompanies))
            {
                throw new InvalidDataException("Неверный формат файла: ожидаются данные StorageCompanies");
            }

            _companies.Clear();

            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] data = line.Split(SeparatorConstants.SeparatorForKeyValue);
                if (data.Length < 2)
                {
                    continue;
                }

                AbstractCompany? company = AbstractCompanyFactory.CreateAbstractCompany(data[1], pictureWidth, pictureHeight);
                if (company is null)
                {
                    continue;
                }

                _companies.Add(data[0], company);
            }
        }
        catch (Exception ex) when (ex is FileNotFoundException || ex is InvalidDataException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new IOException($"Ошибка при загрузке из файла {filename}: {ex.Message}", ex);
        }
    }
}