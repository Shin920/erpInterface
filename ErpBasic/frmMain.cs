using ErpBasic.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinForms = System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ErpBasic
{
    public partial class frmMain : Form
    {
        private DataTable dtMenu;
        private Panel panelTree;      // 좌측 트리 호스트
        private WinForms.TreeView treeView1;
        private string lastButtonName; // 같은 버튼 토글용
        public frmMain()
        {
            InitializeComponent();

            // 필수 이벤트 연결
            this.Load += frmMain_Load;
            this.MdiChildActivate += frmMain_MdiChildActivate;


            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += TabControl1_DrawItem;
            tabControl1.MouseDown += TabControl1_MouseDown;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            // 탭을 고정 크기로 쓰고(OwnerDrawFixed는 보통 Fixed가 안정적)
            tabControl1.SizeMode = TabSizeMode.Fixed;
            // 기본 크기(폭/높이) 넉넉하게
            tabControl1.ItemSize = new Size(100, 30);
            // 탭 내부 여백(글자 양옆/위아래 패딩)
            tabControl1.Padding = new Point(20, 3);


            // MDI 자식 활성화 시 탭 싱크
            this.MdiChildActivate += frmMain_MdiChildActivate;

            // 좌측 트리 패널/트리뷰 준비 → FlowLayoutPanel에 넣어둠
            panelTree = new Panel { Name = "panelTree", Size = new Size(200, 280), Visible = false };
            treeView1 = new WinForms.TreeView { Dock = DockStyle.Fill, ItemHeight = 20 };
            treeView1.AfterSelect += TreeView1_AfterSelect;
            panelTree.Controls.Add(treeView1);
            flowLayoutPanel1.Controls.Add(panelTree);
        }

        // 앱 시작 시 메뉴 데이터 → 상단메뉴/좌측버튼 바인딩
        private void frmMain_Load(object sender, EventArgs e)
        {
            // 디자이너에 기본 TabPage가 남아있을 수 있으니 깨끗이 비움
            tabControl1.TabPages.Clear();

            dtMenu = MenuService.GetUserMenuList();
            BuildMenuStrip();
            BuildLeftButtons();

            // panelTree가 아직 추가 안돼있으면 추가
            if (!flowLayoutPanel1.Controls.Contains(panelTree))
                flowLayoutPanel1.Controls.Add(panelTree);

            // 항상 맨 아래로 보내고, 시작은 숨김
            flowLayoutPanel1.Controls.SetChildIndex(panelTree, flowLayoutPanel1.Controls.Count - 1);
            panelTree.Visible = false;
        }

        // ============ 상단 MenuStrip 생성 ============
        private void BuildMenuStrip()
        {
            menuStrip1.Items.Clear();

            var dv0 = new DataView(dtMenu)
            {
                RowFilter = "Menu_Level = 1",
                Sort = "Sort_Index"
            };

            for (int i = 0; i < dv0.Count; i++)
            {
                var f = new ToolStripMenuItem
                {
                    Name = $"f_menu{dv0[i]["Screen_Code"]}",
                    Text = dv0[i]["Menu_Name"].ToString()
                };
                menuStrip1.Items.Add(f);

                var dv1 = new DataView(dtMenu)
                {
                    RowFilter = $"Menu_Level = 2 AND Parent_Screen_Code = {dv0[i]["Screen_Code"]}",
                    Sort = "Sort_Index"
                };

                for (int k = 0; k < dv1.Count; k++)
                {
                    var s = new ToolStripMenuItem
                    {
                        Name = $"s_menu{dv1[k]["Screen_Code"]}",
                        Text = dv1[k]["Menu_Name"].ToString(),
                        Tag = dv1[k]["Program_Name"].ToString()
                    };
                    s.Click += (ss, ee) =>
                    {
                        var mi = (ToolStripMenuItem)ss;
                        OpenOrCreateForm(mi.Tag?.ToString()?.Trim(), mi.Text);
                    };
                    f.DropDownItems.Add(s);
                }
            }
        }

        // ============ 좌측 대분류 버튼 생성 ============
        private void BuildLeftButtons()
        {
            // 0) 메뉴 데이터 체크
            if (dtMenu == null || dtMenu.Rows.Count == 0)
            {
                WinForms.MessageBox.Show("메뉴 데이터가 없습니다. MenuService.GetUserMenuList() 호출/반환을 확인하세요.");
                return;
            }

            var dv0 = new DataView(dtMenu)
            {
                RowFilter = "Menu_Level = 1",
                Sort = "Sort_Index"
            };
            if (dv0.Count == 0)
            {
                WinForms.MessageBox.Show("대분류(Menu_Level=1)가 없습니다.");
                return;
            }

            // 1) 완전 리셋 후 다시 채움 (panelTree 포함 모두 정리)
            flowLayoutPanel1.SuspendLayout();
            try
            {
                flowLayoutPanel1.Controls.Clear();

                // 2) 대분류 버튼들 추가 (Tag에는 Screen_Code 저장)
                for (int i = 0; i < dv0.Count; i++)
                {
                    var screenCode = Convert.ToInt32(dv0[i]["Screen_Code"]);

                    var btn = new WinForms.Button
                    {
                        Name = $"f_menu{screenCode}",
                        Text = dv0[i]["Menu_Name"].ToString(),
                        Tag = screenCode,                         // ★ 중요: Parent_Screen_Code로 직접 사용
                        Height = 56,
                        Width = flowLayoutPanel1.ClientSize.Width - 6,
                        Margin = new Padding(3, 0, 3, 0),
                        BackColor = Color.FromArgb(97, 101, 110),
                        ForeColor = Color.White,
                        FlatStyle = WinForms.FlatStyle.Flat,
                        Font = new Font("맑은 고딕", 12, FontStyle.Bold)
                    };
                    btn.FlatAppearance.BorderColor = btn.BackColor;

                    btn.Click += (ss, ee) =>
                    {
                        var b = (WinForms.Button)ss;

                        // 같은 버튼 클릭 → 트리 토글
                        if (lastButtonName == b.Name)
                        {
                            panelTree.Visible = !panelTree.Visible;
                            if (!panelTree.Visible) lastButtonName = null;
                            return;
                        }

                        flowLayoutPanel1.SuspendLayout();

                        // 버튼 바로 아래로 panelTree 끼워넣기
                        int buttonIndex = flowLayoutPanel1.Controls.IndexOf(b);
                        int targetIndex = Math.Min(buttonIndex + 1, flowLayoutPanel1.Controls.Count - 1);

                        // 먼저 끝으로 뺐다가 정확한 위치로
                        if (!flowLayoutPanel1.Controls.Contains(panelTree))
                            flowLayoutPanel1.Controls.Add(panelTree);

                        flowLayoutPanel1.Controls.SetChildIndex(panelTree, flowLayoutPanel1.Controls.Count - 1);
                        flowLayoutPanel1.Controls.SetChildIndex(panelTree, targetIndex);

                        flowLayoutPanel1.ResumeLayout(true);

                        // 트리 바인딩 (Tag의 Screen_Code 사용)
                        int parentCode = (int)b.Tag;
                        BindTreeForParentCode(parentCode);

                        panelTree.Visible = true;
                        lastButtonName = b.Name;
                    };

                    flowLayoutPanel1.Controls.Add(btn);
                }

                // 3) panelTree가 없으면 생성, 항상 맨 아래로 고정 (초기 숨김)
                if (panelTree == null)
                {
                    panelTree = new WinForms.Panel
                    {
                        Name = "panelTree",
                        Size = new Size(200, 280),
                        Visible = false
                    };
                    treeView1 = new WinForms.TreeView
                    {
                        Dock = WinForms.DockStyle.Fill,
                        ItemHeight = 20
                    };
                    treeView1.AfterSelect += TreeView1_AfterSelect;
                    panelTree.Controls.Add(treeView1);
                }

                if (!flowLayoutPanel1.Controls.Contains(panelTree))
                    flowLayoutPanel1.Controls.Add(panelTree);

                flowLayoutPanel1.Controls.SetChildIndex(panelTree, flowLayoutPanel1.Controls.Count - 1);
                panelTree.Visible = false;
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout(true);
            }
        }

        private void BindTreeForParentCode(int parentScreenCode)
        {
            treeView1.Nodes.Clear();

            var dv1 = new DataView(dtMenu)
            {
                RowFilter = $"Menu_Level = 2 AND Parent_Screen_Code = {parentScreenCode}",
                Sort = "Sort_Index"
            };

            for (int i = 0; i < dv1.Count; i++)
            {
                var node = new WinForms.TreeNode(dv1[i]["Menu_Name"].ToString())
                {
                    Tag = $"{dv1[i]["Screen_Code"]}|{dv1[i]["Program_Name"]}"
                };
                treeView1.Nodes.Add(node);
            }
        }

        
    

       // 트리에서 소분류 선택 → 폼 열기
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag == null) return;
            var parts = e.Node.Tag.ToString().Split('|');
            if (parts.Length == 2)
            {
                OpenOrCreateForm(parts[1].Trim(), e.Node.Text.Trim());
            }
        }

        
        

        // ============ 폼 열기 (이미 열려있으면 활성화 + 탭 선택) ============
        private void OpenOrCreateForm(string programName, string formText)
        {
            if (string.IsNullOrWhiteSpace(programName))
            {
                MessageBox.Show("프로그램이 등록되어 있지 않습니다.");
                return;
            }

            string rootNs = typeof(frmMain).Namespace; // FinalProject
            var frmType = Type.GetType($"{rootNs}.Forms.{programName}") ??
                          Type.GetType($"{rootNs}.{programName}");

            if (frmType == null || !typeof(Form).IsAssignableFrom(frmType))
            {
                MessageBox.Show($"[{programName}] 폼을 찾을 수 없습니다.");
                return;
            }

            // 이미 열려 있으면 활성화 + 해당 탭 선택
            foreach (Form open in Application.OpenForms)
            {
                if (open.GetType() == frmType)
                {
                    open.Activate();
                    open.BringToFront();

                    // 해당 폼의 탭이 있으면 선택
                    var page = tabControl1.TabPages.Cast<TabPage>()
                                  .FirstOrDefault(tp => tp.Tag == open);
                    if (page != null) tabControl1.SelectedTab = page;
                    return;
                }
            }

            // 새로 열기
            var frm = (Form)Activator.CreateInstance(frmType);
            frm.MdiParent = this;
            frm.Text = formText;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            // 탭은 frmMain_MdiChildActivate에서 자동 생성/연결
        }

        // ============ 탭-연동: MDI 자식 활성화 시 탭 생성/선택 ============
        private void frmMain_MdiChildActivate(object sender, EventArgs e)
        {
            var active = this.ActiveMdiChild;
            if (active == null) return;

            active.WindowState = FormWindowState.Maximized;

            // 이미 탭 연결된 자식이면 그 탭 선택
            if (active.Tag is TabPage existing)
            {
                if (tabControl1.TabPages.Contains(existing))
                    tabControl1.SelectedTab = existing;
                return;
            }

            // 새 자식 → 탭 생성 & 양방향 연결
            var tp = new TabPage(active.Text + "  ")
            {
                Tag = active // 탭 → 폼
            };
            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedTab = tp;

            active.Tag = tp; // 폼 → 탭

            // 자식폼 닫히면 탭 제거
            active.FormClosed += (s2, e2) =>
            {
                if (!tp.IsDisposed && tabControl1.TabPages.Contains(tp))
                    tp.Dispose();
            };
        }

        // 탭 선택 시 해당 폼 활성화
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab?.Tag is Form frm && !frm.IsDisposed)
            {
                frm.Select();
                frm.Activate();
                frm.BringToFront();
            }
        }

        // 탭 텍스트 + X 그리기
        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tab = tabControl1.TabPages[e.Index];
            var rect = e.Bounds;

            // 탭 텍스트
            var textRect = new Rectangle(rect.X + 8, rect.Y + 6, rect.Width - 24, rect.Height - 6);
            TextRenderer.DrawText(e.Graphics, tab.Text, e.Font, textRect, Color.Black,
                                  TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            // X 영역(우측)
            var xRect = new Rectangle(rect.Right - 18, rect.Top + 6, 12, 12);
            e.Graphics.DrawString("x", e.Font, Brushes.DarkGray, xRect.Location);
        }

        // X 클릭으로 탭 닫기(=폼 닫기)
        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var xRect = new Rectangle(r.Right - 18, r.Top + 6, 12, 12);
                if (xRect.Contains(e.Location))
                {
                    // 해당 탭의 폼 닫기 → FormClosed에서 탭 정리됨
                    if (tabControl1.TabPages[i].Tag is Form f && !f.IsDisposed)
                        f.Close();
                    break;
                }
            }
        }

        private void tabControl1_MouseDown_1(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var xRect = new Rectangle(r.Right - 18, r.Top + 6, 12, 12);
                if (xRect.Contains(e.Location))
                {
                    // 폼 연결된 탭이면 폼 닫기 (FormClosed에서 탭 자동 정리)
                    if (tabControl1.TabPages[i].Tag is Form f && !f.IsDisposed)
                    {
                        f.Close();
                    }
                    else
                    {
                        // 초기 빈 탭 등 Tag 없는 경우 → 그냥 탭 제거
                        tabControl1.TabPages.RemoveAt(i);
                    }
                    break;
                }
            }
        }
    }
}
