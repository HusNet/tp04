namespace TP04_Project
{
    partial class ImageDetectionTP04
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBoxForImageLoaded = new System.Windows.Forms.PictureBox();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.comboBoxEdge = new System.Windows.Forms.ComboBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.labelEdge = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImageLoaded)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(38, 486);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(146, 58);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load ";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(727, 486);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 58);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pictureBoxForImageLoaded
            // 
            this.pictureBoxForImageLoaded.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBoxForImageLoaded.Location = new System.Drawing.Point(116, 32);
            this.pictureBoxForImageLoaded.Name = "pictureBoxForImageLoaded";
            this.pictureBoxForImageLoaded.Size = new System.Drawing.Size(657, 426);
            this.pictureBoxForImageLoaded.TabIndex = 4;
            this.pictureBoxForImageLoaded.TabStop = false;
            this.pictureBoxForImageLoaded.Click += new System.EventHandler(this.PictureBoxForImageLoaded_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilter.Enabled = false;
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Items.AddRange(new object[] {
            "None",
            "Rainbow",
            "Black and White"});
            this.comboBoxFilter.Location = new System.Drawing.Point(229, 516);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(201, 28);
            this.comboBoxFilter.TabIndex = 10;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFilter_SelectedIndexChanged);
            // 
            // comboBoxEdge
            // 
            this.comboBoxEdge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEdge.Enabled = false;
            this.comboBoxEdge.FormattingEnabled = true;
            this.comboBoxEdge.IntegralHeight = false;
            this.comboBoxEdge.Items.AddRange(new object[] {
            "None",
            "Prewitt",
            "Kirsch"});
            this.comboBoxEdge.Location = new System.Drawing.Point(475, 516);
            this.comboBoxEdge.Name = "comboBoxEdge";
            this.comboBoxEdge.Size = new System.Drawing.Size(194, 28);
            this.comboBoxEdge.TabIndex = 11;
            this.comboBoxEdge.SelectedIndexChanged += new System.EventHandler(this.ComboBoxEdge_SelectedIndexChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(229, 486);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(44, 20);
            this.labelFilter.TabIndex = 12;
            this.labelFilter.Text = "Filter";
            // 
            // labelEdge
            // 
            this.labelEdge.AutoSize = true;
            this.labelEdge.Location = new System.Drawing.Point(475, 485);
            this.labelEdge.Name = "labelEdge";
            this.labelEdge.Size = new System.Drawing.Size(47, 20);
            this.labelEdge.TabIndex = 13;
            this.labelEdge.Text = "Edge";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(802, 177);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(141, 58);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // ImageDetectionTP04
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 588);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.labelEdge);
            this.Controls.Add(this.labelFilter);
            this.Controls.Add(this.comboBoxEdge);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.pictureBoxForImageLoaded);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Name = "ImageDetectionTP04";
            this.Text = "ImageDetection - TP04";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxForImageLoaded)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBoxForImageLoaded;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxEdge;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.Label labelEdge;
        private System.Windows.Forms.Button btnClear;
    }
}

