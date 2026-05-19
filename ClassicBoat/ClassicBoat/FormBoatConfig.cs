using System;
using System.Drawing;
using System.Windows.Forms;
using ClassicBoat.Drawings;
using ClassicBoat.Entities;

namespace ClassicBoat;

public partial class FormBoatConfig : Form
{
    private DrawingBoat? _currentBoat;
    public event Action<DrawingBoat>? BoatCreated;

    public FormBoatConfig()
    {
        InitializeComponent();
        SetupColorPanels();
        SetupCancelButton();
    }

    private void SetupColorPanels()
    {
        Color[] colors = {
            Color.Red, Color.Green, Color.Blue, Color.Yellow,
            Color.Orange, Color.Purple, Color.Brown, Color.Pink
        };

        Panel[] colorPanels = {
            panelColor1, panelColor2, panelColor3, panelColor4,
            panelColor5, panelColor6, panelColor7, panelColor8
        };

        for (int i = 0; i < colorPanels.Length && i < colors.Length; i++)
        {
            colorPanels[i].BackColor = colors[i];
            colorPanels[i].MouseDown += ColorPanel_MouseDown;
        }
    }

    private void SetupCancelButton()
    {
        buttonCancel.Click += (sender, e) => Close();
    }

    private void ColorPanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (sender is Panel panel)
        {
            panel.DoDragDrop(panel.BackColor, DragDropEffects.Copy);
        }
    }

    private void LabelType_MouseDown(object sender, MouseEventArgs e)
    {
        if (sender is Label label)
        {
            label.DoDragDrop(label.Name, DragDropEffects.Copy);
        }
    }

    private void PanelDisplay_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(typeof(string)) == true ||
            e.Data?.GetDataPresent(typeof(Color)) == true)
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void PanelDisplay_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data?.GetDataPresent(typeof(string)) == true)
        {
            string? labelName = e.Data?.GetData(typeof(string))?.ToString();

            int speed = (int)numericUpDownSpeed.Value;
            double weight = (double)numericUpDownWeight.Value;

            if (labelName == "labelSimpleBoat")
            {
                _currentBoat = new DrawingBoat(speed, weight, Color.White);
            }
            else if (labelName == "labelImprovedBoat")
            {
                bool hasSail = checkBoxHasSail.Checked;
                _currentBoat = new DrawingImprovedBoat(speed, weight, Color.White, Color.Gray, hasSail);
            }

            DrawCurrentBoat();
        }
    }

    private void LabelMainColor_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = e.Data?.GetDataPresent(typeof(Color)) == true ?
            DragDropEffects.Copy : DragDropEffects.None;
    }

    private void LabelMainColor_DragDrop(object sender, DragEventArgs e)
    {
        if (_currentBoat is null)
        {
            MessageBox.Show("Сначала выберите тип лодки!", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (e.Data?.GetDataPresent(typeof(Color)) == true)
        {
            Color newColor = (Color)e.Data.GetData(typeof(Color));
            _currentBoat.ChangeBodyColor(newColor);
            DrawCurrentBoat();
        }
    }

    private void LabelAdditionalColor_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = e.Data?.GetDataPresent(typeof(Color)) == true ?
            DragDropEffects.Copy : DragDropEffects.None;
    }

    private void LabelAdditionalColor_DragDrop(object sender, DragEventArgs e)
    {
        if (_currentBoat is null)
        {
            MessageBox.Show("Сначала выберите тип лодки!", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_currentBoat is not DrawingImprovedBoat improvedBoat)
        {
            MessageBox.Show("Дополнительный цвет можно задать только для лодки с парусом!", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (e.Data?.GetDataPresent(typeof(Color)) == true)
        {
            Color newColor = (Color)e.Data.GetData(typeof(Color));
            improvedBoat.ChangeAdditionalColor(newColor);
            DrawCurrentBoat();
        }
    }

    private void DrawCurrentBoat()
    {
        if (_currentBoat is null) return;

        Bitmap bitmap = new Bitmap(pictureBoxPreview.Width, pictureBoxPreview.Height);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.Clear(Color.LightGray);
            _currentBoat.SetPosition(15, 15);
            _currentBoat.DrawTransport(g);
        }
        pictureBoxPreview.Image = bitmap;
    }

    private void ButtonAdd_Click(object sender, EventArgs e)
    {
        if (_currentBoat is null)
        {
            MessageBox.Show("Сначала создайте лодку (выберите тип перетаскиванием)!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int speed = (int)numericUpDownSpeed.Value;
        double weight = (double)numericUpDownWeight.Value;

        if (_currentBoat is DrawingImprovedBoat improvedBoat)
        {
            Color bodyColor = improvedBoat.GetBodyColor();
            Color additionalColor = improvedBoat.GetAdditionalColor();
            bool hasSail = improvedBoat.GetHasSail();
            _currentBoat = new DrawingImprovedBoat(speed, weight, bodyColor, additionalColor, hasSail);
        }
        else if (_currentBoat is DrawingBoat simpleBoat)
        {
            Color bodyColor = simpleBoat.GetBodyColor();
            _currentBoat = new DrawingBoat(speed, weight, bodyColor);
        }

        BoatCreated?.Invoke(_currentBoat);
        Close();
    }

    private void NumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        if (_currentBoat is null) return;

        int speed = (int)numericUpDownSpeed.Value;
        double weight = (double)numericUpDownWeight.Value;

        if (_currentBoat is DrawingImprovedBoat improvedBoat)
        {
            Color bodyColor = improvedBoat.GetBodyColor();
            Color additionalColor = improvedBoat.GetAdditionalColor();
            bool hasSail = improvedBoat.GetHasSail();
            _currentBoat = new DrawingImprovedBoat(speed, weight, bodyColor, additionalColor, hasSail);
        }
        else if (_currentBoat is DrawingBoat simpleBoat)
        {
            Color bodyColor = simpleBoat.GetBodyColor();
            _currentBoat = new DrawingBoat(speed, weight, bodyColor);
        }

        DrawCurrentBoat();
    }

    private void CheckBoxHasSail_CheckedChanged(object sender, EventArgs e)
    {
        if (_currentBoat is DrawingImprovedBoat improvedBoat)
        {
            int speed = (int)numericUpDownSpeed.Value;
            double weight = (double)numericUpDownWeight.Value;
            Color bodyColor = improvedBoat.GetBodyColor();
            Color additionalColor = improvedBoat.GetAdditionalColor();
            bool hasSail = checkBoxHasSail.Checked;
            _currentBoat = new DrawingImprovedBoat(speed, weight, bodyColor, additionalColor, hasSail);
            DrawCurrentBoat();
        }
    }
}