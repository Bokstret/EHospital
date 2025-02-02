﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace eHospital
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(Exception exception)
        {
            InitializeComponent();

            exceptnText.Text = exception.Message;
        }

        public ErrorWindow(string exception)
        {
            InitializeComponent();

            exceptnText.Text = exception;
        }

        private void extBth_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Environment.Exit(1);
        }
    }
}
