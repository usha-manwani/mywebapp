namespace WindowsFormsApp3
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cresijCamDataSet = new WindowsFormsApp3.CresijCamDataSet();
            this.centralControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.centralControlTableAdapter = new WindowsFormsApp3.CresijCamDataSetTableAdapters.CentralControlTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cCIPDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerServiceDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.computerPowerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectorPowerDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projectorUsedHourDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curtainStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.screenStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lightDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaSignalDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockStatusDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.podiumLockDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classLockedDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temperatureDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.humidityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pM25DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pM10DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centralControlBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cresijCamDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cresijCamDataSet1 = new WindowsFormsApp3.CresijCamDataSet1();
            this.centralControlTableAdapter1 = new WindowsFormsApp3.CresijCamDataSet1TableAdapters.CentralControlTableAdapter();
            
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralControlBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralControlBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Location = new System.Drawing.Point(12, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 206);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(343, 21);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(528, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(442, 136);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // cresijCamDataSet
            // 
            this.cresijCamDataSet.DataSetName = "CresijCamDataSet";
            this.cresijCamDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // centralControlBindingSource
            // 
            this.centralControlBindingSource.DataMember = "CentralControl";
            this.centralControlBindingSource.DataSource = this.cresijCamDataSet;
            // 
            // centralControlTableAdapter
            // 
            this.centralControlTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cCIPDataGridViewTextBoxColumn1,
            this.locationDataGridViewTextBoxColumn1,
            this.statusDataGridViewTextBoxColumn1,
            this.powerStatusDataGridViewTextBoxColumn1,
            this.timerServiceDataGridViewTextBoxColumn1,
            this.computerPowerDataGridViewTextBoxColumn1,
            this.projectorPowerDataGridViewTextBoxColumn1,
            this.projectorUsedHourDataGridViewTextBoxColumn1,
            this.curtainStatusDataGridViewTextBoxColumn1,
            this.screenStatusDataGridViewTextBoxColumn1,
            this.lightDataGridViewTextBoxColumn1,
            this.mediaSignalDataGridViewTextBoxColumn1,
            this.lockStatusDataGridViewTextBoxColumn1,
            this.podiumLockDataGridViewTextBoxColumn1,
            this.classLockedDataGridViewTextBoxColumn1,
            this.temperatureDataGridViewTextBoxColumn1,
            this.humidityDataGridViewTextBoxColumn1,
            this.pM25DataGridViewTextBoxColumn1,
            this.pM10DataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.centralControlBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(1, 1);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1683, 277);
            this.dataGridView2.TabIndex = 2;
            // 
            // cCIPDataGridViewTextBoxColumn1
            // 
            this.cCIPDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cCIPDataGridViewTextBoxColumn1.DataPropertyName = "CCIP";
            this.cCIPDataGridViewTextBoxColumn1.HeaderText = "CCIP";
            this.cCIPDataGridViewTextBoxColumn1.Name = "cCIPDataGridViewTextBoxColumn1";
            // 
            // locationDataGridViewTextBoxColumn1
            // 
            this.locationDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.locationDataGridViewTextBoxColumn1.DataPropertyName = "location";
            this.locationDataGridViewTextBoxColumn1.HeaderText = "location";
            this.locationDataGridViewTextBoxColumn1.Name = "locationDataGridViewTextBoxColumn1";
            // 
            // statusDataGridViewTextBoxColumn1
            // 
            this.statusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusDataGridViewTextBoxColumn1.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn1.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn1.Name = "statusDataGridViewTextBoxColumn1";
            // 
            // powerStatusDataGridViewTextBoxColumn1
            // 
            this.powerStatusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.powerStatusDataGridViewTextBoxColumn1.DataPropertyName = "PowerStatus";
            this.powerStatusDataGridViewTextBoxColumn1.HeaderText = "PowerStatus";
            this.powerStatusDataGridViewTextBoxColumn1.Name = "powerStatusDataGridViewTextBoxColumn1";
            // 
            // timerServiceDataGridViewTextBoxColumn1
            // 
            this.timerServiceDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timerServiceDataGridViewTextBoxColumn1.DataPropertyName = "TimerService";
            this.timerServiceDataGridViewTextBoxColumn1.HeaderText = "TimerService";
            this.timerServiceDataGridViewTextBoxColumn1.Name = "timerServiceDataGridViewTextBoxColumn1";
            // 
            // computerPowerDataGridViewTextBoxColumn1
            // 
            this.computerPowerDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.computerPowerDataGridViewTextBoxColumn1.DataPropertyName = "ComputerPower";
            this.computerPowerDataGridViewTextBoxColumn1.HeaderText = "ComputerPower";
            this.computerPowerDataGridViewTextBoxColumn1.Name = "computerPowerDataGridViewTextBoxColumn1";
            // 
            // projectorPowerDataGridViewTextBoxColumn1
            // 
            this.projectorPowerDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.projectorPowerDataGridViewTextBoxColumn1.DataPropertyName = "ProjectorPower";
            this.projectorPowerDataGridViewTextBoxColumn1.HeaderText = "ProjectorPower";
            this.projectorPowerDataGridViewTextBoxColumn1.Name = "projectorPowerDataGridViewTextBoxColumn1";
            // 
            // projectorUsedHourDataGridViewTextBoxColumn1
            // 
            this.projectorUsedHourDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.projectorUsedHourDataGridViewTextBoxColumn1.DataPropertyName = "ProjectorUsedHour";
            this.projectorUsedHourDataGridViewTextBoxColumn1.HeaderText = "ProjectorUsedHour";
            this.projectorUsedHourDataGridViewTextBoxColumn1.Name = "projectorUsedHourDataGridViewTextBoxColumn1";
            // 
            // curtainStatusDataGridViewTextBoxColumn1
            // 
            this.curtainStatusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.curtainStatusDataGridViewTextBoxColumn1.DataPropertyName = "CurtainStatus";
            this.curtainStatusDataGridViewTextBoxColumn1.HeaderText = "CurtainStatus";
            this.curtainStatusDataGridViewTextBoxColumn1.Name = "curtainStatusDataGridViewTextBoxColumn1";
            // 
            // screenStatusDataGridViewTextBoxColumn1
            // 
            this.screenStatusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.screenStatusDataGridViewTextBoxColumn1.DataPropertyName = "ScreenStatus";
            this.screenStatusDataGridViewTextBoxColumn1.HeaderText = "ScreenStatus";
            this.screenStatusDataGridViewTextBoxColumn1.Name = "screenStatusDataGridViewTextBoxColumn1";
            // 
            // lightDataGridViewTextBoxColumn1
            // 
            this.lightDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lightDataGridViewTextBoxColumn1.DataPropertyName = "light";
            this.lightDataGridViewTextBoxColumn1.HeaderText = "light";
            this.lightDataGridViewTextBoxColumn1.Name = "lightDataGridViewTextBoxColumn1";
            // 
            // mediaSignalDataGridViewTextBoxColumn1
            // 
            this.mediaSignalDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.mediaSignalDataGridViewTextBoxColumn1.DataPropertyName = "MediaSignal";
            this.mediaSignalDataGridViewTextBoxColumn1.HeaderText = "MediaSignal";
            this.mediaSignalDataGridViewTextBoxColumn1.Name = "mediaSignalDataGridViewTextBoxColumn1";
            // 
            // lockStatusDataGridViewTextBoxColumn1
            // 
            this.lockStatusDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lockStatusDataGridViewTextBoxColumn1.DataPropertyName = "LockStatus";
            this.lockStatusDataGridViewTextBoxColumn1.HeaderText = "LockStatus";
            this.lockStatusDataGridViewTextBoxColumn1.Name = "lockStatusDataGridViewTextBoxColumn1";
            // 
            // podiumLockDataGridViewTextBoxColumn1
            // 
            this.podiumLockDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.podiumLockDataGridViewTextBoxColumn1.DataPropertyName = "PodiumLock";
            this.podiumLockDataGridViewTextBoxColumn1.HeaderText = "PodiumLock";
            this.podiumLockDataGridViewTextBoxColumn1.Name = "podiumLockDataGridViewTextBoxColumn1";
            // 
            // classLockedDataGridViewTextBoxColumn1
            // 
            this.classLockedDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.classLockedDataGridViewTextBoxColumn1.DataPropertyName = "ClassLocked";
            this.classLockedDataGridViewTextBoxColumn1.HeaderText = "ClassLocked";
            this.classLockedDataGridViewTextBoxColumn1.Name = "classLockedDataGridViewTextBoxColumn1";
            // 
            // temperatureDataGridViewTextBoxColumn1
            // 
            this.temperatureDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.temperatureDataGridViewTextBoxColumn1.DataPropertyName = "Temperature";
            this.temperatureDataGridViewTextBoxColumn1.HeaderText = "Temperature";
            this.temperatureDataGridViewTextBoxColumn1.Name = "temperatureDataGridViewTextBoxColumn1";
            // 
            // humidityDataGridViewTextBoxColumn1
            // 
            this.humidityDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.humidityDataGridViewTextBoxColumn1.DataPropertyName = "Humidity";
            this.humidityDataGridViewTextBoxColumn1.HeaderText = "Humidity";
            this.humidityDataGridViewTextBoxColumn1.Name = "humidityDataGridViewTextBoxColumn1";
            // 
            // pM25DataGridViewTextBoxColumn1
            // 
            this.pM25DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pM25DataGridViewTextBoxColumn1.DataPropertyName = "PM25";
            this.pM25DataGridViewTextBoxColumn1.HeaderText = "PM25";
            this.pM25DataGridViewTextBoxColumn1.Name = "pM25DataGridViewTextBoxColumn1";
            // 
            // pM10DataGridViewTextBoxColumn1
            // 
            this.pM10DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pM10DataGridViewTextBoxColumn1.DataPropertyName = "PM10";
            this.pM10DataGridViewTextBoxColumn1.HeaderText = "PM10";
            this.pM10DataGridViewTextBoxColumn1.Name = "pM10DataGridViewTextBoxColumn1";
            // 
            // centralControlBindingSource1
            // 
            this.centralControlBindingSource1.DataMember = "CentralControl";
            this.centralControlBindingSource1.DataSource = this.cresijCamDataSet1BindingSource;
            // 
            // cresijCamDataSet1BindingSource
            // 
            this.cresijCamDataSet1BindingSource.DataSource = this.cresijCamDataSet1;
            this.cresijCamDataSet1BindingSource.Position = 0;
            // 
            // cresijCamDataSet1
            // 
            this.cresijCamDataSet1.DataSetName = "CresijCamDataSet1";
            this.cresijCamDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // centralControlTableAdapter1
            // 
            this.centralControlTableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 645);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralControlBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centralControlBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cresijCamDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private CresijCamDataSet cresijCamDataSet;
        private System.Windows.Forms.BindingSource centralControlBindingSource;
        private CresijCamDataSetTableAdapters.CentralControlTableAdapter centralControlTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource cresijCamDataSet1BindingSource;
        private CresijCamDataSet1 cresijCamDataSet1;
        private System.Windows.Forms.BindingSource centralControlBindingSource1;
        private CresijCamDataSet1TableAdapters.CentralControlTableAdapter centralControlTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCIPDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timerServiceDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn computerPowerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectorPowerDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn projectorUsedHourDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn curtainStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn screenStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lightDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mediaSignalDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lockStatusDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn podiumLockDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn classLockedDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn temperatureDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn humidityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pM25DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pM10DataGridViewTextBoxColumn1;
       
        
    }
}




