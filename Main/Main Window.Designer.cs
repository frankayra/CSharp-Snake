namespace Main
{
    partial class Form1
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
            this.btn_game_editor = new System.Windows.Forms.Button();
            this.btn_default_game = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_game_editor
            // 
            this.btn_game_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_game_editor.Location = new System.Drawing.Point(41, 46);
            this.btn_game_editor.Name = "btn_game_editor";
            this.btn_game_editor.Size = new System.Drawing.Size(148, 111);
            this.btn_game_editor.TabIndex = 0;
            this.btn_game_editor.Text = "Editar Juego";
            this.btn_game_editor.UseVisualStyleBackColor = true;
            this.btn_game_editor.Click += new System.EventHandler(this.Btn_game_editor_Click);
            // 
            // btn_default_game
            // 
            this.btn_default_game.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_default_game.Location = new System.Drawing.Point(270, 46);
            this.btn_default_game.Name = "btn_default_game";
            this.btn_default_game.Size = new System.Drawing.Size(148, 111);
            this.btn_default_game.TabIndex = 1;
            this.btn_default_game.Text = "Juego Rapido";
            this.btn_default_game.UseVisualStyleBackColor = true;
            this.btn_default_game.Click += new System.EventHandler(this.Btn_default_game_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 218);
            this.Controls.Add(this.btn_default_game);
            this.Controls.Add(this.btn_game_editor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_game_editor;
        private System.Windows.Forms.Button btn_default_game;
    }
}

