using System.ComponentModel.DataAnnotations;

namespace WowBloger.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}