using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
                new ApiResource("ResourceEmployee"){Scopes={"EmployeeReadPermission,EmployeeCreatePermission"}},
                new ApiResource("ResourceEmployee2"){Scopes={"EmployeeFullPermission"}},
                new ApiResource("ResourcePatient"){Scopes={"PatientFullPermission"}},
                new ApiResource("ResourcePrescription"){Scopes={"PrescriptionFullPermission"}},
                new ApiResource("ResourceAppointment"){Scopes={"AppointmentFullPermission"}},
                new ApiResource("ResourceReview"){Scopes={"ReviewFullPermission"}},
                new ApiResource("ResourcePayment"){Scopes={"PaymentFullPermission"}},
                new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
                new ApiResource("ResourceOcelot"){Scopes={"OcelotFullPermission"}},
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("EmployeeReadPermission","Read Employee Authority For Employee Operations"),
            new ApiScope("EmployeeCreatePermission","Create Employee Authority For Employee Operations"),
            new ApiScope("EmployeeFullPermission","Create Employee Authority For Employee Operations"),
            new ApiScope("PatientFullPermission","Full Authority For Patient Operations"),
            new ApiScope("PrescriptionFullPermission","Full Authority For Prescription Operations"),
            new ApiScope("AppointmentFullPermission","Full Authority For Appointment Operations"),
            new ApiScope("ReviewFullPermission","Full Authority For Review Operations"),
            new ApiScope("PaymentFullPermission","Full Authority For Payment Operations"),
            new ApiScope("MessageFullPermission","Full Authority For Message Operations"),
            new ApiScope("OcelotFullPermission","Full Authority For Ocelot Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="PatientVisitor",
                ClientName="Hospital Patient User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret ("hospitalsecret".Sha256()) },
                AllowedScopes={ "EmployeeReadPermission", "ReviewFullPermission", "EmployeeFullPermission", "AppointmentFullPermission", "ReviewFullPermission", "OcelotFullPermission", IdentityServerConstants.LocalApi.ScopeName },
                AllowAccessTokensViaBrowser=true,
            },

            new Client
            {
                ClientId="PatientAdmin",
                ClientName="Hospital Patient Admin",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={ new Secret  ("hospitalsecret".Sha256())  },
                AllowedScopes=
                { "EmployeeReadPermission", "EmployeeCreatePermission", "PatientFullPermission" ,
                    "PrescriptionFullPermission", "AppointmentFullPermission", "ReviewFullPermission",
                    "PaymentFullPermission", "MessageFullPermission", "OcelotFullPermission",

                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    },

                AccessTokenLifetime=600
            }
        };
    }
}