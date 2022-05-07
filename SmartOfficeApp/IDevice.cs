using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartOfficeApp
{
    public interface IDevice
    {
        Task<string> Name { get; }
        Task<string> Status { get; }
        string ImageStatus { get; }
        UserControl Menu { get; }
    }
}
