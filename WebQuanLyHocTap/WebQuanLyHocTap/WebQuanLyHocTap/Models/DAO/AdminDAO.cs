using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQuanLyHocTap.Models;
using PagedList.Mvc;
using PagedList;
using System.Web.Services.Description;

public class AdminDAO
{
    QuanLyHocTapDBContext db = null;
    public AdminDAO()
    {
        db = new QuanLyHocTapDBContext();
    }
    //them 1 quan tri vao danh sach quan tri
    public long Insert(QuanTri entity)
    {
        db.QuanTris.Add(entity);
        db.SaveChanges();
        return entity.AdminID;
    }
    //them gianh vien  vao danh sach giang vien
    public long Insert(GiangVien entity)
    {
        db.GiangViens.Add(entity);
        db.SaveChanges();
        return entity.GiangVienID;
    }
    //them 1 sinh vien vao danh sach quan tri
    public long Insert(SinhVien entity)
    {
        db.SinhViens.Add(entity);
        db.SaveChanges();
        return entity.SinhVienID;
    }
    public GiangVien GetByName2(string userName)
    {
        return db.GiangViens.SingleOrDefault(x => x.UserName == userName);
    }
  
    // tim id cua quang tri
    public QuanTri GetByName(string userName)
    {
        return db.QuanTris.SingleOrDefault(x => x.UserName == userName);
    }
    // tim id cua sinh vien
    public SinhVien GetByName3(string userName)
    {
        return db.SinhViens.SingleOrDefault(x => x.UserName == userName);
    }
    //update giang vien
    public bool Update(GiangVien entity)
    {
        try
        {
            var gv = db.GiangViens.Find(entity.GiangVienID);
            gv.UserName = entity.UserName;
            gv.PassWord = entity.PassWord;
            gv.TenGV = entity.TenGV;
            db.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
       
    }
    //update sinh vien
    public bool UpdateSinhVien(SinhVien entity)
    {
        try
        {
            var sv = db.SinhViens.Find(entity.SinhVienID);
            sv.UserName = entity.UserName;
            sv.Password = entity.Password;
            sv.TenSV = entity.TenSV;
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //Update môn hoc
    public bool UpdateMonHoc(MonHoc entity)
    {
        try
        {
            var monhoc = db.MonHocs.Find(entity.MonHocID);
            monhoc.TenMonHoc = entity.TenMonHoc;
            monhoc.isLock = entity.isLock;
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //tim id cua giang vien
    public GiangVien ViewDetailGiangVien(int id)
    {
        return db.GiangViens.Find(id);
    }
    //tim id cua sinh vien
    public SinhVien ViewDetailSinhVien(int id)
    {
        return db.SinhViens.Find(id);
    }
    //tim id cua mon hoc
    public MonHoc ViewDetailMonHoc(int id)
    {
        return db.MonHocs.Find(id);
    }
    //chia trang cua giang vien
    public IEnumerable<GiangVien> ListAllPaging(string search, int page, int pageSize)
    {
        IQueryable<GiangVien> searchGiangVien = db.GiangViens;
        if (!string.IsNullOrEmpty(search))
        {
            searchGiangVien = searchGiangVien.Where(x => x.UserName.Contains(search) || x.TenGV.Contains(search));
        }
        return searchGiangVien.OrderByDescending(x => x.GiangVienID).ToPagedList(page, pageSize);
    }
    //chia trang chua sinh vien
    public IEnumerable<SinhVien> ListAllPaging2(string search,int page, int pageSize)
    {
        IQueryable<SinhVien> searchSinhVien = db.SinhViens;
        if (!string.IsNullOrEmpty(search))
        {
            searchSinhVien = searchSinhVien.Where(x => x.UserName.Contains(search) || x.TenSV.Contains(search));
        }
        return searchSinhVien.OrderByDescending(x => x.SinhVienID).ToPagedList(page, pageSize);
    }
    //chia trang cua mon hoc
    public IEnumerable<LopHocPhan> ListAllPaging3(string search,int page, int pageSize)
    {
        IQueryable<LopHocPhan> searchLopHoc = db.LopHocPhans;
        if (!string.IsNullOrEmpty(search))
        {
            searchLopHoc = searchLopHoc.Where(x => x.tenHocPhan.Contains(search) );
        }
        return searchLopHoc.OrderByDescending(x => x.LopHPID).ToPagedList(page, pageSize);
    }
    //chia trang cua mon hoc
    public IEnumerable<MonHoc> ListAllPaging4(string search, int page, int pageSize)
    {
        IQueryable<MonHoc> searchMonHoc = db.MonHocs;
        if (!string.IsNullOrEmpty(search))
        {
            searchMonHoc = searchMonHoc.Where(x => x.TenMonHoc.Contains(search) );
        }
        return searchMonHoc.OrderByDescending(x => x.MonHocID).ToPagedList(page, pageSize);
    }
    //dang nhap cua quan tri
    public int Login(string userName, string passWord)
    {
        var result = db.QuanTris.SingleOrDefault(x => x.UserName == userName);
        if (result == null)
        {
            return 0;
        }
        else
        {
            if (result.PassWord == passWord)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
    //dang nhap cua giang vien
    public int Login2(string userName, string passWord)
    {
        var result = db.GiangViens.SingleOrDefault(x => x.UserName == userName);
        if (result == null)
        {
            return 0;
        }
        else
        {
            if (result.PassWord == passWord)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
    //dang nhap cua sinh vien
    public int Login3(string userName, string passWord)
    {
        var result = db.SinhViens.SingleOrDefault(x => x.UserName == userName);
        if (result == null)
        {
            return 0;
        }
        else
        {
            if (result.Password == passWord)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
    //xoa giang vien
    public bool XoaGV(int id)
    {
        try
        {
            var idgv = db.GiangViens.SingleOrDefault(x => x.GiangVienID == id);
            db.GiangViens.Remove(idgv);
            db.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
       
    }
    //xoa sinh vien
    public bool XoaSV(int id)
    {
        try
        {
            var idsv = db.SinhViens.SingleOrDefault(x => x.SinhVienID == id);
            db.SinhViens.Remove(idsv);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    //xoa lop hoc phan
    public bool XoaLopHocPhan(int id)
    {
        try
        {
            var idlophoc = db.LopHocPhans.SingleOrDefault(x => x.LopHPID == id);
            db.LopHocPhans.Remove(idlophoc);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    //xoa mon hoc
    public bool XoaMonHoc(int id)
    {
        try
        {
            var idmonhoc = db.MonHocs.SingleOrDefault(x => x.MonHocID == id);
            db.MonHocs.Remove(idmonhoc);
            db.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    //them giang vien
    public long Themgv(GiangVien giangVien)
    {
        
            db.GiangViens.Add(giangVien);
            db.SaveChanges();
        return giangVien.GiangVienID;
    

    }
    //them sinh viên
    public long Themsv(SinhVien sinhVien)
    {

        db.SinhViens.Add(sinhVien);
        db.SaveChanges();
        return sinhVien.SinhVienID;


    }
    //admin thêm lop hoc de sinh vien dang ky 
    public long ThemLopHoc(LopHocPhan lophocPhan)
    {

        db.LopHocPhans.Add(lophocPhan);
        db.SaveChanges();
        return lophocPhan.LopHPID;


    }
    //them mon hoc
    public long Themmh(MonHoc monHoc)
    {

        db.MonHocs.Add(monHoc);
        db.SaveChanges();
        return monHoc.MonHocID;


    }
    // chuyển trang thái môn học
    public bool ChuyenTrangThaiMonHoc(int id)
    {
        var monhoc = db.MonHocs.Find(id);
        monhoc.isLock = !monhoc.isLock;
        db.SaveChanges();
        return monhoc.isLock;
    }

}
