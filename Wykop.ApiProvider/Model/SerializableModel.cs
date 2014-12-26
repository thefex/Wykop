using Newtonsoft.Json;

namespace Wykop.ApiProvider.Model
{
    public abstract class SerializableModel
    {
        public string SerializeToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}