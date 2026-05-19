using System;
using ClassicBoat.Drawings;
using ClassicBoat.Helpers;

namespace ClassicBoat.CollectionGenericObjects;

// Класс-фабрика для создания экземпляра AbstractCompany
public static class AbstractCompanyFactory
{
    public static AbstractCompany? CreateAbstractCompany(string info, int pictureWidth, int pictureHeight)
    {
        string[] data = info.Split(SeparatorConstants.SeparatorForCompanyData);
        if (data.Length < 3)
        {
            return null;
        }

        ICollectionGenericObjects<DrawingBoat>? collection = Enum.Parse<CollectionType>(data[1]) switch
        {
            CollectionType.Massive => new MassiveGenericObjects<DrawingBoat>(),
            CollectionType.List => new ListGenericObjects<DrawingBoat>(),
            CollectionType.LinkedList => new LinkedListGenericObjects<DrawingBoat>(),
            _ => null,
        };

        if (collection is null)
        {
            return null;
        }

        AbstractCompany? company = data[0] switch
        {
            nameof(HarborCompany) => new HarborCompany(pictureWidth, pictureHeight, collection),
            _ => null,
        };

        if (company is null)
        {
            return null;
        }

        foreach (string elem in data[2].Split(SeparatorConstants.SeparatorForItems, StringSplitOptions.RemoveEmptyEntries))
        {
            DrawingBoat? boat = DrawingBoatFactory.CreateDrawingBoat(elem);
            if (boat is null)
            {
                continue;
            }
            if (!collection.InsertObject(boat))
            {
                break;
            }
        }

        return company;
    }
}