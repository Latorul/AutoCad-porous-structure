namespace Model
{
    public class Parameter
    {
        private double _minValue;

        public double MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }

        private double _maxValue;

        public double MaxVlaue
        {
            get { return _maxValue; }
            set { _maxValue = value; }
        }

        private double _value;

        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public Parameter(double value, double minValue, double maxValue)
        {
            MinValue = minValue;
            maxValue = maxValue;
            Value = value;
        }

        private void Validate()
        {
            
        }
    }
}