namespace WASender
{
    partial class AddCaption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCaption));
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txtLongMessage = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txtLongMessage);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(17, 93);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(512, 286);
            this.materialCard1.TabIndex = 0;
            // 
            // txtLongMessage
            // 
            this.txtLongMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLongMessage.AnimateReadOnly = false;
            this.txtLongMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtLongMessage.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLongMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLongMessage.Depth = 0;
            this.txtLongMessage.HideSelection = true;
            this.txtLongMessage.Hint = "Type Your Message here";
            this.txtLongMessage.Location = new System.Drawing.Point(16, 17);
            this.txtLongMessage.MaxLength = 2147483647;
            this.txtLongMessage.MouseState = MaterialSkin.MouseState.OUT;
            this.txtLongMessage.Name = "txtLongMessage";
            this.txtLongMessage.PasswordChar = '\0';
            this.txtLongMessage.ReadOnly = false;
            this.txtLongMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtLongMessage.SelectedText = "";
            this.txtLongMessage.SelectionLength = 0;
            this.txtLongMessage.SelectionStart = 0;
            this.txtLongMessage.ShortcutsEnabled = true;
            this.txtLongMessage.Size = new System.Drawing.Size(479, 252);
            this.txtLongMessage.TabIndex = 72;
            this.txtLongMessage.TabStop = false;
            this.txtLongMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLongMessage.UseSystemPasswordChar = false;
            // 
            // materialButton2
            // 
            this.materialButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(361, 411);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(168, 36);
            this.materialButton2.TabIndex = 75;
            this.materialButton2.Text = "Save";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // AddCaption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 484);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialCard1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCaption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddCaption";
            this.Load += new System.EventHandler(this.AddCaption_Load);
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtLongMessage;
        private MaterialSkin.Controls.MaterialButton materialButton2;
    }
}