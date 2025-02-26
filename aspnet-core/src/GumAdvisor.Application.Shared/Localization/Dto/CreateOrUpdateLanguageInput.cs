using System.ComponentModel.DataAnnotations;

namespace GumAdvisor.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}