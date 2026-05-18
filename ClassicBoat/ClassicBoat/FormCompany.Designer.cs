namespace ClassicBoat;

partial class FormCompany
{
    private System.ComponentModel.IContainer components = null;
    private PictureBox pictureBoxField;
    private Button buttonAddSimple;
    private Button buttonAddImproved;
    private Button buttonRemove;
    private Button buttonTransfer;
    private Button buttonRefresh;
    private TextBox textBoxPosition;
    private Label labelPosition;
    private Label labelStatus;
    private GroupBox groupBoxActions;

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
        this.buttonAddSimple = new Button();
        this.buttonAddImproved = new Button();
        this.buttonRemove = new Button();
        this.buttonTransfer = new Button();
        this.buttonRefresh = new Button();
        this.textBoxPosition = new TextBox();
        this.labelPosition = new Label();
        this.labelStatus = new Label();
        this.groupBoxActions = new GroupBox();

        this.groupBoxActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBoxField).BeginInit();
        this.SuspendLayout();

        // pictureBoxField
        this.pictureBoxField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.pictureBoxField.BackColor = Color.LightBlue;
        this.pictureBoxField.Location = new Point(12, 12);
        this.pictureBoxField.Name = "pictureBoxField";
        this.pictureBoxField.Size = new Size(800, 500);
        this.pictureBoxField.TabIndex = 0;
        this.pictureBoxField.TabStop = false;

        // groupBoxActions
        this.groupBoxActions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
        this.groupBoxActions.Controls.Add(this.labelPosition);
        this.groupBoxActions.Controls.Add(this.textBoxPosition);
        this.groupBoxActions.Controls.Add(this.buttonAddSimple);
        this.groupBoxActions.Controls.Add(this.buttonAddImproved);
        this.groupBoxActions.Controls.Add(this.buttonRemove);
        this.groupBoxActions.Controls.Add(this.buttonTransfer);
        this.groupBoxActions.Controls.Add(this.buttonRefresh);
        this.groupBoxActions.Location = new Point(820, 12);
        this.groupBoxActions.Name = "groupBoxActions";
        this.groupBoxActions.Size = new Size(200, 500);
        this.groupBoxActions.TabIndex = 1;
        this.groupBoxActions.TabStop = false;
        this.groupBoxActions.Text = "Управление гаванью";

        // buttonAddSimple
        this.buttonAddSimple.Location = new Point(10, 30);
        this.buttonAddSimple.Name = "buttonAddSimple";
        this.buttonAddSimple.Size = new Size(180, 40);
        this.buttonAddSimple.TabIndex = 0;
        this.buttonAddSimple.Text = "Добавить простую лодку";
        this.buttonAddSimple.UseVisualStyleBackColor = true;
        this.buttonAddSimple.Click += new EventHandler(this.ButtonAddSimple_Click);

        // buttonAddImproved
        this.buttonAddImproved.Location = new Point(10, 80);
        this.buttonAddImproved.Name = "buttonAddImproved";
        this.buttonAddImproved.Size = new Size(180, 40);
        this.buttonAddImproved.TabIndex = 1;
        this.buttonAddImproved.Text = "Добавить лодку с парусом";
        this.buttonAddImproved.UseVisualStyleBackColor = true;
        this.buttonAddImproved.Click += new EventHandler(this.ButtonAddImproved_Click);

        // labelPosition
        this.labelPosition.Location = new Point(10, 135);
        this.labelPosition.Name = "labelPosition";
        this.labelPosition.Size = new Size(180, 25);
        this.labelPosition.Text = "Номер позиции для удаления:";
        this.labelPosition.TextAlign = ContentAlignment.MiddleLeft;

        // textBoxPosition
        this.textBoxPosition.Location = new Point(10, 165);
        this.textBoxPosition.Name = "textBoxPosition";
        this.textBoxPosition.Size = new Size(180, 23);
        this.textBoxPosition.TabIndex = 2;

        // buttonRemove
        this.buttonRemove.Location = new Point(10, 200);
        this.buttonRemove.Name = "buttonRemove";
        this.buttonRemove.Size = new Size(180, 40);
        this.buttonRemove.TabIndex = 3;
        this.buttonRemove.Text = "Удалить лодку по позиции";
        this.buttonRemove.UseVisualStyleBackColor = true;
        this.buttonRemove.Click += new EventHandler(this.ButtonRemove_Click);

        // buttonTransfer
        this.buttonTransfer.Location = new Point(10, 260);
        this.buttonTransfer.Name = "buttonTransfer";
        this.buttonTransfer.Size = new Size(180, 40);
        this.buttonTransfer.TabIndex = 4;
        this.buttonTransfer.Text = "Передать лодку на тесты";
        this.buttonTransfer.UseVisualStyleBackColor = true;
        this.buttonTransfer.Click += new EventHandler(this.ButtonTransfer_Click);

        // buttonRefresh
        this.buttonRefresh.Location = new Point(10, 320);
        this.buttonRefresh.Name = "buttonRefresh";
        this.buttonRefresh.Size = new Size(180, 40);
        this.buttonRefresh.TabIndex = 5;
        this.buttonRefresh.Text = "Обновить отображение";
        this.buttonRefresh.UseVisualStyleBackColor = true;
        this.buttonRefresh.Click += new EventHandler(this.ButtonRefresh_Click);

        // labelStatus
        this.labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.labelStatus.Location = new Point(820, 520);
        this.labelStatus.Name = "labelStatus";
        this.labelStatus.Size = new Size(200, 30);
        this.labelStatus.Text = "Лодок в гавани: 0";
        this.labelStatus.TextAlign = ContentAlignment.MiddleCenter;

        // FormCompany
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1034, 561);
        this.Controls.Add(this.labelStatus);
        this.Controls.Add(this.groupBoxActions);
        this.Controls.Add(this.pictureBoxField);
        this.MinimumSize = new Size(900, 600);
        this.Name = "FormCompany";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Лабораторная работа №3";
        this.Resize += new EventHandler(this.FormCompany_Resize);

        this.groupBoxActions.ResumeLayout(false);
        this.groupBoxActions.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBoxField).EndInit();
        this.ResumeLayout(false);
    }
}