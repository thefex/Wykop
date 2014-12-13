namespace Wykop.ApiProvider.Data
{
    public class ApiParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Name + "," + Value;
        }
    }
}