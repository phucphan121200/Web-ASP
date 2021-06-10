using System;
using System.Data;

public partial class cms_admin_SanPham_QuanLyDonHang_DonHang_HienThi : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LayDonHang();
    }

    private void LayDonHang()
    {
        DataTable dt = new DataTable();
        dt = HiPhucShop.DonDatHang.Thongtin_Dondathang_Desc();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            ltrDonHang.Text += @"
<tr id='maDong_" + dt.Rows[i]["MaDonDatHang"] + @"'>
    <td class='cotMa'>" + dt.Rows[i]["MaDonDatHang"] + @"</td>
    <td class='cotDonGia'>" + dt.Rows[i]["NgayTao"] + @"</td>
    <td class='cotDonGia'>" + dt.Rows[i]["ThanhTienDH"] + @"</td>
    <td class='cotDonGia'>" + HienThiTinhTrangDonHang(dt.Rows[i]["TinhTrangDonHang"].ToString()) + @"</td>
    <td class='cotDonGia'>
        Mã KH: " + dt.Rows[i]["MaKH"] + @"<br/>
        Tên KH: " + dt.Rows[i]["TenKH"] + @"<br/>
        Số điện thoại KH: " + dt.Rows[i]["sdtKH"] + @"<br/>
        Email KH: " + dt.Rows[i]["EmailKH"] + @"<br/>
    </td>
    <td class='cotCongCu'>
        <a href="+ "\"javascript:window.open('cms/admin/sanpham/quanlydonhang/chitietdonhang.aspx?id=" + dt.Rows[i]["MaDonDatHang"] + "')\"" + @" class='xem' title='Xem'></a>
        <a href='javascript:XoaDonHang(" + dt.Rows[i]["MaDonDatHang"] + @")' class='xoa' title='Xóa'></a>
    </td> 
</tr>
";
        }

    }

    private string HienThiTinhTrangDonHang(string maTinhTrang)
    {
        string s = maTinhTrang;
        switch (maTinhTrang)
        {
            case "1":
                s = "Khách hàng đã thanh toán";
                break;

            case "0":
                s = "Khách hàng hủy thanh toán";
                break;

            default:
                s = "Chờ KH thanh toán";
                break;
        }

        return s;
    }
}