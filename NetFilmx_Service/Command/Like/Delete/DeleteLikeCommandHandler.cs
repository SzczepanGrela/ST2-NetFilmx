using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Like
{
    public class DeleteLikeCommandHandler : IRequestHandler<DeleteLikeCommand, CResult>
    {
        private readonly ILikeRepository _likeRepository;

        public DeleteLikeCommandHandler(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<CResult> Handle(DeleteLikeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var like = await _likeRepository.GetByUserAndVideoAsync(request.UserId, request.VideoId);
                if (like == null)
                {
                    return CResult.Failure("Like not found");
                }

                await _likeRepository.DeleteAsync(like.Id);
                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Failed to delete like: {ex.Message}");
            }
        }
    }
}