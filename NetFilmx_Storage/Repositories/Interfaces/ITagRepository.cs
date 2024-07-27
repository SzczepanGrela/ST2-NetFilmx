using NetFilmx_Storage.Entities;
using System.Collections.Generic;

namespace NetFilmx_Storage.Repositories
{
    public interface ITagRepository
    {
        List<Tag> GetTags();
        Tag GetTagById(int id);
        void AddTag(Tag tag);
        void EditTag(Tag tag);
        void DeleteTag(int id);
       
        bool IsTagExist(string Name);
    }
}
