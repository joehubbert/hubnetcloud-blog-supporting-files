namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    partial class ProductDetail
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
            productDetailUpdateProductButton = new Button();
            productDetailOverviewActiveStatusCheckbox = new CheckBox();
            productDetailToggleEditModeButton = new Button();
            productDetailOverviewProductIdTextbox = new TextBox();
            productDetailOverviewCreatedTimestampTextbox = new TextBox();
            productDetailOverviewLastUpdatedTimestampTextbox = new TextBox();
            productDetailOverviewCreatedByTextbox = new TextBox();
            productDetailOverviewLastUpdatedByTextbox = new TextBox();
            productDetailOverviewLastUpdatedTimestampTextboxLabel = new Label();
            productDetailOverviewLastUpdatedByTextboxLabel = new Label();
            productDetailOverviewCreatedTimestampTextboxLabel = new Label();
            productDetailOverviewCreatedByTextboxLabel = new Label();
            productDetailProductIdLabel = new Label();
            productDetailTitleLabel = new Label();
            productDetailTabControl = new TabControl();
            productDetailTabControlOverviewPage = new TabPage();
            productDetailOverviewPerUnitGroupBox = new GroupBox();
            productDetailOverviewUnitMinimumStockQuantityTextbox = new TextBox();
            productDetailOverviewUnitMinimumStockQuantityLabel = new Label();
            productDetailOverviewUnitMinimumOrderQuantityTextbox = new TextBox();
            productDetailOverviewUnitMinimumOrderQuantityLabel = new Label();
            productDetailOverviewUnitPriceTextboxB = new TextBox();
            productDetailOverviewUnitPriceLabel = new Label();
            productDetailOverviewUnitPriceTextboxSeparatorLabel = new Label();
            productDetailOverviewUnitPriceTextboxA = new TextBox();
            productDetailOverviewUnitStockQuantityHeldTextbox = new TextBox();
            productDetailOverviewUnitStockQuantityHeldLabel = new Label();
            productDetailOverviewWholesaleGroupBox = new GroupBox();
            productDetailOverviewWholesalePricePerUnitTextboxB = new TextBox();
            productDetailOverviewWholesalePricePerUnitTextboxA = new TextBox();
            productDetailOverviewWholesaleReorderFlagLabel = new Label();
            productDetailOverviewWholesalePricePerUnitTextboxSeparator = new Label();
            productDetailOverviewWholesalePricePerUnitLabel = new Label();
            productDetailOverviewWholesaleReorderFlagPanel = new Panel();
            productDetailOverviewWholesaleReorderFlagYesRadioButton = new RadioButton();
            productDetailOverviewWholesaleReorderFlagNoRadioButton = new RadioButton();
            productDetailOverviewWholesaleCartonQuantityTextbox = new TextBox();
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox = new TextBox();
            productDetailOverviewWholesaleCartonQuantityLabel = new Label();
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel = new Label();
            productDetailOverviewSupplierComboBox = new ComboBox();
            productDetailOverviewProductCategoryComboBox = new ComboBox();
            productDetailOverviewProductNameTextbox = new TextBox();
            productDetailOverviewProductNameLabel = new Label();
            productDetailOverviewProductCategoryLabel = new Label();
            productDetailOverviewSupplierLabel = new Label();
            productDetailTabControlProductImagePage = new TabPage();
            productDetailProductImagePictureBox = new PictureBox();
            productDetailProductImagePictureBoxLabel = new Label();
            productDetailProductImageChooseProductImageButton = new Button();
            productDetailTabControlProductNotesPage = new TabPage();
            productDetailProductNotesRefreshDataButton = new Button();
            productDetailProductNotesCreateNewProductNoteButton = new Button();
            productDetailProductNotesExistingProductNotesDataGridView = new DataGridView();
            productDetailProductImageRemoveProductImageButton = new Button();
            productDetailTabControl.SuspendLayout();
            productDetailTabControlOverviewPage.SuspendLayout();
            productDetailOverviewPerUnitGroupBox.SuspendLayout();
            productDetailOverviewWholesaleGroupBox.SuspendLayout();
            productDetailOverviewWholesaleReorderFlagPanel.SuspendLayout();
            productDetailTabControlProductImagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productDetailProductImagePictureBox).BeginInit();
            productDetailTabControlProductNotesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productDetailProductNotesExistingProductNotesDataGridView).BeginInit();
            SuspendLayout();
            // 
            // productDetailUpdateProductButton
            // 
            productDetailUpdateProductButton.Enabled = false;
            productDetailUpdateProductButton.FlatStyle = FlatStyle.Flat;
            productDetailUpdateProductButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailUpdateProductButton.Location = new Point(545, 753);
            productDetailUpdateProductButton.Margin = new Padding(4);
            productDetailUpdateProductButton.Name = "productDetailUpdateProductButton";
            productDetailUpdateProductButton.Size = new Size(185, 70);
            productDetailUpdateProductButton.TabIndex = 25;
            productDetailUpdateProductButton.Text = "Update Product";
            productDetailUpdateProductButton.UseVisualStyleBackColor = true;
            productDetailUpdateProductButton.Click += productDetailUpdateProductButton_Click;
            // 
            // productDetailOverviewActiveStatusCheckbox
            // 
            productDetailOverviewActiveStatusCheckbox.AutoSize = true;
            productDetailOverviewActiveStatusCheckbox.Enabled = false;
            productDetailOverviewActiveStatusCheckbox.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            productDetailOverviewActiveStatusCheckbox.Location = new Point(171, 505);
            productDetailOverviewActiveStatusCheckbox.Margin = new Padding(4);
            productDetailOverviewActiveStatusCheckbox.Name = "productDetailOverviewActiveStatusCheckbox";
            productDetailOverviewActiveStatusCheckbox.Size = new Size(130, 24);
            productDetailOverviewActiveStatusCheckbox.TabIndex = 11;
            productDetailOverviewActiveStatusCheckbox.Text = "Active Product*";
            productDetailOverviewActiveStatusCheckbox.UseVisualStyleBackColor = true;
            // 
            // productDetailToggleEditModeButton
            // 
            productDetailToggleEditModeButton.FlatStyle = FlatStyle.Flat;
            productDetailToggleEditModeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailToggleEditModeButton.Location = new Point(1165, 13);
            productDetailToggleEditModeButton.Margin = new Padding(4);
            productDetailToggleEditModeButton.Name = "productDetailToggleEditModeButton";
            productDetailToggleEditModeButton.Size = new Size(108, 92);
            productDetailToggleEditModeButton.TabIndex = 24;
            productDetailToggleEditModeButton.Text = "Toggle Edit Mode";
            productDetailToggleEditModeButton.UseVisualStyleBackColor = true;
            productDetailToggleEditModeButton.Click += ProductDetailToggleEditModeButton_Click;
            // 
            // productDetailOverviewProductIdTextbox
            // 
            productDetailOverviewProductIdTextbox.Location = new Point(171, 28);
            productDetailOverviewProductIdTextbox.MaxLength = 36;
            productDetailOverviewProductIdTextbox.Name = "productDetailOverviewProductIdTextbox";
            productDetailOverviewProductIdTextbox.ReadOnly = true;
            productDetailOverviewProductIdTextbox.Size = new Size(370, 27);
            productDetailOverviewProductIdTextbox.TabIndex = 1;
            // 
            // productDetailOverviewCreatedTimestampTextbox
            // 
            productDetailOverviewCreatedTimestampTextbox.Location = new Point(818, 327);
            productDetailOverviewCreatedTimestampTextbox.MaxLength = 50;
            productDetailOverviewCreatedTimestampTextbox.Name = "productDetailOverviewCreatedTimestampTextbox";
            productDetailOverviewCreatedTimestampTextbox.ReadOnly = true;
            productDetailOverviewCreatedTimestampTextbox.Size = new Size(370, 27);
            productDetailOverviewCreatedTimestampTextbox.TabIndex = 18;
            // 
            // productDetailOverviewLastUpdatedTimestampTextbox
            // 
            productDetailOverviewLastUpdatedTimestampTextbox.Location = new Point(818, 418);
            productDetailOverviewLastUpdatedTimestampTextbox.MaxLength = 50;
            productDetailOverviewLastUpdatedTimestampTextbox.Name = "productDetailOverviewLastUpdatedTimestampTextbox";
            productDetailOverviewLastUpdatedTimestampTextbox.ReadOnly = true;
            productDetailOverviewLastUpdatedTimestampTextbox.Size = new Size(370, 27);
            productDetailOverviewLastUpdatedTimestampTextbox.TabIndex = 20;
            // 
            // productDetailOverviewCreatedByTextbox
            // 
            productDetailOverviewCreatedByTextbox.Location = new Point(818, 282);
            productDetailOverviewCreatedByTextbox.MaxLength = 50;
            productDetailOverviewCreatedByTextbox.Name = "productDetailOverviewCreatedByTextbox";
            productDetailOverviewCreatedByTextbox.ReadOnly = true;
            productDetailOverviewCreatedByTextbox.Size = new Size(370, 27);
            productDetailOverviewCreatedByTextbox.TabIndex = 17;
            // 
            // productDetailOverviewLastUpdatedByTextbox
            // 
            productDetailOverviewLastUpdatedByTextbox.Location = new Point(818, 372);
            productDetailOverviewLastUpdatedByTextbox.MaxLength = 50;
            productDetailOverviewLastUpdatedByTextbox.Name = "productDetailOverviewLastUpdatedByTextbox";
            productDetailOverviewLastUpdatedByTextbox.ReadOnly = true;
            productDetailOverviewLastUpdatedByTextbox.Size = new Size(370, 27);
            productDetailOverviewLastUpdatedByTextbox.TabIndex = 19;
            // 
            // productDetailOverviewLastUpdatedTimestampTextboxLabel
            // 
            productDetailOverviewLastUpdatedTimestampTextboxLabel.AutoSize = true;
            productDetailOverviewLastUpdatedTimestampTextboxLabel.Location = new Point(627, 421);
            productDetailOverviewLastUpdatedTimestampTextboxLabel.Name = "productDetailOverviewLastUpdatedTimestampTextboxLabel";
            productDetailOverviewLastUpdatedTimestampTextboxLabel.Size = new Size(175, 20);
            productDetailOverviewLastUpdatedTimestampTextboxLabel.TabIndex = 54;
            productDetailOverviewLastUpdatedTimestampTextboxLabel.Text = "Last Updated Timestamp";
            // 
            // productDetailOverviewLastUpdatedByTextboxLabel
            // 
            productDetailOverviewLastUpdatedByTextboxLabel.AutoSize = true;
            productDetailOverviewLastUpdatedByTextboxLabel.Location = new Point(685, 375);
            productDetailOverviewLastUpdatedByTextboxLabel.Name = "productDetailOverviewLastUpdatedByTextboxLabel";
            productDetailOverviewLastUpdatedByTextboxLabel.Size = new Size(117, 20);
            productDetailOverviewLastUpdatedByTextboxLabel.TabIndex = 53;
            productDetailOverviewLastUpdatedByTextboxLabel.Text = "Last Updated By";
            // 
            // productDetailOverviewCreatedTimestampTextboxLabel
            // 
            productDetailOverviewCreatedTimestampTextboxLabel.AutoSize = true;
            productDetailOverviewCreatedTimestampTextboxLabel.Location = new Point(663, 330);
            productDetailOverviewCreatedTimestampTextboxLabel.Name = "productDetailOverviewCreatedTimestampTextboxLabel";
            productDetailOverviewCreatedTimestampTextboxLabel.Size = new Size(139, 20);
            productDetailOverviewCreatedTimestampTextboxLabel.TabIndex = 52;
            productDetailOverviewCreatedTimestampTextboxLabel.Text = "Created Timestamp";
            // 
            // productDetailOverviewCreatedByTextboxLabel
            // 
            productDetailOverviewCreatedByTextboxLabel.AutoSize = true;
            productDetailOverviewCreatedByTextboxLabel.Location = new Point(721, 285);
            productDetailOverviewCreatedByTextboxLabel.Name = "productDetailOverviewCreatedByTextboxLabel";
            productDetailOverviewCreatedByTextboxLabel.Size = new Size(81, 20);
            productDetailOverviewCreatedByTextboxLabel.TabIndex = 49;
            productDetailOverviewCreatedByTextboxLabel.Text = "Created By";
            // 
            // productDetailProductIdLabel
            // 
            productDetailProductIdLabel.AutoSize = true;
            productDetailProductIdLabel.Location = new Point(73, 30);
            productDetailProductIdLabel.Name = "productDetailProductIdLabel";
            productDetailProductIdLabel.Size = new Size(77, 20);
            productDetailProductIdLabel.TabIndex = 43;
            productDetailProductIdLabel.Text = "Product Id";
            // 
            // productDetailTitleLabel
            // 
            productDetailTitleLabel.AutoSize = true;
            productDetailTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailTitleLabel.Location = new Point(13, 9);
            productDetailTitleLabel.Margin = new Padding(4, 0, 4, 0);
            productDetailTitleLabel.Name = "productDetailTitleLabel";
            productDetailTitleLabel.Size = new Size(179, 32);
            productDetailTitleLabel.TabIndex = 42;
            productDetailTitleLabel.Text = "Product Detail";
            // 
            // productDetailTabControl
            // 
            productDetailTabControl.Appearance = TabAppearance.FlatButtons;
            productDetailTabControl.Controls.Add(productDetailTabControlOverviewPage);
            productDetailTabControl.Controls.Add(productDetailTabControlProductImagePage);
            productDetailTabControl.Controls.Add(productDetailTabControlProductNotesPage);
            productDetailTabControl.Location = new Point(13, 121);
            productDetailTabControl.Name = "productDetailTabControl";
            productDetailTabControl.SelectedIndex = 0;
            productDetailTabControl.Size = new Size(1264, 625);
            productDetailTabControl.TabIndex = 0;
            // 
            // productDetailTabControlOverviewPage
            // 
            productDetailTabControlOverviewPage.BackColor = Color.SkyBlue;
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewPerUnitGroupBox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewWholesaleGroupBox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewSupplierComboBox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewActiveStatusCheckbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewProductCategoryComboBox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewCreatedTimestampTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewProductNameTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewProductNameLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewProductIdTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewProductCategoryLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewLastUpdatedTimestampTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewSupplierLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewCreatedByTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewLastUpdatedByTextbox);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewLastUpdatedTimestampTextboxLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewLastUpdatedByTextboxLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewCreatedTimestampTextboxLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailOverviewCreatedByTextboxLabel);
            productDetailTabControlOverviewPage.Controls.Add(productDetailProductIdLabel);
            productDetailTabControlOverviewPage.Location = new Point(4, 32);
            productDetailTabControlOverviewPage.Name = "productDetailTabControlOverviewPage";
            productDetailTabControlOverviewPage.Padding = new Padding(3);
            productDetailTabControlOverviewPage.Size = new Size(1256, 589);
            productDetailTabControlOverviewPage.TabIndex = 0;
            productDetailTabControlOverviewPage.Text = "Overview";
            // 
            // productDetailOverviewPerUnitGroupBox
            // 
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitMinimumStockQuantityTextbox);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitMinimumStockQuantityLabel);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitMinimumOrderQuantityTextbox);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitMinimumOrderQuantityLabel);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitPriceTextboxB);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitPriceLabel);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitPriceTextboxSeparatorLabel);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitPriceTextboxA);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitStockQuantityHeldTextbox);
            productDetailOverviewPerUnitGroupBox.Controls.Add(productDetailOverviewUnitStockQuantityHeldLabel);
            productDetailOverviewPerUnitGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailOverviewPerUnitGroupBox.Location = new Point(627, 28);
            productDetailOverviewPerUnitGroupBox.Name = "productDetailOverviewPerUnitGroupBox";
            productDetailOverviewPerUnitGroupBox.Size = new Size(561, 198);
            productDetailOverviewPerUnitGroupBox.TabIndex = 77;
            productDetailOverviewPerUnitGroupBox.TabStop = false;
            productDetailOverviewPerUnitGroupBox.Text = "Per Unit";
            // 
            // productDetailOverviewUnitMinimumStockQuantityTextbox
            // 
            productDetailOverviewUnitMinimumStockQuantityTextbox.Enabled = false;
            productDetailOverviewUnitMinimumStockQuantityTextbox.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitMinimumStockQuantityTextbox.Location = new Point(284, 109);
            productDetailOverviewUnitMinimumStockQuantityTextbox.MaxLength = 50;
            productDetailOverviewUnitMinimumStockQuantityTextbox.Name = "productDetailOverviewUnitMinimumStockQuantityTextbox";
            productDetailOverviewUnitMinimumStockQuantityTextbox.ReadOnly = true;
            productDetailOverviewUnitMinimumStockQuantityTextbox.Size = new Size(99, 27);
            productDetailOverviewUnitMinimumStockQuantityTextbox.TabIndex = 15;
            // 
            // productDetailOverviewUnitMinimumStockQuantityLabel
            // 
            productDetailOverviewUnitMinimumStockQuantityLabel.AutoSize = true;
            productDetailOverviewUnitMinimumStockQuantityLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitMinimumStockQuantityLabel.Location = new Point(68, 112);
            productDetailOverviewUnitMinimumStockQuantityLabel.Name = "productDetailOverviewUnitMinimumStockQuantityLabel";
            productDetailOverviewUnitMinimumStockQuantityLabel.Size = new Size(203, 20);
            productDetailOverviewUnitMinimumStockQuantityLabel.TabIndex = 73;
            productDetailOverviewUnitMinimumStockQuantityLabel.Text = "Unit Minimum Stock Quantity";
            // 
            // productDetailOverviewUnitMinimumOrderQuantityTextbox
            // 
            productDetailOverviewUnitMinimumOrderQuantityTextbox.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitMinimumOrderQuantityTextbox.Location = new Point(284, 67);
            productDetailOverviewUnitMinimumOrderQuantityTextbox.MaxLength = 50;
            productDetailOverviewUnitMinimumOrderQuantityTextbox.Name = "productDetailOverviewUnitMinimumOrderQuantityTextbox";
            productDetailOverviewUnitMinimumOrderQuantityTextbox.ReadOnly = true;
            productDetailOverviewUnitMinimumOrderQuantityTextbox.Size = new Size(99, 27);
            productDetailOverviewUnitMinimumOrderQuantityTextbox.TabIndex = 14;
            // 
            // productDetailOverviewUnitMinimumOrderQuantityLabel
            // 
            productDetailOverviewUnitMinimumOrderQuantityLabel.AutoSize = true;
            productDetailOverviewUnitMinimumOrderQuantityLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitMinimumOrderQuantityLabel.Location = new Point(60, 70);
            productDetailOverviewUnitMinimumOrderQuantityLabel.Name = "productDetailOverviewUnitMinimumOrderQuantityLabel";
            productDetailOverviewUnitMinimumOrderQuantityLabel.Size = new Size(211, 20);
            productDetailOverviewUnitMinimumOrderQuantityLabel.TabIndex = 71;
            productDetailOverviewUnitMinimumOrderQuantityLabel.Text = "Unit Minimum Order Quantity*";
            // 
            // productDetailOverviewUnitPriceTextboxB
            // 
            productDetailOverviewUnitPriceTextboxB.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitPriceTextboxB.Location = new Point(402, 26);
            productDetailOverviewUnitPriceTextboxB.MaxLength = 50;
            productDetailOverviewUnitPriceTextboxB.Name = "productDetailOverviewUnitPriceTextboxB";
            productDetailOverviewUnitPriceTextboxB.ReadOnly = true;
            productDetailOverviewUnitPriceTextboxB.Size = new Size(45, 27);
            productDetailOverviewUnitPriceTextboxB.TabIndex = 13;
            // 
            // productDetailOverviewUnitPriceLabel
            // 
            productDetailOverviewUnitPriceLabel.AutoSize = true;
            productDetailOverviewUnitPriceLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitPriceLabel.Location = new Point(193, 29);
            productDetailOverviewUnitPriceLabel.Name = "productDetailOverviewUnitPriceLabel";
            productDetailOverviewUnitPriceLabel.Size = new Size(78, 20);
            productDetailOverviewUnitPriceLabel.TabIndex = 53;
            productDetailOverviewUnitPriceLabel.Text = "Unit Price*";
            // 
            // productDetailOverviewUnitPriceTextboxSeparatorLabel
            // 
            productDetailOverviewUnitPriceTextboxSeparatorLabel.AutoSize = true;
            productDetailOverviewUnitPriceTextboxSeparatorLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitPriceTextboxSeparatorLabel.Location = new Point(388, 29);
            productDetailOverviewUnitPriceTextboxSeparatorLabel.Name = "productDetailOverviewUnitPriceTextboxSeparatorLabel";
            productDetailOverviewUnitPriceTextboxSeparatorLabel.Size = new Size(12, 20);
            productDetailOverviewUnitPriceTextboxSeparatorLabel.TabIndex = 70;
            productDetailOverviewUnitPriceTextboxSeparatorLabel.Text = ".";
            // 
            // productDetailOverviewUnitPriceTextboxA
            // 
            productDetailOverviewUnitPriceTextboxA.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitPriceTextboxA.Location = new Point(283, 26);
            productDetailOverviewUnitPriceTextboxA.MaxLength = 50;
            productDetailOverviewUnitPriceTextboxA.Name = "productDetailOverviewUnitPriceTextboxA";
            productDetailOverviewUnitPriceTextboxA.ReadOnly = true;
            productDetailOverviewUnitPriceTextboxA.Size = new Size(99, 27);
            productDetailOverviewUnitPriceTextboxA.TabIndex = 12;
            // 
            // productDetailOverviewUnitStockQuantityHeldTextbox
            // 
            productDetailOverviewUnitStockQuantityHeldTextbox.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitStockQuantityHeldTextbox.Location = new Point(284, 152);
            productDetailOverviewUnitStockQuantityHeldTextbox.MaxLength = 50;
            productDetailOverviewUnitStockQuantityHeldTextbox.Name = "productDetailOverviewUnitStockQuantityHeldTextbox";
            productDetailOverviewUnitStockQuantityHeldTextbox.ReadOnly = true;
            productDetailOverviewUnitStockQuantityHeldTextbox.Size = new Size(99, 27);
            productDetailOverviewUnitStockQuantityHeldTextbox.TabIndex = 16;
            // 
            // productDetailOverviewUnitStockQuantityHeldLabel
            // 
            productDetailOverviewUnitStockQuantityHeldLabel.AutoSize = true;
            productDetailOverviewUnitStockQuantityHeldLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewUnitStockQuantityHeldLabel.Location = new Point(93, 155);
            productDetailOverviewUnitStockQuantityHeldLabel.Name = "productDetailOverviewUnitStockQuantityHeldLabel";
            productDetailOverviewUnitStockQuantityHeldLabel.Size = new Size(172, 20);
            productDetailOverviewUnitStockQuantityHeldLabel.TabIndex = 56;
            productDetailOverviewUnitStockQuantityHeldLabel.Text = "Unit Stock Quantity Held";
            // 
            // productDetailOverviewWholesaleGroupBox
            // 
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesalePricePerUnitTextboxB);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesalePricePerUnitTextboxA);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleReorderFlagLabel);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesalePricePerUnitTextboxSeparator);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesalePricePerUnitLabel);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleReorderFlagPanel);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleCartonQuantityTextbox);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleUnitQuantityPerCartonTextbox);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleCartonQuantityLabel);
            productDetailOverviewWholesaleGroupBox.Controls.Add(productDetailOverviewWholesaleUnitQuantityPerCartonLabel);
            productDetailOverviewWholesaleGroupBox.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailOverviewWholesaleGroupBox.Location = new Point(23, 198);
            productDetailOverviewWholesaleGroupBox.Name = "productDetailOverviewWholesaleGroupBox";
            productDetailOverviewWholesaleGroupBox.Size = new Size(518, 246);
            productDetailOverviewWholesaleGroupBox.TabIndex = 76;
            productDetailOverviewWholesaleGroupBox.TabStop = false;
            productDetailOverviewWholesaleGroupBox.Text = "Wholesale";
            // 
            // productDetailOverviewWholesalePricePerUnitTextboxB
            // 
            productDetailOverviewWholesalePricePerUnitTextboxB.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesalePricePerUnitTextboxB.Location = new Point(402, 36);
            productDetailOverviewWholesalePricePerUnitTextboxB.MaxLength = 50;
            productDetailOverviewWholesalePricePerUnitTextboxB.Name = "productDetailOverviewWholesalePricePerUnitTextboxB";
            productDetailOverviewWholesalePricePerUnitTextboxB.ReadOnly = true;
            productDetailOverviewWholesalePricePerUnitTextboxB.Size = new Size(45, 27);
            productDetailOverviewWholesalePricePerUnitTextboxB.TabIndex = 6;
            // 
            // productDetailOverviewWholesalePricePerUnitTextboxA
            // 
            productDetailOverviewWholesalePricePerUnitTextboxA.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesalePricePerUnitTextboxA.Location = new Point(284, 36);
            productDetailOverviewWholesalePricePerUnitTextboxA.MaxLength = 50;
            productDetailOverviewWholesalePricePerUnitTextboxA.Name = "productDetailOverviewWholesalePricePerUnitTextboxA";
            productDetailOverviewWholesalePricePerUnitTextboxA.ReadOnly = true;
            productDetailOverviewWholesalePricePerUnitTextboxA.Size = new Size(99, 27);
            productDetailOverviewWholesalePricePerUnitTextboxA.TabIndex = 5;
            // 
            // productDetailOverviewWholesaleReorderFlagLabel
            // 
            productDetailOverviewWholesaleReorderFlagLabel.AutoSize = true;
            productDetailOverviewWholesaleReorderFlagLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleReorderFlagLabel.Location = new Point(125, 183);
            productDetailOverviewWholesaleReorderFlagLabel.Name = "productDetailOverviewWholesaleReorderFlagLabel";
            productDetailOverviewWholesaleReorderFlagLabel.Size = new Size(149, 20);
            productDetailOverviewWholesaleReorderFlagLabel.TabIndex = 72;
            productDetailOverviewWholesaleReorderFlagLabel.Text = "Wbolesale Reorder?*";
            // 
            // productDetailOverviewWholesalePricePerUnitTextboxSeparator
            // 
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.AutoSize = true;
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.Location = new Point(388, 43);
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.Name = "productDetailOverviewWholesalePricePerUnitTextboxSeparator";
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.Size = new Size(12, 20);
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.TabIndex = 73;
            productDetailOverviewWholesalePricePerUnitTextboxSeparator.Text = ".";
            // 
            // productDetailOverviewWholesalePricePerUnitLabel
            // 
            productDetailOverviewWholesalePricePerUnitLabel.AutoSize = true;
            productDetailOverviewWholesalePricePerUnitLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesalePricePerUnitLabel.Location = new Point(98, 39);
            productDetailOverviewWholesalePricePerUnitLabel.Name = "productDetailOverviewWholesalePricePerUnitLabel";
            productDetailOverviewWholesalePricePerUnitLabel.Size = new Size(175, 20);
            productDetailOverviewWholesalePricePerUnitLabel.TabIndex = 57;
            productDetailOverviewWholesalePricePerUnitLabel.Text = "Wholesale Price Per Unit*";
            // 
            // productDetailOverviewWholesaleReorderFlagPanel
            // 
            productDetailOverviewWholesaleReorderFlagPanel.Controls.Add(productDetailOverviewWholesaleReorderFlagYesRadioButton);
            productDetailOverviewWholesaleReorderFlagPanel.Controls.Add(productDetailOverviewWholesaleReorderFlagNoRadioButton);
            productDetailOverviewWholesaleReorderFlagPanel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleReorderFlagPanel.Location = new Point(284, 160);
            productDetailOverviewWholesaleReorderFlagPanel.Name = "productDetailOverviewWholesaleReorderFlagPanel";
            productDetailOverviewWholesaleReorderFlagPanel.Size = new Size(166, 61);
            productDetailOverviewWholesaleReorderFlagPanel.TabIndex = 67;
            // 
            // productDetailOverviewWholesaleReorderFlagYesRadioButton
            // 
            productDetailOverviewWholesaleReorderFlagYesRadioButton.AutoSize = true;
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Enabled = false;
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Location = new Point(93, 21);
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Name = "productDetailOverviewWholesaleReorderFlagYesRadioButton";
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Size = new Size(48, 24);
            productDetailOverviewWholesaleReorderFlagYesRadioButton.TabIndex = 10;
            productDetailOverviewWholesaleReorderFlagYesRadioButton.Text = "Yes";
            productDetailOverviewWholesaleReorderFlagYesRadioButton.UseVisualStyleBackColor = true;
            // 
            // productDetailOverviewWholesaleReorderFlagNoRadioButton
            // 
            productDetailOverviewWholesaleReorderFlagNoRadioButton.AutoSize = true;
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Enabled = false;
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Location = new Point(17, 21);
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Name = "productDetailOverviewWholesaleReorderFlagNoRadioButton";
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Size = new Size(47, 24);
            productDetailOverviewWholesaleReorderFlagNoRadioButton.TabIndex = 9;
            productDetailOverviewWholesaleReorderFlagNoRadioButton.Text = "No";
            productDetailOverviewWholesaleReorderFlagNoRadioButton.UseVisualStyleBackColor = true;
            // 
            // productDetailOverviewWholesaleCartonQuantityTextbox
            // 
            productDetailOverviewWholesaleCartonQuantityTextbox.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleCartonQuantityTextbox.Location = new Point(284, 122);
            productDetailOverviewWholesaleCartonQuantityTextbox.MaxLength = 50;
            productDetailOverviewWholesaleCartonQuantityTextbox.Name = "productDetailOverviewWholesaleCartonQuantityTextbox";
            productDetailOverviewWholesaleCartonQuantityTextbox.ReadOnly = true;
            productDetailOverviewWholesaleCartonQuantityTextbox.Size = new Size(99, 27);
            productDetailOverviewWholesaleCartonQuantityTextbox.TabIndex = 8;
            // 
            // productDetailOverviewWholesaleUnitQuantityPerCartonTextbox
            // 
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Location = new Point(284, 77);
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.MaxLength = 50;
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Name = "productDetailOverviewWholesaleUnitQuantityPerCartonTextbox";
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.ReadOnly = true;
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.Size = new Size(99, 27);
            productDetailOverviewWholesaleUnitQuantityPerCartonTextbox.TabIndex = 7;
            // 
            // productDetailOverviewWholesaleCartonQuantityLabel
            // 
            productDetailOverviewWholesaleCartonQuantityLabel.AutoSize = true;
            productDetailOverviewWholesaleCartonQuantityLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleCartonQuantityLabel.Location = new Point(81, 125);
            productDetailOverviewWholesaleCartonQuantityLabel.Name = "productDetailOverviewWholesaleCartonQuantityLabel";
            productDetailOverviewWholesaleCartonQuantityLabel.Size = new Size(192, 20);
            productDetailOverviewWholesaleCartonQuantityLabel.TabIndex = 54;
            productDetailOverviewWholesaleCartonQuantityLabel.Text = "Wholesale Carton Quantity*";
            // 
            // productDetailOverviewWholesaleUnitQuantityPerCartonLabel
            // 
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.AutoSize = true;
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.Font = new Font("Segoe UI", 11F);
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.Location = new Point(26, 80);
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.Name = "productDetailOverviewWholesaleUnitQuantityPerCartonLabel";
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.Size = new Size(247, 20);
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.TabIndex = 55;
            productDetailOverviewWholesaleUnitQuantityPerCartonLabel.Text = "Wholesale Unit Quantity Per Carton*";
            // 
            // productDetailOverviewSupplierComboBox
            // 
            productDetailOverviewSupplierComboBox.Enabled = false;
            productDetailOverviewSupplierComboBox.FormattingEnabled = true;
            productDetailOverviewSupplierComboBox.Location = new Point(171, 154);
            productDetailOverviewSupplierComboBox.Name = "productDetailOverviewSupplierComboBox";
            productDetailOverviewSupplierComboBox.Size = new Size(370, 28);
            productDetailOverviewSupplierComboBox.TabIndex = 4;
            // 
            // productDetailOverviewProductCategoryComboBox
            // 
            productDetailOverviewProductCategoryComboBox.Enabled = false;
            productDetailOverviewProductCategoryComboBox.FormattingEnabled = true;
            productDetailOverviewProductCategoryComboBox.Location = new Point(171, 110);
            productDetailOverviewProductCategoryComboBox.Name = "productDetailOverviewProductCategoryComboBox";
            productDetailOverviewProductCategoryComboBox.Size = new Size(370, 28);
            productDetailOverviewProductCategoryComboBox.TabIndex = 3;
            // 
            // productDetailOverviewProductNameTextbox
            // 
            productDetailOverviewProductNameTextbox.Location = new Point(171, 70);
            productDetailOverviewProductNameTextbox.MaxLength = 50;
            productDetailOverviewProductNameTextbox.Name = "productDetailOverviewProductNameTextbox";
            productDetailOverviewProductNameTextbox.ReadOnly = true;
            productDetailOverviewProductNameTextbox.Size = new Size(370, 27);
            productDetailOverviewProductNameTextbox.TabIndex = 2;
            // 
            // productDetailOverviewProductNameLabel
            // 
            productDetailOverviewProductNameLabel.AutoSize = true;
            productDetailOverviewProductNameLabel.Location = new Point(43, 73);
            productDetailOverviewProductNameLabel.Name = "productDetailOverviewProductNameLabel";
            productDetailOverviewProductNameLabel.Size = new Size(110, 20);
            productDetailOverviewProductNameLabel.TabIndex = 66;
            productDetailOverviewProductNameLabel.Text = "Product Name*";
            // 
            // productDetailOverviewProductCategoryLabel
            // 
            productDetailOverviewProductCategoryLabel.AutoSize = true;
            productDetailOverviewProductCategoryLabel.Location = new Point(23, 113);
            productDetailOverviewProductCategoryLabel.Name = "productDetailOverviewProductCategoryLabel";
            productDetailOverviewProductCategoryLabel.Size = new Size(130, 20);
            productDetailOverviewProductCategoryLabel.TabIndex = 67;
            productDetailOverviewProductCategoryLabel.Text = "Product Category*";
            // 
            // productDetailOverviewSupplierLabel
            // 
            productDetailOverviewSupplierLabel.AutoSize = true;
            productDetailOverviewSupplierLabel.Location = new Point(83, 157);
            productDetailOverviewSupplierLabel.Name = "productDetailOverviewSupplierLabel";
            productDetailOverviewSupplierLabel.Size = new Size(70, 20);
            productDetailOverviewSupplierLabel.TabIndex = 68;
            productDetailOverviewSupplierLabel.Text = "Supplier*";
            // 
            // productDetailTabControlProductImagePage
            // 
            productDetailTabControlProductImagePage.BackColor = Color.SkyBlue;
            productDetailTabControlProductImagePage.Controls.Add(productDetailProductImageRemoveProductImageButton);
            productDetailTabControlProductImagePage.Controls.Add(productDetailProductImagePictureBox);
            productDetailTabControlProductImagePage.Controls.Add(productDetailProductImagePictureBoxLabel);
            productDetailTabControlProductImagePage.Controls.Add(productDetailProductImageChooseProductImageButton);
            productDetailTabControlProductImagePage.Location = new Point(4, 32);
            productDetailTabControlProductImagePage.Name = "productDetailTabControlProductImagePage";
            productDetailTabControlProductImagePage.Size = new Size(1256, 589);
            productDetailTabControlProductImagePage.TabIndex = 5;
            productDetailTabControlProductImagePage.Text = "Product Image";
            // 
            // productDetailProductImagePictureBox
            // 
            productDetailProductImagePictureBox.BorderStyle = BorderStyle.Fixed3D;
            productDetailProductImagePictureBox.Location = new Point(134, 76);
            productDetailProductImagePictureBox.Name = "productDetailProductImagePictureBox";
            productDetailProductImagePictureBox.Size = new Size(500, 500);
            productDetailProductImagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            productDetailProductImagePictureBox.TabIndex = 79;
            productDetailProductImagePictureBox.TabStop = false;
            // 
            // productDetailProductImagePictureBoxLabel
            // 
            productDetailProductImagePictureBoxLabel.AutoSize = true;
            productDetailProductImagePictureBoxLabel.Font = new Font("Segoe UI", 11F);
            productDetailProductImagePictureBoxLabel.Location = new Point(22, 76);
            productDetailProductImagePictureBoxLabel.Name = "productDetailProductImagePictureBoxLabel";
            productDetailProductImagePictureBoxLabel.Size = new Size(106, 20);
            productDetailProductImagePictureBoxLabel.TabIndex = 81;
            productDetailProductImagePictureBoxLabel.Text = "Product Image";
            // 
            // productDetailProductImageChooseProductImageButton
            // 
            productDetailProductImageChooseProductImageButton.Enabled = false;
            productDetailProductImageChooseProductImageButton.FlatStyle = FlatStyle.Flat;
            productDetailProductImageChooseProductImageButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailProductImageChooseProductImageButton.Location = new Point(134, 12);
            productDetailProductImageChooseProductImageButton.Margin = new Padding(4);
            productDetailProductImageChooseProductImageButton.Name = "productDetailProductImageChooseProductImageButton";
            productDetailProductImageChooseProductImageButton.Size = new Size(159, 51);
            productDetailProductImageChooseProductImageButton.TabIndex = 21;
            productDetailProductImageChooseProductImageButton.Text = "Choose Product Image";
            productDetailProductImageChooseProductImageButton.UseVisualStyleBackColor = true;
            productDetailProductImageChooseProductImageButton.Click += productDetailProductImageChooseProductImageButton_Click;
            // 
            // productDetailTabControlProductNotesPage
            // 
            productDetailTabControlProductNotesPage.BackColor = Color.SkyBlue;
            productDetailTabControlProductNotesPage.Controls.Add(productDetailProductNotesRefreshDataButton);
            productDetailTabControlProductNotesPage.Controls.Add(productDetailProductNotesCreateNewProductNoteButton);
            productDetailTabControlProductNotesPage.Controls.Add(productDetailProductNotesExistingProductNotesDataGridView);
            productDetailTabControlProductNotesPage.Location = new Point(4, 27);
            productDetailTabControlProductNotesPage.Name = "productDetailTabControlProductNotesPage";
            productDetailTabControlProductNotesPage.Size = new Size(1256, 594);
            productDetailTabControlProductNotesPage.TabIndex = 4;
            productDetailTabControlProductNotesPage.Text = "Product Notes";
            // 
            // productDetailProductNotesRefreshDataButton
            // 
            productDetailProductNotesRefreshDataButton.FlatStyle = FlatStyle.Flat;
            productDetailProductNotesRefreshDataButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailProductNotesRefreshDataButton.Location = new Point(1093, 95);
            productDetailProductNotesRefreshDataButton.Margin = new Padding(4);
            productDetailProductNotesRefreshDataButton.Name = "productDetailProductNotesRefreshDataButton";
            productDetailProductNotesRefreshDataButton.Size = new Size(151, 70);
            productDetailProductNotesRefreshDataButton.TabIndex = 23;
            productDetailProductNotesRefreshDataButton.Text = "Refresh Data";
            productDetailProductNotesRefreshDataButton.UseVisualStyleBackColor = true;
            productDetailProductNotesRefreshDataButton.Click += ProductDetailProductNotesRefreshDataButton_Click;
            // 
            // productDetailProductNotesCreateNewProductNoteButton
            // 
            productDetailProductNotesCreateNewProductNoteButton.FlatStyle = FlatStyle.Flat;
            productDetailProductNotesCreateNewProductNoteButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailProductNotesCreateNewProductNoteButton.Location = new Point(1093, 17);
            productDetailProductNotesCreateNewProductNoteButton.Margin = new Padding(4);
            productDetailProductNotesCreateNewProductNoteButton.Name = "productDetailProductNotesCreateNewProductNoteButton";
            productDetailProductNotesCreateNewProductNoteButton.Size = new Size(151, 70);
            productDetailProductNotesCreateNewProductNoteButton.TabIndex = 22;
            productDetailProductNotesCreateNewProductNoteButton.Text = "Create New Product Note";
            productDetailProductNotesCreateNewProductNoteButton.UseVisualStyleBackColor = true;
            productDetailProductNotesCreateNewProductNoteButton.Click += ProductDetailProductNotesCreateNewProductNoteButton_Click;
            // 
            // productDetailProductNotesExistingProductNotesDataGridView
            // 
            productDetailProductNotesExistingProductNotesDataGridView.AllowUserToAddRows = false;
            productDetailProductNotesExistingProductNotesDataGridView.AllowUserToDeleteRows = false;
            productDetailProductNotesExistingProductNotesDataGridView.BackgroundColor = Color.SkyBlue;
            productDetailProductNotesExistingProductNotesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productDetailProductNotesExistingProductNotesDataGridView.Location = new Point(21, 17);
            productDetailProductNotesExistingProductNotesDataGridView.Name = "productDetailProductNotesExistingProductNotesDataGridView";
            productDetailProductNotesExistingProductNotesDataGridView.ReadOnly = true;
            productDetailProductNotesExistingProductNotesDataGridView.Size = new Size(1059, 523);
            productDetailProductNotesExistingProductNotesDataGridView.TabIndex = 21;
            // 
            // productDetailProductImageRemoveProductImageButton
            // 
            productDetailProductImageRemoveProductImageButton.FlatStyle = FlatStyle.Flat;
            productDetailProductImageRemoveProductImageButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            productDetailProductImageRemoveProductImageButton.Location = new Point(301, 12);
            productDetailProductImageRemoveProductImageButton.Margin = new Padding(4);
            productDetailProductImageRemoveProductImageButton.Name = "productDetailProductImageRemoveProductImageButton";
            productDetailProductImageRemoveProductImageButton.Size = new Size(159, 51);
            productDetailProductImageRemoveProductImageButton.TabIndex = 82;
            productDetailProductImageRemoveProductImageButton.Text = "Remove Product Image";
            productDetailProductImageRemoveProductImageButton.UseVisualStyleBackColor = true;
            productDetailProductImageRemoveProductImageButton.Click += productDetailProductImageRemoveProductImageButton_Click;
            // 
            // ProductDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1289, 836);
            Controls.Add(productDetailTabControl);
            Controls.Add(productDetailUpdateProductButton);
            Controls.Add(productDetailToggleEditModeButton);
            Controls.Add(productDetailTitleLabel);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "ProductDetail";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CRM - Product Detail";
            productDetailTabControl.ResumeLayout(false);
            productDetailTabControlOverviewPage.ResumeLayout(false);
            productDetailTabControlOverviewPage.PerformLayout();
            productDetailOverviewPerUnitGroupBox.ResumeLayout(false);
            productDetailOverviewPerUnitGroupBox.PerformLayout();
            productDetailOverviewWholesaleGroupBox.ResumeLayout(false);
            productDetailOverviewWholesaleGroupBox.PerformLayout();
            productDetailOverviewWholesaleReorderFlagPanel.ResumeLayout(false);
            productDetailOverviewWholesaleReorderFlagPanel.PerformLayout();
            productDetailTabControlProductImagePage.ResumeLayout(false);
            productDetailTabControlProductImagePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productDetailProductImagePictureBox).EndInit();
            productDetailTabControlProductNotesPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productDetailProductNotesExistingProductNotesDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button productDetailUpdateProductButton;
        private CheckBox productDetailOverviewActiveStatusCheckbox;
        private Button productDetailToggleEditModeButton;
        private TextBox productDetailOverviewProductIdTextbox;
        private TextBox productDetailOverviewCreatedTimestampTextbox;
        private TextBox productDetailOverviewLastUpdatedTimestampTextbox;
        private TextBox productDetailOverviewCreatedByTextbox;
        private TextBox productDetailOverviewLastUpdatedByTextbox;
        private Label productDetailOverviewLastUpdatedTimestampTextboxLabel;
        private Label productDetailOverviewLastUpdatedByTextboxLabel;
        private Label productDetailOverviewCreatedTimestampTextboxLabel;
        private Label productDetailOverviewCreatedByTextboxLabel;
        private Label productDetailProductIdLabel;
        private Label productDetailTitleLabel;
        private TabControl productDetailTabControl;
        private TabPage productDetailTabControlOverviewPage;
        private TabPage productDetailTabControlProductNotesPage;
        private Button productDetailProductNotesCreateNewProductNoteButton;
        private DataGridView productDetailProductNotesExistingProductNotesDataGridView;
        private ComboBox productDetailOverviewSupplierComboBox;
        private ComboBox productDetailOverviewProductCategoryComboBox;
        private TextBox productDetailOverviewProductNameTextbox;
        private Label productDetailOverviewProductNameLabel;
        private Label productDetailOverviewProductCategoryLabel;
        private Label productDetailOverviewSupplierLabel;
        private GroupBox productDetailOverviewWholesaleGroupBox;
        private TextBox productDetailOverviewWholesalePricePerUnitTextboxB;
        private TextBox productDetailOverviewWholesalePricePerUnitTextboxA;
        private Label productDetailOverviewWholesaleReorderFlagLabel;
        private Label productDetailOverviewWholesalePricePerUnitTextboxSeparator;
        private Label productDetailOverviewWholesalePricePerUnitLabel;
        private Panel productDetailOverviewWholesaleReorderFlagPanel;
        private RadioButton productDetailOverviewWholesaleReorderFlagYesRadioButton;
        private RadioButton productDetailOverviewWholesaleReorderFlagNoRadioButton;
        private TextBox productDetailOverviewWholesaleCartonQuantityTextbox;
        private TextBox productDetailOverviewWholesaleUnitQuantityPerCartonTextbox;
        private Label productDetailOverviewWholesaleCartonQuantityLabel;
        private Label productDetailOverviewWholesaleUnitQuantityPerCartonLabel;
        private GroupBox productDetailOverviewPerUnitGroupBox;
        private TextBox productDetailOverviewUnitMinimumStockQuantityTextbox;
        private Label productDetailOverviewUnitMinimumStockQuantityLabel;
        private TextBox productDetailOverviewUnitMinimumOrderQuantityTextbox;
        private Label productDetailOverviewUnitMinimumOrderQuantityLabel;
        private TextBox productDetailOverviewUnitPriceTextboxB;
        private Label productDetailOverviewUnitPriceLabel;
        private Label productDetailOverviewUnitPriceTextboxSeparatorLabel;
        private TextBox productDetailOverviewUnitPriceTextboxA;
        private TextBox productDetailOverviewUnitStockQuantityHeldTextbox;
        private Label productDetailOverviewUnitStockQuantityHeldLabel;
        private Button productDetailProductNotesRefreshDataButton;
        private TabPage productDetailTabControlProductImagePage;
        private PictureBox productDetailProductImagePictureBox;
        private Label productDetailProductImagePictureBoxLabel;
        private Button productDetailProductImageChooseProductImageButton;
        private Button productDetailProductImageRemoveProductImageButton;
    }
}