using SampleApi.Models;

namespace SampleApi.Services;

/// <summary>
/// A service class for managing posts.
/// </summary>
public class PostService : IPostService
{
    private static readonly List<Post> AllPosts = [];

    /// <inheritdoc/>
    public Task CreatePost(Post item)
    {
        AllPosts.Add(item);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task<Post?> UpdatePost(int id, Post item)
    {
        var post = AllPosts.FirstOrDefault(post => post.Id == id);
        if (post != null)
        {
            post.Title = item.Title;
            post.Body = item.Body;
            post.UserId = item.UserId;
        }

        return Task.FromResult(post);
    }

    /// <inheritdoc/>
    public Task<Post?> GetPost(int id)
    {
        return Task.FromResult(AllPosts.FirstOrDefault(post => post.Id == id));
    }

    /// <inheritdoc/>
    public Task<List<Post>> GetAllPosts()
    {
        return Task.FromResult(AllPosts);
    }

    /// <inheritdoc/>
    public Task DeletePost(int id)
    {
        var post = AllPosts.FirstOrDefault(post => post.Id == id);
        if (post != null)
        {
            AllPosts.Remove(post);
        }

        return Task.CompletedTask;
    }
}