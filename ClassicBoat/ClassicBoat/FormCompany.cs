using System;
using System.Drawing;
using System.Windows.Forms;
using ClassicBoat.CollectionGenericObjects;
using ClassicBoat.Drawings;

namespace ClassicBoat;

public partial class FormCompany : Form
{
    private AbstractCompany? _company;
    private readonly StorageCompanies _storageCompanies;

    // Конструктор формы, инициализирует хранилище компаний
    public FormCompany()
    {
        InitializeComponent();
        _storageCompanies = new StorageCompanies();
        RefreshDisplay();
        RefreshCompanyList();
    }

    // Обновление отображения текущей компании
    private void RefreshDisplay()
    {
        if (_company is not null)
        {
            pictureBoxField.Image = _company.Show();
            UpdateStatusLabel();
        }
        else
        {
            pictureBoxField.Image = null;
            labelStatus.Text = "Лодок в гавани: 0 (компания не выбрана)";
        }
    }

    // Обновление текста статуса с количеством лодок
    private void UpdateStatusLabel()
    {
        if (_company is not null)
        {
            labelStatus.Text = $"Лодок в гавани: {_company.GetCountObjects()}";
        }
    }

    // Обновление списка компаний в ListBox
    private void RefreshCompanyList()
    {
        listBoxCompanies.Items.Clear();
        foreach (var key in _storageCompanies.StorageKeys)
        {
            listBoxCompanies.Items.Add(key);
        }
    }

    // Кнопка добавления лодки (открывает форму конфигурации)
    private void ButtonAddBoat_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FormBoatConfig configForm = new FormBoatConfig();
        configForm.BoatCreated += OnBoatCreated;
        configForm.Show();
    }

    // Обработчик события создания лодки из формы конфигурации
    private void OnBoatCreated(DrawingBoat boat)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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

    // Удаление лодки из текущей компании по указанной позиции
    private void ButtonRemove_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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

    // Передача случайной лодки из текущей компании на тест-драйв
    private void ButtonTransfer_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

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

    // Обновление отображения текущей компании
    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        RefreshDisplay();
        MessageBox.Show("Отображение обновлено!", "Информация",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // Обработка изменения размера формы
    private void FormCompany_Resize(object sender, EventArgs e)
    {
        RefreshDisplay();
    }

    // Добавление новой компании в хранилище
    private void ButtonCompanyAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxCompanyName.Text))
        {
            MessageBox.Show("Введите название компании!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        CollectionType collectionType = CollectionType.None;
        if (radioButtonMassive.Checked) collectionType = CollectionType.Massive;
        else if (radioButtonList.Checked) collectionType = CollectionType.List;
        else if (radioButtonLinkedList.Checked) collectionType = CollectionType.LinkedList;

        _storageCompanies.AddCompany(textBoxCompanyName.Text, collectionType,
            pictureBoxField.Width, pictureBoxField.Height);

        RefreshCompanyList();
        textBoxCompanyName.Clear();

        MessageBox.Show("Компания добавлена в хранилище!", "Успех",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    // Удаление компании из хранилища
    private void ButtonCompanyDel_Click(object sender, EventArgs e)
    {
        if (listBoxCompanies.SelectedItem is null)
        {
            MessageBox.Show("Выберите компанию для удаления!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (MessageBox.Show($"Удалить компанию \"{listBoxCompanies.SelectedItem}\"?", "Подтверждение",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            _storageCompanies.DelCompany(listBoxCompanies.SelectedItem.ToString());
            RefreshCompanyList();

            if (_company is not null && listBoxCompanies.Items.Count == 0)
            {
                _company = null;
                RefreshDisplay();
            }

            MessageBox.Show("Компания удалена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Выбор компании из списка
    private void ListBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxCompanies.SelectedItem is null) return;

        string companyName = listBoxCompanies.SelectedItem.ToString();
        _company = _storageCompanies[companyName];

        if (_company is null)
        {
            MessageBox.Show("Не удалось получить компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        RefreshDisplay();
    }
}