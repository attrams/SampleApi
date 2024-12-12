using Microsoft.AspNetCore.Mvc;
using SampleApi.Models;
using SampleApi.Services;

namespace SampleApi.Controllers;

/// <summary>
/// Represents the controller for <see cref="Post"/>
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postsService;

    /// <summary>
    /// Initializes a <see cref="PostsController"/> instance
    /// </summary>
    /// <param name="postService">An instance of <see cref="IPostService"/> used to manage services related to post.</param>
    public PostController(IPostService postService)
    {
        _postsService = postService;
    }

    /// <summary>
    /// Retrieves a specific post by its ID.
    /// </summary>
    /// <param name="id">The ID of the post to retrieve.</param>
    /// <returns>An HTTP 200 response with the post if found, or an HTTP 404 if not found.</returns>
    [HttpGet("{id}", Name = "GetPost")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postsService.GetPost(id);
        if (post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    /// <summary>
    /// Retrieves all posts.
    /// </summary>
    /// <returns>An HTTP 200 response with a list of all posts.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Post>>> GetPosts()
    {
        var posts = await _postsService.GetAllPosts();
        return Ok(posts);
    }

    /// <summary>
    /// Creates a new post.
    /// </summary>
    /// <param name="post">The post object to create.</param>
    /// <returns>An HTTP 201 response with the created post and its location(route).</returns>
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
        await _postsService.CreatePost(post);

        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    /// <summary>
    /// Updates an existing post.
    /// </summary>
    /// <param name="id">The ID of the post to update.</param>
    /// <param name="post">The updated post object.</param>
    /// <returns>
    /// An HTTP 200 response with the updated post if successful,
    /// an HTTP 400 if the ID does not match the post ID,
    /// or an HTTP 404 if the post is not found.
    /// </returns>
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePost(int id, Post post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }
        var updatedPost = await _postsService.UpdatePost(id, post);
        if (updatedPost is null)
        {
            return NotFound();
        }

        return Ok(post);
    }
}
