﻿using FluentValidation;
using NLayerProject.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Validations
{
    public class UserProfileValidator : AbstractValidator<UserProfileDto>
    {
        public UserProfileValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kullanıcının adı boş olamaz.")
               .NotNull().WithMessage("Kullanıcının adı null olamaz.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Kullanıcının soyadı boş olamaz.")
              .NotNull().WithMessage("Kullanıcının soyadı null olamaz.");
        }
    }
}
