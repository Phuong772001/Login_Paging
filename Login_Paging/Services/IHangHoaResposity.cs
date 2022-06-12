using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Data;
using Login_Paging.Models;

namespace Login_Paging.Services
{
    public interface IHangHoaResposity
    {
        List<HangHoaModel> GetAll(string search,int page = 1);
    }
}
