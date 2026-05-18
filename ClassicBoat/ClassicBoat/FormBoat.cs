using System;
using System.Drawing;
using System.Windows.Forms;
using ClassicBoat.Drawings;
using ClassicBoat.MovementStrategy;

namespace ClassicBoat;

public partial class FormBoat : Form
{
    private readonly CanvasForBoat _canvas;
    private DirectionType _checkBordersState;
    private BaseTemplateMovement? _templateMovement;

    public FormBoat()
    {
        InitializeComponent();
        _canvas = new CanvasForBoat();
        _checkBordersState = DirectionType.None;
        _templateMovement = null;
    }

    private void FormBoat_Load(object sender, EventArgs e)
    {
        if (pictureBoxField.Width > 0 && pictureBoxField.Height > 0)
        {
            _canvas.SetPictureSize(pictureBoxField.Width, pictureBoxField.Height);
        }

        comboBoxDestination.Items.Clear();
        comboBoxDestination.Items.Add("К центру");
        comboBoxDestination.Items.Add("В правый нижний угол");
    }

    private void Draw()
    {
        var image = _canvas.DrawCanvas();
        if (image != null)
            pictureBoxField.Image = image;
    }

    // Создание простой лодки
    private void ButtonCreate_Click(object sender, EventArgs e)
    {
        Random random = new Random();

        int speed = random.Next(100, 300);
        double weight = random.Next(1000, 3000);
        Color bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        DrawingBoat boat = new DrawingBoat(speed, weight, bodyColor);

        if (_canvas.InsertBoat(boat))
        {
            _canvas.SetBoatPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxDestination.Enabled = false;
            comboBoxDestination.SelectedIndex = -1;
            _templateMovement = null;
            Draw();

            // Заголовок для простой лодки
            this.Text = $"Лодка (простая) | Скорость: {speed} | Вес: {weight} | Шаг: {(int)boat.BoatStep}";
        }
        else
        {
            MessageBox.Show("Объект слишком большой для поля!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Создание продвинутой лодки (с парусом)
    private void ButtonCreateImproved_Click(object sender, EventArgs e)
    {
        Random random = new Random();

        int speed = random.Next(100, 300);
        double weight = random.Next(1000, 3000);
        Color bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        Color additionalColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        bool hasSail = random.Next(2) == 1;

        DrawingImprovedBoat boat = new DrawingImprovedBoat(speed, weight, bodyColor, additionalColor, hasSail);

        if (_canvas.InsertBoat(boat))
        {
            _canvas.SetBoatPosition(random.Next(10, 100), random.Next(10, 100));
            comboBoxDestination.Enabled = true;
            comboBoxDestination.SelectedIndex = -1;
            _templateMovement = null;
            Draw();

            // Заголовок для продвинутой лодки с информацией о парусе
            string sailStatus = hasSail ? "есть" : "нет";
            this.Text = $"Лодка (продвинутая) | Скорость: {speed} | Вес: {weight} | Шаг: {(int)boat.BoatStep} | Парус: {sailStatus}";
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

    private void ComboBoxDestination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_canvas.DrawingBoat is null) return;

        _templateMovement = comboBoxDestination.SelectedIndex switch
        {
            0 => new MoveToCenter(),
            1 => new MoveToRightDownBorder(),
            _ => null
        };

        if (_templateMovement is null) return;

        _templateMovement.SetData(new MoveableAdapterBoat(_canvas.DrawingBoat),
            pictureBoxField.Width, pictureBoxField.Height);
        comboBoxDestination.Enabled = false;
    }

    private void ButtonStep_Click(object sender, EventArgs e)
    {
        if (_templateMovement is null) return;

        _templateMovement.MakeStep();

        if (_templateMovement.IsFinishReached)
        {
            comboBoxDestination.Enabled = true;
            comboBoxDestination.SelectedIndex = -1;
            MessageBox.Show("Цель достигнута!", "Уведомление",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        Draw();
    }
}