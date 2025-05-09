namespace Million.Application.Queries.GetPropertyQuery;
public class GetPropertiesQueryValidator : AbstractValidator<GetPropertiesQuery>
{
    public GetPropertiesQueryValidator()
    {
        RuleFor(q => q.MinPrice)
            .GreaterThanOrEqualTo(0)
            .When(q => q.MinPrice.HasValue)
            .WithMessage("MinPrice must be a positive number.");

        RuleFor(q => q.MaxPrice)
            .GreaterThanOrEqualTo(0)
            .When(q => q.MaxPrice.HasValue)
            .WithMessage("MaxPrice must be a positive number.");

        RuleFor(q => q)
            .Must(q => !q.MinPrice.HasValue || !q.MaxPrice.HasValue || q.MinPrice <= q.MaxPrice)
            .WithMessage("MinPrice must be less than or equal to MaxPrice.");
    }
}
