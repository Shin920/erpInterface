using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIMaking.Services
{
    public static class MenuService
    {
        // 샘플 메뉴 스키마:
        // Menu_Level(1=대분류, 2=소분류), Screen_Code, Parent_Screen_Code, Sort_Index, Menu_Name, Program_Name
        public static DataTable GetUserMenuList()
        {
            var dt = new DataTable();
            dt.Columns.Add("Menu_Level", typeof(int));
            dt.Columns.Add("Screen_Code", typeof(int));
            dt.Columns.Add("Parent_Screen_Code", typeof(int));
            dt.Columns.Add("Sort_Index", typeof(int));
            dt.Columns.Add("Menu_Name", typeof(string));
            dt.Columns.Add("Program_Name", typeof(string));

            // 대분류
            dt.Rows.Add(1, 100, 0, 1, "기준정보", "");
            dt.Rows.Add(1, 200, 0, 2, "업무", "");
            dt.Rows.Add(1, 300, 0, 3, "생산관리", "");
            dt.Rows.Add(1, 400, 0, 4, "구매관리", "");

            // 소분류 (대분류: 100)
            dt.Rows.Add(2, 110, 100, 1, "거래처 관리", "frmCustomers");
            dt.Rows.Add(2, 120, 100, 2, "제품 관리", "frmProducts"); 
            dt.Rows.Add(2, 130, 100, 3, "사용자 관리", "frmUsers");

            // 소분류 (대분류: 200)
            dt.Rows.Add(2, 210, 200, 1, "주문 등록", "frmOrders");
            dt.Rows.Add(2, 220, 200, 2, "출고 관리", "frmShipments");

            // 소분류 (대분류: 300)
            dt.Rows.Add(2, 310, 300, 1, "공정 관리", "frmWorkbench");
            

            return dt;
        }
    }
}
