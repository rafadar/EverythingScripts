using System;

namespace PowerShellRunner.Models
{
    public class ExecutionHistoryModel
    {
        public string ScriptName { get; set; }
        public DateTime ExecutionTime { get; set; }
        public string Output { get; set; }
    }
}