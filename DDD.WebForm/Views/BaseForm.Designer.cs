
namespace DDD.WebForm.Views
{
    partial class BaseForm
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
            this.DebugLayoutLabel = new System.Windows.Forms.Label();
            this.UserIDLayoutLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DebugLayoutLabel
            // 
            this.DebugLayoutLabel.AutoSize = true;
            this.DebugLayoutLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.DebugLayoutLabel.Location = new System.Drawing.Point(12, 240);
            this.DebugLayoutLabel.Name = "DebugLayoutLabel";
            this.DebugLayoutLabel.Size = new System.Drawing.Size(71, 12);
            this.DebugLayoutLabel.TabIndex = 1;
            this.DebugLayoutLabel.Text = "DebugLayout";
            // 
            // UserIDLayoutLabel
            // 
            this.UserIDLayoutLabel.AutoSize = true;
            this.UserIDLayoutLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.UserIDLayoutLabel.Location = new System.Drawing.Point(89, 240);
            this.UserIDLayoutLabel.Name = "UserIDLayoutLabel";
            this.UserIDLayoutLabel.Size = new System.Drawing.Size(74, 12);
            this.UserIDLayoutLabel.TabIndex = 2;
            this.UserIDLayoutLabel.Text = "UserIDLayout";
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.UserIDLayoutLabel);
            this.Controls.Add(this.DebugLayoutLabel);
            this.Name = "BaseForm";
            this.Text = "BaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DebugLayoutLabel;
        private System.Windows.Forms.Label UserIDLayoutLabel;
    }
}