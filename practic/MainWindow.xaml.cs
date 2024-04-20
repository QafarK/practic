using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _name;
        string _surname;
        string _gender;
        bool? _check;
        string _country;
        List<Person> people = new();
        public MainWindow()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            comboBox.Items.Add("Baku");
            comboBox.Items.Add("Sumqayit");
            comboBox.Items.Add("Ankara");
            comboBox.Items.Add("Istanbul");
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            TextBox? text = sender as TextBox;
            if (text!.Text is not null)
                _name = text.Text;
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            TextBox? text = sender as TextBox;
            if (text!.Text is not null)
                _surname = text.Text;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton? radioButton = sender as RadioButton;
            _gender = radioButton.Content.ToString();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox? check = sender as CheckBox;
            if (check!.IsChecked == true)
                _check = true;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox? check = sender as CheckBox;
            if (check!.IsChecked == false)
                _check = false;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox? combo = sender as ComboBox;
            _country = combo.SelectedItem.ToString();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Person person = new(_name, _surname, _gender, _check, _country);
            listBox.Items.Add(person);
        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listBox.SelectedItems.Count; i++)
            {
                listBox.Items.Remove(listBox.SelectedItems[i]);
            }
        }
    }

    class Person
    {
        string _name;
        string _surname;
        string _gender;
        bool? _check;
        string _country;

        public string Name { get; set; }
        public string Surname { get; set; }

        public Person() { }

        public Person(string name, string surname, string gender, bool? check, string country)
        {
            _name = name;
            _surname = surname;
            _gender = gender;
            _check = check;
            _country = country;
        }

        public override string ToString() => $"Name: {_name} Surname: {_surname} Gender: {_gender} Check:{_check} Country: {_country}";
    }
}