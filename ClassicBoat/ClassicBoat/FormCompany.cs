using System;
using System.Drawing;
using System.Windows.Forms;
using ClassicBoat.CollectionGenericObjects;
using ClassicBoat.Drawings;
using ClassicBoat.Exceptions;
using Serilog;

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
        
        Log.Information("Приложение запущено");
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
            listBoxCompanies.Items.Add(key.ToString());
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
        
        Log.Information("Открыта форма создания лодки");
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

        try
        {
            if (_company + boat)
            {
                MessageBox.Show("Лодка добавлена в гавань!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDisplay();
                Log.Information("Добавлена лодка: {@Boat}", boat);
            }
        }
        catch (CollectionOverflowException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка переполнения",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Warning(ex, "Ошибка переполнения коллекции при добавлении лодки");
        }
        catch (PositionOutOfCollectionException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка позиции",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Warning(ex, "Ошибка позиции при добавлении лодки");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Не удалось добавить лодку: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Error(ex, "Неизвестная ошибка при добавлении лодки");
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
            try
            {
                if (_company - position)
                {
                    MessageBox.Show("Лодка удалена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDisplay();
                    Log.Information("Удалена лодка с позиции {Position}", position);
                }
            }
            catch (PositionOutOfCollectionException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка позиции",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning(ex, "Ошибка позиции при удалении лодки: позиция {Position}", position);
            }
            catch (ObjectNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Объект не найден",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning(ex, "Попытка удалить несуществующую лодку с позиции {Position}", position);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось удалить лодку: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Неизвестная ошибка при удалении лодки");
            }
        }
    }

    // Передача случайной лодки из текущей компании на тест-драйв (с клонированием)
    private void ButtonTransfer_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DrawingBoat? originalBoat = _company.GetRandomObject();

        if (originalBoat is null)
        {
            MessageBox.Show("В гавани нет лодок для передачи!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        // Клонирование объекта
        DrawingBoat? clonedBoat = originalBoat.Clone() as DrawingBoat;
        
        if (clonedBoat is null)
        {
            MessageBox.Show("Не удалось клонировать лодку!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        FormBoat formBoat = new FormBoat();
        formBoat.SetDrawingBoat(clonedBoat);
        formBoat.ShowDialog();

        Log.Information("Лодка клонирована и передана на тест-драйв");
        RefreshDisplay();
    }

    // Обновление отображения текущей компании
    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        RefreshDisplay();
        MessageBox.Show("Отображение обновлено!", "Информация",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        Log.Information("Отображение гавани обновлено");
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
        
        Log.Information("Добавлена компания {CompanyName} с типом коллекции {CollectionType}", 
            textBoxCompanyName.Text, collectionType);
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
            string companyName = listBoxCompanies.SelectedItem.ToString();
            _storageCompanies.DelCompany(companyName);
            RefreshCompanyList();

            if (_company is not null && listBoxCompanies.Items.Count == 0)
            {
                _company = null;
                RefreshDisplay();
            }

            MessageBox.Show("Компания удалена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            Log.Information("Удалена компания {CompanyName}", companyName);
        }
    }

    // Выбор компании из списка
    private void ListBoxCompanies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBoxCompanies.SelectedItem is null) return;

        string selectedItem = listBoxCompanies.SelectedItem.ToString();

        // Извлекаем имя компании (всё, что до " - ")
        string companyName = selectedItem.Split(new[] { " - " }, StringSplitOptions.None)[0];

        _company = _storageCompanies.GetCompany(companyName);

        if (_company is null)
        {
            MessageBox.Show($"Не удалось получить компанию! Имя: {companyName}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        RefreshDisplay();
        Log.Information("Выбрана компания {CompanyName}", companyName);
    }

    // Обработка нажатия "Сохранить"
    private void SaveMenuItem_Click(object sender, EventArgs e)
    {
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _storageCompanies.SaveData(saveFileDialog.FileName);
                MessageBox.Show("Сохранение прошло успешно!", "Результат", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.Information("Данные сохранены в файл {FileName}", saveFileDialog.FileName);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning(ex, "Ошибка при сохранении: нет данных для сохранения");
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка доступа к файлу: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Ошибка ввода-вывода при сохранении в файл {FileName}", saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Неизвестная ошибка при сохранении в файл {FileName}", saveFileDialog.FileName);
            }
        }
    }

    // Обработка нажатия "Загрузить"
    private void LoadMenuItem_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                _storageCompanies.LoadData(openFileDialog.FileName, 
                    pictureBoxField.Width, pictureBoxField.Height);
                MessageBox.Show("Загрузка прошла успешно!", "Результат", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCompanyList();
                _company = null;
                RefreshDisplay();
                Log.Information("Данные загружены из файла {FileName}", openFileDialog.FileName);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning(ex, "Файл не найден при загрузке: {FileName}", openFileDialog.FileName);
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка формата файла",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning(ex, "Неверный формат файла при загрузке: {FileName}", openFileDialog.FileName);
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка доступа к файлу: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Ошибка ввода-вывода при загрузке из файла {FileName}", openFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Error(ex, "Неизвестная ошибка при загрузке из файла {FileName}", openFileDialog.FileName);
            }
        }
    }

    // Сортировка по типу
    private void ButtonSortByType_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            _company.SortCollection(new DrawingBoatCompareByType());
            RefreshDisplay();
            Log.Information("Выполнена сортировка по типу");
            MessageBox.Show("Сортировка по типу выполнена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (NotSupportedException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Log.Warning(ex, "Сортировка недоступна для данного типа коллекции");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Error(ex, "Ошибка при сортировке по типу");
        }
    }

    // Сортировка по цвету
    private void ButtonSortByColor_Click(object sender, EventArgs e)
    {
        if (_company is null)
        {
            MessageBox.Show("Сначала выберите компанию!", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        
        try
        {
            _company.SortCollection(new DrawingBoatCompareByColor());
            RefreshDisplay();
            Log.Information("Выполнена сортировка по цвету");
            MessageBox.Show("Сортировка по цвету выполнена!", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (NotSupportedException ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Log.Warning(ex, "Сортировка недоступна для данного типа коллекции");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при сортировке: {ex.Message}", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Log.Error(ex, "Ошибка при сортировке по цвету");
        }
    }
}