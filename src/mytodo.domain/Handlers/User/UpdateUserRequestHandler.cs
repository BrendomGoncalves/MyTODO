using MediatR;
using mytodo.domain.Repository;
using mytodo.domain.Services;
using mytodo.shareable.Requests.User;
using mytodo.shareable.Responses.User;
using OperationResult;

namespace mytodo.domain.Handlers.User;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, Result<UpdateUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEncryptionService _encryptionService;

    public UpdateUserRequestHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
        IEncryptionService encryptionService)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _encryptionService = encryptionService;
    }

    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(request.UserId);

        if (request.UserName != null) user.Username = request.UserName;
        if (request.Email != null) user.Email = request.Email;
        if (request.PasswordHash != null)
        {
            user.PasswordHash = _encryptionService.Encrypt(request.PasswordHash);
        }

        await _userRepository.UpdateUserAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(new UpdateUserResponse(user.UserId, user.Username));
    }
}