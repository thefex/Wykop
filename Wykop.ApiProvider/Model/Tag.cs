namespace Wykop.ApiProvider.Model
{
    public class Tag
    {
        public Tag(string tagName)
        {
            Name = tagName;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return "#" + Name;
        }
    }
}