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
using BloggingPlatformAPI.Interfaces.Services;
using BloggingPlatformAPI.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BloggingPlatformAPI.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tag)
        {
            _tagService = tag;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            var result = await _tagService.GetTags();

            return Ok(result);
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(Guid id)
        {
            var tag = await _tagService.GetTag(id);

            if (tag == null)
            {
                return NotFound();
            }

            return tag;
        }

        // PUT: api/Tag/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTag(Guid id, TagPut tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }

            var result = await _tagService.PutTag(id, tag);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // POST: api/Tag
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(TagPost tag)
        {
           var result = await _tagService.PostTag(tag);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var result = await _tagService.DeleteTag(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
