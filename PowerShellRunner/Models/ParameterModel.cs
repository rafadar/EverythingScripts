using System;

namespace PowerShellRunner.Models
{
    public class ParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsRequired { get; set; }

        public ParameterModel(string name, string value, bool isRequired)
        {
            Name = name;
            Value = value;
            IsRequired = isRequired;
        }
    }
}