namespace ClassicBoat;

partial class FormCompany
{
    private System.ComponentModel.IContainer components = null;

    // Элементы управления на форме
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
    private GroupBox groupBoxStorage;
    private TextBox textBoxCompanyName;
    private Label labelCompanyName;
    private RadioButton radioButtonMassive;
    private RadioButton radioButtonList;
    private RadioButton radioButtonLinkedList;
    private Button buttonCompanyAdd;
    private Button buttonCompanyDel;
    private ListBox listBoxCompanies;
    private Label labelCompanies;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    // Инициализация всех компонентов формы
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

        this.groupBoxStorage = new GroupBox();
        this.textBoxCompanyName = new TextBox();
        this.labelCompanyName = new Label();
        this.radioButtonMassive = new RadioButton();
        this.radioButtonList = new RadioButton();
        this.radioButtonLinkedList = new RadioButton();
        this.buttonCompanyAdd = new Button();
        this.buttonCompanyDel = new Button();
        this.listBoxCompanies = new ListBox();
        this.labelCompanies = new Label();

        this.groupBoxActions.SuspendLayout();
        this.groupBoxStorage.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBoxField).BeginInit();
        this.SuspendLayout();

        // Поле для отображения лодок в гавани
        this.pictureBoxField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.pictureBoxField.BackColor = Color.LightBlue;
        this.pictureBoxField.Location = new Point(12, 12);
        this.pictureBoxField.Name = "pictureBoxField";
        this.pictureBoxField.Size = new Size(700, 500);
        this.pictureBoxField.TabIndex = 0;
        this.pictureBoxField.TabStop = false;

        // Группа элементов управления гаванью
        this.groupBoxActions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.groupBoxActions.Controls.Add(this.labelPosition);
        this.groupBoxActions.Controls.Add(this.textBoxPosition);
        this.groupBoxActions.Controls.Add(this.buttonAddSimple);
        this.groupBoxActions.Controls.Add(this.buttonAddImproved);
        this.groupBoxActions.Controls.Add(this.buttonRemove);
        this.groupBoxActions.Controls.Add(this.buttonTransfer);
        this.groupBoxActions.Controls.Add(this.buttonRefresh);
        this.groupBoxActions.Location = new Point(720, 12);
        this.groupBoxActions.Name = "groupBoxActions";
        this.groupBoxActions.Size = new Size(200, 340);
        this.groupBoxActions.TabIndex = 1;
        this.groupBoxActions.TabStop = false;
        this.groupBoxActions.Text = "Управление гаванью";

        // Кнопка добавления простой лодки
        this.buttonAddSimple.Location = new Point(10, 25);
        this.buttonAddSimple.Name = "buttonAddSimple";
        this.buttonAddSimple.Size = new Size(180, 40);
        this.buttonAddSimple.Text = "Добавить простую лодку";
        this.buttonAddSimple.Click += new EventHandler(this.ButtonAddSimple_Click);

        // Кнопка добавления лодки с парусом
        this.buttonAddImproved.Location = new Point(10, 70);
        this.buttonAddImproved.Name = "buttonAddImproved";
        this.buttonAddImproved.Size = new Size(180, 40);
        this.buttonAddImproved.Text = "Добавить лодку с парусом";
        this.buttonAddImproved.Click += new EventHandler(this.ButtonAddImproved_Click);

        // Метка для поля ввода позиции удаления
        this.labelPosition.Location = new Point(10, 120);
        this.labelPosition.Name = "labelPosition";
        this.labelPosition.Size = new Size(180, 25);
        this.labelPosition.Text = "Номер позиции для удаления:";

        // Поле для ввода позиции удаления
        this.textBoxPosition.Location = new Point(10, 148);
        this.textBoxPosition.Name = "textBoxPosition";
        this.textBoxPosition.Size = new Size(180, 23);

        // Кнопка удаления лодки по позиции
        this.buttonRemove.Location = new Point(10, 180);
        this.buttonRemove.Name = "buttonRemove";
        this.buttonRemove.Size = new Size(180, 40);
        this.buttonRemove.Text = "Удалить лодку по позиции";
        this.buttonRemove.Click += new EventHandler(this.ButtonRemove_Click);

        // Кнопка передачи лодки на тест-драйв
        this.buttonTransfer.Location = new Point(10, 230);
        this.buttonTransfer.Name = "buttonTransfer";
        this.buttonTransfer.Size = new Size(180, 40);
        this.buttonTransfer.Text = "Передать лодку на тесты";
        this.buttonTransfer.Click += new EventHandler(this.ButtonTransfer_Click);

        // Кнопка обновления отображения
        this.buttonRefresh.Location = new Point(10, 280);
        this.buttonRefresh.Name = "buttonRefresh";
        this.buttonRefresh.Size = new Size(180, 40);
        this.buttonRefresh.Text = "Обновить отображение";
        this.buttonRefresh.Click += new EventHandler(this.ButtonRefresh_Click);

        // Группа элементов управления хранилищем компаний
        this.groupBoxStorage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        this.groupBoxStorage.Controls.Add(this.labelCompanyName);
        this.groupBoxStorage.Controls.Add(this.textBoxCompanyName);
        this.groupBoxStorage.Controls.Add(this.radioButtonMassive);
        this.groupBoxStorage.Controls.Add(this.radioButtonList);
        this.groupBoxStorage.Controls.Add(this.radioButtonLinkedList);
        this.groupBoxStorage.Controls.Add(this.buttonCompanyAdd);
        this.groupBoxStorage.Controls.Add(this.buttonCompanyDel);
        this.groupBoxStorage.Controls.Add(this.labelCompanies);
        this.groupBoxStorage.Controls.Add(this.listBoxCompanies);
        this.groupBoxStorage.Location = new Point(720, 360);
        this.groupBoxStorage.Name = "groupBoxStorage";
        this.groupBoxStorage.Size = new Size(200, 290);
        this.groupBoxStorage.TabIndex = 2;
        this.groupBoxStorage.TabStop = false;
        this.groupBoxStorage.Text = "Хранилище компаний";

        // Метка для поля ввода названия компании
        this.labelCompanyName.Location = new Point(10, 22);
        this.labelCompanyName.Name = "labelCompanyName";
        this.labelCompanyName.Size = new Size(180, 20);
        this.labelCompanyName.Text = "Название компании:";

        // Поле для ввода названия компании
        this.textBoxCompanyName.Location = new Point(10, 45);
        this.textBoxCompanyName.Name = "textBoxCompanyName";
        this.textBoxCompanyName.Size = new Size(180, 23);

        // Переключатель выбора коллекции на массиве
        this.radioButtonMassive.Location = new Point(10, 75);
        this.radioButtonMassive.Name = "radioButtonMassive";
        this.radioButtonMassive.Size = new Size(80, 20);
        this.radioButtonMassive.Text = "Массив";
        this.radioButtonMassive.Checked = true;

        // Переключатель выбора коллекции на списке
        this.radioButtonList.Location = new Point(90, 75);
        this.radioButtonList.Name = "radioButtonList";
        this.radioButtonList.Size = new Size(80, 20);
        this.radioButtonList.Text = "Список";

        // Переключатель выбора коллекции на связном списке
        this.radioButtonLinkedList.Location = new Point(10, 100);
        this.radioButtonLinkedList.Name = "radioButtonLinkedList";
        this.radioButtonLinkedList.Size = new Size(130, 20);
        this.radioButtonLinkedList.Text = "Связанный список";

        // Кнопка добавления компании в хранилище
        this.buttonCompanyAdd.Location = new Point(10, 128);
        this.buttonCompanyAdd.Name = "buttonCompanyAdd";
        this.buttonCompanyAdd.Size = new Size(180, 30);
        this.buttonCompanyAdd.Text = "Добавить компанию";
        this.buttonCompanyAdd.Click += new EventHandler(this.ButtonCompanyAdd_Click);

        // Кнопка удаления компании из хранилища
        this.buttonCompanyDel.Location = new Point(10, 163);
        this.buttonCompanyDel.Name = "buttonCompanyDel";
        this.buttonCompanyDel.Size = new Size(180, 30);
        this.buttonCompanyDel.Text = "Удалить компанию";
        this.buttonCompanyDel.Click += new EventHandler(this.ButtonCompanyDel_Click);

        // Метка для списка компаний
        this.labelCompanies.Location = new Point(10, 200);
        this.labelCompanies.Name = "labelCompanies";
        this.labelCompanies.Size = new Size(180, 20);
        this.labelCompanies.Text = "Список компаний:";

        // Список компаний для выбора
        this.listBoxCompanies.Location = new Point(10, 223);
        this.listBoxCompanies.Name = "listBoxCompanies";
        this.listBoxCompanies.Size = new Size(180, 40);
        this.listBoxCompanies.SelectedIndexChanged += new EventHandler(this.ListBoxCompanies_SelectedIndexChanged);

        // Статусная строка с количеством лодок
        this.labelStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        this.labelStatus.Location = new Point(720, 615);
        this.labelStatus.Name = "labelStatus";
        this.labelStatus.Size = new Size(200, 30);
        this.labelStatus.Text = "Лодок в гавани: 0";
        this.labelStatus.TextAlign = ContentAlignment.MiddleCenter;

        // Настройки главной формы
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(934, 660);
        this.Controls.Add(this.groupBoxStorage);
        this.Controls.Add(this.groupBoxActions);
        this.Controls.Add(this.labelStatus);
        this.Controls.Add(this.pictureBoxField);
        this.MinimumSize = new Size(900, 660);
        this.Name = "FormCompany";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Лабораторная работа №4";
        this.Resize += new EventHandler(this.FormCompany_Resize);

        this.groupBoxActions.ResumeLayout(false);
        this.groupBoxActions.PerformLayout();
        this.groupBoxStorage.ResumeLayout(false);
        this.groupBoxStorage.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)this.pictureBoxField).EndInit();
        this.ResumeLayout(false);
    }
}