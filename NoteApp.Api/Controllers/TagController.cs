
using Microsoft.AspNetCore.Mvc;
using NoteApp.Api.Models;
using NoteApp.Business.Concrete;
using NoteApp.DataAccess;
using NoteApp.Entities.Concrete;

namespace TagApp.Api.Controllers;

[ApiController]
[Route("api/[Controller]s")]
public class TagController : ControllerBase
{
    TagManager TagManager = new TagManager(new EfTagDal());

    public TagController()
    {

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        try
        {
            var result = TagManager.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No Tag was found with this id."); }

        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag([FromBody] TagModel tagModel)
    {
        try
        {
            Tag createdTag = new Tag
            {
                Name = tagModel.Name,
                UserId = tagModel.UserId
            };
            TagManager.Insert(createdTag);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTag([FromBody] Tag Tag)
    {
        try
        {
            TagManager.Delete(Tag);
            return Ok($"Successfully deleted Tag with this id: {Tag.TagId}");
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }

    [HttpGet("{id}/user")]
    public async Task<IActionResult> GetAllTagsByUserId(int id)
    {
        try
        {
            var result = TagManager.GetAllTagsByUserId(id);
            if (result != null)
            {
                return Ok(result);
            }
            else { return NotFound("No Tag was found with this id!"); }
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }
}
