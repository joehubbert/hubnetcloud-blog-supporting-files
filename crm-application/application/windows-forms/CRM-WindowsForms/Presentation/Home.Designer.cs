namespace CRM_WindowsForms.Presentation
{
    partial class Home
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
            homeNavOrderManagement = new Button();
            homeNavAppConfiguration = new Button();
            homeNavProductManagement = new Button();
            homeNavCompanyAdministration = new Button();
            homeNavCustomerManagement = new Button();
            homeTitleLabel = new Label();
            homeNavSupplierManagementButton = new Button();
            homeMenuStrip = new MenuStrip();
            homeMenuStripOrderManagement = new ToolStripMenuItem();
            homeMenuStripCustomerManagement = new ToolStripMenuItem();
            homeMenuStripCustomerManagementCreateCustomer = new ToolStripMenuItem();
            homeMenuStripCustomerManagementViewAllCustomer = new ToolStripMenuItem();
            homeMenuStripProductManagement = new ToolStripMenuItem();
            homeMenuStripProductManagementCreateProduct = new ToolStripMenuItem();
            homeMenuStripProductManagementViewAllProduct = new ToolStripMenuItem();
            homeMenuStripCompanyAdministration = new ToolStripMenuItem();
            homeMenuStripSupplierManagement = new ToolStripMenuItem();
            homeMenuStripSupplierManagementCreateSupplier = new ToolStripMenuItem();
            homeMenuStripSupplierManagementViewAllSupplier = new ToolStripMenuItem();
            homeMenuStripOptions = new ToolStripMenuItem();
            homeMenuStripOptionsAppConfiguration = new ToolStripMenuItem();
            homeMenuStripLanguage = new ToolStripMenuItem();
            homeMenuStripHelp = new ToolStripMenuItem();
            homeMenuStripHelpAbout = new ToolStripMenuItem();
            homeMenuStripHelpEasterEgg = new ToolStripMenuItem();
            homeMenuStripHelpEasterEggSolitaire = new ToolStripMenuItem();
            homeMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // homeNavOrderManagement
            // 
            homeNavOrderManagement.BackColor = Color.Salmon;
            homeNavOrderManagement.FlatStyle = FlatStyle.Flat;
            homeNavOrderManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavOrderManagement.ForeColor = Color.Black;
            homeNavOrderManagement.Location = new Point(249, 164);
            homeNavOrderManagement.Margin = new Padding(4);
            homeNavOrderManagement.Name = "homeNavOrderManagement";
            homeNavOrderManagement.Size = new Size(208, 73);
            homeNavOrderManagement.TabIndex = 0;
            homeNavOrderManagement.Text = "Order Management";
            homeNavOrderManagement.UseVisualStyleBackColor = false;
            homeNavOrderManagement.Click += homeNavOrderManagement_Click;
            // 
            // homeNavAppConfiguration
            // 
            homeNavAppConfiguration.BackColor = Color.MediumPurple;
            homeNavAppConfiguration.FlatStyle = FlatStyle.Flat;
            homeNavAppConfiguration.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavAppConfiguration.ForeColor = Color.Black;
            homeNavAppConfiguration.Location = new Point(685, 36);
            homeNavAppConfiguration.Margin = new Padding(4);
            homeNavAppConfiguration.Name = "homeNavAppConfiguration";
            homeNavAppConfiguration.Size = new Size(208, 73);
            homeNavAppConfiguration.TabIndex = 1;
            homeNavAppConfiguration.Text = "App Configuration";
            homeNavAppConfiguration.UseVisualStyleBackColor = false;
            homeNavAppConfiguration.Click += homeNavAppConfiguration_Click;
            // 
            // homeNavProductManagement
            // 
            homeNavProductManagement.BackColor = Color.SkyBlue;
            homeNavProductManagement.FlatStyle = FlatStyle.Flat;
            homeNavProductManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavProductManagement.ForeColor = Color.Black;
            homeNavProductManagement.Location = new Point(249, 263);
            homeNavProductManagement.Margin = new Padding(4);
            homeNavProductManagement.Name = "homeNavProductManagement";
            homeNavProductManagement.Size = new Size(208, 73);
            homeNavProductManagement.TabIndex = 3;
            homeNavProductManagement.Text = "Product Management";
            homeNavProductManagement.UseVisualStyleBackColor = false;
            homeNavProductManagement.Click += homeNavProductManagement_Click;
            // 
            // homeNavCompanyAdministration
            // 
            homeNavCompanyAdministration.BackColor = Color.LemonChiffon;
            homeNavCompanyAdministration.FlatStyle = FlatStyle.Flat;
            homeNavCompanyAdministration.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavCompanyAdministration.ForeColor = Color.Black;
            homeNavCompanyAdministration.Location = new Point(484, 263);
            homeNavCompanyAdministration.Margin = new Padding(4);
            homeNavCompanyAdministration.Name = "homeNavCompanyAdministration";
            homeNavCompanyAdministration.Size = new Size(208, 73);
            homeNavCompanyAdministration.TabIndex = 4;
            homeNavCompanyAdministration.Text = "Company Administration";
            homeNavCompanyAdministration.UseVisualStyleBackColor = false;
            homeNavCompanyAdministration.Click += homeNavCompanyAdministration_Click;
            // 
            // homeNavCustomerManagement
            // 
            homeNavCustomerManagement.BackColor = Color.LightGreen;
            homeNavCustomerManagement.FlatStyle = FlatStyle.Flat;
            homeNavCustomerManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavCustomerManagement.ForeColor = Color.Black;
            homeNavCustomerManagement.Location = new Point(484, 164);
            homeNavCustomerManagement.Margin = new Padding(4);
            homeNavCustomerManagement.Name = "homeNavCustomerManagement";
            homeNavCustomerManagement.Size = new Size(208, 73);
            homeNavCustomerManagement.TabIndex = 5;
            homeNavCustomerManagement.Text = "Customer Management";
            homeNavCustomerManagement.UseVisualStyleBackColor = false;
            homeNavCustomerManagement.Click += homeNavCustomerManagement_Click;
            // 
            // homeTitleLabel
            // 
            homeTitleLabel.AutoSize = true;
            homeTitleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeTitleLabel.Location = new Point(13, 32);
            homeTitleLabel.Margin = new Padding(4, 0, 4, 0);
            homeTitleLabel.Name = "homeTitleLabel";
            homeTitleLabel.Size = new Size(171, 41);
            homeTitleLabel.TabIndex = 6;
            homeTitleLabel.Text = "CRM Home";
            // 
            // homeNavSupplierManagementButton
            // 
            homeNavSupplierManagementButton.BackColor = Color.MediumAquamarine;
            homeNavSupplierManagementButton.FlatStyle = FlatStyle.Flat;
            homeNavSupplierManagementButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            homeNavSupplierManagementButton.ForeColor = Color.Black;
            homeNavSupplierManagementButton.Location = new Point(249, 362);
            homeNavSupplierManagementButton.Margin = new Padding(4);
            homeNavSupplierManagementButton.Name = "homeNavSupplierManagementButton";
            homeNavSupplierManagementButton.Size = new Size(208, 73);
            homeNavSupplierManagementButton.TabIndex = 7;
            homeNavSupplierManagementButton.Text = "Supplier Management";
            homeNavSupplierManagementButton.UseVisualStyleBackColor = false;
            homeNavSupplierManagementButton.Click += homeNavSupplierManagementButton_Click;
            // 
            // homeMenuStrip
            // 
            homeMenuStrip.BackColor = Color.White;
            homeMenuStrip.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            homeMenuStrip.Items.AddRange(new ToolStripItem[] { homeMenuStripOrderManagement, homeMenuStripCustomerManagement, homeMenuStripProductManagement, homeMenuStripCompanyAdministration, homeMenuStripSupplierManagement, homeMenuStripOptions, homeMenuStripHelp });
            homeMenuStrip.Location = new Point(0, 0);
            homeMenuStrip.Name = "homeMenuStrip";
            homeMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            homeMenuStrip.Size = new Size(925, 25);
            homeMenuStrip.TabIndex = 0;
            homeMenuStrip.Text = "homeMenuStrip";
            // 
            // homeMenuStripOrderManagement
            // 
            homeMenuStripOrderManagement.BackColor = Color.White;
            homeMenuStripOrderManagement.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripOrderManagement.Name = "homeMenuStripOrderManagement";
            homeMenuStripOrderManagement.Size = new Size(136, 21);
            homeMenuStripOrderManagement.Text = "Order Management";
            // 
            // homeMenuStripCustomerManagement
            // 
            homeMenuStripCustomerManagement.BackColor = Color.White;
            homeMenuStripCustomerManagement.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripCustomerManagement.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripCustomerManagementCreateCustomer, homeMenuStripCustomerManagementViewAllCustomer });
            homeMenuStripCustomerManagement.Name = "homeMenuStripCustomerManagement";
            homeMenuStripCustomerManagement.Size = new Size(157, 21);
            homeMenuStripCustomerManagement.Text = "Customer Management";
            // 
            // homeMenuStripCustomerManagementCreateCustomer
            // 
            homeMenuStripCustomerManagementCreateCustomer.BackColor = Color.Transparent;
            homeMenuStripCustomerManagementCreateCustomer.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripCustomerManagementCreateCustomer.Name = "homeMenuStripCustomerManagementCreateCustomer";
            homeMenuStripCustomerManagementCreateCustomer.Size = new Size(187, 22);
            homeMenuStripCustomerManagementCreateCustomer.Text = "Create Customer";
            homeMenuStripCustomerManagementCreateCustomer.Click += homeMenuStripCustomerManagementCreateCustomer_Click;
            // 
            // homeMenuStripCustomerManagementViewAllCustomer
            // 
            homeMenuStripCustomerManagementViewAllCustomer.BackColor = Color.Transparent;
            homeMenuStripCustomerManagementViewAllCustomer.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripCustomerManagementViewAllCustomer.Name = "homeMenuStripCustomerManagementViewAllCustomer";
            homeMenuStripCustomerManagementViewAllCustomer.Size = new Size(187, 22);
            homeMenuStripCustomerManagementViewAllCustomer.Text = "View All Customers";
            homeMenuStripCustomerManagementViewAllCustomer.Click += homeMenuStripCustomerManagementViewAllCustomer_Click;
            // 
            // homeMenuStripProductManagement
            // 
            homeMenuStripProductManagement.BackColor = Color.White;
            homeMenuStripProductManagement.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripProductManagement.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripProductManagementCreateProduct, homeMenuStripProductManagementViewAllProduct });
            homeMenuStripProductManagement.Name = "homeMenuStripProductManagement";
            homeMenuStripProductManagement.Size = new Size(146, 21);
            homeMenuStripProductManagement.Text = "Product Management";
            // 
            // homeMenuStripProductManagementCreateProduct
            // 
            homeMenuStripProductManagementCreateProduct.BackColor = Color.Transparent;
            homeMenuStripProductManagementCreateProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripProductManagementCreateProduct.Name = "homeMenuStripProductManagementCreateProduct";
            homeMenuStripProductManagementCreateProduct.Size = new Size(176, 22);
            homeMenuStripProductManagementCreateProduct.Text = "Create Product";
            homeMenuStripProductManagementCreateProduct.Click += homeMenuStripProductManagementCreateProduct_Click;
            // 
            // homeMenuStripProductManagementViewAllProduct
            // 
            homeMenuStripProductManagementViewAllProduct.BackColor = Color.Transparent;
            homeMenuStripProductManagementViewAllProduct.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripProductManagementViewAllProduct.Name = "homeMenuStripProductManagementViewAllProduct";
            homeMenuStripProductManagementViewAllProduct.Size = new Size(176, 22);
            homeMenuStripProductManagementViewAllProduct.Text = "View All Products";
            homeMenuStripProductManagementViewAllProduct.Click += homeMenuStripProductManagementViewAllProduct_Click;
            // 
            // homeMenuStripCompanyAdministration
            // 
            homeMenuStripCompanyAdministration.BackColor = Color.White;
            homeMenuStripCompanyAdministration.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripCompanyAdministration.Name = "homeMenuStripCompanyAdministration";
            homeMenuStripCompanyAdministration.Size = new Size(163, 21);
            homeMenuStripCompanyAdministration.Text = "Company Administration";
            // 
            // homeMenuStripSupplierManagement
            // 
            homeMenuStripSupplierManagement.BackColor = Color.Transparent;
            homeMenuStripSupplierManagement.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripSupplierManagement.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripSupplierManagementCreateSupplier, homeMenuStripSupplierManagementViewAllSupplier });
            homeMenuStripSupplierManagement.Name = "homeMenuStripSupplierManagement";
            homeMenuStripSupplierManagement.Size = new Size(149, 21);
            homeMenuStripSupplierManagement.Text = "Supplier Management";
            // 
            // homeMenuStripSupplierManagementCreateSupplier
            // 
            homeMenuStripSupplierManagementCreateSupplier.BackColor = Color.Transparent;
            homeMenuStripSupplierManagementCreateSupplier.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripSupplierManagementCreateSupplier.Name = "homeMenuStripSupplierManagementCreateSupplier";
            homeMenuStripSupplierManagementCreateSupplier.Size = new Size(180, 22);
            homeMenuStripSupplierManagementCreateSupplier.Text = "Create Supplier";
            homeMenuStripSupplierManagementCreateSupplier.Click += homeMenuStripSupplierManagementCreateSupplier_Click;
            // 
            // homeMenuStripSupplierManagementViewAllSupplier
            // 
            homeMenuStripSupplierManagementViewAllSupplier.BackColor = Color.Transparent;
            homeMenuStripSupplierManagementViewAllSupplier.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripSupplierManagementViewAllSupplier.Name = "homeMenuStripSupplierManagementViewAllSupplier";
            homeMenuStripSupplierManagementViewAllSupplier.Size = new Size(180, 22);
            homeMenuStripSupplierManagementViewAllSupplier.Text = "View All Suppliers";
            homeMenuStripSupplierManagementViewAllSupplier.Click += homeMenuStripSupplierManagementViewAllSupplier_Click;
            // 
            // homeMenuStripOptions
            // 
            homeMenuStripOptions.BackColor = Color.Transparent;
            homeMenuStripOptions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripOptions.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripOptionsAppConfiguration, homeMenuStripLanguage });
            homeMenuStripOptions.Name = "homeMenuStripOptions";
            homeMenuStripOptions.Size = new Size(66, 21);
            homeMenuStripOptions.Text = "Options";
            // 
            // homeMenuStripOptionsAppConfiguration
            // 
            homeMenuStripOptionsAppConfiguration.BackColor = Color.Transparent;
            homeMenuStripOptionsAppConfiguration.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripOptionsAppConfiguration.Name = "homeMenuStripOptionsAppConfiguration";
            homeMenuStripOptionsAppConfiguration.Size = new Size(183, 22);
            homeMenuStripOptionsAppConfiguration.Text = "App Configuration";
            homeMenuStripOptionsAppConfiguration.Click += homeMenuStripOptionsAppConfiguration_Click;
            // 
            // homeMenuStripLanguage
            // 
            homeMenuStripLanguage.BackColor = Color.Transparent;
            homeMenuStripLanguage.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripLanguage.Name = "homeMenuStripLanguage";
            homeMenuStripLanguage.Size = new Size(183, 22);
            homeMenuStripLanguage.Text = "Language";
            // 
            // homeMenuStripHelp
            // 
            homeMenuStripHelp.BackColor = Color.Transparent;
            homeMenuStripHelp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripHelp.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripHelpAbout, homeMenuStripHelpEasterEgg });
            homeMenuStripHelp.Name = "homeMenuStripHelp";
            homeMenuStripHelp.Size = new Size(47, 21);
            homeMenuStripHelp.Text = "Help";
            // 
            // homeMenuStripHelpAbout
            // 
            homeMenuStripHelpAbout.BackColor = Color.Transparent;
            homeMenuStripHelpAbout.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripHelpAbout.Name = "homeMenuStripHelpAbout";
            homeMenuStripHelpAbout.Size = new Size(145, 22);
            homeMenuStripHelpAbout.Text = "About";
            homeMenuStripHelpAbout.Click += homeMenuStripHelpAbout_Click;
            // 
            // homeMenuStripHelpEasterEgg
            // 
            homeMenuStripHelpEasterEgg.BackColor = Color.Transparent;
            homeMenuStripHelpEasterEgg.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripHelpEasterEgg.DropDownItems.AddRange(new ToolStripItem[] { homeMenuStripHelpEasterEggSolitaire });
            homeMenuStripHelpEasterEgg.Name = "homeMenuStripHelpEasterEgg";
            homeMenuStripHelpEasterEgg.Size = new Size(145, 22);
            homeMenuStripHelpEasterEgg.Text = "Easter Eggs";
            // 
            // homeMenuStripHelpEasterEggSolitaire
            // 
            homeMenuStripHelpEasterEggSolitaire.BackColor = Color.Transparent;
            homeMenuStripHelpEasterEggSolitaire.DisplayStyle = ToolStripItemDisplayStyle.Text;
            homeMenuStripHelpEasterEggSolitaire.Name = "homeMenuStripHelpEasterEggSolitaire";
            homeMenuStripHelpEasterEggSolitaire.Size = new Size(123, 22);
            homeMenuStripHelpEasterEggSolitaire.Text = "Solitaire";
            homeMenuStripHelpEasterEggSolitaire.Click += homeMenuStripHelpEasterEggSolitaire_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(925, 479);
            Controls.Add(homeNavSupplierManagementButton);
            Controls.Add(homeTitleLabel);
            Controls.Add(homeNavCustomerManagement);
            Controls.Add(homeNavCompanyAdministration);
            Controls.Add(homeNavProductManagement);
            Controls.Add(homeNavAppConfiguration);
            Controls.Add(homeNavOrderManagement);
            Controls.Add(homeMenuStrip);
            Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MainMenuStrip = homeMenuStrip;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Home";
            homeMenuStrip.ResumeLayout(false);
            homeMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button homeNavOrderManagement;
        private Button homeNavAppConfiguration;
        private Button homeNavProductManagement;
        private Button homeNavCompanyAdministration;
        private Button homeNavCustomerManagement;
        private Label homeTitleLabel;
        private Button homeNavSupplierManagementButton;
        private MenuStrip homeMenuStrip;
        private ToolStripMenuItem homeMenuStripOrderManagement;
        private ToolStripMenuItem homeMenuStripCustomerManagement;
        private ToolStripMenuItem homeMenuStripProductManagement;
        private ToolStripMenuItem homeMenuStripCompanyAdministration;
        private ToolStripMenuItem homeMenuStripSupplierManagement;
        private ToolStripMenuItem homeMenuStripOptions;
        private ToolStripMenuItem homeMenuStripHelp;
        private ToolStripMenuItem homeMenuStripCustomerManagementCreateCustomer;
        private ToolStripMenuItem homeMenuStripCustomerManagementViewAllCustomer;
        private ToolStripMenuItem homeMenuStripProductManagementCreateProduct;
        private ToolStripMenuItem homeMenuStripProductManagementViewAllProduct;
        private ToolStripMenuItem homeMenuStripSupplierManagementCreateSupplier;
        private ToolStripMenuItem homeMenuStripSupplierManagementViewAllSupplier;
        private ToolStripMenuItem homeMenuStripOptionsAppConfiguration;
        private ToolStripMenuItem homeMenuStripLanguage;
        private ToolStripMenuItem homeMenuStripHelpAbout;
        private ToolStripMenuItem homeMenuStripHelpEasterEgg;
        private ToolStripMenuItem homeMenuStripHelpEasterEggSolitaire;
    }
}