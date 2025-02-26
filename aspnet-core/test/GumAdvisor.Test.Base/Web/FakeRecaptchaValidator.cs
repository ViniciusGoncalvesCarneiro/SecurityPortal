using System.Threading.Tasks;
using GumAdvisor.Security.Recaptcha;

namespace GumAdvisor.Test.Base.Web
{
    public class FakeRecaptchaValidator : IRecaptchaValidator
    {
        public Task ValidateAsync(string captchaResponse)
        {
            return Task.CompletedTask;
        }
    }
}
