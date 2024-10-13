using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace MyAvaloniaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnSubmitClicked(object sender, RoutedEventArgs e)
        {
            // Get values from the form
            var firstName = txtFirstName.Text;
            var middleName = txtMiddleName.Text;
            var lastName = txtLastName.Text;
            var ageText = txtAge.Text;
            var dob = dpDob.SelectedDate;
            var country = (cmbCountry.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Validate inputs
            var validationMessage = ValidateInputs(firstName, middleName, lastName, ageText, dob, country);

            if (string.IsNullOrEmpty(validationMessage))
            {
                lblValidationMessage.Text = "Form submitted successfully!";
            }
            else
            {
                lblValidationMessage.Text = validationMessage;
            }
        }

        private string ValidateInputs(string firstName, string middleName, string lastName, string ageText, DateTimeOffset? dob, string country)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                return "First name is required.";
            if (string.IsNullOrWhiteSpace(lastName))
                return "Last name is required.";
            if (!int.TryParse(ageText, out int age) || age < 0)
                return "Age must be a positive number.";
            if (dob == null)
                return "Date of birth is required.";
            if (string.IsNullOrWhiteSpace(country))
                return "Country is required.";

            return null; // No validation errors
        }
    }
}
