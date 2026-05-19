using System.Windows;

namespace Edj20Tester
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            SendRequest("RELAY5_ON");
        }

        private void SendRequest(string command)
        {
            txtLog.AppendText("REQUEST -> " + command + "\n");

            string response = GenerateResponse(command);

            HandleResponse(response);
        }

        private string GenerateResponse(string command)
        {
            if (command == "RELAY5_ON")
            {
                return "TP2=110.5";
            }

            return "ERROR";
        }

        private void HandleResponse(string response)
        {
            txtLog.AppendText("RESPONSE <- " + response + "\n");

            if (response.Contains("110.5"))
            {
                txtLog.AppendText("VALIDATION -> PASS\n\n");
            }
            else
            {
                txtLog.AppendText("VALIDATION -> FAIL\n\n");
            }
        }
    }
}
