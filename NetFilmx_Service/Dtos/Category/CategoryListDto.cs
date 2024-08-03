namespace NetFilmx_Service.Dtos.Category
{
    public class CategoryListDto : ICategoryDto
    {
        public CategoryListDto(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public int Id { get; }
        public string Name { get; }

    }
}
