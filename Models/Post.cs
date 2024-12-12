namespace SampleApi.Models;

/// <summary>
/// Represents a <see cref="Post"/> entity.
/// </summary>
public class Post
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
}