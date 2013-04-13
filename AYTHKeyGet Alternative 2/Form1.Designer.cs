namespace AYTHKeyGet_Alternative_2
{
    partial class frmBrowser
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
            this.browserEx = new csExWB.cEXWB();
            this.SuspendLayout();
            // 
            // browserEx
            // 
            this.browserEx.Border3DEnabled = false;
            this.browserEx.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.browserEx.DocumentTitle = "";
            this.browserEx.DownloadActiveX = true;
            this.browserEx.DownloadFrames = true;
            this.browserEx.DownloadImages = true;
            this.browserEx.DownloadJava = true;
            this.browserEx.DownloadScripts = true;
            this.browserEx.DownloadSounds = true;
            this.browserEx.DownloadVideo = true;
            this.browserEx.FileDownloadDirectory = "C:\\";
            this.browserEx.Location = new System.Drawing.Point(12, 6);
            this.browserEx.LocationUrl = "about:blank";
            this.browserEx.Name = "browserEx";
            this.browserEx.ObjectForScripting = null;
            this.browserEx.OffLine = false;
            this.browserEx.RegisterAsBrowser = false;
            this.browserEx.RegisterAsDropTarget = false;
            this.browserEx.RegisterForInternalDragDrop = true;
            this.browserEx.ScrollBarsEnabled = true;
            this.browserEx.SendSourceOnDocumentCompleteWBEx = false;
            this.browserEx.Silent = false;
            this.browserEx.Size = new System.Drawing.Size(207, 34);
            this.browserEx.TabIndex = 0;
            this.browserEx.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.browserEx.UseInternalDownloadManager = true;
            this.browserEx.WBDOCDOWNLOADCTLFLAG = 112;
            this.browserEx.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.browserEx.WBDOCHOSTUIFLAG = 262276;
            this.browserEx.ProtocolHandlerBeginTransaction += new csExWB.ProtocolHandlerBeginTransactionEventHandler(this.browserEx_ProtocolHandlerBeginTransaction);
            this.browserEx.ProtocolHandlerOnResponse += new csExWB.ProtocolHandlerOnResponseEventHandler(this.browserEx_ProtocolHandlerOnResponse);
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 48);
            this.Controls.Add(this.browserEx);
            this.Name = "frmBrowser";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBrowser_FormClosing);
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private csExWB.cEXWB browserEx;

    }
}

