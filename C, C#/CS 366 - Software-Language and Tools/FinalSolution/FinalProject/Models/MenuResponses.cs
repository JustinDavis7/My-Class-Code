using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models {

    public class MenuResponses {

        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your food choice")]
        public string Food { get; set; }
    }
}