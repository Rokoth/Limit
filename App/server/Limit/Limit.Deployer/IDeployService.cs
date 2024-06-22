using System.Threading.Tasks;

namespace Limit.LimitDeployer
{
    public interface IDeployService
    {
        Task Deploy(int? num = null);
    }
}
