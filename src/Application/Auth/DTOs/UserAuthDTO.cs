using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Application.Auth.DTOs
{
    public class UserAuthDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ProfileImage { get; set; }
    }
}
