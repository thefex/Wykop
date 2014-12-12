using System.Threading.Tasks;

namespace Wykop.Common.Interfaces
{
    public interface ILoadable
    {
        Task Load();
        Task Unload();
    }
}