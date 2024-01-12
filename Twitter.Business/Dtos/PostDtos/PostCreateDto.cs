using FluentValidation;

namespace Twitter.Business.Dtos.PostDtos;

public class PostCreateDto
{
    public string Content { get; set; }
}
public class PostCreateDtoValidator : AbstractValidator<PostCreateDto>
{
    public PostCreateDtoValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2)
            .MaximumLength(512);
    }
}
