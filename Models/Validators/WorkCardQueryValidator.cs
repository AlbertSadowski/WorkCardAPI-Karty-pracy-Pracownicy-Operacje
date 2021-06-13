using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Entities;

namespace WorkCardAPI.Models.Validators
{
    public class WorkCardQueryValidator : AbstractValidator<WorkCardQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames =  
            { 
              nameof(WorkCard.CardNumber), 
              nameof(WorkCard.Order),
              nameof(WorkCard.Technology)
            }; 
        public WorkCardQueryValidator()
        {
            RuleFor(w => w.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(w => w.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"Page Size must be in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(w => w.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",",allowedSortByColumnNames)}]");
        }
    }
}
