using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PowerShellRunner.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _selectedScript;
        private string _selectedTenant;
        private ObservableCollection<ParameterModel> _parameters;
        private string _executionOutput;

        public string SelectedScript
        {
            get => _selectedScript;
            set
            {
                _selectedScript = value;
                OnPropertyChanged();
                LoadParameters();
            }
        }

        public string SelectedTenant
        {
            get => _selectedTenant;
            set
            {
                _selectedTenant = value;
                OnPropertyChanged();
                LoadTenantConfig();
            }
        }

        public ObservableCollection<ParameterModel> Parameters
        {
            get => _parameters;
            set
            {
                _parameters = value;
                OnPropertyChanged();
            }
        }

        public string ExecutionOutput
        {
            get => _executionOutput;
            set
            {
                _executionOutput = value;
                OnPropertyChanged();
            }
        }

        public ICommand ExecuteScriptCommand { get; }

        public MainWindowViewModel()
        {
            Parameters = new ObservableCollection<ParameterModel>();
            ExecuteScriptCommand = new RelayCommand(ExecuteScript);
        }

        private void LoadParameters()
        {
            // Load parameters from the selected script's param block
            // This is a placeholder for actual implementation
        }

        private void LoadTenantConfig()
        {
            // Load tenant configuration and map parameters if map.json exists
            // This is a placeholder for actual implementation
        }

        private void ExecuteScript()
        {
            // Execute the PowerShell script and capture output
            var scriptPath = Path.Combine("Scripts", "ScriptName", SelectedScript);
            var tenantConfigPath = Path.Combine("Tenants", SelectedTenant);
            var processStartInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-ExecutionPolicy Bypass -File \"{scriptPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = processStartInfo })
            {
                process.OutputDataReceived += (sender, e) => ExecutionOutput += e.Data + "\n";
                process.ErrorDataReceived += (sender, e) => ExecutionOutput += "ERROR: " + e.Data + "\n";
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }

            SaveExecutionHistory();
        }

        private void SaveExecutionHistory()
        {
            // Save execution history to history.json
            // This is a placeholder for actual implementation
        }
    }
}