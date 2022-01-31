using BandAPI.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BandAPI.Models
{
    [TitleAndDescrption(ErrorMessage = "Title must be different form description")]
    public abstract class AlbumManipulationDto
    {

        [Required(ErrorMessage = "Title needs to be filled in.")]
        [MaxLength(200, ErrorMessage = "Title needs to be up to 200 characters.")]
        public string Title { get; set; }

        [MaxLength(400, ErrorMessage = "Description needs to be up to 400 characters.")]
        public virtual string Description { get; set; }
    }
}
