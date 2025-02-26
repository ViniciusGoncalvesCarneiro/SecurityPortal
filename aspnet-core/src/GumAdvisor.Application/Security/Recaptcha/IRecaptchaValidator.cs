using System.Threading.Tasks;

namespace GumAdvisor.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}