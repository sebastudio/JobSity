using System.Threading.Tasks;
using TripSity.Model;

namespace TripSity.AzureBlob
{
    public interface IFileManagerLogic
    {
        Task Upload(FileModel model);
    }
}
