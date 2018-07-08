using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Sampler.Basic.Core;

namespace Sampler.Basic
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly int userId;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

            string value = this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            this.userId = int.Parse(value);
            //this.httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value; 
        }

        public int UserId 
        {
            get
            {
                return this.userId; 
            }
        }
    }
}
