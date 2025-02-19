using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloggingPlatformAPI.Data;
using BloggingPlatformAPI.Models;
using BloggingPlatformAPI.Interfaces;
using BloggingPlatformAPI.Dtos;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService post)
        {
            _postService = post;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var result = await _postService.GetPosts();

            return Ok(result);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostGet>> GetPost(Guid id)
        {
            var post = await _postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        // PUT: api/Posts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(Guid id, PostPut post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var result = await _postService.PutPost(id, post);



            return Ok(result);
        }

        // POST: api/Posts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostGet>> PostPost(PostPost post)
        {
            var result = await _postService.PostPost(post);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _postService.DeletePost(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(id);
        }

      
    }
}
