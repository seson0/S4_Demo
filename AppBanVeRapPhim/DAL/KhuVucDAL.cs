using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBanVeRapPhim.DAL
{
    internal class KhuVucDAL
    {
        private S4_AppBanVeEntities dbContext;

        public KhuVucDAL()
        {
            dbContext = new S4_AppBanVeEntities();
        }

        // Lấy danh sách khu vực
        public List<KhuVuc> GetAllKhuVuc()
        {
            return dbContext.KhuVuc.ToList();
        }

        // Thêm mới khu vực
        public void AddKhuVuc(KhuVuc khuVuc)
        {
            dbContext.KhuVuc.Add(khuVuc);
            dbContext.SaveChanges();
        }

        // Sửa thông tin khu vực
        public void UpdateKhuVuc(KhuVuc khuVuc)
        {
            var existingKhuVuc = dbContext.KhuVuc.FirstOrDefault(kv => kv.Ma == khuVuc.Ma);
            if (existingKhuVuc != null)
            {
                existingKhuVuc.MaSoKhuVuc = khuVuc.MaSoKhuVuc;
                existingKhuVuc.Ten = khuVuc.Ten;
                dbContext.SaveChanges();
            }
        }

        // Xóa khu vực
        public void DeleteKhuVuc(int maKhuVuc)
        {
            var khuVuc = dbContext.KhuVuc.FirstOrDefault(kv => kv.Ma == maKhuVuc);
            if (khuVuc != null)
            {
                dbContext.KhuVuc.Remove(khuVuc);
                dbContext.SaveChanges();
            }
        }
    }
}
