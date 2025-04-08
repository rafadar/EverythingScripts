using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Diagnostics;
using ParameterModel = PowerShellRunner.Models.ParameterModel;
using System.ComponentModel;
using PowerShellRunner.Utilities;
using PowerShellRunner.Models;
using System;
using System.IO.Packaging;

namespace PowerShellRunner.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _selectedScript;
        private TenantConfigModel _selectedTenant;
        private ObservableCollection<ParameterModel> _parameters;
        private string _executionOutput;
        private ObservableCollection<string> _scripts;

        public string SelectedScript
        {
            get => _selectedScript;
            set
            {
                _selectedScript = value;
                OnPropertyChanged();
            }
        }

        public TenantConfigModel SelectedTenant
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

        public ObservableCollection<string> Scripts
        {
            get => _scripts;
            set
            {
                _scripts = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TenantConfigModel> Tenants { get; set; }

        public ICommand ExecuteScriptCommand { get; }
        public ICommand LoadParametersCommand { get; }

        public MainWindowViewModel()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var baseDirectory = Path.Combine(documentsPath, "PowerShellRunner");

            Directory.CreateDirectory(Path.Combine(baseDirectory, "Tenants"));
            Directory.CreateDirectory(Path.Combine(baseDirectory, "Scripts"));

            Parameters = new ObservableCollection<ParameterModel>();
            ExecuteScriptCommand = new RelayCommand(ExecuteScript);
            Scripts = new ObservableCollection<string>();
            LoadParametersCommand = new RelayCommand(LoadParameters);
            LoadScripts();
            LoadTenants();
        }

        private void LoadParameters()
        {
            // Load parameters from the selected script's param block
            // This is a placeholder for actual implementation
        }

        private void LoadTenants()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var tenantsDirectory = Path.Combine(documentsPath, "PowerShellRunner", "Tenants");
        // tenantsDirectory = Path.Combine(documentsPath, "Tenants");
        
            if (!Directory.Exists(tenantsDirectory))
            {
                Directory.CreateDirectory(tenantsDirectory); // Create the directory if it doesn't exist
                Tenants = new ObservableCollection<TenantConfigModel>(); // Initialize an empty collection
                return;
            }

            var tenantFiles = Directory.GetFiles(tenantsDirectory, "*.config.json");
            Tenants = new ObservableCollection<TenantConfigModel>(
                tenantFiles.Select(file => JsonConvert.DeserializeObject<TenantConfigModel>(File.ReadAllText(file))));
        }

        private void LoadTenantConfig()
        {
            if (SelectedTenant != null)
            {
                Parameters = SelectedTenant != null ? new ObservableCollection<ParameterModel>(SelectedTenant.Parameters) : new ObservableCollection<ParameterModel>();
            }
        }

        private void ExecuteScript()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var scriptsDirectory = Path.Combine(documentsPath, "PowerShellRunner", "Scripts");
            var scriptPath = Path.Combine(scriptsDirectory, SelectedScript);

            if (!File.Exists(scriptPath))
            {
                ExecutionOutput = "Script file not found.";
                return;
            }

            var tenantConfigPath = Path.Combine(documentsPath, "PowerShellRunner", "Tenants", SelectedTenant.TenantName + ".config.json");
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

        private void LoadScripts()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var scriptsDirectory = Path.Combine(documentsPath, "PowerShellRunner", "Scripts");

            if (Directory.Exists(scriptsDirectory))
            {
                var scriptFiles = Directory.GetFiles(scriptsDirectory, "*.ps1");
                Scripts = new ObservableCollection<string>(scriptFiles.Select(Path.GetFileName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}