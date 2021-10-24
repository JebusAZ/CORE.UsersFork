using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CORE.UsersFork.Services;
using CORE.UsersFork.Configuration;
using CORE.UsersFork.Interfaces;
using CORE.UsersFork.Models;

namespace CORE.UsersFork.Services
{
    public class FactorizerService
    {
        public static IUser Inicializar(EServer typeServer)
        {
            return typeServer switch
            {
                EServer.UDEFINED => throw new NullReferenceException(),
                EServer.LOCAL => new UserService(BridgeDBConnection<UserModel>.Create(ConnectionStrings.LocalServer, CORE.Connection.Models.DbEnum.Sql)),
                EServer.CLOUD => new UserService(BridgeDBConnection<UserModel>.Create(ConnectionStrings.CloudServer, CORE.Connection.Models.DbEnum.Sql)),
                _ => throw new NullReferenceException(),
            };

        }

        public static ILogin Login(EServer typeServer)
        {
            return typeServer switch
            {
                EServer.UDEFINED => throw new NullReferenceException(),
                EServer.LOCAL => new LoginService(BridgeDBConnection<LoginModel>.Create(ConnectionStrings.LocalServer, CORE.Connection.Models.DbEnum.Sql)),
                EServer.CLOUD => new LoginService(BridgeDBConnection<LoginModel>.Create(ConnectionStrings.CloudServer, CORE.Connection.Models.DbEnum.Sql)),
                _ => throw new NullReferenceException(),
            };

        }
    }
}
