﻿using System.Windows;

using BusinessObjects;
using Services;

namespace WpfApp1
{
    /// <summary> Interaction logic for LoginWindow.xaml </summary>
    public partial class LoginWindow : Window
    {
        private readonly IAccountService iAccountService;

        public LoginWindow()
        {
            InitializeComponent();
            iAccountService = new AccountService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            AccountMember account = iAccountService.GetAccountById(txtUser.Text);

            if (account != null && account.MemberPassword.Equals(txtPass.Password) && account.MemberRole == 1)
            {
                this.Hide();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("You are not permission!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
