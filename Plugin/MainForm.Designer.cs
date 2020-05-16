namespace Plugin
{
	partial class MainForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.heightBox = new System.Windows.Forms.TextBox();
			this.hallowBox = new System.Windows.Forms.TextBox();
			this.lengthPerchBox = new System.Windows.Forms.TextBox();
			this.diameterPerchBox = new System.Windows.Forms.TextBox();
			this.depthBox = new System.Windows.Forms.TextBox();
			this.widthBox = new System.Windows.Forms.TextBox();
			this.fastenersBox = new System.Windows.Forms.TextBox();
			this.Build = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.errorLabel = new System.Windows.Forms.Label();
			this.AdditionalBox = new System.Windows.Forms.GroupBox();
			this.housingBox = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cleanButton = new System.Windows.Forms.Button();
			this.helpProvider1 = new System.Windows.Forms.HelpProvider();
			this.AdditionalBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Height";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 86);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Hallow height";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 114);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Length perch";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(79, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Diameter perch";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(1, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Depth";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Width";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(3, 79);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 13);
			this.label7.TabIndex = 7;
			this.label7.Text = "Width fasteners";
			// 
			// heightBox
			// 
			this.heightBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.heightBox, "Height has to be from 250 mm 500 mm");
			this.heightBox.Location = new System.Drawing.Point(102, 52);
			this.heightBox.Name = "heightBox";
			this.helpProvider1.SetShowHelp(this.heightBox, true);
			this.heightBox.Size = new System.Drawing.Size(79, 20);
			this.heightBox.TabIndex = 2;
			this.heightBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.heightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// hallowBox
			// 
			this.hallowBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.hallowBox, "Hallow height depends on height. It has to be higher 25 mm and below on 26 mm");
			this.hallowBox.Location = new System.Drawing.Point(102, 83);
			this.hallowBox.Name = "hallowBox";
			this.helpProvider1.SetShowHelp(this.hallowBox, true);
			this.hallowBox.Size = new System.Drawing.Size(79, 20);
			this.hallowBox.TabIndex = 3;
			this.hallowBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.hallowBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// lengthPerchBox
			// 
			this.lengthPerchBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.lengthPerchBox, "Length perch has to be more 25 mm and less than 35 mm");
			this.lengthPerchBox.Location = new System.Drawing.Point(102, 111);
			this.lengthPerchBox.Name = "lengthPerchBox";
			this.helpProvider1.SetShowHelp(this.lengthPerchBox, true);
			this.lengthPerchBox.Size = new System.Drawing.Size(79, 20);
			this.lengthPerchBox.TabIndex = 4;
			this.lengthPerchBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.lengthPerchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// diameterPerchBox
			// 
			this.diameterPerchBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.diameterPerchBox, "Diameter perch has to be more 5 mm and less 10 mm");
			this.diameterPerchBox.Location = new System.Drawing.Point(102, 140);
			this.diameterPerchBox.Name = "diameterPerchBox";
			this.helpProvider1.SetShowHelp(this.diameterPerchBox, true);
			this.diameterPerchBox.Size = new System.Drawing.Size(79, 20);
			this.diameterPerchBox.TabIndex = 5;
			this.diameterPerchBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.diameterPerchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// depthBox
			// 
			this.depthBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.depthBox, "Depth has to be more 120 mm and less 190 mm");
			this.depthBox.Location = new System.Drawing.Point(92, 19);
			this.depthBox.Name = "depthBox";
			this.helpProvider1.SetShowHelp(this.depthBox, true);
			this.depthBox.Size = new System.Drawing.Size(79, 20);
			this.depthBox.TabIndex = 6;
			this.depthBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.depthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// widthBox
			// 
			this.widthBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.widthBox, "Width has to be more 120 mm and less 190 mm");
			this.widthBox.Location = new System.Drawing.Point(92, 46);
			this.widthBox.Name = "widthBox";
			this.helpProvider1.SetShowHelp(this.widthBox, true);
			this.widthBox.Size = new System.Drawing.Size(79, 20);
			this.widthBox.TabIndex = 7;
			this.widthBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.widthBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// fastenersBox
			// 
			this.fastenersBox.ForeColor = System.Drawing.Color.Black;
			this.helpProvider1.SetHelpString(this.fastenersBox, "Width fasteners has to be more 30 mm and less 50 mm");
			this.fastenersBox.Location = new System.Drawing.Point(92, 75);
			this.fastenersBox.Name = "fastenersBox";
			this.helpProvider1.SetShowHelp(this.fastenersBox, true);
			this.fastenersBox.Size = new System.Drawing.Size(79, 20);
			this.fastenersBox.TabIndex = 8;
			this.fastenersBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.fastenersBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
			// 
			// Build
			// 
			this.helpProvider1.SetHelpString(this.Build, "Build bird house");
			this.Build.Location = new System.Drawing.Point(201, 306);
			this.Build.Name = "Build";
			this.helpProvider1.SetShowHelp(this.Build, true);
			this.Build.Size = new System.Drawing.Size(126, 23);
			this.Build.TabIndex = 10;
			this.Build.Text = "Build";
			this.Build.UseVisualStyleBackColor = true;
			this.Build.Click += new System.EventHandler(this.Build_Click);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(186, 52);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(112, 13);
			this.label15.TabIndex = 23;
			this.label15.Text = "( from 250  to 500 mm)";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(186, 80);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(141, 13);
			this.label16.TabIndex = 24;
			this.label16.Text = "( from 26  to (height-26) mm )";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(186, 111);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(103, 13);
			this.label17.TabIndex = 25;
			this.label17.Text = "( from 25  to 35 mm )";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(186, 140);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(97, 13);
			this.label18.TabIndex = 26;
			this.label18.Text = "( from 5  to 10 mm )";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(177, 18);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(115, 13);
			this.label19.TabIndex = 27;
			this.label19.Text = "( from 120  to 190 mm )";
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(176, 50);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(115, 13);
			this.label20.TabIndex = 28;
			this.label20.Text = "( from 120  to 190 mm )";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(176, 79);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(103, 13);
			this.label21.TabIndex = 29;
			this.label21.Text = "( from 30  to 50 mm )";
			// 
			// errorLabel
			// 
			this.errorLabel.AutoSize = true;
			this.errorLabel.BackColor = System.Drawing.SystemColors.Control;
			this.errorLabel.ForeColor = System.Drawing.Color.Red;
			this.errorLabel.Location = new System.Drawing.Point(11, 9);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(112, 13);
			this.errorLabel.TabIndex = 30;
			this.errorLabel.Text = "Please, check all data";
			// 
			// AdditionalBox
			// 
			this.AdditionalBox.Controls.Add(this.fastenersBox);
			this.AdditionalBox.Controls.Add(this.label6);
			this.AdditionalBox.Controls.Add(this.label21);
			this.AdditionalBox.Controls.Add(this.label7);
			this.AdditionalBox.Controls.Add(this.label19);
			this.AdditionalBox.Controls.Add(this.label20);
			this.AdditionalBox.Controls.Add(this.widthBox);
			this.AdditionalBox.Controls.Add(this.label5);
			this.AdditionalBox.Controls.Add(this.depthBox);
			this.AdditionalBox.Location = new System.Drawing.Point(10, 194);
			this.AdditionalBox.Name = "AdditionalBox";
			this.AdditionalBox.Size = new System.Drawing.Size(317, 106);
			this.AdditionalBox.TabIndex = 31;
			this.AdditionalBox.TabStop = false;
			this.AdditionalBox.Text = "Parameters for rectangle ";
			// 
			// housingBox
			// 
			this.housingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.housingBox.FormattingEnabled = true;
			this.helpProvider1.SetHelpString(this.housingBox, "Choose type of housing");
			this.housingBox.Items.AddRange(new object[] {
            "Rectangle",
            "Сylinder"});
			this.housingBox.Location = new System.Drawing.Point(102, 25);
			this.housingBox.Name = "housingBox";
			this.helpProvider1.SetShowHelp(this.housingBox, true);
			this.housingBox.Size = new System.Drawing.Size(79, 21);
			this.housingBox.TabIndex = 1;
			this.housingBox.SelectedIndexChanged += new System.EventHandler(this.HousingBox_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(83, 13);
			this.label8.TabIndex = 33;
			this.label8.Text = "Choose housing";
			// 
			// cleanButton
			// 
			this.helpProvider1.SetHelpString(this.cleanButton, "Clean first 4 fields");
			this.cleanButton.Location = new System.Drawing.Point(10, 306);
			this.cleanButton.Name = "cleanButton";
			this.helpProvider1.SetShowHelp(this.cleanButton, true);
			this.cleanButton.Size = new System.Drawing.Size(126, 23);
			this.cleanButton.TabIndex = 34;
			this.cleanButton.Text = "Clean";
			this.cleanButton.UseVisualStyleBackColor = true;
			this.cleanButton.Click += new System.EventHandler(this.CleanButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.ClientSize = new System.Drawing.Size(333, 336);
			this.Controls.Add(this.cleanButton);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.housingBox);
			this.Controls.Add(this.AdditionalBox);
			this.Controls.Add(this.errorLabel);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.Build);
			this.Controls.Add(this.diameterPerchBox);
			this.Controls.Add(this.lengthPerchBox);
			this.Controls.Add(this.hallowBox);
			this.Controls.Add(this.heightBox);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.HelpButton = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Text = "BirdHouseBuilder";
			this.AdditionalBox.ResumeLayout(false);
			this.AdditionalBox.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox heightBox;
		private System.Windows.Forms.TextBox hallowBox;
		private System.Windows.Forms.TextBox lengthPerchBox;
		private System.Windows.Forms.TextBox diameterPerchBox;
		private System.Windows.Forms.TextBox depthBox;
		private System.Windows.Forms.TextBox widthBox;
		private System.Windows.Forms.TextBox fastenersBox;
		private System.Windows.Forms.Button Build;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label errorLabel;
		private System.Windows.Forms.GroupBox AdditionalBox;
		private System.Windows.Forms.ComboBox housingBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button cleanButton;
		private System.Windows.Forms.HelpProvider helpProvider1;
	}
}


