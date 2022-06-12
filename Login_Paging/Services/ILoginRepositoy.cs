using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Models;

namespace Login_Paging.Services
{
   public interface ILoginRepositoy
   {
       string Login(LoginModel mode);
   }
}
