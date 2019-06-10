﻿using IdentityServer4.Admin.Domain.Events.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.Domain.EventHandlers
{
    public class UserEventHandler
        : INotificationHandler<UserRegisteredEvent>,
        INotificationHandler<NewLoginAddedEvent>
    {
        public async Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {

        }

        public async Task Handle(NewLoginAddedEvent notification, CancellationToken cancellationToken)
        {
        }
    }
}
