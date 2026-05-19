using System.Drawing;
using ClassicBoat.Drawings;

namespace ClassicBoat.CollectionGenericObjects;

// Гавань для лодок
public class HarborCompany : AbstractCompany
{
    public HarborCompany(int pictureWidth, int pictureHeight,
        ICollectionGenericObjects<DrawingBoat> collection)
        : base(pictureWidth, pictureHeight, 125, 55, collection)
    {
    }

    protected override string GetChildTypeName() => nameof(HarborCompany);

    protected override void DrawBackground(Graphics g)
    {
        g.Clear(Color.LightBlue);

        using Pen gridPen = new Pen(Color.Gray, 1);

        int cols = (int)Math.Floor((double)_pictureWidth / _placeSizeWidth);
        int rows = (int)Math.Floor((double)_pictureHeight / _placeSizeHeight);

        for (int row = 0; row <= rows; row++)
        {
            int y = row * _placeSizeHeight;
            g.DrawLine(gridPen, 0, y, _pictureWidth, y);
        }

        for (int col = 0; col <= cols; col++)
        {
            int x = col * _placeSizeWidth;
            g.DrawLine(gridPen, x, 0, x, _pictureHeight);
        }
    }

    protected override void DrawObjects(Graphics g)
    {
        for (int i = 0; i < _collection.MaxCount; i++)
        {
            DrawingBoat? boat = _collection.GetObject(i);

            if (boat is not null)
            {
                var (x, y) = GetPositionByIndex(i);

                int drawX = x + 2;
                int drawY = y + (_placeSizeHeight - boat.BoatHeight);

                boat.SetPosition(drawX, drawY);
                boat.DrawTransport(g);
            }
        }
    }
}