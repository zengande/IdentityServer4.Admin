﻿using FluentValidation;
using IdentityServer4.Admin.Domain.Commands.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentityServer4.Admin.Domain.Validations.Client
{
    public class UpdateClientCommandValidator : ClientCommandValidation<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            ValidateGrantType();
            ValidateOriginalClinetId();
            ValidateIdentityTokenLifetime();
            ValidateAccessTokenLifetime();
            ValidateAuthorizationCodeLifetime();
            ValidateSlidingRefreshTokenLifetime();
            ValidateDeviceCodeLifetime();
            ValidateAbsoluteRefreshTokenLifetime();
        }

        private void ValidateOriginalClinetId()
        {
            RuleFor(c=>c.OriginalClinetId).NotEmpty().WithMessage("Last ClientId must be set");
        }
    }
}
