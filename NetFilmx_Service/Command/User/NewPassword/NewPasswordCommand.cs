using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.User
{
    public sealed class NewPasswordCommand : IRequest<CResult>
    {


        public NewPasswordCommand(int id, string password)
        {
            Id = id;

            Password = password;
        }

        public int Id { get; }

        public string Password { get; }

    }
}
