namespace CarFactory
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            carBrand = new ComboBox();
            BrandBox = new GroupBox();
            bodyTypeBox = new GroupBox();
            carBodyType = new ComboBox();
            colorBox = new GroupBox();
            carColor = new ComboBox();
            engineBox = new GroupBox();
            carEngine = new ComboBox();
            transmissionBox = new GroupBox();
            carTransmission = new ComboBox();
            steeringPositionBox = new GroupBox();
            carSteeringPosition = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            confirmButton = new Button();
            BrandBox.SuspendLayout();
            bodyTypeBox.SuspendLayout();
            colorBox.SuspendLayout();
            engineBox.SuspendLayout();
            transmissionBox.SuspendLayout();
            steeringPositionBox.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Showcard Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(265, 9);
            label1.Name = "label1";
            label1.Size = new Size(359, 40);
            label1.TabIndex = 3;
            label1.Text = "Выберите свою машину";
            // 
            // carBrand
            // 
            carBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            carBrand.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carBrand.FormattingEnabled = true;
            carBrand.Items.AddRange(new object[] { "Toyota", "Volkswagen", "Mitsubishi", "Honda", "Mercedez" });
            carBrand.Location = new Point(6, 102);
            carBrand.Name = "carBrand";
            carBrand.Size = new Size(203, 40);
            carBrand.TabIndex = 4;
            // 
            // BrandBox
            // 
            BrandBox.Controls.Add(carBrand);
            BrandBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            BrandBox.Location = new Point(445, 176);
            BrandBox.Name = "BrandBox";
            BrandBox.Size = new Size(215, 167);
            BrandBox.TabIndex = 6;
            BrandBox.TabStop = false;
            BrandBox.Text = "Модель машины";
            // 
            // bodyTypeBox
            // 
            bodyTypeBox.Controls.Add(carBodyType);
            bodyTypeBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            bodyTypeBox.Location = new Point(224, 176);
            bodyTypeBox.Name = "bodyTypeBox";
            bodyTypeBox.Size = new Size(215, 167);
            bodyTypeBox.TabIndex = 7;
            bodyTypeBox.TabStop = false;
            bodyTypeBox.Text = "Форма кузова";
            // 
            // carBodyType
            // 
            carBodyType.DropDownStyle = ComboBoxStyle.DropDownList;
            carBodyType.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carBodyType.FormattingEnabled = true;
            carBodyType.Items.AddRange(new object[] { "Convertible", "Sedan", "Hatchback" });
            carBodyType.Location = new Point(6, 102);
            carBodyType.Name = "carBodyType";
            carBodyType.Size = new Size(203, 40);
            carBodyType.TabIndex = 4;
            // 
            // colorBox
            // 
            colorBox.Controls.Add(carColor);
            colorBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            colorBox.Location = new Point(3, 176);
            colorBox.Name = "colorBox";
            colorBox.Size = new Size(215, 167);
            colorBox.TabIndex = 8;
            colorBox.TabStop = false;
            colorBox.Text = "Цвет кузова";
            // 
            // carColor
            // 
            carColor.DropDownStyle = ComboBoxStyle.DropDownList;
            carColor.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carColor.FormattingEnabled = true;
            carColor.Items.AddRange(new object[] { "Red", "Blue", "Black", "White" });
            carColor.Location = new Point(6, 102);
            carColor.Name = "carColor";
            carColor.Size = new Size(203, 40);
            carColor.TabIndex = 4;
            // 
            // engineBox
            // 
            engineBox.Controls.Add(carEngine);
            engineBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            engineBox.Location = new Point(445, 3);
            engineBox.Name = "engineBox";
            engineBox.Size = new Size(215, 167);
            engineBox.TabIndex = 8;
            engineBox.TabStop = false;
            engineBox.Text = "Тип двигателя";
            // 
            // carEngine
            // 
            carEngine.DropDownStyle = ComboBoxStyle.DropDownList;
            carEngine.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carEngine.FormattingEnabled = true;
            carEngine.Items.AddRange(new object[] { "V6", "V8", "V12" });
            carEngine.Location = new Point(6, 102);
            carEngine.Name = "carEngine";
            carEngine.Size = new Size(203, 40);
            carEngine.TabIndex = 4;
            // 
            // transmissionBox
            // 
            transmissionBox.Controls.Add(carTransmission);
            transmissionBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            transmissionBox.Location = new Point(224, 3);
            transmissionBox.Name = "transmissionBox";
            transmissionBox.Size = new Size(215, 167);
            transmissionBox.TabIndex = 8;
            transmissionBox.TabStop = false;
            transmissionBox.Text = "Коробка передач";
            // 
            // carTransmission
            // 
            carTransmission.DropDownStyle = ComboBoxStyle.DropDownList;
            carTransmission.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carTransmission.FormattingEnabled = true;
            carTransmission.Items.AddRange(new object[] { "Automatical", "Mechanical" });
            carTransmission.Location = new Point(6, 102);
            carTransmission.Name = "carTransmission";
            carTransmission.Size = new Size(203, 40);
            carTransmission.TabIndex = 4;
            // 
            // steeringPositionBox
            // 
            steeringPositionBox.Controls.Add(carSteeringPosition);
            steeringPositionBox.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            steeringPositionBox.Location = new Point(3, 3);
            steeringPositionBox.Name = "steeringPositionBox";
            steeringPositionBox.Size = new Size(215, 167);
            steeringPositionBox.TabIndex = 7;
            steeringPositionBox.TabStop = false;
            steeringPositionBox.Text = "Позиция руля";
            // 
            // carSteeringPosition
            // 
            carSteeringPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            carSteeringPosition.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            carSteeringPosition.FormattingEnabled = true;
            carSteeringPosition.Items.AddRange(new object[] { "LeftPosition", "RightPosition" });
            carSteeringPosition.Location = new Point(6, 102);
            carSteeringPosition.Name = "carSteeringPosition";
            carSteeringPosition.Size = new Size(203, 40);
            carSteeringPosition.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            flowLayoutPanel1.Controls.Add(steeringPositionBox);
            flowLayoutPanel1.Controls.Add(transmissionBox);
            flowLayoutPanel1.Controls.Add(engineBox);
            flowLayoutPanel1.Controls.Add(colorBox);
            flowLayoutPanel1.Controls.Add(bodyTypeBox);
            flowLayoutPanel1.Controls.Add(BrandBox);
            flowLayoutPanel1.Controls.Add(confirmButton);
            flowLayoutPanel1.Location = new Point(63, 84);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(668, 448);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // confirmButton
            // 
            confirmButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            confirmButton.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            confirmButton.Location = new Point(3, 349);
            confirmButton.Name = "confirmButton";
            confirmButton.Size = new Size(660, 52);
            confirmButton.TabIndex = 10;
            confirmButton.Text = "Подтвердить";
            confirmButton.UseVisualStyleBackColor = true;
            confirmButton.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 544);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CarFactory";
            Load += Form1_Load;
            BrandBox.ResumeLayout(false);
            bodyTypeBox.ResumeLayout(false);
            colorBox.ResumeLayout(false);
            engineBox.ResumeLayout(false);
            transmissionBox.ResumeLayout(false);
            steeringPositionBox.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private ComboBox carBrand;
        private GroupBox BrandBox;
        private GroupBox bodyTypeBox;
        private ComboBox carBodyType;
        private GroupBox colorBox;
        private ComboBox carColor;
        private GroupBox engineBox;
        private ComboBox carEngine;
        private GroupBox transmissionBox;
        private ComboBox carTransmission;
        private GroupBox steeringPositionBox;
        private ComboBox carSteeringPosition;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button confirmButton;
    }
}