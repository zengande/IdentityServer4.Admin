﻿using IdentityServer4.Admin.Domain.Commands.User;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations
{
    public class RegisterNewUserCommandValidator : UserCommandValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidator()
        {
            ValidateEmail();
            ValidatePassword();
        }
    }
}
