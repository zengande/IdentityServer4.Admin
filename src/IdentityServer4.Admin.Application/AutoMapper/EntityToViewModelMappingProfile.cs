﻿using AutoMapper;
using IdentityServer4.Admin.Application.ViewModels;
using IdentityServer4.Admin.Application.ViewModels.ApiResource;
using IdentityServer4.Admin.Application.ViewModels.Client;
using IdentityServer4.Admin.Application.ViewModels.IdentityResource;
using IdentityServer4.Admin.Application.ViewModels.Role;
using IdentityServer4.Admin.Application.ViewModels.User;
using IdentityServer4.Admin.Identity.Entities;
using IdentityServer4.EntityFramework.Entities;

namespace IdentityServer4.Admin.Application.AutoMapper
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>(MemberList.Destination);
            CreateMap<ApplicationUser, PagingUserViewModel>(MemberList.Destination)
                .ForMember(v => v.Gravatar, options => options.MapFrom(src => src.Avatar));

            CreateMap<ApplicationRole, RoleViewModel>(MemberList.Destination);

            CreateMap<ApiResource, ApiResourceViewModel>();

            CreateMap<Secret, SecretViewModel>(MemberList.Destination);

            CreateMap<Property, PropertyViewModel>();

            CreateMap<ApiScope, ScopeViewModel>();

            CreateMap<UserClaim, ClaimViewModel>(MemberList.Destination);

            CreateMap<Models.Client, ClientViewModel>(MemberList.Destination);
            CreateMap<ClientClaim, ClaimViewModel>(MemberList.Destination);

            CreateMap<IdentityResource, IdentityResourceViewModel>(MemberList.Destination);

        }
    }
}
