using System.ComponentModel.DataAnnotations;
using BlogApp.Entity;

namespace BlogApp.Models
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Başlık")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "açıklama")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string? Url { get; set; }

        [Required]
        [Display(Name = "İçerik")]
        public string? Content { get; set; }

        public bool İsActive { get; set; }
        public List<Tag> Tags { get; set; } = new();
        
    }
}