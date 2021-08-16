using System;
using System.IO;
using System.Windows;


namespace SignUpWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            textBoxPassword.Password = "";
            textBoxUserName.Text = "";
        }

        private void buttonLogIn_Click(object sender, RoutedEventArgs e)
        {
            string srt = textBoxUserName.Text + " " + textBoxPassword.Password;
            if (textBoxPassword.Password.Length >= 8 || textBoxUserName.Text.Length > 0)
            {
                using (FileStream fs = new FileStream("data.txt", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(srt);
                }
            }
            else
            {
                 MessageBox.Show("Введіть логін і пароль");
            }
                        
            


            if(checkBoxRememberMe.IsChecked==true)
            {
                Properties.Settings.Default.UserName = textBoxUserName.Text;
                Properties.Settings.Default.Password = textBoxPassword.Password;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.UserName != string.Empty)
            {
                textBoxUserName.Text = Properties.Settings.Default.UserName;
                textBoxPassword.Password = Properties.Settings.Default.Password;
            }
        }
    }
}


        


