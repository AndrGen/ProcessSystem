using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProcessSystem.UI.Blazor.Client.Models
{
    public class RegisterFormModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression
        (@"(http|ftp|https)://([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?", //надо не надо хз я
            ErrorMessage = "Please Enter Valid Url")]
        public string Url { get; set; }
        // [Required] нужно, но будет потом как то заполнять
        public IEnumerable<string> ProcessTypesList { get; set; }
    }
}