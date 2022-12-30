using FluentValidation;
using Merchandising.Application.Models;

namespace Merchandising.API.Validations;

public class CreateProductValidator : AbstractValidator<CreateProductRequestVM>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.CategoryId).NotNull();
    }
}
