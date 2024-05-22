﻿using CandidateManagementSystem.Application.Candidates.Queries.GetCandidatesWithPagination;

namespace TestTask.Application.Candidates.Queries.GetCandidatesWithPagination;

public class GetCandidatesWithPaginationQueryValidator : AbstractValidator<GetCandidatesWithPaginationQuery>
{
    public GetCandidatesWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
