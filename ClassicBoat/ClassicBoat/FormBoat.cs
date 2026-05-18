using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassicBoat;

public partial class FormBoat : Form
{
    private readonly CanvasForBoat _canvas;
    private DirectionType _checkBordersState;

    public FormBoat()
    {
        InitializeComponent();
        _canvas = new CanvasForBoat();
        _checkBordersState = DirectionType.None;
    }

    private void FormBoat_Load(object sender, EventArgs e)
    {
        if (pictureBoxField.Width > 0 && pictureBoxField.Height > 0)
        {
            _canvas.SetPictureSize(pictureBoxField.Width, pictureBoxField.Height);
        }
    }

    private void Draw()
    {
        var image = _canvas.DrawCanvas();
        if (image != null)
            pictureBoxField.Image = image;
    }

    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        Random random = new Random();
        DrawingBoat boat = new DrawingBoat();

        int speed = random.Next(100, 300);
        double weight = random.Next(1000, 3000);
        Color color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        boat.Init(speed, weight, color);

        if (_canvas.InsertBoat(boat))
        {
            _canvas.SetBoatPosition(random.Next(10, 100), random.Next(10, 100));
            Draw();

            this.Text = $"Лодка | Скорость: {speed} | Вес: {weight} | Шаг: {(int)boat.BoatStep}";
        }
        else
        {
            MessageBox.Show("Объект слишком большой для поля!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ButtonMove_Click(object sender, EventArgs e)
    {
        string name = ((Button)sender)?.Name ?? string.Empty;
        DirectionType direction = DirectionType.None;

        switch (name)
        {
            case "buttonUp": direction = DirectionType.Up; break;
            case "buttonDown": direction = DirectionType.Down; break;
            case "buttonLeft": direction = DirectionType.Left; break;
            case "buttonRight": direction = DirectionType.Right; break;
        }

        if (_canvas.MoveTransport(direction))
        {
            Draw();
        }
    }

    private void ButtonCheckBorders_Click(object sender, EventArgs e)
    {
        Random random = new Random();

        switch (_checkBordersState)
        {
            case DirectionType.None:
            case DirectionType.Down:
                _canvas.SetBoatPosition(random.Next(10, 100) - 1000, random.Next(10, 100));
                _checkBordersState = DirectionType.Left;
                break;
            case DirectionType.Left:
                _canvas.SetBoatPosition(random.Next(10, 100), random.Next(10, 100) - 1000);
                _checkBordersState = DirectionType.Up;
                break;
            case DirectionType.Up:
                _canvas.SetBoatPosition(random.Next(10, 100) + pictureBoxField.Width, random.Next(10, 100));
                _checkBordersState = DirectionType.Right;
                break;
            case DirectionType.Right:
                _canvas.SetBoatPosition(random.Next(10, 100), random.Next(10, 100) + pictureBoxField.Height);
                _checkBordersState = DirectionType.Down;
                break;
        }
        Draw();
    }
}