﻿using IdentityServer4.Admin.API.Extensions;
using IdentityServer4.Admin.Application.Interfaces;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.BuildingBlock.Mvc;
using IdentityServer4.Admin.Domain.Core.Bus;
using IdentityServer4.Admin.Domain.Core.Notifications;
using IdentityServer4.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.API.Controllers.v1._0
{

    [Route(ApiRouteTemplate)]
    [Authorize(Policy = PolicyNames.Admin)]
    [ApiVersion("1.0")]
    public class ClientsController : ApiController
    {
        private readonly IClientService _clientService;
        public ClientsController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            IClientService clientService) : base(notifications, mediator)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<JsonResponse<IList<ClientViewModel>>>> Get()
        {
            var clients = await _clientService.GetClientsAsync();

            return JsonResponse(clients);
        }

        [HttpGet, Route("{clientId}")]
        public async Task<ActionResult<JsonResponse<Client>>> Get(string clientId)
        {
            var client = await _clientService.GetClientDetails(clientId);

            return JsonResponse(client);
        }

        [HttpPost]
        public async Task<ActionResult<JsonResponse<bool>>> Post([FromBody]CreateClientViewModel model)
        {
            await _clientService.CreateAsync(model);
            return JsonResponse(true);
        }

        [HttpDelete, Route("{clientId}")]
        public async Task<ActionResult<JsonResponse<bool>>> Delete(string clientId)
        {
            await _clientService.RemoveAsync(clientId);
            return JsonResponse(true);
        }

        [HttpPut]
        public async Task<ActionResult<JsonResponse<bool>>> Put([FromBody]UpdateClientViewModel model)
        {
            await _clientService.UpdateAsync(model);
            return JsonResponse(true);
        }

        #region Property

        [HttpGet, Route("{clientId}/properties")]
        public async Task<ActionResult<JsonResponse<IEnumerable<PropertyViewModel>>>> Properties(string clientId)
        {
            var properties = await _clientService.GetPropertiesAsync(clientId);
            return JsonResponse(properties);
        }

        [HttpDelete, Route("{clientId}/properties/{id}")]
        public async Task<ActionResult<JsonResponse<bool>>> RemoveProperty(string clientId, int id)
        {
            await _clientService.RemovePropertiesAsync(clientId, id);

            return JsonResponse(false);
        }

        [HttpPost, Route("{clientId}/properties")]
        public async Task<ActionResult<JsonResponse<bool>>> SaveProperty(string clientId, [FromBody]SaveClientPropertyViewModel model)
        {
            await _clientService.SavePropertyAsync(clientId, model);

            return JsonResponse(true);
        }

        #endregion

        #region Secret

        [HttpGet, Route("{clientId}/secrets")]
        public async Task<ActionResult<JsonResponse<IEnumerable<SecretViewModel>>>> Secrets(string clientId)
        {
            var secrets = await _clientService.GetSecretsAsync(clientId);
            return JsonResponse(secrets);
        }

        [HttpDelete, Route("{clientId}/secrets/{id}")]
        public async Task<ActionResult<JsonResponse<bool>>> RemoveSecret(string clientId, int id)
        {
            await _clientService.RemoveSecretAsync(clientId, id);

            return JsonResponse(false);
        }

        [HttpPost, Route("{clientId}/secrets")]
        public async Task<ActionResult<JsonResponse<bool>>> SaveSecret(string clientId, [FromBody]SaveClientSecretViewModel model)
        {
            model.ClientId = clientId;
            await _clientService.SaveSecretAsync(model);
            return JsonResponse(true);
        }
        #endregion

        #region Claim

        [HttpGet, Route("{clientId}/claims")]
        public async Task<ActionResult<JsonResponse<IEnumerable<ClaimViewModel>>>> Claims(string clientId)
        {
            var claims = await _clientService.GetClaimsAsync(clientId);
            return JsonResponse(claims);
        }

        [HttpDelete, Route("{clientId}/claims/{id}")]
        public async Task<ActionResult<JsonResponse<bool>>> RemoveClaim(string clientId, int id)
        {
            await _clientService.RemoveClaimAsync(clientId, id);
            return JsonResponse(false);
        }

        [HttpPost, Route("{clientId}/claims")]
        public async Task<ActionResult<JsonResponse<bool>>> SaveClaim(string clientId, [FromBody]SaveClientClaimViewModel model)
        {
            model.ClientId = clientId;
            await _clientService.SaveClaimAsync(model);
            return JsonResponse(true);
        }

        #endregion
    }
}
