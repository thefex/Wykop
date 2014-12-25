namespace Wykop.ApiProvider.Data
{
    public class MethodParameter
    {
        public string MethodName { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return MethodName + "/" + Value;
        }
    }
}