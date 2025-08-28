using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIMaking
{
    public static class CommonUtil
    {
        public static void OpenCreateForm(Form mdiParent, string programName, string formText = null)
        {
            // 같은 네임스페이스 안의 클래스를 찾기 위해 현재 어셈블리/네임스페이스 사용
            string ns = typeof(CommonUtil).Namespace; // "MenuDemo"
            // Forms 폴더에 있다면 네임스페이스가 MenuDemo.Forms 일 가능성 큼
            // 우선순위로 MenuDemo.Forms.programName → 실패 시 MenuDemo.programName
            Type frmType = Type.GetType($"{ns}.Forms.{programName}") ??
                           Type.GetType($"{ns}.{programName}");

            if (frmType == null || !typeof(Form).IsAssignableFrom(frmType))
            {
                MessageBox.Show($"[{programName}] 폼을 찾을 수 없습니다.");
                return;
            }

            // 이미 열려 있으면 활성화
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == frmType)
                {
                    f.Activate();
                    f.BringToFront();
                    if (f.MdiParent == mdiParent) return;
                }
            }

            // 새로 생성
            try
            {
                var frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = mdiParent;
                if (!string.IsNullOrWhiteSpace(formText))
                    frm.Text = formText.Trim();
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("폼 생성 중 오류: " + ex.Message);
            }
        }
    }
}
