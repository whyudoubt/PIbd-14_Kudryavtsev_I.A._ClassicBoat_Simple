using System;
using System.Drawing;
using System.Windows.Forms;
using ClassicBoat.CollectionGenericObjects;
using ClassicBoat.Drawings;

namespace ClassicBoat;

public partial class FormCompany : Form
{
    private readonly AbstractCompany _company;

    public FormCompany()
    {
        InitializeComponent();

        _company = new HarborCompany(pictureBoxField.Width, pictureBoxField.Height,
            new MassiveGenericObjects<DrawingBoat>());

        RefreshDisplay();
    }

    private void RefreshDisplay()
    {
        pictureBoxField.Image = _company.Show();
        UpdateStatusLabel();
    }

    private void UpdateStatusLabel()
    {
        labelStatus.Text = $"Лодок в гавани: {_company.GetCountObjects()}";
    }

    private void ButtonAddSimple_Click(object sender, EventArgs e)
    {
        Random random = new Random();

        ColorDialog colorDialog = new ColorDialog();
        Color bodyColor;

        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            bodyColor = colorDialog.Color;
        }
        else
        {
            bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        int speed = random.Next(100, 300);
        double weight = random.Next(1000, 3000);

        DrawingBoat boat = new DrawingBoat(speed, weight, bodyColor);

        if (_company + boat)
        {
            MessageBox.Show("Лодка добавлена в гавань!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDisplay();
        }
        else
        {
            MessageBox.Show("Не удалось добавить лодку!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ButtonAddImproved_Click(object sender, EventArgs e)
    {
        Random random = new Random();

        ColorDialog colorDialog1 = new ColorDialog();
        Color bodyColor;
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            bodyColor = colorDialog1.Color;
        }
        else
        {
            bodyColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        ColorDialog colorDialog2 = new ColorDialog();
        Color sailColor;
        if (colorDialog2.ShowDialog() == DialogResult.OK)
        {
            sailColor = colorDialog2.Color;
        }
        else
        {
            sailColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

        int speed = random.Next(100, 300);
        double weight = random.Next(1000, 3000);
        bool hasSail = true;

        DrawingImprovedBoat boat = new DrawingImprovedBoat(speed, weight, bodyColor, sailColor, hasSail);

        if (_company + boat)
        {
            MessageBox.Show("Продвинутая лодка добавлена в гавань!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshDisplay();
        }
        else
        {
            MessageBox.Show("Не удалось добавить лодку!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void ButtonRemove_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxPosition.Text))
        {
            MessageBox.Show("Введите номер позиции!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(textBoxPosition.Text, out int position))
        {
            MessageBox.Show("Введите корректное число!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Удалить лодку с позиции {position}?", "Подтверждение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            if (_company - position)
            {
                MessageBox.Show("Лодка удалена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDisplay();
            }
            else
            {
                MessageBox.Show("Не удалось удалить лодку! Неверная позиция.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void ButtonTransfer_Click(object sender, EventArgs e)
    {
        DrawingBoat? boat = _company.GetRandomObject();

        if (boat is null)
        {
            MessageBox.Show("В гавани нет лодок для передачи!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FormBoat formBoat = new FormBoat();
        formBoat.SetDrawingBoat(boat);
        formBoat.ShowDialog();

        RefreshDisplay();
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        RefreshDisplay();
        MessageBox.Show("Отображение обновлено!", "Информация",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void FormCompany_Resize(object sender, EventArgs e)
    {
        // Можно обновить отображение при изменении размера
        RefreshDisplay();
    }
}