using MediatR;
using mytodo.domain.Repository;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.domain.Handlers.User;

public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Result<DeleteUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteUserRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<DeleteUserResponse>> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        await _userRepository.DeleteUserAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new DeleteUserResponse(user.UserId, user.Username));
    }
}