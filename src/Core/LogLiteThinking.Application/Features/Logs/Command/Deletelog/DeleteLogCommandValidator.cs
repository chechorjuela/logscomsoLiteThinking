using LogLiteThinking.Application.Features.Logs.Command.CreateLog;

namespace LogLiteThinking.Application.Features.Logs.Command.DeleteLog;

public class DeleteLogCommandValidator : AbstractValidator<DeleteLogCommand>
{
    public DeleteLogCommandValidator()
    {
        RuleFor(l => l.Id)
            .NotEmpty().WithMessage("{Id} can not empty");
    }
}