using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetAllTags();
        List<Tag> GetTagsByVideoId(int videoId);

        Tag GetTagById(int tagId);
        Tag GetTagByName(string tagName);

        void AddTag(Tag tag);
        void UpdateTag(Tag tag);
        void DeleteTag(int tagId);
       
        bool IsTagExist(int tagId);
        bool IsTagExist(string tagName);
    }
}
