namespace QuickPaint
{
    partial class QuickPaint
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickPaint));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButtonNew = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonObjectType = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPencilColor = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonFillColor = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonFillMode = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonDelete = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonQuit = new System.Windows.Forms.ToolBarButton();
            this.toolbarImages = new System.Windows.Forms.ImageList();
            this.toolBarButtonPencilWidth = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.Add(this.toolBarButtonNew);
            this.toolBar1.Buttons.Add(this.toolBarButtonObjectType);
            this.toolBar1.Buttons.Add(this.toolBarButtonPencilColor);
            this.toolBar1.Buttons.Add(this.toolBarButtonFillColor);
            this.toolBar1.Buttons.Add(this.toolBarButtonFillMode);
            this.toolBar1.Buttons.Add(this.toolBarButtonPencilWidth);
            this.toolBar1.Buttons.Add(this.toolBarButtonDelete);
            this.toolBar1.Buttons.Add(this.toolBarButtonQuit);
            this.toolBar1.ImageList = this.toolbarImages;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButtonNew
            // 
            this.toolBarButtonNew.ImageIndex = 7;
            // 
            // toolBarButtonObjectType
            // 
            this.toolBarButtonObjectType.ImageIndex = 0;
            // 
            // toolBarButtonPencilColor
            // 
            this.toolBarButtonPencilColor.ImageIndex = 1;
            // 
            // toolBarButtonFillColor
            // 
            this.toolBarButtonFillColor.ImageIndex = 1;
            // 
            // toolBarButtonFillMode
            // 
            this.toolBarButtonFillMode.ImageIndex = 3;
            // 
            // toolBarButtonDelete
            // 
            this.toolBarButtonDelete.ImageIndex = 2;
            // 
            // toolBarButtonQuit
            // 
            this.toolBarButtonQuit.ImageIndex = 6;
            this.toolbarImages.Images.Clear();
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.toolbarImages.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource7"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource8"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource9"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource10"))));
            this.toolbarImages.Images.Add(((System.Drawing.Image)(resources.GetObject("resource11"))));
            // 
            // toolBarButtonPencilWidth
            // 
            this.toolBarButtonPencilWidth.ImageIndex = 8;
            // 
            // QuickPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.toolBar1);
            this.Name = "QuickPaint";
            this.Text = "QuickPaint";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.QuickPaint_MouseUp);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.QuickPaint_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.QuickPaint_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton toolBarButtonObjectType;
        private System.Windows.Forms.ToolBarButton toolBarButtonPencilColor;
        private System.Windows.Forms.ImageList toolbarImages;
        private System.Windows.Forms.ToolBarButton toolBarButtonQuit;
        private System.Windows.Forms.ToolBarButton toolBarButtonFillColor;
        private System.Windows.Forms.ToolBarButton toolBarButtonFillMode;
        private System.Windows.Forms.ToolBarButton toolBarButtonDelete;
        private System.Windows.Forms.ToolBarButton toolBarButtonNew;
        private System.Windows.Forms.ToolBarButton toolBarButtonPencilWidth;
    }
}

