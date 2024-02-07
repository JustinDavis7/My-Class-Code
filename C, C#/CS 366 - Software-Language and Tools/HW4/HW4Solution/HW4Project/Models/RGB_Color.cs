using System.ComponentModel.DataAnnotations;

namespace HW4.Models {

    public class RGB {
        [Required(ErrorMessage = "Please enter 0 - 255 for Red.")]
        public int? red {get; set;}

        [Required(ErrorMessage = "Please enter 0 - 255 for Green.")]
        public int? green {get; set;}

        [Required(ErrorMessage = "Please enter 0 - 255 for Blue.")]
        public int? blue {get; set;}
    }
}
