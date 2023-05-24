using FluentValidation;
using MiniEshop.Application.DomainServices.ProductService.Requests;

namespace MiniEshop.Application.Validators;

public class ProductUpsertRequestValidator : AbstractValidator<ProductUpsertRequest>
{
    public ProductUpsertRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage("Məhsul adı boş ola bilməz")
            .MinimumLength(2)
                .WithMessage("Məhsul adının ölçüsü minimum 2 ola bilər")
            .MaximumLength(30)
                .WithMessage("Məhsul adının ölçüsü maximum 30 ola bilər");

        RuleFor(x => x.Quantity)
            .GreaterThan(0)
                .WithMessage("Məhsul miqdarı sıfırdan böyük olmalıdır");

        RuleFor(x => x.Price)
            .GreaterThan(0)
                .WithMessage("Məhsul qiyməti sıfırdan böyük olmalıdır"); ;
    }
}
