using WebApp.Models;
namespace WebApp.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QLBanVaLiContext _context;
        public LoaiSpRepository(QLBanVaLiContext context)
        {
            _context = context;
        }
        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
        public TLoaiSp Delete(string maloaiSp)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }
        public TLoaiSp GetLoaiSp(string maloaiSp)
        {
            return _context.TLoaiSps.Find(maloaiSp);
        }
        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}