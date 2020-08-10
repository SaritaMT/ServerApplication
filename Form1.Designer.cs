namespace ServerApplication
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
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.labelServerState = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxClientData = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxHTTPData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Location = new System.Drawing.Point(56, 26);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStopServer.TabIndex = 1;
            this.buttonStopServer.Text = "Stop Server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // labelServerState
            // 
            this.labelServerState.AutoSize = true;
            this.labelServerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerState.Location = new System.Drawing.Point(289, 9);
            this.labelServerState.Name = "labelServerState";
            this.labelServerState.Size = new System.Drawing.Size(114, 15);
            this.labelServerState.TabIndex = 5;
            this.labelServerState.Text = "Server Not Running";
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(577, 26);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "Close";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Clients Registered and Connection Satus";
            // 
            // listBoxClients
            // 
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.Location = new System.Drawing.Point(56, 82);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(596, 95);
            this.listBoxClients.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Data Received From Client";
            // 
            // listBoxClientData
            // 
            this.listBoxClientData.FormattingEnabled = true;
            this.listBoxClientData.Location = new System.Drawing.Point(56, 209);
            this.listBoxClientData.Name = "listBoxClientData";
            this.listBoxClientData.Size = new System.Drawing.Size(596, 95);
            this.listBoxClientData.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "HTTP Data From Client";
            // 
            // textBoxHTTPData
            // 
            this.textBoxHTTPData.Location = new System.Drawing.Point(59, 353);
            this.textBoxHTTPData.Multiline = true;
            this.textBoxHTTPData.Name = "textBoxHTTPData";
            this.textBoxHTTPData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxHTTPData.Size = new System.Drawing.Size(593, 85);
            this.textBoxHTTPData.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 450);
            this.Controls.Add(this.textBoxHTTPData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxClientData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxClients);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.labelServerState);
            this.Controls.Add(this.buttonStopServer);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.Label labelServerState;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxClientData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxHTTPData;
    }
}

