﻿using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace PetGuardian.API.Identity.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if(birthDateClaim is null)
            {
                return Task.CompletedTask;
            }

            var birthDate = Convert.ToDateTime(birthDateClaim.Value);

            var userAge = DateTime.Today.Year - birthDate.Year;

            //check if the user already has 18, otherwise he's like 17 years old
            if(birthDate > DateTime.Today.AddYears(-userAge))
            {
                userAge--;
            }

            if(userAge >= requirement.Age) 
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
