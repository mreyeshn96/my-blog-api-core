using System;

namespace my_app_backend.Models.ViewModel
{
    public class PostVM
    {
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}