using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewStart.Server.Data;
using NewStart.Server.Models;

namespace NewStart.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        public readonly DataContext _context;

        public BlogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {

            var Tags = await _context.Tag.ToListAsync();

            var Posts = await _context.Post.ToListAsync();

            var PostsTags = await _context.PostTag.ToListAsync();

            var tagDictionary = Tags.ToDictionary(tag => tag.Id);
            var postDictionary = Posts.ToDictionary(post => post.Id);

            // Créer une liste pour stocker les objets BlogModel
            List<BlogModel> blogModels = new List<BlogModel>();

            // Boucle sur les entités PostModelTagModel
            foreach (var postTag in PostsTags)
            {
                // Récupérer les objets PostModel et TagModel correspondants
                if (postDictionary.TryGetValue(postTag.PostsId, out var postModel) &&
                    tagDictionary.TryGetValue(postTag.TagsId, out var tagModel))
                {
                    // Si l'objet BlogModel correspondant n'existe pas, le créer
                    var blogModel = blogModels.FirstOrDefault(b => b.Id == postModel.Id);

                    if (blogModel == null)
                    {
                        blogModel = new BlogModel
                        {
                            Id = postModel.Id,
                            Title = postModel.Title,
                            Description = postModel.Description,
                            References = new List<string>()
                        };

                        blogModels.Add(blogModel);
                    }

                    // Ajouter la référence de TagModel à la liste References du BlogModel
                    blogModel.References.Add(tagModel.Reference);
                }
            }


            return Ok(blogModels);
        }
    }
}
