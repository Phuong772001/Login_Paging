using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Login_Paging.Data;
using Login_Paging.Models;
using Microsoft.EntityFrameworkCore;

namespace Login_Paging.Services
{
    public class HangHoaRepositoy : IHangHoaResposity
    {
        private readonly MyDbcontext _context;
        public static int Page_size { get; set; } = 7;
        public HangHoaRepositoy(MyDbcontext context)
        {
            _context = context;
        }
        public List<HangHoaModel> GetAll(string search,int page =1)
        {
            var allProducts = _context.HangHoas
                .AsQueryable();
            allProducts = allProducts.Skip((page - 1) * Page_size).Take(Page_size);
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHangHoa.Contains(search));
            }
            var result = allProducts.Select(hh => new HangHoaModel
            {
                Id = hh.Id,
                TenHangHoa = hh.TenHangHoa,
                DonGia = hh.DonGia

            });
            return result.ToList();
        }
        
    }
}
