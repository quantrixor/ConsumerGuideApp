using ConsumerGuideApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.Entity;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsumerGuideApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ConsumerGuideDBEntities _context;

        public MainPage()
        {
            InitializeComponent();
            _context = new ConsumerGuideDBEntities();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCompanies();
            LoadServices();
        }

        private void LoadServices()
        {
            var services = _context.Services
                .Include("ServiceCategories")
                .ToList();

            ServicesDataGrid.ItemsSource = services;
        }


        private void LoadCompanies()
        {
            var companies = _context.Companies
                .Include("OwnershipTypes")
                .Include("Specializations")
                .ToList();

            CompaniesDataGrid.ItemsSource = companies;
        }

        private void btnSearchCompany_Click(object sender, RoutedEventArgs e)
        {
            var searchQuery = SearchBoxCompany.Text.ToLower();
            var companies = _context.Companies
                .Include("OwnershipTypes")
                .Include("Specializations")
                .Where(c => c.Name.ToLower().Contains(searchQuery) ||
                            c.Address.ToLower().Contains(searchQuery) ||
                            c.Phone.ToLower().Contains(searchQuery) ||
                            c.Grade.ToLower().Contains(searchQuery) ||
                            c.Specializations.Name.ToLower().Contains(searchQuery) ||
                            c.OwnershipTypes.Name.ToLower().Contains(searchQuery))
                .Select(c => new
                {
                    c.Name,
                    c.Address,
                    c.Phone,
                    c.Grade,
                    SpecializationName = c.Specializations.Name,
                    OwnershipTypeName = c.OwnershipTypes.Name,
                    c.WorkingHours,
                    c.WorkingDays
                })
                .ToList();

            CompaniesDataGrid.ItemsSource = companies;
        }

        private void btnUpdateCompany_Click(object sender, RoutedEventArgs e)
        {
            LoadCompanies();
        }

        private void AddCompany_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompanyManagePage());
        }

        private void EditCompany_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Companies)CompaniesDataGrid.SelectedItem;

            if (selectedItem != null)
            {
                NavigationService.Navigate(new CompanyManagePage(selectedItem));
            }
        }

        private void DeleteCompany_Click(object sender, RoutedEventArgs e)
        {
            var selectedCompany = (Companies)CompaniesDataGrid.SelectedItem;
            if (selectedCompany != null)
            {
                _context.Companies.Remove(selectedCompany);
                _context.SaveChanges();
                LoadCompanies();
            }
        }

        private void AddService_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ServiceManagePage());
        }

        private void EditService_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = (Services)ServicesDataGrid.SelectedItem;
            if (selectedService != null)
            {
                NavigationService.Navigate(new ServiceManagePage(selectedService));
            }
        }

        private void DeleteService_Click(object sender, RoutedEventArgs e)
        {
            var selectedService = (Services)ServicesDataGrid.SelectedItem;
            if (selectedService != null)
            {
                _context.Services.Remove(selectedService);
                _context.SaveChanges();
                LoadServices();
            }
        }
    }
}
