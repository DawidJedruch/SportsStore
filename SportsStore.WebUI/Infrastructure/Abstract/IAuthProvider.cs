using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SportsStore.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password);
    }
}