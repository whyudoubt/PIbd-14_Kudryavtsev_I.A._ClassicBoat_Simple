namespace ClassicBoat;

partial class FormBoat
{
    private System.ComponentModel.IContainer components = null;

    private PictureBox pictureBoxField;

    private Button buttonCreate;
    private Button buttonCreateImproved;
    private Button buttonCheckBorders;
    private Button buttonLeft;
    private Button buttonRight;
    private Button buttonUp;
    private Button buttonDown;
    private ComboBox comboBoxDestination;
    private Button buttonStep;
    private Label labelDestination;

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
        this.pictureBoxField = new PictureBox();

        this.buttonCreate = new Button();
        this.buttonCreateImproved = new Button();
        this.buttonCheckBorders = new Button();

        this.buttonLeft = new Button();
        this.buttonRight = new Button();
        this.buttonUp = new Button();
        this.buttonDown = new Button();

        this.comboBoxDestination = new ComboBox();
        this.buttonStep = new Button();
        this.labelDestination = new Label();

        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).BeginInit();
        this.SuspendLayout();

        // pictureBoxField
        this.pictureBoxField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.pictureBoxField.BackColor = Color.White;
        this.pictureBoxField.Location = new Point(0, 0);
        this.pictureBoxField.Name = "pictureBoxField";
        this.pictureBoxField.Size = new Size(800, 500);
        this.pictureBoxField.TabIndex = 0;
        this.pictureBoxField.TabStop = false;

        // buttonCreate (простая лодка)
        this.buttonCreate.Location = new Point(12, 415);
        this.buttonCreate.Name = "buttonCreate";
        this.buttonCreate.Size = new Size(100, 40);
        this.buttonCreate.TabIndex = 1;
        this.buttonCreate.Text = "Создать (простая)";
        this.buttonCreate.UseVisualStyleBackColor = true;
        this.buttonCreate.Click += new EventHandler(this.ButtonCreate_Click);

        // buttonCreateImproved
        this.buttonCreateImproved.Location = new Point(120, 415);
        this.buttonCreateImproved.Name = "buttonCreateImproved";
        this.buttonCreateImproved.Size = new Size(120, 40);
        this.buttonCreateImproved.TabIndex = 2;
        this.buttonCreateImproved.Text = "Создать (продвинутая)";
        this.buttonCreateImproved.UseVisualStyleBackColor = true;
        this.buttonCreateImproved.Click += new EventHandler(this.ButtonCreateImproved_Click);

        // buttonCheckBorders
        this.buttonCheckBorders.Location = new Point(12, 12);
        this.buttonCheckBorders.Name = "buttonCheckBorders";
        this.buttonCheckBorders.Size = new Size(140, 40);
        this.buttonCheckBorders.TabIndex = 3;
        this.buttonCheckBorders.Text = "Проверка границ";
        this.buttonCheckBorders.UseVisualStyleBackColor = true;
        this.buttonCheckBorders.Click += new EventHandler(this.ButtonCheckBorders_Click);

        // labelDestination
        this.labelDestination.Location = new Point(430, 15);
        this.labelDestination.Name = "labelDestination";
        this.labelDestination.Size = new Size(140, 25);
        this.labelDestination.Text = "Цель перемещения:";
        this.labelDestination.TextAlign = ContentAlignment.MiddleRight;

        // comboBoxDestination
        this.comboBoxDestination.Location = new Point(580, 15);
        this.comboBoxDestination.Name = "comboBoxDestination";
        this.comboBoxDestination.Size = new Size(140, 23);
        this.comboBoxDestination.TabIndex = 4;
        this.comboBoxDestination.DropDownStyle = ComboBoxStyle.DropDownList;
        this.comboBoxDestination.Enabled = false;
        this.comboBoxDestination.SelectedIndexChanged += new EventHandler(this.ComboBoxDestination_SelectedIndexChanged);

        // buttonStep
        this.buttonStep.Location = new Point(730, 12);
        this.buttonStep.Name = "buttonStep";
        this.buttonStep.Size = new Size(60, 30);
        this.buttonStep.TabIndex = 5;
        this.buttonStep.Text = "Шаг";
        this.buttonStep.UseVisualStyleBackColor = true;
        this.buttonStep.Click += new EventHandler(this.ButtonStep_Click);

        // buttonLeft
        this.buttonLeft.Location = new Point(680, 415);
        this.buttonLeft.Name = "buttonLeft";
        this.buttonLeft.Size = new Size(40, 40);
        this.buttonLeft.TabIndex = 6;
        this.buttonLeft.Text = "←";
        this.buttonLeft.UseVisualStyleBackColor = true;
        this.buttonLeft.Click += new EventHandler(this.ButtonMove_Click);

        // buttonRight
        this.buttonRight.Location = new Point(740, 415);
        this.buttonRight.Name = "buttonRight";
        this.buttonRight.Size = new Size(40, 40);
        this.buttonRight.TabIndex = 7;
        this.buttonRight.Text = "→";
        this.buttonRight.UseVisualStyleBackColor = true;
        this.buttonRight.Click += new EventHandler(this.ButtonMove_Click);

        // buttonUp
        this.buttonUp.Location = new Point(710, 375);
        this.buttonUp.Name = "buttonUp";
        this.buttonUp.Size = new Size(40, 40);
        this.buttonUp.TabIndex = 8;
        this.buttonUp.Text = "↑";
        this.buttonUp.UseVisualStyleBackColor = true;
        this.buttonUp.Click += new EventHandler(this.ButtonMove_Click);

        // buttonDown
        this.buttonDown.Location = new Point(710, 455);
        this.buttonDown.Name = "buttonDown";
        this.buttonDown.Size = new Size(40, 40);
        this.buttonDown.TabIndex = 9;
        this.buttonDown.Text = "↓";
        this.buttonDown.UseVisualStyleBackColor = true;
        this.buttonDown.Click += new EventHandler(this.ButtonMove_Click);

        // FormBoat
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 500);

        this.Controls.Add(this.buttonStep);
        this.Controls.Add(this.comboBoxDestination);
        this.Controls.Add(this.labelDestination);
        this.Controls.Add(this.buttonDown);
        this.Controls.Add(this.buttonUp);
        this.Controls.Add(this.buttonRight);
        this.Controls.Add(this.buttonLeft);
        this.Controls.Add(this.buttonCheckBorders);
        this.Controls.Add(this.buttonCreateImproved);
        this.Controls.Add(this.buttonCreate);
        this.Controls.Add(this.pictureBoxField);

        this.MinimumSize = new Size(600, 450);
        this.Name = "FormBoat";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Лабораторная работа №2";
        this.Load += new EventHandler(this.FormBoat_Load);

        // Кнопки поверх PictureBox
        this.buttonCreate.Parent = this.pictureBoxField;
        this.buttonCreateImproved.Parent = this.pictureBoxField;
        this.buttonCheckBorders.Parent = this.pictureBoxField;
        this.buttonLeft.Parent = this.pictureBoxField;
        this.buttonRight.Parent = this.pictureBoxField;
        this.buttonUp.Parent = this.pictureBoxField;
        this.buttonDown.Parent = this.pictureBoxField;
        this.labelDestination.Parent = this.pictureBoxField;
        this.comboBoxDestination.Parent = this.pictureBoxField;
        this.buttonStep.Parent = this.pictureBoxField;

        ((System.ComponentModel.ISupportInitialize)(this.pictureBoxField)).EndInit();
        this.ResumeLayout(false);
    }
}