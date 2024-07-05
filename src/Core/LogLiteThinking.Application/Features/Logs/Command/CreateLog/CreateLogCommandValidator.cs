using LogLiteThinking.Application.Features.Logs.Command.CreateLog;

namespace LogLiteThinking.Application.Features.Logs.Command.UpdateLog;

public class CreateLogCommandValidator : AbstractValidator<CreateLogCommand>
{
    public CreateLogCommandValidator()
    {
        RuleFor(l => l.Title)
            .NotEmpty().WithMessage("{Title} can not empty");
        
        RuleFor(l => l.Description)
            .NotEmpty().WithMessage("{Description} can not empty");
    }
}