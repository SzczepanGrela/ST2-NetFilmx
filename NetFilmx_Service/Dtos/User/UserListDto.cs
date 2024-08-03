namespace NetFilmx_Service.Dtos.User
{
    public class UserListDto : IUserDto
    {

        public UserListDto(string username, string email, int id)
        {
            Username = username;
            Email = email;
            Id = id;
        }

        public string Username { get; }
        public string Email { get; }
        public int Id { get; }
    }
}
