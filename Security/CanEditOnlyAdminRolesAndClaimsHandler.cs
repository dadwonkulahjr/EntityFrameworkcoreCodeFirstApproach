using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EntityFrameworkcoreCodeFirstApproach.Security
{
    public class CanEditOnlyAdminRolesAndClaimsHandler : AuthorizationHandler<ManageAdminRolesAndCliamsRequirements>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ManageAdminRolesAndCliamsRequirements requirement)
        {
            var authFiterContext = context.Resource as AuthorizationFilterContext;
            if(authFiterContext == null)
            {
                return Task.CompletedTask;
            }

            string loggedInUser = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string adminIdBeenEdited = authFiterContext.HttpContext.Request.Query["userId"];

            if(context.User.IsInRole("Admin") && context.User.HasClaim(claims => claims.Type == "Edit Role" && claims.Value == "true") &&
                adminIdBeenEdited.ToLower() != loggedInUser.ToLower())
            {
                context.Succeed(requirement: requirement);
            }
           
            return Task.CompletedTask;
        }
    }
}
