namespace NewStart.Server.Models
{
    public class PostModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public List<TagModel> Tags { get; } = [];
    }

    public class TagModel
    {
        public int Id { get; set; }

        public string? Reference { get; set; }

        public List<PostModel> Posts { get; } = [];
    }

    public class PostModelTagModel
    {
        public int PostsId { get; set; }

        public int TagsId { get; set; }
    }


    public class BlogModel
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public List<string>? References { get; set; }
    }
}
