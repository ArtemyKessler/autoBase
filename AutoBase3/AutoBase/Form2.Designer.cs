namespace AutoBase
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.autoBaseDataSet = new AutoBase.AutoBaseDataSet();
            this.ridersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ridersTableAdapter = new AutoBase.AutoBaseDataSetTableAdapters.RidersTableAdapter();
            this.ridersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.addBtn = new System.Windows.Forms.Button();
            this.delBtn = new System.Windows.Forms.Button();
            this.insBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(486, 202);
            this.dgv.TabIndex = 0;
            // 
            // autoBaseDataSet
            // 
            this.autoBaseDataSet.DataSetName = "AutoBaseDataSet";
            this.autoBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ridersBindingSource
            // 
            this.ridersBindingSource.DataMember = "Riders";
            this.ridersBindingSource.DataSource = this.autoBaseDataSet;
            // 
            // ridersTableAdapter
            // 
            this.ridersTableAdapter.ClearBeforeFill = true;
            // 
            // ridersBindingSource1
            // 
            this.ridersBindingSource1.DataMember = "Riders";
            this.ridersBindingSource1.DataSource = this.autoBaseDataSet;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(339, 208);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(135, 40);
            this.addBtn.TabIndex = 1;
            this.addBtn.TabStop = false;
            this.addBtn.Text = "Добавить";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(12, 208);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(135, 40);
            this.delBtn.TabIndex = 2;
            this.delBtn.TabStop = false;
            this.delBtn.Text = "Удалить";
            this.delBtn.UseVisualStyleBackColor = true;
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // insBtn
            // 
            this.insBtn.Location = new System.Drawing.Point(178, 208);
            this.insBtn.Name = "insBtn";
            this.insBtn.Size = new System.Drawing.Size(135, 40);
            this.insBtn.TabIndex = 3;
            this.insBtn.TabStop = false;
            this.insBtn.Text = "Изменить";
            this.insBtn.UseVisualStyleBackColor = true;
            this.insBtn.Click += new System.EventHandler(this.insBtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 260);
            this.Controls.Add(this.insBtn);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dgv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Водители";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ridersBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv;
        private AutoBaseDataSet autoBaseDataSet;
        private System.Windows.Forms.BindingSource ridersBindingSource;
        private AutoBaseDataSetTableAdapters.RidersTableAdapter ridersTableAdapter;
        private System.Windows.Forms.BindingSource ridersBindingSource1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button delBtn;
        private System.Windows.Forms.Button insBtn;
    }
}