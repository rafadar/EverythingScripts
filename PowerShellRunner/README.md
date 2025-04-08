# PowerShellRunner

PowerShellRunner is a .NET WPF application designed to execute PowerShell scripts with a user-friendly interface. The application follows the MVVM (Model-View-ViewModel) design pattern, ensuring a clean separation of concerns and maintainability.

## Project Structure

The project is organized into the following folders:

- **Models/**: Contains classes that represent the data structures used in the application.
  - `ExecutionHistoryModel.cs`: Represents the execution history of PowerShell scripts.
  - `ParameterModel.cs`: Represents a parameter for a PowerShell script.
  - `TenantConfigModel.cs`: Represents the configuration for a tenant.

- **ViewModels/**: Contains the ViewModel classes that handle the logic for the views.
  - `MainWindowViewModel.cs`: Implements the logic for the main window of the application.

- **Views/**: Contains the XAML files that define the UI layout.
  - `MainWindow.xaml`: Defines the layout and UI elements for the main window.

- **Scripts/**: Contains the PowerShell scripts and related files.
  - `ScriptName/`: A folder for a specific PowerShell script.
    - `script.ps1`: The PowerShell script to be executed.
    - `map.json`: An optional JSON file that maps parameters from the tenant configuration to the parameters defined in the PowerShell script.
    - `history.json`: Stores the execution history of the PowerShell script in JSON format.

- **Tenants/**: Contains tenant configuration files.
  - `tenant-config.json`: Contains the configuration for a tenant in JSON format.

## Features

- **Script Selection**: Users can select a PowerShell script from the `/Scripts/ScriptName/` directory.
- **Tenant Configuration**: Users can select a tenant configuration from the `/Tenants/` directory.
- **Parameter Auto-Population**: The application auto-populates parameters from the `param(...)` block in the selected script.
- **Parameter Mapping**: Users can utilize an optional `map.json` file to map parameters from the tenant configuration.
- **Parameter Editing**: Users can view and edit parameters before executing the script.
- **Real-Time Output**: The application displays real-time output (stdout/stderr) in a log box during script execution.
- **Execution History**: Each execution is saved in `history.json` within the respective script folder.

## Getting Started

1. Clone the repository to your local machine.
2. Open the solution in your preferred .NET development environment.
3. Build the project to restore dependencies.
4. Run the application and follow the on-screen instructions to select scripts and tenant configurations.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.