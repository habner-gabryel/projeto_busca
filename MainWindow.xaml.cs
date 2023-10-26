using projeto_busca.Views.Pages;
using System;
using System.Windows;

namespace projeto_busca
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btLargura_Click(object sender, EventArgs e)
        {
            try
            {
                MainFrame.NavigationService.Navigate(new LarguraPage());
            } catch (Exception ex)
            {
               ExceptionTextBox.Text = "Ocorreu uma exceção: " + ex.Message;
            }
        }

        private void btProfundidade_Click(object sender, EventArgs e)
        {
            try
            { 
                MainFrame.NavigationService.Navigate(new ProfundidadePage());
            } catch(Exception ex)
            {
                ExceptionTextBox.Text = "Ocorreu uma exceção: " + ex.Message;
            }
        }

        private void btGulosa_Click(object sender, EventArgs e)
        {
            try
            {
                MainFrame.NavigationService.Navigate(new GulosaPage());
            } catch (Exception ex) {
                ExceptionTextBox.Text = "Ocorreu uma exceção: " + ex.Message;
            }
        }

        private void btEstrela_Click(object sender, EventArgs e)
        {
            try
            {
            MainFrame.NavigationService.Navigate(new EstrelaPage());
            } catch ( Exception ex)
            {
                ExceptionTextBox.Text = "Ocorreu uma exceção: " + ex.Message;
            }
        }
    }
}
