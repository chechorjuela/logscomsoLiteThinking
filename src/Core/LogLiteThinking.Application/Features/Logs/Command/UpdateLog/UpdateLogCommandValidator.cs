namespace LogLiteThinking.Application.Features.Logs.Command.UpdateLog;

public class UpdateLogCommandValidator : AbstractValidator<UpdateLogCommand>
{
    public UpdateLogCommandValidator()
    {
        RuleFor(l => l.Title)
            .NotEmpty().WithMessage("{Title} can not empty");
    }
}