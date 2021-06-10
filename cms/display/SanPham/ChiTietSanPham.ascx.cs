using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cms_display_SanPham_ChiTietSanPham : System.Web.UI.UserControl
{
    protected string id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
            id = Request.QueryString["id"];

        if (!IsPostBack)
            LayChiTietSanPham(id);
    }

    private void LayChiTietSanPham(string id)
    {
        DataTable dt=new DataTable();
        dt = HiPhucShop.SanPham.Thongtin_Sanpham_by_id(id);
        if (dt.Rows.Count > 0)
        {
            ltrAnhSanPham.Text = "<img class='imgsp' src='/pic/sanpham/" + dt.Rows[0]["AnhSP"] + @"' alt='" + dt.Rows[0]["TenSP"] + @"' />";

            ltrTenSanPham.Text = dt.Rows[0]["TenSP"].ToString();
            ltrGiaSP.Text = dt.Rows[0]["GiaSP"].ToString();

           
            

            ltrThongTinChiTiet.Text= dt.Rows[0]["MotaSP"].ToString();
        }
    }

    

   

   
}