namespace Editor_de_Niveles
{
    partial class Editor
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
            this.btn_load_level = new System.Windows.Forms.Button();
            this.pb_current_level = new System.Windows.Forms.PictureBox();
            this.ofd_select_level = new System.Windows.Forms.OpenFileDialog();
            this.nud_rows = new System.Windows.Forms.NumericUpDown();
            this.nud_cols = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_haga_click = new System.Windows.Forms.Label();
            this.btn_paint_field = new System.Windows.Forms.Button();
            this.btn_save_level = new System.Windows.Forms.Button();
            this.nud_eggs_number = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_snake_weight_lvl10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_current_level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_eggs_number)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_load_level
            // 
            this.btn_load_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load_level.Location = new System.Drawing.Point(650, 22);
            this.btn_load_level.Name = "btn_load_level";
            this.btn_load_level.Size = new System.Drawing.Size(106, 46);
            this.btn_load_level.TabIndex = 7;
            this.btn_load_level.Text = "Cargar";
            this.btn_load_level.UseVisualStyleBackColor = true;
            this.btn_load_level.Click += new System.EventHandler(this.Btn_load_txt_Click);
            // 
            // pb_current_level
            // 
            this.pb_current_level.Location = new System.Drawing.Point(12, 34);
            this.pb_current_level.Name = "pb_current_level";
            this.pb_current_level.Size = new System.Drawing.Size(500, 500);
            this.pb_current_level.TabIndex = 6;
            this.pb_current_level.TabStop = false;
            this.pb_current_level.Paint += new System.Windows.Forms.PaintEventHandler(this.Pb_current_level_Paint);
            this.pb_current_level.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pb_current_level_MouseClick);
            // 
            // ofd_select_level
            // 
            this.ofd_select_level.Filter = "Mat files(*.MAT)|*.MAT|All files (*.*)|*.*";
            // 
            // nud_rows
            // 
            this.nud_rows.Location = new System.Drawing.Point(535, 22);
            this.nud_rows.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nud_rows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_rows.Name = "nud_rows";
            this.nud_rows.Size = new System.Drawing.Size(47, 20);
            this.nud_rows.TabIndex = 8;
            this.nud_rows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_rows.ValueChanged += new System.EventHandler(this.Nud_rows_ValueChanged);
            // 
            // nud_cols
            // 
            this.nud_cols.Location = new System.Drawing.Point(535, 65);
            this.nud_cols.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nud_cols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_cols.Name = "nud_cols";
            this.nud_cols.Size = new System.Drawing.Size(47, 20);
            this.nud_cols.TabIndex = 9;
            this.nud_cols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nud_cols.ValueChanged += new System.EventHandler(this.Nud_cols_ValueChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(518, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 46);
            this.button1.TabIndex = 10;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // lbl_haga_click
            // 
            this.lbl_haga_click.AutoSize = true;
            this.lbl_haga_click.Location = new System.Drawing.Point(127, 9);
            this.lbl_haga_click.Name = "lbl_haga_click";
            this.lbl_haga_click.Size = new System.Drawing.Size(272, 13);
            this.lbl_haga_click.TabIndex = 11;
            this.lbl_haga_click.Text = "Haga click en la casilla que desee agregar un obstaculo";
            this.lbl_haga_click.Visible = false;
            // 
            // btn_paint_field
            // 
            this.btn_paint_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_paint_field.Location = new System.Drawing.Point(518, 198);
            this.btn_paint_field.Name = "btn_paint_field";
            this.btn_paint_field.Size = new System.Drawing.Size(102, 46);
            this.btn_paint_field.TabIndex = 12;
            this.btn_paint_field.Text = "Pintar";
            this.btn_paint_field.UseVisualStyleBackColor = true;
            this.btn_paint_field.Click += new System.EventHandler(this.Btn_paint_field_Click);
            // 
            // btn_save_level
            // 
            this.btn_save_level.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save_level.Location = new System.Drawing.Point(650, 74);
            this.btn_save_level.Name = "btn_save_level";
            this.btn_save_level.Size = new System.Drawing.Size(106, 46);
            this.btn_save_level.TabIndex = 13;
            this.btn_save_level.Text = "Salvar";
            this.btn_save_level.UseVisualStyleBackColor = true;
            this.btn_save_level.Click += new System.EventHandler(this.Btn_save_level_Click);
            // 
            // nud_eggs_number
            // 
            this.nud_eggs_number.Location = new System.Drawing.Point(535, 111);
            this.nud_eggs_number.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_eggs_number.Name = "nud_eggs_number";
            this.nud_eggs_number.Size = new System.Drawing.Size(47, 20);
            this.nud_eggs_number.TabIndex = 14;
            this.nud_eggs_number.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_eggs_number.ValueChanged += new System.EventHandler(this.Nud_eggs_number_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(561, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tamaño de la Serpiente en Nivel 10 (por casillas)";
            // 
            // lbl_snake_weight_lvl10
            // 
            this.lbl_snake_weight_lvl10.AutoSize = true;
            this.lbl_snake_weight_lvl10.Location = new System.Drawing.Point(657, 167);
            this.lbl_snake_weight_lvl10.Name = "lbl_snake_weight_lvl10";
            this.lbl_snake_weight_lvl10.Size = new System.Drawing.Size(13, 13);
            this.lbl_snake_weight_lvl10.TabIndex = 16;
            this.lbl_snake_weight_lvl10.Text = "0";
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 546);
            this.Controls.Add(this.lbl_snake_weight_lvl10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_eggs_number);
            this.Controls.Add(this.btn_save_level);
            this.Controls.Add(this.btn_paint_field);
            this.Controls.Add(this.lbl_haga_click);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nud_cols);
            this.Controls.Add(this.nud_rows);
            this.Controls.Add(this.btn_load_level);
            this.Controls.Add(this.pb_current_level);
            this.Name = "Editor";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pb_current_level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_eggs_number)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_load_level;
        private System.Windows.Forms.PictureBox pb_current_level;
        private System.Windows.Forms.OpenFileDialog ofd_select_level;
        private System.Windows.Forms.NumericUpDown nud_rows;
        private System.Windows.Forms.NumericUpDown nud_cols;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_haga_click;
        private System.Windows.Forms.Button btn_paint_field;
        private System.Windows.Forms.Button btn_save_level;
        private System.Windows.Forms.NumericUpDown nud_eggs_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_snake_weight_lvl10;
    }
}

