using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ABC_Healthcare_webapi
{
    public class APIAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            ABC_HealthcareEntities objEntity = new ABC_HealthcareEntities();
            IQueryable<Customer> cust = objEntity.Customers;
            var user = cust.Any(i => i.email.Equals(context.UserName, StringComparison.OrdinalIgnoreCase) && i.password == context.Password);
            //var user_email = from e in cust
            //                 where e.email == context.UserName
            //                 select e.email;

            
            //var user_password = from e in cust
            //                 where e.email == context.UserName
            //                 select e.password;

            IQueryable < Admin_User > admin_Users = objEntity.Admin_User;
             var admin = admin_Users.Any(i => i.username.Equals(context.UserName, StringComparison.OrdinalIgnoreCase) && i.password == context.Password);

            if (admin)

            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                context.Validated(identity);
            }
            else if (user)

            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Hi User"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}