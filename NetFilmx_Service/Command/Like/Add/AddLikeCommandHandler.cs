using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Like
{
    public class AddLikeCommandHandler : IRequestHandler<AddLikeCommand, CResult>
    {
        private readonly ILikeRepository _likeRepository;

        public AddLikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<CResult> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var like = new NetFilmx_Storage.Entities.Like(request.VideoId, request.UserId);

                var result = await _likeRepository.AddAsync(like);
                return CResult.Success(result.Id);
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to add like: {ex.Message}");
            }
        }
    }
}