using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Analytics.Dashboard.Application.Auth.Commands
{
    public record LoginGoogleCommand(string Token) : IRequest<string>;
}
