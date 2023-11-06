using System.Collections.Generic;

namespace Model
{
    public class PorousParameter
    {
        private Dictionary<ParameterType, Parameter> _parameters;

        public PorousParameter()
        {
            
        }

        private void Validate()
        {
            
        }

        public Dictionary<ParameterType, Parameter> Parameters { get; set; }
    }
}