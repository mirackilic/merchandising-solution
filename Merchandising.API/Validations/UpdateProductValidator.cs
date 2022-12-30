using FluentValidation;
using Merchandising.Application.Models;

namespace Merchandising.API.Validations;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequestVM>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        RuleFor(x => x.CategoryId).NotNull();
    }
}