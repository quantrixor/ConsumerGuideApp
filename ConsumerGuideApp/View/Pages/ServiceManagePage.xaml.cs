using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ConsumerGuideApp.Model; // Добавьте пространство имен для моделей данных

namespace ConsumerGuideApp.View.Pages
{
    public partial class ServiceManagePage : Page
    {
        private ConsumerGuideDBEntities _context;
        private Services _service;

        public ServiceManagePage(Services service = null)
        {
            InitializeComponent();
            _context = new ConsumerGuideDBEntities();
            _service = service ?? new Services();
            DataContext = _service;

            LoadServiceCategories();

            if (service != null)
            {
                txtServiceName.Text = service.Name;
                txtDescription.Text = service.Description;
                cbServiceCategory.SelectedValue = service.ServiceCategoryID;
            }
        }

        private void LoadServiceCategories()
        {
            var serviceCategories = _context.ServiceCategories.ToList();
            cbServiceCategory.ItemsSource = serviceCategories;
            cbServiceCategory.DisplayMemberPath = "Name";
            cbServiceCategory.SelectedValuePath = "ServiceCategoryID";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                _service.Name = txtServiceName.Text;
                _service.Description = txtDescription.Text;
                _service.ServiceCategoryID = (int)cbServiceCategory.SelectedValue;

                if (_service.ServiceID == 0)
                {
                    _context.Services.Add(_service);
                }
                else
                {
                    var existingService = _context.Services.FirstOrDefault(s => s.ServiceID == _service.ServiceID);
                    if (existingService != null)
                    {
                        existingService.Name = _service.Name;
                        existingService.Description = _service.Description;
                        existingService.ServiceCategoryID = _service.ServiceCategoryID;
                    }
                }

                _context.SaveChanges();
                MessageBox.Show("Информация сохранена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Вернуться на предыдущую страницу или обновить текущую
                NavigationService.GoBack();
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) ||
                string.IsNullOrWhiteSpace(txtDescription.Text) ||
                cbServiceCategory.SelectedValue == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля корректно.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Вернуться на предыдущую страницу или закрыть текущую
            NavigationService.GoBack();
        }
    }
}
