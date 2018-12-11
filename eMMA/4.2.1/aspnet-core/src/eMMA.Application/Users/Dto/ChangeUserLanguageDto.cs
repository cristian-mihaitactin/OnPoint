using System.ComponentModel.DataAnnotations;

namespace eMMA.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}