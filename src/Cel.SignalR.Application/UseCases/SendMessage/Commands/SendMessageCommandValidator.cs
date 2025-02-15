using Cel.SignalR.Application.Common.Validators;
using FluentValidation;

namespace Cel.SignalR.Application.UseCases.SendMessage.Commands;

public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
{
    public SendMessageCommandValidator()
    {
        RuleFor(item => item.MessageModel.Body)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");

        RuleFor(item => item.MessageModel.Receivers)
            .NotNull()
            .WithMessage("{PropertyName} is required.");

        RuleFor(item => item.MessageModel.User)
            .NotNull()
            .WithMessage("{PropertyName} is required.");

        RuleFor(item => item.MessageModel.User)
            .SetValidator(new UserValidator())
            .WithMessage("{PropertyName} is required.");

        RuleForEach(item => item.MessageModel.Receivers)
            .SetValidator(new UserValidator())
            .WithMessage("{PropertyName} is required.");
    }
}
