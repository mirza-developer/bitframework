﻿using Bit.Core.Models;
using Bit.Owin.Contracts.Metadata;
using Bit.Owin.Implementations.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bit.Owin.Metadata.Views
{
    public class LoginViewMetadataBuilder : DefaultViewMetadataBuilder
    {
        public override Task<IEnumerable<ObjectMetadata>> BuildMetadata()
        {
            AddViewMetadata(new ViewMetadata
            {
                ViewName = "login",
                Messages = new List<EnvironmentCulture>
                {
                    new EnvironmentCulture
                    {
                        Name = "FaIr",
                        Values = new List<EnvironmentCultureValue>
                        {
                            new EnvironmentCultureValue { Name = "UserNameIsRequired" , Title = "نام کاربری اجباری است" },
                            new EnvironmentCultureValue { Name = "PasswordIsRequired" , Title = "رمز عبور اجباری است" },
                            new EnvironmentCultureValue { Name = "RememberMe" , Title = "مرا به خاطر بسپار" },
                            new EnvironmentCultureValue { Name = "OrLoginUsing" , Title = "یا وارد شوید با:" },
                            new EnvironmentCultureValue { Name = "Microsoft" , Title = "مایکروسافت" },
                            new EnvironmentCultureValue { Name = "Facebook" , Title = "فیسبوک" },
                            new EnvironmentCultureValue { Name = "Twitter" , Title = "توییتر" },
                            new EnvironmentCultureValue { Name = "LinkedIn" , Title = "لینکداین" },
                            new EnvironmentCultureValue { Name = "Google" , Title = "گوگل" },
                            new EnvironmentCultureValue { Name = "Login" , Title = "ورود" },
                            new EnvironmentCultureValue { Name = "LoginTitle" , Title = "ورود" },
                            new EnvironmentCultureValue { Name = "UserName" , Title = "نام کاربری" },
                            new EnvironmentCultureValue { Name = "Error" , Title = "خطا" },
                            new EnvironmentCultureValue { Name = "Password" , Title = "رمز عبور" },
                            new EnvironmentCultureValue { Name = "LoginFailed" , Title = "ورود ناموفق" }
                        }
                    },
                    new EnvironmentCulture
                    {
                        Name = "EnUs",
                        Values = new List<EnvironmentCultureValue>
                        {
                            new EnvironmentCultureValue { Name = "UserNameIsRequired" , Title = "User name is required" },
                            new EnvironmentCultureValue { Name = "PasswordIsRequired" , Title = "Password is required" },
                            new EnvironmentCultureValue { Name = "RememberMe" , Title = "Remember me" },
                            new EnvironmentCultureValue { Name = "OrLoginUsing" , Title = "Or login using:" },
                            new EnvironmentCultureValue { Name = "Microsoft" , Title = "Microsoft" },
                            new EnvironmentCultureValue { Name = "Facebook" , Title = "Facebook" },
                            new EnvironmentCultureValue { Name = "Twitter" , Title = "Twitter" },
                            new EnvironmentCultureValue { Name = "LinkedIn" , Title = "LinkedIn" },
                            new EnvironmentCultureValue { Name = "Google" , Title = "Google" },
                            new EnvironmentCultureValue { Name = "Login" , Title = "Login" },
                            new EnvironmentCultureValue { Name = "LoginTitle" , Title = "Login" },
                            new EnvironmentCultureValue { Name = "UserName" , Title = "User name" },
                            new EnvironmentCultureValue { Name = "Error" , Title = "Error" },
                            new EnvironmentCultureValue { Name = "Password" , Title = "Password" },
                            new EnvironmentCultureValue { Name = "LoginFailed" , Title = "Login failed" }
                        }
                    }
                }
            });

            return base.BuildMetadata();
        }
    }
}
