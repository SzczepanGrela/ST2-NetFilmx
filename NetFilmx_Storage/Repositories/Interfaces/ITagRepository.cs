using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAllTagsAsync();
        Task<List<Tag>> GetTagsByVideoIdAsync(int videoId);

        Task<Tag> GetTagByIdAsync(int tagId);
        Task<Tag> GetTagByNameAsync(string tagName);

        Task AddTagAsync(Tag tag);
        Task UpdateTagAsync(Tag tag);
        Task DeleteTagAsync(int tagId);

        Task<bool> IsTagExistAsync(int tagId);
        Task<bool> IsTagExistAsync(string tagName);

        Task<int> GetTagCountByIdAsync(int tagId);
        Task<int> GetTagCountByNameAsync(string tagName);
    }
}
