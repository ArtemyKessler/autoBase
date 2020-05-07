namespace AutoBase
{
    partial class Home
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.RidersBtn = new System.Windows.Forms.Button();
            this.CarsBtn = new System.Windows.Forms.Button();
            this.VoyageBtn = new System.Windows.Forms.Button();
            this.ListBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RidersBtn
            // 
            this.RidersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RidersBtn.Location = new System.Drawing.Point(13, 109);
            this.RidersBtn.Name = "RidersBtn";
            this.RidersBtn.Size = new System.Drawing.Size(259, 50);
            this.RidersBtn.TabIndex = 0;
            this.RidersBtn.TabStop = false;
            this.RidersBtn.Text = "Водители";
            this.RidersBtn.UseVisualStyleBackColor = true;
            this.RidersBtn.Click += new System.EventHandler(this.RidersBtn_Click);
            // 
            // CarsBtn
            // 
            this.CarsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CarsBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CarsBtn.Location = new System.Drawing.Point(13, 165);
            this.CarsBtn.Name = "CarsBtn";
            this.CarsBtn.Size = new System.Drawing.Size(259, 50);
            this.CarsBtn.TabIndex = 1;
            this.CarsBtn.TabStop = false;
            this.CarsBtn.Text = "Автомобили";
            this.CarsBtn.UseVisualStyleBackColor = true;
            this.CarsBtn.Click += new System.EventHandler(this.CarsBtn_Click);
            // 
            // VoyageBtn
            // 
            this.VoyageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VoyageBtn.Location = new System.Drawing.Point(13, 221);
            this.VoyageBtn.Name = "VoyageBtn";
            this.VoyageBtn.Size = new System.Drawing.Size(259, 50);
            this.VoyageBtn.TabIndex = 2;
            this.VoyageBtn.TabStop = false;
            this.VoyageBtn.Text = "Рейсы";
            this.VoyageBtn.UseVisualStyleBackColor = true;
            this.VoyageBtn.Click += new System.EventHandler(this.VoyageBtn_Click);
            // 
            // ListBtn
            // 
            this.ListBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBtn.Location = new System.Drawing.Point(12, 277);
            this.ListBtn.Name = "ListBtn";
            this.ListBtn.Size = new System.Drawing.Size(259, 50);
            this.ListBtn.TabIndex = 3;
            this.ListBtn.TabStop = false;
            this.ListBtn.Text = "Путевые Листы";
            this.ListBtn.UseVisualStyleBackColor = true;
            this.ListBtn.Click += new System.EventHandler(this.ListBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(71, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(174, 103);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 339);
            this.Controls.Add(this.ListBtn);
            this.Controls.Add(this.VoyageBtn);
            this.Controls.Add(this.CarsBtn);
            this.Controls.Add(this.RidersBtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoBase";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RidersBtn;
        private System.Windows.Forms.Button CarsBtn;
        private System.Windows.Forms.Button VoyageBtn;
        private System.Windows.Forms.Button ListBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

