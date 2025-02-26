using System.ComponentModel.DataAnnotations;

namespace GumAdvisor.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
