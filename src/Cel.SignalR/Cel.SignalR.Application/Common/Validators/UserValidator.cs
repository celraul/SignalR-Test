using Cel.SignalR.Application.Models.Users;
using FluentValidation;

namespace Cel.SignalR.Application.Common.Validators;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(item => item.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");

        RuleFor(item => item.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");

        RuleFor(item => item.Id)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}
