namespace BookShop
{
    partial class Bookstore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bookstore));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.FileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderMenuMake = new System.Windows.Forms.ToolStripMenuItem();
            this.OrderMenuMyOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuContact = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.LoginStatus = new System.Windows.Forms.Label();
            this.BookSelector = new System.Windows.Forms.ComboBox();
            this.BookSelectorText = new System.Windows.Forms.Label();
            this.AddBookSellectorText = new System.Windows.Forms.Label();
            this.AuthorBookSelector = new System.Windows.Forms.ComboBox();
            this.GenreBookSelector = new System.Windows.Forms.ComboBox();
            this.AuthorBookSelectorText = new System.Windows.Forms.Label();
            this.GenreBookSelectorText = new System.Windows.Forms.Label();
            this.PublisherBookSelectorText = new System.Windows.Forms.Label();
            this.PublisherBookSelector = new System.Windows.Forms.ComboBox();
            this.CategoryBookSelector = new System.Windows.Forms.ComboBox();
            this.CategoryBookSelectorText = new System.Windows.Forms.Label();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.AmountBoxText = new System.Windows.Forms.Label();
            this.SubmitBook = new System.Windows.Forms.Button();
            this.BookChoicePanel = new System.Windows.Forms.Panel();
            this.PickedBooksPanel = new System.Windows.Forms.Panel();
            this.DeletePicked = new System.Windows.Forms.ComboBox();
            this.DeletePickedLabel = new System.Windows.Forms.Label();
            this.DeletePickedSubmit = new System.Windows.Forms.Button();
            this.PickedOrder = new System.Windows.Forms.Label();
            this.SubmitOrder = new System.Windows.Forms.Button();
            this.PickedBooksLabel = new System.Windows.Forms.Label();
            this.MyOrdersPanel = new System.Windows.Forms.Panel();
            this.MyOrdersDGV = new System.Windows.Forms.DataGridView();
            this.MyOrdersLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.BookChoicePanel.SuspendLayout();
            this.PickedBooksPanel.SuspendLayout();
            this.MyOrdersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyOrdersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::BookShop.Properties.Resources.background60;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OrderMenu,
            this.HelpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenuLogin,
            this.FileMenuExit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // FileMenuLogin
            // 
            this.FileMenuLogin.Name = "FileMenuLogin";
            this.FileMenuLogin.Size = new System.Drawing.Size(104, 22);
            this.FileMenuLogin.Text = "Login";
            this.FileMenuLogin.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // FileMenuExit
            // 
            this.FileMenuExit.Name = "FileMenuExit";
            this.FileMenuExit.Size = new System.Drawing.Size(104, 22);
            this.FileMenuExit.Text = "Exit";
            this.FileMenuExit.Click += new System.EventHandler(this.FileMenuExit_Click);
            // 
            // OrderMenu
            // 
            this.OrderMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OrderMenuMake,
            this.OrderMenuMyOrders});
            this.OrderMenu.Name = "OrderMenu";
            this.OrderMenu.Size = new System.Drawing.Size(54, 20);
            this.OrderMenu.Text = "Orders";
            // 
            // OrderMenuMake
            // 
            this.OrderMenuMake.Enabled = false;
            this.OrderMenuMake.Name = "OrderMenuMake";
            this.OrderMenuMake.Size = new System.Drawing.Size(152, 22);
            this.OrderMenuMake.Text = "Make an Order";
            this.OrderMenuMake.Click += new System.EventHandler(this.OrderMenuMake_Click);
            // 
            // OrderMenuMyOrders
            // 
            this.OrderMenuMyOrders.Enabled = false;
            this.OrderMenuMyOrders.Name = "OrderMenuMyOrders";
            this.OrderMenuMyOrders.Size = new System.Drawing.Size(152, 22);
            this.OrderMenuMyOrders.Text = "My Orders";
            this.OrderMenuMyOrders.Click += new System.EventHandler(this.OrderMenuMyOrders_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpMenuContact,
            this.HelpMenuAbout});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(44, 20);
            this.HelpMenu.Text = "Help";
            // 
            // HelpMenuContact
            // 
            this.HelpMenuContact.Name = "HelpMenuContact";
            this.HelpMenuContact.Size = new System.Drawing.Size(116, 22);
            this.HelpMenuContact.Text = "Contact";
            this.HelpMenuContact.Click += new System.EventHandler(this.HelpMenuContact_Click);
            // 
            // HelpMenuAbout
            // 
            this.HelpMenuAbout.Name = "HelpMenuAbout";
            this.HelpMenuAbout.Size = new System.Drawing.Size(116, 22);
            this.HelpMenuAbout.Text = "About";
            this.HelpMenuAbout.Click += new System.EventHandler(this.HelpMenuAbout_Click);
            // 
            // LoginStatus
            // 
            this.LoginStatus.BackColor = System.Drawing.Color.Transparent;
            this.LoginStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoginStatus.Location = new System.Drawing.Point(0, 348);
            this.LoginStatus.Name = "LoginStatus";
            this.LoginStatus.Size = new System.Drawing.Size(898, 13);
            this.LoginStatus.TabIndex = 1;
            this.LoginStatus.Text = "Not logged in";
            // 
            // BookSelector
            // 
            this.BookSelector.FormattingEnabled = true;
            this.BookSelector.Location = new System.Drawing.Point(55, 22);
            this.BookSelector.Name = "BookSelector";
            this.BookSelector.Size = new System.Drawing.Size(121, 21);
            this.BookSelector.TabIndex = 2;
            // 
            // BookSelectorText
            // 
            this.BookSelectorText.AutoSize = true;
            this.BookSelectorText.BackColor = System.Drawing.Color.Transparent;
            this.BookSelectorText.Location = new System.Drawing.Point(79, 6);
            this.BookSelectorText.Name = "BookSelectorText";
            this.BookSelectorText.Size = new System.Drawing.Size(73, 13);
            this.BookSelectorText.TabIndex = 3;
            this.BookSelectorText.Text = "Select a book";
            // 
            // AddBookSellectorText
            // 
            this.AddBookSellectorText.AutoSize = true;
            this.AddBookSellectorText.BackColor = System.Drawing.Color.Transparent;
            this.AddBookSellectorText.Location = new System.Drawing.Point(29, 46);
            this.AddBookSellectorText.Name = "AddBookSellectorText";
            this.AddBookSellectorText.Size = new System.Drawing.Size(177, 13);
            this.AddBookSellectorText.TabIndex = 4;
            this.AddBookSellectorText.Text = "Or Choose a category where to look";
            // 
            // AuthorBookSelector
            // 
            this.AuthorBookSelector.FormattingEnabled = true;
            this.AuthorBookSelector.Location = new System.Drawing.Point(9, 92);
            this.AuthorBookSelector.Name = "AuthorBookSelector";
            this.AuthorBookSelector.Size = new System.Drawing.Size(97, 21);
            this.AuthorBookSelector.TabIndex = 5;
            this.AuthorBookSelector.SelectedValueChanged += new System.EventHandler(this.AuthorBookSelector_SelectedValueChanged);
            // 
            // GenreBookSelector
            // 
            this.GenreBookSelector.FormattingEnabled = true;
            this.GenreBookSelector.Location = new System.Drawing.Point(64, 132);
            this.GenreBookSelector.Name = "GenreBookSelector";
            this.GenreBookSelector.Size = new System.Drawing.Size(97, 21);
            this.GenreBookSelector.TabIndex = 6;
            this.GenreBookSelector.SelectedValueChanged += new System.EventHandler(this.GenreBookSelector_SelectedValueChanged);
            // 
            // AuthorBookSelectorText
            // 
            this.AuthorBookSelectorText.AutoSize = true;
            this.AuthorBookSelectorText.BackColor = System.Drawing.Color.Transparent;
            this.AuthorBookSelectorText.Location = new System.Drawing.Point(29, 73);
            this.AuthorBookSelectorText.Name = "AuthorBookSelectorText";
            this.AuthorBookSelectorText.Size = new System.Drawing.Size(43, 13);
            this.AuthorBookSelectorText.TabIndex = 7;
            this.AuthorBookSelectorText.Text = "Authors";
            // 
            // GenreBookSelectorText
            // 
            this.GenreBookSelectorText.AutoSize = true;
            this.GenreBookSelectorText.BackColor = System.Drawing.Color.Transparent;
            this.GenreBookSelectorText.Location = new System.Drawing.Point(99, 116);
            this.GenreBookSelectorText.Name = "GenreBookSelectorText";
            this.GenreBookSelectorText.Size = new System.Drawing.Size(36, 13);
            this.GenreBookSelectorText.TabIndex = 8;
            this.GenreBookSelectorText.Text = "Genre";
            // 
            // PublisherBookSelectorText
            // 
            this.PublisherBookSelectorText.AutoSize = true;
            this.PublisherBookSelectorText.BackColor = System.Drawing.Color.Transparent;
            this.PublisherBookSelectorText.Location = new System.Drawing.Point(144, 73);
            this.PublisherBookSelectorText.Name = "PublisherBookSelectorText";
            this.PublisherBookSelectorText.Size = new System.Drawing.Size(50, 13);
            this.PublisherBookSelectorText.TabIndex = 9;
            this.PublisherBookSelectorText.Text = "Publisher";
            // 
            // PublisherBookSelector
            // 
            this.PublisherBookSelector.FormattingEnabled = true;
            this.PublisherBookSelector.Location = new System.Drawing.Point(123, 92);
            this.PublisherBookSelector.Name = "PublisherBookSelector";
            this.PublisherBookSelector.Size = new System.Drawing.Size(97, 21);
            this.PublisherBookSelector.TabIndex = 10;
            this.PublisherBookSelector.SelectedValueChanged += new System.EventHandler(this.PublisherBookSelector_SelectedValueChanged);
            // 
            // CategoryBookSelector
            // 
            this.CategoryBookSelector.FormattingEnabled = true;
            this.CategoryBookSelector.Location = new System.Drawing.Point(55, 175);
            this.CategoryBookSelector.Name = "CategoryBookSelector";
            this.CategoryBookSelector.Size = new System.Drawing.Size(121, 21);
            this.CategoryBookSelector.TabIndex = 11;
            // 
            // CategoryBookSelectorText
            // 
            this.CategoryBookSelectorText.AutoSize = true;
            this.CategoryBookSelectorText.BackColor = System.Drawing.Color.Transparent;
            this.CategoryBookSelectorText.Location = new System.Drawing.Point(73, 159);
            this.CategoryBookSelectorText.Name = "CategoryBookSelectorText";
            this.CategoryBookSelectorText.Size = new System.Drawing.Size(97, 13);
            this.CategoryBookSelectorText.TabIndex = 12;
            this.CategoryBookSelectorText.Text = "Output by category";
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(70, 230);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(100, 20);
            this.AmountBox.TabIndex = 13;
            // 
            // AmountBoxText
            // 
            this.AmountBoxText.AutoSize = true;
            this.AmountBoxText.BackColor = System.Drawing.Color.Transparent;
            this.AmountBoxText.Location = new System.Drawing.Point(50, 214);
            this.AmountBoxText.Name = "AmountBoxText";
            this.AmountBoxText.Size = new System.Drawing.Size(156, 13);
            this.AmountBoxText.TabIndex = 14;
            this.AmountBoxText.Text = "Enter a Number of Picked book";
            // 
            // SubmitBook
            // 
            this.SubmitBook.Location = new System.Drawing.Point(9, 282);
            this.SubmitBook.Name = "SubmitBook";
            this.SubmitBook.Size = new System.Drawing.Size(201, 23);
            this.SubmitBook.TabIndex = 15;
            this.SubmitBook.Text = "Add the book to Shopping Cart";
            this.SubmitBook.UseVisualStyleBackColor = true;
            this.SubmitBook.Click += new System.EventHandler(this.SubmitBook_Click);
            // 
            // BookChoicePanel
            // 
            this.BookChoicePanel.BackgroundImage = global::BookShop.Properties.Resources.background34;
            this.BookChoicePanel.Controls.Add(this.BookSelectorText);
            this.BookChoicePanel.Controls.Add(this.SubmitBook);
            this.BookChoicePanel.Controls.Add(this.BookSelector);
            this.BookChoicePanel.Controls.Add(this.AmountBoxText);
            this.BookChoicePanel.Controls.Add(this.AddBookSellectorText);
            this.BookChoicePanel.Controls.Add(this.AmountBox);
            this.BookChoicePanel.Controls.Add(this.AuthorBookSelector);
            this.BookChoicePanel.Controls.Add(this.CategoryBookSelectorText);
            this.BookChoicePanel.Controls.Add(this.GenreBookSelector);
            this.BookChoicePanel.Controls.Add(this.CategoryBookSelector);
            this.BookChoicePanel.Controls.Add(this.AuthorBookSelectorText);
            this.BookChoicePanel.Controls.Add(this.PublisherBookSelector);
            this.BookChoicePanel.Controls.Add(this.GenreBookSelectorText);
            this.BookChoicePanel.Controls.Add(this.PublisherBookSelectorText);
            this.BookChoicePanel.Location = new System.Drawing.Point(3, 27);
            this.BookChoicePanel.Name = "BookChoicePanel";
            this.BookChoicePanel.Size = new System.Drawing.Size(225, 317);
            this.BookChoicePanel.TabIndex = 16;
            // 
            // PickedBooksPanel
            // 
            this.PickedBooksPanel.BackgroundImage = global::BookShop.Properties.Resources.background34;
            this.PickedBooksPanel.Controls.Add(this.DeletePicked);
            this.PickedBooksPanel.Controls.Add(this.DeletePickedLabel);
            this.PickedBooksPanel.Controls.Add(this.DeletePickedSubmit);
            this.PickedBooksPanel.Controls.Add(this.PickedOrder);
            this.PickedBooksPanel.Controls.Add(this.SubmitOrder);
            this.PickedBooksPanel.Controls.Add(this.PickedBooksLabel);
            this.PickedBooksPanel.Location = new System.Drawing.Point(229, 27);
            this.PickedBooksPanel.Name = "PickedBooksPanel";
            this.PickedBooksPanel.Size = new System.Drawing.Size(175, 317);
            this.PickedBooksPanel.TabIndex = 17;
            this.PickedBooksPanel.Visible = false;
            // 
            // DeletePicked
            // 
            this.DeletePicked.FormattingEnabled = true;
            this.DeletePicked.Location = new System.Drawing.Point(30, 172);
            this.DeletePicked.Name = "DeletePicked";
            this.DeletePicked.Size = new System.Drawing.Size(121, 21);
            this.DeletePicked.TabIndex = 5;
            // 
            // DeletePickedLabel
            // 
            this.DeletePickedLabel.AutoSize = true;
            this.DeletePickedLabel.BackColor = System.Drawing.Color.Transparent;
            this.DeletePickedLabel.Location = new System.Drawing.Point(14, 148);
            this.DeletePickedLabel.Name = "DeletePickedLabel";
            this.DeletePickedLabel.Size = new System.Drawing.Size(141, 13);
            this.DeletePickedLabel.TabIndex = 4;
            this.DeletePickedLabel.Text = "Pick Id to Delete From Order";
            // 
            // DeletePickedSubmit
            // 
            this.DeletePickedSubmit.Location = new System.Drawing.Point(17, 199);
            this.DeletePickedSubmit.Name = "DeletePickedSubmit";
            this.DeletePickedSubmit.Size = new System.Drawing.Size(135, 23);
            this.DeletePickedSubmit.TabIndex = 3;
            this.DeletePickedSubmit.Text = "Delete Book From Order";
            this.DeletePickedSubmit.UseVisualStyleBackColor = true;
            this.DeletePickedSubmit.Click += new System.EventHandler(this.DeletePickedSubmit_Click);
            // 
            // PickedOrder
            // 
            this.PickedOrder.AutoSize = true;
            this.PickedOrder.BackColor = System.Drawing.Color.Transparent;
            this.PickedOrder.Location = new System.Drawing.Point(23, 42);
            this.PickedOrder.Name = "PickedOrder";
            this.PickedOrder.Size = new System.Drawing.Size(13, 13);
            this.PickedOrder.TabIndex = 2;
            this.PickedOrder.Text = "  ";
            // 
            // SubmitOrder
            // 
            this.SubmitOrder.Location = new System.Drawing.Point(4, 281);
            this.SubmitOrder.Name = "SubmitOrder";
            this.SubmitOrder.Size = new System.Drawing.Size(160, 23);
            this.SubmitOrder.TabIndex = 1;
            this.SubmitOrder.Text = "Submit Order";
            this.SubmitOrder.UseVisualStyleBackColor = true;
            this.SubmitOrder.Click += new System.EventHandler(this.SubmitOrder_Click);
            // 
            // PickedBooksLabel
            // 
            this.PickedBooksLabel.AutoSize = true;
            this.PickedBooksLabel.BackColor = System.Drawing.Color.Transparent;
            this.PickedBooksLabel.Location = new System.Drawing.Point(46, 5);
            this.PickedBooksLabel.Name = "PickedBooksLabel";
            this.PickedBooksLabel.Size = new System.Drawing.Size(73, 13);
            this.PickedBooksLabel.TabIndex = 0;
            this.PickedBooksLabel.Text = "Picked Books";
            // 
            // MyOrdersPanel
            // 
            this.MyOrdersPanel.BackgroundImage = global::BookShop.Properties.Resources.background34;
            this.MyOrdersPanel.Controls.Add(this.MyOrdersDGV);
            this.MyOrdersPanel.Controls.Add(this.MyOrdersLabel);
            this.MyOrdersPanel.Location = new System.Drawing.Point(410, 28);
            this.MyOrdersPanel.Name = "MyOrdersPanel";
            this.MyOrdersPanel.Size = new System.Drawing.Size(488, 317);
            this.MyOrdersPanel.TabIndex = 18;
            this.MyOrdersPanel.Visible = false;
            // 
            // MyOrdersDGV
            // 
            this.MyOrdersDGV.AllowUserToAddRows = false;
            this.MyOrdersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.MyOrdersDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.MyOrdersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyOrdersDGV.Location = new System.Drawing.Point(3, 32);
            this.MyOrdersDGV.Name = "MyOrdersDGV";
            this.MyOrdersDGV.ReadOnly = true;
            this.MyOrdersDGV.RowHeadersVisible = false;
            this.MyOrdersDGV.ShowEditingIcon = false;
            this.MyOrdersDGV.Size = new System.Drawing.Size(482, 272);
            this.MyOrdersDGV.TabIndex = 2;
            // 
            // MyOrdersLabel
            // 
            this.MyOrdersLabel.AutoSize = true;
            this.MyOrdersLabel.BackColor = System.Drawing.Color.Transparent;
            this.MyOrdersLabel.Location = new System.Drawing.Point(196, 5);
            this.MyOrdersLabel.Name = "MyOrdersLabel";
            this.MyOrdersLabel.Size = new System.Drawing.Size(55, 13);
            this.MyOrdersLabel.TabIndex = 0;
            this.MyOrdersLabel.Text = "My Orders";
            // 
            // Bookstore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BookShop.Properties.Resources.background48;
            this.ClientSize = new System.Drawing.Size(898, 361);
            this.Controls.Add(this.MyOrdersPanel);
            this.Controls.Add(this.PickedBooksPanel);
            this.Controls.Add(this.BookChoicePanel);
            this.Controls.Add(this.LoginStatus);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(914, 400);
            this.MinimumSize = new System.Drawing.Size(914, 400);
            this.Name = "Bookstore";
            this.ShowInTaskbar = false;
            this.Text = "Bookstore";
            this.Load += new System.EventHandler(this.Bookstore_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BookChoicePanel.ResumeLayout(false);
            this.BookChoicePanel.PerformLayout();
            this.PickedBooksPanel.ResumeLayout(false);
            this.PickedBooksPanel.PerformLayout();
            this.MyOrdersPanel.ResumeLayout(false);
            this.MyOrdersPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyOrdersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenuLogin;
        private System.Windows.Forms.ToolStripMenuItem FileMenuExit;
        private System.Windows.Forms.Label LoginStatus;
        private System.Windows.Forms.ComboBox BookSelector;
        private System.Windows.Forms.Label BookSelectorText;
        private System.Windows.Forms.Label AddBookSellectorText;
        private System.Windows.Forms.ComboBox AuthorBookSelector;
        private System.Windows.Forms.ComboBox GenreBookSelector;
        private System.Windows.Forms.Label AuthorBookSelectorText;
        private System.Windows.Forms.Label GenreBookSelectorText;
        private System.Windows.Forms.Label PublisherBookSelectorText;
        private System.Windows.Forms.ComboBox PublisherBookSelector;
        private System.Windows.Forms.ComboBox CategoryBookSelector;
        private System.Windows.Forms.Label CategoryBookSelectorText;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.Label AmountBoxText;
        private System.Windows.Forms.Button SubmitBook;
        private System.Windows.Forms.Panel BookChoicePanel;
        private System.Windows.Forms.Panel PickedBooksPanel;
        private System.Windows.Forms.Label PickedBooksLabel;
        private System.Windows.Forms.ToolStripMenuItem OrderMenu;
        private System.Windows.Forms.ToolStripMenuItem OrderMenuMake;
        private System.Windows.Forms.ToolStripMenuItem OrderMenuMyOrders;
        private System.Windows.Forms.Panel MyOrdersPanel;
        private System.Windows.Forms.Label MyOrdersLabel;
        private System.Windows.Forms.DataGridView MyOrdersDGV;
        private System.Windows.Forms.Button SubmitOrder;
        private System.Windows.Forms.Label PickedOrder;
        private System.Windows.Forms.Button DeletePickedSubmit;
        private System.Windows.Forms.Label DeletePickedLabel;
        private System.Windows.Forms.ComboBox DeletePicked;
        private System.Windows.Forms.ToolStripMenuItem HelpMenu;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuContact;
        private System.Windows.Forms.ToolStripMenuItem HelpMenuAbout;
    }
}

