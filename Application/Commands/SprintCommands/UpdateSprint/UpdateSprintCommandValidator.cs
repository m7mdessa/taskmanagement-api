﻿using Domain.Aggregates.ProjectAggregate;
using FluentValidation;


namespace Application.Commands.SprintCommands.UpdateSprint
{
   
    public class UpdateSprintCommandValidator : AbstractValidator<UpdateSprintCommand>
    {

        public UpdateSprintCommandValidator()
        {
            RuleFor(p => p.SprintName)
                .NotEmpty().WithMessage("{SprintName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{SprintName} must not exceed 50 characters.");

        
        }

        
    }
}