using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIMaking;
using UIMaking.Services;

namespace UIMaking
{
    public partial class frmMain : Form
    {
        private DataTable dtMenu;
        private Panel panelTree;       // 좌측 트리뷰를 담는 패널
        private TreeView treeView1;
        private string lastButtonName; // 같은 버튼 토글용
        

        public frmMain()
        {
            InitializeComponent();

            // (디자이너에서 배치했다면 아래 생성부는 생략 가능)
            // --- MenuStrip ---
            if (this.MainMenuStrip == null)
            {
                var ms = new MenuStrip { Name = "menuStrip1", Dock = DockStyle.Top };
                this.MainMenuStrip = ms;
                this.Controls.Add(ms);
            }

            // --- 좌측 FlowLayoutPanel ---
            var flp = this.Controls["flowLayoutPanel1"] as FlowLayoutPanel;
            if (flp == null)
            {
                flp = new FlowLayoutPanel
                {
                    Name = "flowLayoutPanel1",
                    Dock = DockStyle.Left,
                    Width = 220,
                    AutoScroll = true,
                    BackColor = Color.FromArgb(97, 101, 110)
                };
                this.Controls.Add(flp);
            }

            // --- 상단 TabControl ---
         
            // MDI 설정
            this.IsMdiContainer = true;
            this.MdiChildActivate += FrmMain_MdiChildActivate;

            // 좌측 트리 패널 & 트리
            panelTree = new Panel
            {
                Name = "panelTree",
                Size = new Size(200, 300),
                Visible = false
            };
            treeView1 = new TreeView
            {
                Dock = DockStyle.Fill,
                ItemHeight = 20
            };
            treeView1.AfterSelect += TreeView1_AfterSelect;
            panelTree.Controls.Add(treeView1);
            flp.Controls.Add(panelTree);
        }
        

        // ===========================
        // 상단 MenuStrip 생성
        // ===========================
        private void BuildMenuStrip()
        {
            var ms = this.MainMenuStrip;
            ms.Items.Clear();

            var dv0 = new DataView(dtMenu)
            {
                RowFilter = "Menu_Level = 1",
                Sort = "Sort_Index"
            };

            for (int i = 0; i < dv0.Count; i++)
            {
                var f_menu = new ToolStripMenuItem
                {
                    Name = $"f_menu{dv0[i]["Screen_Code"]}",
                    Text = dv0[i]["Menu_Name"].ToString()
                };
                ms.Items.Add(f_menu);

                var dv1 = new DataView(dtMenu)
                {
                    RowFilter = $"Menu_Level = 2 AND Parent_Screen_Code = {dv0[i]["Screen_Code"]}",
                    Sort = "Sort_Index"
                };

                for (int k = 0; k < dv1.Count; k++)
                {
                    var s_menu = new ToolStripMenuItem
                    {
                        Name = $"s_menu{dv1[k]["Screen_Code"]}",
                        Text = dv1[k]["Menu_Name"].ToString(),
                        Tag = dv1[k]["Program_Name"].ToString()
                    };
                    s_menu.Click += (s, e) =>
                    {
                        var mi = (ToolStripMenuItem)s;
                        OpenOrCreateForm(mi.Tag?.ToString()?.Trim(), mi.Text);
                    };
                    f_menu.DropDownItems.Add(s_menu);
                }
            }

            ms.ItemAdded += (s, e) =>
            {
                // 시스템 기본 메뉴(닫기/최소화 등) 숨김
                if (string.IsNullOrEmpty(e.Item.Text) ||
                    e.Item.Text.Contains("닫기") ||
                    e.Item.Text.Contains("최소화") ||
                    e.Item.Text.Contains("이전 크기"))
                {
                    e.Item.Visible = false;
                }
            };
        }

        // ===========================
        // 좌측 대분류 버튼 + 트리 (토글)
        // ===========================
        private void BuildLeftButtonsAndTree()
        {
            var flp = (FlowLayoutPanel)this.Controls["flowLayoutPanel1"];
            // 기존 버튼 제거(트리 패널은 유지)
            for (int i = flp.Controls.Count - 1; i >= 0; i--)
            {
                if (flp.Controls[i] != panelTree)
                    flp.Controls.RemoveAt(i);
            }

            var dv0 = new DataView(dtMenu)
            {
                RowFilter = "Menu_Level = 1",
                Sort = "Sort_Index"
            };

            for (int i = 0; i < dv0.Count; i++)
            {
                var btn = new Button
                {
                    Name = $"f_menu{dv0[i]["Screen_Code"]}",
                    Text = dv0[i]["Menu_Name"].ToString(),
                    Tag = i, // 인덱스 저장
                    Dock = DockStyle.Top,
                    Width = flp.Width - 6,
                    Height = 60,
                    Margin = new Padding(3, 0, 3, 0),
                    BackColor = Color.FromArgb(97, 101, 110),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("맑은 고딕", 12, FontStyle.Bold)
                };
                btn.FlatAppearance.BorderColor = btn.BackColor;

                btn.Click += (s, e) =>
                {
                    var b = (Button)s;

                    // 같은 버튼이면 트리 토글
                    if (lastButtonName == b.Name)
                    {
                        panelTree.Visible = !panelTree.Visible;
                        if (!panelTree.Visible) lastButtonName = null;
                        return;
                    }

                    // 트리 패널 위치를 "해당 버튼 바로 아래"로 이동
                    var targetIndex = flp.Controls.GetChildIndex(b);
                    flp.Controls.SetChildIndex(panelTree, targetIndex + 1);
                    flp.Invalidate();

                    // 트리 바인딩
                    BindTreeForParentScreen(b.Name);

                    panelTree.Visible = true;
                    lastButtonName = b.Name;
                };

                flp.Controls.Add(btn);
            }
        }

        private void BindTreeForParentScreen(string parentButtonName)
        {
            treeView1.Nodes.Clear();

            // 버튼 이름에서 Screen_Code 추출
            // ex) "f_menu100" → 100
            int parentCode = int.Parse(parentButtonName.Replace("f_menu", ""));

            var dv1 = new DataView(dtMenu)
            {
                RowFilter = $"Menu_Level = 2 AND Parent_Screen_Code = {parentCode}",
                Sort = "Sort_Index"
            };

            for (int i = 0; i < dv1.Count; i++)
            {
                var node = new TreeNode(dv1[i]["Menu_Name"].ToString())
                {
                    Tag = $"{dv1[i]["Screen_Code"]}|{dv1[i]["Program_Name"]}"
                };
                treeView1.Nodes.Add(node);
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null) return;
            var parts = e.Node.Tag.ToString().Split('|'); // "ScreenCode|ProgramName"
            if (parts.Length == 2)
            {
                string program = parts[1].Trim();
                string formText = e.Node.Text.Trim();
                OpenOrCreateForm(program, formText);
            }
        }

        // ===========================
        // 폼 열기 (여기선 CommonUtil 안 쓰고 내부로)
        // ===========================
        private void OpenOrCreateForm(string programName, string formText)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                MessageBox.Show("프로그램이 등록되어 있지 않습니다.");
                return;
            }

            string ns = typeof(frmMain).Namespace; // "MenuDemo"
            Type frmType = Type.GetType($"{ns}.Forms.{programName}") ??
                           Type.GetType($"{ns}.{programName}");

            if (frmType == null)
            {
                MessageBox.Show($"[{programName}] 폼을 찾을 수 없습니다.");
                return;
            }

            // 이미 열린 폼이면 활성화
            foreach (Form f in Application.OpenForms)
            {
                if (f.GetType() == frmType)
                {
                    f.Activate();
                    f.BringToFront();
                    return;
                }
            }

            // 새로 열기
            try
            {
                var frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                if (!string.IsNullOrWhiteSpace(formText))
                    frm.Text = formText;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("폼 생성 오류: " + ex.Message);
            }
        }

        // ===========================
        // 탭-연동 MDI
        // ===========================
        private void FrmMain_MdiChildActivate(object sender, EventArgs e)
        {
            // 자식 폼 있으면 최대화만
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            }
        }
       

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            // 1) 메뉴 데이터 로딩
            dtMenu = MenuService.GetUserMenuList();

            // 2) 상단 메뉴스트립 작성
            BuildMenuStrip();

            // 3) 좌측 대분류 버튼 + 트리
            BuildLeftButtonsAndTree();
        }
    }
}
