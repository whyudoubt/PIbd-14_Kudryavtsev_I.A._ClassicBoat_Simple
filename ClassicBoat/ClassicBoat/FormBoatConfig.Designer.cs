namespace ClassicBoat;

partial class FormBoatConfig
{
    private System.ComponentModel.IContainer components = null;

    // Элементы управления для параметров
    private GroupBox groupBoxParameters;
    private Label labelSpeed;
    private NumericUpDown numericUpDownSpeed;
    private Label labelWeight;
    private NumericUpDown numericUpDownWeight;
    private CheckBox checkBoxHasSail;

    // Элементы для выбора типа
    private GroupBox groupBoxType;
    private Label labelSimpleBoat;
    private Label labelImprovedBoat;

    // Панель для отображения лодки
    private Panel panelDisplay;
    private PictureBox pictureBoxPreview;

    // Элементы для выбора цвета
    private GroupBox groupBoxColors;
    private Panel panelColor1;
    private Panel panelColor2;
    private Panel panelColor3;
    private Panel panelColor4;
    private Panel panelColor5;
    private Panel panelColor6;
    private Panel panelColor7;
    private Panel panelColor8;
    private Label labelMainColor;
    private Label labelAdditionalColor;

    // Кнопки
    private Button buttonAdd;
    private Button buttonCancel;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        // Создание элементов
        this.groupBoxParameters = new GroupBox();
        this.labelSpeed = new Label();
        this.numericUpDownSpeed = new NumericUpDown();
        this.labelWeight = new Label();
        this.numericUpDownWeight = new NumericUpDown();
        this.checkBoxHasSail = new CheckBox();

        this.groupBoxType = new GroupBox();
        this.labelSimpleBoat = new Label();
        this.labelImprovedBoat = new Label();

        this.panelDisplay = new Panel();
        this.pictureBoxPreview = new PictureBox();

        this.groupBoxColors = new GroupBox();
        this.panelColor1 = new Panel();
        this.panelColor2 = new Panel();
        this.panelColor3 = new Panel();
        this.panelColor4 = new Panel();
        this.panelColor5 = new Panel();
        this.panelColor6 = new Panel();
        this.panelColor7 = new Panel();
        this.panelColor8 = new Panel();
        this.labelMainColor = new Label();
        this.labelAdditionalColor = new Label();

        this.buttonAdd = new Button();
        this.buttonCancel = new Button();

        // Подписка на события
        this.numericUpDownSpeed.ValueChanged += this.NumericUpDown_ValueChanged;
        this.numericUpDownWeight.ValueChanged += this.NumericUpDown_ValueChanged;
        this.checkBoxHasSail.CheckedChanged += this.CheckBoxHasSail_CheckedChanged;
        this.buttonAdd.Click += this.ButtonAdd_Click;
        this.buttonCancel.Click += (s, e) => this.Close();

        this.labelSimpleBoat.MouseDown += this.LabelType_MouseDown;
        this.labelImprovedBoat.MouseDown += this.LabelType_MouseDown;

        this.panelDisplay.AllowDrop = true;
        this.panelDisplay.DragEnter += this.PanelDisplay_DragEnter;
        this.panelDisplay.DragDrop += this.PanelDisplay_DragDrop;

        this.labelMainColor.AllowDrop = true;
        this.labelMainColor.DragEnter += this.LabelMainColor_DragEnter;
        this.labelMainColor.DragDrop += this.LabelMainColor_DragDrop;

        this.labelAdditionalColor.AllowDrop = true;
        this.labelAdditionalColor.DragEnter += this.LabelAdditionalColor_DragEnter;
        this.labelAdditionalColor.DragDrop += this.LabelAdditionalColor_DragDrop;

        // Настройка цветовых панелей
        this.panelColor1.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor2.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor3.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor4.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor5.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor6.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor7.MouseDown += this.ColorPanel_MouseDown;
        this.panelColor8.MouseDown += this.ColorPanel_MouseDown;

        // Установка цветов панелей
        this.panelColor1.BackColor = Color.Red;
        this.panelColor2.BackColor = Color.Green;
        this.panelColor3.BackColor = Color.Blue;
        this.panelColor4.BackColor = Color.Yellow;
        this.panelColor5.BackColor = Color.Orange;
        this.panelColor6.BackColor = Color.Purple;
        this.panelColor7.BackColor = Color.Brown;
        this.panelColor8.BackColor = Color.Pink;

        // groupBoxParameters
        this.groupBoxParameters.Location = new Point(12, 12);
        this.groupBoxParameters.Size = new Size(200, 130);
        this.groupBoxParameters.Text = "Параметры лодки";

        this.labelSpeed.Location = new Point(10, 25);
        this.labelSpeed.Size = new Size(60, 25);
        this.labelSpeed.Text = "Скорость:";

        this.numericUpDownSpeed.Location = new Point(80, 25);
        this.numericUpDownSpeed.Size = new Size(100, 23);
        this.numericUpDownSpeed.Minimum = 100;
        this.numericUpDownSpeed.Maximum = 1000;
        this.numericUpDownSpeed.Value = 200;

        this.labelWeight.Location = new Point(10, 55);
        this.labelWeight.Size = new Size(60, 25);
        this.labelWeight.Text = "Вес:";

        this.numericUpDownWeight.Location = new Point(80, 55);
        this.numericUpDownWeight.Size = new Size(100, 23);
        this.numericUpDownWeight.Minimum = 1000;
        this.numericUpDownWeight.Maximum = 5000;
        this.numericUpDownWeight.Value = 2000;

        this.checkBoxHasSail.Location = new Point(10, 85);
        this.checkBoxHasSail.Size = new Size(100, 25);
        this.checkBoxHasSail.Text = "Есть парус";

        this.groupBoxParameters.Controls.Add(this.labelSpeed);
        this.groupBoxParameters.Controls.Add(this.numericUpDownSpeed);
        this.groupBoxParameters.Controls.Add(this.labelWeight);
        this.groupBoxParameters.Controls.Add(this.numericUpDownWeight);
        this.groupBoxParameters.Controls.Add(this.checkBoxHasSail);

        // groupBoxType
        this.groupBoxType.Location = new Point(12, 150);
        this.groupBoxType.Size = new Size(200, 70);
        this.groupBoxType.Text = "Выбор типа (перетаскиванием)";

        this.labelSimpleBoat.BorderStyle = BorderStyle.FixedSingle;
        this.labelSimpleBoat.Location = new Point(10, 25);
        this.labelSimpleBoat.Size = new Size(90, 30);
        this.labelSimpleBoat.Text = "Простая";
        this.labelSimpleBoat.TextAlign = ContentAlignment.MiddleCenter;
        this.labelSimpleBoat.Name = "labelSimpleBoat";

        this.labelImprovedBoat.BorderStyle = BorderStyle.FixedSingle;
        this.labelImprovedBoat.Location = new Point(100, 25);
        this.labelImprovedBoat.Size = new Size(90, 30);
        this.labelImprovedBoat.Text = "Продвинутая";
        this.labelImprovedBoat.TextAlign = ContentAlignment.MiddleCenter;
        this.labelImprovedBoat.Name = "labelImprovedBoat";

        this.groupBoxType.Controls.Add(this.labelSimpleBoat);
        this.groupBoxType.Controls.Add(this.labelImprovedBoat);

        // panelDisplay
        this.panelDisplay.Location = new Point(220, 12);
        this.panelDisplay.Size = new Size(300, 200);
        this.panelDisplay.BackColor = Color.LightGray;

        this.pictureBoxPreview.Dock = DockStyle.Fill;
        this.pictureBoxPreview.BackColor = Color.LightGray;

        this.panelDisplay.Controls.Add(this.pictureBoxPreview);

        // groupBoxColors
        this.groupBoxColors.Location = new Point(220, 220);
        this.groupBoxColors.Size = new Size(300, 150);
        this.groupBoxColors.Text = "Выбор цвета (перетаскиванием)";

        // Цветовые панели (первый ряд)
        this.panelColor1.Location = new Point(10, 25);
        this.panelColor1.Size = new Size(30, 30);
        this.panelColor1.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor2.Location = new Point(50, 25);
        this.panelColor2.Size = new Size(30, 30);
        this.panelColor2.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor3.Location = new Point(90, 25);
        this.panelColor3.Size = new Size(30, 30);
        this.panelColor3.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor4.Location = new Point(130, 25);
        this.panelColor4.Size = new Size(30, 30);
        this.panelColor4.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor5.Location = new Point(170, 25);
        this.panelColor5.Size = new Size(30, 30);
        this.panelColor5.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor6.Location = new Point(210, 25);
        this.panelColor6.Size = new Size(30, 30);
        this.panelColor6.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor7.Location = new Point(250, 25);
        this.panelColor7.Size = new Size(30, 30);
        this.panelColor7.BorderStyle = BorderStyle.FixedSingle;

        this.panelColor8.Location = new Point(10, 65);
        this.panelColor8.Size = new Size(30, 30);
        this.panelColor8.BorderStyle = BorderStyle.FixedSingle;

        // Метки для цветов
        this.labelMainColor.BorderStyle = BorderStyle.FixedSingle;
        this.labelMainColor.Location = new Point(50, 70);
        this.labelMainColor.Size = new Size(100, 30);
        this.labelMainColor.Text = "Основной цвет";
        this.labelMainColor.TextAlign = ContentAlignment.MiddleCenter;

        this.labelAdditionalColor.BorderStyle = BorderStyle.FixedSingle;
        this.labelAdditionalColor.Location = new Point(160, 70);
        this.labelAdditionalColor.Size = new Size(100, 30);
        this.labelAdditionalColor.Text = "Цвет паруса";
        this.labelAdditionalColor.TextAlign = ContentAlignment.MiddleCenter;

        this.groupBoxColors.Controls.Add(this.panelColor1);
        this.groupBoxColors.Controls.Add(this.panelColor2);
        this.groupBoxColors.Controls.Add(this.panelColor3);
        this.groupBoxColors.Controls.Add(this.panelColor4);
        this.groupBoxColors.Controls.Add(this.panelColor5);
        this.groupBoxColors.Controls.Add(this.panelColor6);
        this.groupBoxColors.Controls.Add(this.panelColor7);
        this.groupBoxColors.Controls.Add(this.panelColor8);
        this.groupBoxColors.Controls.Add(this.labelMainColor);
        this.groupBoxColors.Controls.Add(this.labelAdditionalColor);

        // Кнопки
        this.buttonAdd.Location = new Point(220, 380);
        this.buttonAdd.Size = new Size(140, 40);
        this.buttonAdd.Text = "Добавить";

        this.buttonCancel.Location = new Point(380, 380);
        this.buttonCancel.Size = new Size(140, 40);
        this.buttonCancel.Text = "Отмена";

        // FormBoatConfig
        this.ClientSize = new Size(534, 440);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonAdd);
        this.Controls.Add(this.groupBoxColors);
        this.Controls.Add(this.panelDisplay);
        this.Controls.Add(this.groupBoxType);
        this.Controls.Add(this.groupBoxParameters);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FormBoatConfig";
        this.StartPosition = FormStartPosition.CenterParent;
        this.Text = "Создание новой лодки";

        this.ResumeLayout(false);
    }
}