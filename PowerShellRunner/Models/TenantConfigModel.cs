using System.Collections.Generic;

namespace PowerShellRunner.Models
{
    public class TenantConfigModel
    {
        public string TenantName { get; set; }
        public List<ParameterModel> Parameters { get; set; }

        public TenantConfigModel()
        {
            Parameters = new List<ParameterModel>();
        }
    }
}