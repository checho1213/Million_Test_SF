namespace Million.Application.Queries.GetPropertyQuery;
public class GetPropertiesQueryValidator : AbstractValidator<GetPropertiesQuery>
{
    public GetPropertiesQueryValidator()
    {
        
        RuleFor(q => q.MaxPrice)
            .GreaterThanOrEqualTo(0)
            .When(q => q.MaxPrice.HasValue)
            .WithMessage("MaxPrice must be a positive number.");       
    }
}
