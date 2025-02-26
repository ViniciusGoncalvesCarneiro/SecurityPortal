using System.Threading.Tasks;

namespace GumAdvisor.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}