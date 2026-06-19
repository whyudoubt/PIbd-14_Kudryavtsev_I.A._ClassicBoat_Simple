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

    // Конструктор формы, инициализирует компоненты и создает объект для работы с полем
    public FormBoat()
    {
        InitializeComponent();
        _canvas = new CanvasForBoat();
        _checkBordersState = DirectionType.None;
        _templateMovement = null;
    }

    // Событие загрузки формы, устанавливает размеры поля и заполняет выпадающий список целями перемещения
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

    // Отрисовка текущего состояния лодки на поле
    private void Draw()
    {
        var image = _canvas.DrawCanvas();
        if (image != null)
            pictureBoxField.Image = image;
    }

    // Создание простой лодки со случайными характеристиками
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

            this.Text = $"Лодка (простая) | Скорость: {speed} | Вес: {weight} | Шаг: {(int)boat.BoatStep}";
        }
        else
        {
            MessageBox.Show("Объект слишком большой для поля!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Создание продвинутой лодки с парусом, характеристики задаются случайно
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

            string sailStatus = hasSail ? "есть" : "нет";
            this.Text = $"Лодка (продвинутая) | Скорость: {speed} | Вес: {weight} | Шаг: {(int)boat.BoatStep} | Парус: {sailStatus}";
        }
        else
        {
            MessageBox.Show("Объект слишком большой для поля!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // Обработка нажатия кнопок управления (вверх, вниз, влево, вправо)
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

    // Проверка границ поля, лодка не должна выходить за пределы видимой области
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

    // Выбор цели перемещения из выпадающего списка
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

    // Выполнение одного шага перемещения к выбранной цели
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

    // Метод для получения лодки из внешнего источника (из гавани)
    public void SetDrawingBoat(DrawingBoat boat)
    {
        if (boat is null)
        {
            MessageBox.Show("Лодка не существует!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (pictureBoxField.Width > 0 && pictureBoxField.Height > 0)
        {
            _canvas.SetPictureSize(pictureBoxField.Width, pictureBoxField.Height);
        }

        Random random = new Random();

        if (boat.BoatWidth > pictureBoxField.Width || boat.BoatHeight > pictureBoxField.Height)
        {
            MessageBox.Show($"Лодка слишком большая для поля! Размеры лодки: {boat.BoatWidth}x{boat.BoatHeight}, поле: {pictureBoxField.Width}x{pictureBoxField.Height}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        boat.SetPosition(0, 0);

        if (_canvas.InsertBoat(boat))
        {
            int maxX = Math.Max(20, pictureBoxField.Width - boat.BoatWidth - 20);
            int maxY = Math.Max(20, pictureBoxField.Height - boat.BoatHeight - 20);
            int posX = random.Next(10, maxX);
            int posY = random.Next(10, maxY);

            _canvas.SetBoatPosition(posX, posY);
            comboBoxDestination.SelectedIndex = -1;
            _templateMovement = null;

            if (boat is DrawingImprovedBoat)
            {
                comboBoxDestination.Enabled = true;
                this.Text = $"Лодка (продвинутая, передана из гавани) | Шаг: {(int)boat.BoatStep}";
            }
            else
            {
                comboBoxDestination.Enabled = false;
                this.Text = $"Лодка (простая, передана из гавани) | Шаг: {(int)boat.BoatStep}";
            }

            Draw();

            MessageBox.Show($"Лодка успешно передана на тест-драйв!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Не удалось добавить лодку на поле!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}