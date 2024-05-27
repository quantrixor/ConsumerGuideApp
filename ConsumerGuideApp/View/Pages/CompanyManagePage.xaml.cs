using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ConsumerGuideApp.Model;

namespace ConsumerGuideApp.View.Pages
{
    public partial class CompanyManagePage : Page
    {
        private ConsumerGuideDBEntities _context;
        private Companies _company;

        public CompanyManagePage(Companies company = null)
        {
            InitializeComponent();
            _context = new ConsumerGuideDBEntities();
            _company = company ?? new Companies();
            DataContext = _company;

            LoadOwnershipTypes();
            LoadSpecializations();
            LoadServices();

            if (company != null)
            {
                txtName.Text = company.Name;
                txtGrade.Text = company.Grade;
                txtAddress.Text = company.Address;
                txtPhone.Text = company.Phone;
                cbOwnershipType.SelectedValue = company.OwnershipTypeID;
                cbSpecialization.SelectedValue = company.SpecializationID;
                SetWorkingHours(company.WorkingHours);
                SetWorkingDays(company.WorkingDays);
                LoadCompanyServices(company.CompanyID); // Загрузка услуг компании
            }
        }
        private void LoadCompanyServices(int companyId)
        {
            var companyServices = _context.Companies
                                          .Where(c => c.CompanyID == companyId)
                                          .SelectMany(c => c.Services)
                                          .ToList();

            lbServices.ItemsSource = companyServices;
            lbServices.DisplayMemberPath = "Name";
            lbServices.SelectedValuePath = "ServiceID";
        }


        private void LoadOwnershipTypes()
        {
            var ownershipTypes = _context.OwnershipTypes.ToList();
            cbOwnershipType.ItemsSource = ownershipTypes;
            cbOwnershipType.DisplayMemberPath = "Name";
            cbOwnershipType.SelectedValuePath = "OwnershipTypeID";
        }

        private void LoadSpecializations()
        {
            var specializations = _context.Specializations.ToList();
            cbSpecialization.ItemsSource = specializations;
            cbSpecialization.DisplayMemberPath = "Name";
            cbSpecialization.SelectedValuePath = "SpecializationID";
        }
        private void LoadServices()
        {
            var services = _context.Services.ToList();
            lbServices.ItemsSource = services;
            lbServices.DisplayMemberPath = "Name";
            lbServices.SelectedValuePath = "ServiceID";
        }

        private void SetSelectedServices(int companyId)
        {
            var selectedServices = _context.Companies
                                           .Where(c => c.CompanyID == companyId)
                                           .SelectMany(c => c.Services)
                                           .Select(s => s.ServiceID)
                                           .ToList();

            foreach (var service in lbServices.Items)
            {
                var listBoxItem = lbServices.ItemContainerGenerator.ContainerFromItem(service) as ListBoxItem;
                if (listBoxItem != null)
                {
                    listBoxItem.IsSelected = selectedServices.Contains(((Services)service).ServiceID);
                }
            }
        }


        private void SetWorkingHours(string workingHours)
        {
            var parts = workingHours.Split('-');
            if (parts.Length == 2)
            {
                cbStartTime.Text = parts[0];
                cbEndTime.Text = parts[1];
            }
        }

        private void SetWorkingDays(string workingDays)
        {
            var days = workingDays.Split(',');
            foreach (var day in days)
            {
                switch (day.Trim())
                {
                    case "Пн": chkMonday.IsChecked = true; break;
                    case "Вт": chkTuesday.IsChecked = true; break;
                    case "Ср": chkWednesday.IsChecked = true; break;
                    case "Чт": chkThursday.IsChecked = true; break;
                    case "Пт": chkFriday.IsChecked = true; break;
                    case "Сб": chkSaturday.IsChecked = true; break;
                    case "Вс": chkSunday.IsChecked = true; break;
                }
            }
        }

        private string GetWorkingHours()
        {
            return $"{cbStartTime.Text}-{cbEndTime.Text}";
        }

        private string GetWorkingDays()
        {
            var days = new[]
            {
                chkMonday.IsChecked == true ? "Пн" : null,
                chkTuesday.IsChecked == true ? "Вт" : null,
                chkWednesday.IsChecked == true ? "Ср" : null,
                chkThursday.IsChecked == true ? "Чт" : null,
                chkFriday.IsChecked == true ? "Пт" : null,
                chkSaturday.IsChecked == true ? "Сб" : null,
                chkSunday.IsChecked == true ? "Вс" : null
            }.Where(d => d != null);

            return string.Join(", ", days);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                _company.Name = txtName.Text;
                _company.Grade = txtGrade.Text;
                _company.Address = txtAddress.Text;
                _company.Phone = txtPhone.Text;
                _company.OwnershipTypeID = (int)cbOwnershipType.SelectedValue;
                _company.SpecializationID = (int)cbSpecialization.SelectedValue;
                _company.WorkingHours = GetWorkingHours();
                _company.WorkingDays = GetWorkingDays();

                if (_company.CompanyID == 0)
                {
                    _context.Companies.Add(_company);
                }
                else
                {
                    var existingCompany = _context.Companies.FirstOrDefault(c => c.CompanyID == _company.CompanyID);
                    if (existingCompany != null)
                    {
                        existingCompany.Name = _company.Name;
                        existingCompany.Grade = _company.Grade;
                        existingCompany.Address = _company.Address;
                        existingCompany.Phone = _company.Phone;
                        existingCompany.OwnershipTypeID = _company.OwnershipTypeID;
                        existingCompany.SpecializationID = _company.SpecializationID;
                        existingCompany.WorkingHours = _company.WorkingHours;
                        existingCompany.WorkingDays = _company.WorkingDays;
                    }
                }

                _context.SaveChanges();

                // Обновить услуги компании
                var existingCompanyServices = _context.Companies
                                                      .Include("Services")
                                                      .FirstOrDefault(c => c.CompanyID == _company.CompanyID);

                if (existingCompanyServices != null)
                {
                    existingCompanyServices.Services.Clear();
                    foreach (Services selectedService in lbServices.SelectedItems)
                    {
                        existingCompanyServices.Services.Add(selectedService);
                    }
                }

                _context.SaveChanges();

                MessageBox.Show("Информация сохранена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                cbOwnershipType.SelectedValue == null ||
                cbSpecialization.SelectedValue == null ||
                string.IsNullOrWhiteSpace(cbStartTime.Text) ||
                string.IsNullOrWhiteSpace(cbEndTime.Text) ||
                !GetWorkingDays().Any())
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

        private void txtPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                return;
            }

            TextBox textBox = sender as TextBox;
            string text = textBox.Text + e.Text;

            if (text.Length == 1)
            {
                textBox.Text = "+7 (";
                textBox.SelectionStart = textBox.Text.Length;
            }
            else if (text.Length == 8)
            {
                textBox.Text += ") ";
                textBox.SelectionStart = textBox.Text.Length;
            }
            else if (text.Length == 13 || text.Length == 16)
            {
                textBox.Text += "-";
                textBox.SelectionStart = textBox.Text.Length;
            }

            if (textBox.Text.Length >= 18)
            {
                e.Handled = true;
            }
        }
    }
}
