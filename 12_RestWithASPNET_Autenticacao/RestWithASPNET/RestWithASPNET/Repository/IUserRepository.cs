using RestWithASPNET.Data.VO;
using RestWithASPNET.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository {
    public interface IUserRepository {
        User ValidateCredentials(UserVO user);
    }
}
