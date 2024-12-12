using SampleApi.Models;

namespace SampleApi.Services;

/// <summary>
/// A service interface for managing posts.
/// </summary>
public interface IPostService
{
    /// <summary>
    /// Adds a new post.
    /// </summary>
    /// <param name="item">The post to add.</param>
    /// <returns>A completed task.</returns>
    Task CreatePost(Post item);

    /// <summary>
    /// Updates an existing post identified by its ID.
    /// </summary>
    /// <param name="id">The ID of the post to update.</param>
    /// <param name="item">The updated post data.</param>
    /// <returns>A task that returns the updated post, or null if no post with the given ID was found.</returns>
    Task<Post?> UpdatePost(int id, Post item);

    /// <summary>
    /// Retrieves a post by its ID.
    /// </summary>
    /// <param name="id">The ID of the post to retrieve.</param>
    /// <returns>A task that returns the post if found, or null if no post with the given ID exists.</returns>
    Task<Post?> GetPost(int id);

    /// <summary>
    /// Retrieves all posts.
    /// </summary>
    /// <returns>A task that returns the list of all posts.</returns>
    Task<List<Post>> GetAllPosts();

    /// <summary>
    /// Deletes a post identified by its ID.
    /// </summary>
    /// <param name="id">The ID of the post to delete.</param>
    /// <returns>A completed task.</returns>
    Task DeletePost(int id);
}