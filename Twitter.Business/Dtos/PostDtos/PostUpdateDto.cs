using FluentValidation;

namespace Twitter.Business.Dtos.PostDtos;
public class PostUpdateDtoValidator : AbstractValidator<PostUpdateDto>
{
    public PostUpdateDtoValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(512);
    }
}
public class PostUpdateDto
{
    public string Content { get; set; }
}
