namespace ErpBasic.Forms
{
    partial class frmUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tblSearch = new System.Windows.Forms.TableLayoutPanel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboMoldcode = new System.Windows.Forms.ComboBox();
            this.pnlDataGridView = new System.Windows.Forms.Panel();
            this.dgvMoldList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpLastEquip = new System.Windows.Forms.DateTimePicker();
            this.txtMoldName1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboWorkCenter = new System.Windows.Forms.ComboBox();
            this.dtpInDate = new System.Windows.Forms.DateTimePicker();
            this.txtMoldGroup = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMoldPrice = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.numHit = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSearch.SuspendLayout();
            this.tblSearch.SuspendLayout();
            this.pnlDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoldList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHit)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblSubTitle.Location = new System.Drawing.Point(38, 122);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(145, 29);
            this.lblSubTitle.TabIndex = 49;
            this.lblSubTitle.Text = "☷ 조회내역";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("맑은 고딕", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTitle.Location = new System.Drawing.Point(40, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 40);
            this.lblTitle.TabIndex = 47;
            this.lblTitle.Text = "사용자 정보등록";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.tblSearch);
            this.pnlSearch.Location = new System.Drawing.Point(43, 64);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1457, 55);
            this.pnlSearch.TabIndex = 48;
            // 
            // tblSearch
            // 
            this.tblSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblSearch.ColumnCount = 6;
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.90934F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.26374F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.66667F));
            this.tblSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.66667F));
            this.tblSearch.Controls.Add(this.txtCode, 1, 0);
            this.tblSearch.Controls.Add(this.label14, 4, 0);
            this.tblSearch.Controls.Add(this.label15, 2, 0);
            this.tblSearch.Controls.Add(this.txtName, 3, 0);
            this.tblSearch.Controls.Add(this.label16, 0, 0);
            this.tblSearch.Controls.Add(this.cboMoldcode, 5, 0);
            this.tblSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSearch.Location = new System.Drawing.Point(0, 0);
            this.tblSearch.Name = "tblSearch";
            this.tblSearch.RowCount = 1;
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tblSearch.Size = new System.Drawing.Size(1457, 55);
            this.tblSearch.TabIndex = 6;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(174, 17);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(312, 21);
            this.txtCode.TabIndex = 42;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.Location = new System.Drawing.Point(972, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(163, 53);
            this.label14.TabIndex = 4;
            this.label14.Text = "부서 이름";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(493, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(157, 53);
            this.label15.TabIndex = 3;
            this.label15.Text = "사용자명";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(657, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(308, 21);
            this.txtName.TabIndex = 4;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label16.Location = new System.Drawing.Point(4, 1);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 53);
            this.label16.TabIndex = 0;
            this.label16.Text = "사용자코드";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboMoldcode
            // 
            this.cboMoldcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoldcode.FormattingEnabled = true;
            this.cboMoldcode.Location = new System.Drawing.Point(1142, 17);
            this.cboMoldcode.Name = "cboMoldcode";
            this.cboMoldcode.Size = new System.Drawing.Size(311, 20);
            this.cboMoldcode.TabIndex = 39;
            // 
            // pnlDataGridView
            // 
            this.pnlDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDataGridView.Controls.Add(this.dgvMoldList);
            this.pnlDataGridView.Controls.Add(this.panel1);
            this.pnlDataGridView.Location = new System.Drawing.Point(43, 157);
            this.pnlDataGridView.Name = "pnlDataGridView";
            this.pnlDataGridView.Size = new System.Drawing.Size(1457, 658);
            this.pnlDataGridView.TabIndex = 50;
            // 
            // dgvMoldList
            // 
            this.dgvMoldList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMoldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoldList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMoldList.Location = new System.Drawing.Point(0, 0);
            this.dgvMoldList.Name = "dgvMoldList";
            this.dgvMoldList.RowTemplate.Height = 23;
            this.dgvMoldList.Size = new System.Drawing.Size(1457, 415);
            this.dgvMoldList.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1457, 243);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtCode1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpLastEquip);
            this.panel2.Controls.Add(this.txtMoldName1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.cboWorkCenter);
            this.panel2.Controls.Add(this.dtpInDate);
            this.panel2.Controls.Add(this.txtMoldGroup);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtMoldPrice);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.numHit);
            this.panel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel2.Location = new System.Drawing.Point(4, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1451, 194);
            this.panel2.TabIndex = 73;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(30, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 15);
            this.label6.TabIndex = 75;
            this.label6.Text = " ✧  금형코드";
            // 
            // txtCode1
            // 
            this.txtCode1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCode1.Location = new System.Drawing.Point(140, 47);
            this.txtCode1.Name = "txtCode1";
            this.txtCode1.Size = new System.Drawing.Size(149, 23);
            this.txtCode1.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(30, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 77;
            this.label4.Text = " ✧  금형명";
            // 
            // dtpLastEquip
            // 
            this.dtpLastEquip.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpLastEquip.Location = new System.Drawing.Point(861, 92);
            this.dtpLastEquip.Name = "dtpLastEquip";
            this.dtpLastEquip.Size = new System.Drawing.Size(148, 23);
            this.dtpLastEquip.TabIndex = 91;
            // 
            // txtMoldName1
            // 
            this.txtMoldName1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldName1.Location = new System.Drawing.Point(140, 92);
            this.txtMoldName1.Name = "txtMoldName1";
            this.txtMoldName1.Size = new System.Drawing.Size(149, 23);
            this.txtMoldName1.TabIndex = 78;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(30, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 15);
            this.label7.TabIndex = 79;
            this.label7.Text = " ✧  금형그룹";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.txtRemark.Location = new System.Drawing.Point(1141, 50);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(297, 110);
            this.txtRemark.TabIndex = 73;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.label10.Location = new System.Drawing.Point(1065, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 74;
            this.label10.Text = " ✧  비고";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(371, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 15);
            this.label13.TabIndex = 90;
            this.label13.Text = " ✧  입고일자";
            // 
            // cboWorkCenter
            // 
            this.cboWorkCenter.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWorkCenter.FormattingEnabled = true;
            this.cboWorkCenter.Location = new System.Drawing.Point(860, 47);
            this.cboWorkCenter.Name = "cboWorkCenter";
            this.cboWorkCenter.Size = new System.Drawing.Size(149, 23);
            this.cboWorkCenter.TabIndex = 88;
            // 
            // dtpInDate
            // 
            this.dtpInDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpInDate.Location = new System.Drawing.Point(501, 137);
            this.dtpInDate.Name = "dtpInDate";
            this.dtpInDate.Size = new System.Drawing.Size(148, 23);
            this.dtpInDate.TabIndex = 89;
            // 
            // txtMoldGroup
            // 
            this.txtMoldGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldGroup.Location = new System.Drawing.Point(140, 137);
            this.txtMoldGroup.Name = "txtMoldGroup";
            this.txtMoldGroup.Size = new System.Drawing.Size(149, 23);
            this.txtMoldGroup.TabIndex = 80;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(371, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 15);
            this.label8.TabIndex = 81;
            this.label8.Text = " ✧  구매금액";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(719, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 15);
            this.label12.TabIndex = 87;
            this.label12.Text = " ✧  장착작업장";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(371, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 84;
            this.label9.Text = " ✧  보장타수";
            // 
            // txtMoldPrice
            // 
            this.txtMoldPrice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMoldPrice.Location = new System.Drawing.Point(500, 92);
            this.txtMoldPrice.Name = "txtMoldPrice";
            this.txtMoldPrice.Size = new System.Drawing.Size(149, 23);
            this.txtMoldPrice.TabIndex = 82;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(719, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 15);
            this.label11.TabIndex = 86;
            this.label11.Text = " ✧  최종장착일시";
            // 
            // numHit
            // 
            this.numHit.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.numHit.Location = new System.Drawing.Point(500, 47);
            this.numHit.Name = "numHit";
            this.numHit.Size = new System.Drawing.Size(148, 23);
            this.numHit.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 29);
            this.label3.TabIndex = 72;
            this.label3.Text = "☷ 입력정보";
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 830);
            this.Controls.Add(this.lblSubTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlDataGridView);
            this.Name = "frmUsers";
            this.Text = "frmUsers";
            this.pnlSearch.ResumeLayout(false);
            this.tblSearch.ResumeLayout(false);
            this.tblSearch.PerformLayout();
            this.pnlDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoldList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblSubTitle;
        protected System.Windows.Forms.Label lblTitle;
        protected System.Windows.Forms.Panel pnlSearch;
        protected System.Windows.Forms.TableLayoutPanel tblSearch;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboMoldcode;
        protected System.Windows.Forms.Panel pnlDataGridView;
        private System.Windows.Forms.DataGridView dgvMoldList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCode1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpLastEquip;
        private System.Windows.Forms.TextBox txtMoldName1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboWorkCenter;
        private System.Windows.Forms.DateTimePicker dtpInDate;
        private System.Windows.Forms.TextBox txtMoldGroup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMoldPrice;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numHit;
        protected System.Windows.Forms.Label label3;
    }
}