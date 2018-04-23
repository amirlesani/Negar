namespace negar
{
    partial class AdvancedSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedSearchForm));
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerX2 = new BehComponents.DateTimePickerX();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePickerX1 = new BehComponents.DateTimePickerX();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Image = global::negar.Properties.Resources.if_sign_check_299110;
            this.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchButton.Location = new System.Drawing.Point(158, 95);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(73, 32);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "اعمال";
            this.searchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(235, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "شروع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "پایان";
            // 
            // label3
            // 
            this.label3.Image = global::negar.Properties.Resources.if_calendar_285670__1_;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 64);
            this.label3.TabIndex = 34;
            // 
            // dateTimePickerX2
            // 
            this.dateTimePickerX2.AnchorSize = new System.Drawing.Size(147, 25);
            this.dateTimePickerX2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dateTimePickerX2.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePickerX2.CalendarBoldedDayForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickerX2.CalendarBorderColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarDayRectTickness = 2F;
            this.dateTimePickerX2.CalendarDaysBackColor = System.Drawing.Color.White;
            this.dateTimePickerX2.CalendarDaysFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerX2.CalendarDaysForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.dateTimePickerX2.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.dateTimePickerX2.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.dateTimePickerX2.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.dateTimePickerX2.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.dateTimePickerX2.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.dateTimePickerX2.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX2.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX2.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX2.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX2.CalendarShowToday = true;
            this.dateTimePickerX2.CalendarShowTodayRect = true;
            this.dateTimePickerX2.CalendarShowToolTips = false;
            this.dateTimePickerX2.CalendarShowTrailing = true;
            this.dateTimePickerX2.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.dateTimePickerX2.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX2.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.dateTimePickerX2.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX2.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX2.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.dateTimePickerX2.CalendarTitleBackColor = System.Drawing.Color.IndianRed;
            this.dateTimePickerX2.CalendarTitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimePickerX2.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarTodayBackColor = System.Drawing.Color.Gainsboro;
            this.dateTimePickerX2.CalendarTodayFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerX2.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.dateTimePickerX2.CalendarTodayRectTickness = 2F;
            this.dateTimePickerX2.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dateTimePickerX2.CalendarType = BehComponents.CalendarTypes.Persian;
            this.dateTimePickerX2.CalendarWeekDaysBackColor = System.Drawing.Color.Linen;
            this.dateTimePickerX2.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimePickerX2.CalendarWeekDaysForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX2.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.dateTimePickerX2.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.dateTimePickerX2.ClearButtonBackColor = System.Drawing.Color.White;
            this.dateTimePickerX2.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePickerX2.ClearButtonImage = null;
            this.dateTimePickerX2.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateTimePickerX2.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.dateTimePickerX2.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.dateTimePickerX2.ClearButtonText = "";
            this.dateTimePickerX2.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateTimePickerX2.ClearButtonToolTip = "";
            this.dateTimePickerX2.ClearButtonWidth = 17;
            this.dateTimePickerX2.ClearDateTimeWhenDownDeleteKey = true;
            this.dateTimePickerX2.CustomFormat = "";
            this.dateTimePickerX2.DockSide = BehComponents.DropDownEmpty.Alignments.Right;
            this.dateTimePickerX2.DropDownClosedWhenClickOnDays = true;
            this.dateTimePickerX2.DropDownClosedWhenSelectedDateChanged = false;
            this.dateTimePickerX2.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.dateTimePickerX2.Format4Binding = "yyyy/MM/dd";
            this.dateTimePickerX2.Location = new System.Drawing.Point(82, 22);
            this.dateTimePickerX2.Name = "dateTimePickerX2";
            this.dateTimePickerX2.RightToLeftLayout = true;
            this.dateTimePickerX2.ShowClearButton = false;
            this.dateTimePickerX2.Size = new System.Drawing.Size(147, 25);
            this.dateTimePickerX2.TabIndex = 0;
            this.dateTimePickerX2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dateTimePickerX2.TextWhenClearButtonClicked = "";
            // 
            // button1
            // 
            this.button1.Image = global::negar.Properties.Resources.if_sign_error_299045;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(82, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 32);
            this.button1.TabIndex = 3;
            this.button1.Text = "بستن";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dateTimePickerX1
            // 
            this.dateTimePickerX1.AnchorSize = new System.Drawing.Size(147, 25);
            this.dateTimePickerX1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dateTimePickerX1.BackColor = System.Drawing.Color.Transparent;
            this.dateTimePickerX1.CalendarBoldedDayForeColor = System.Drawing.Color.DimGray;
            this.dateTimePickerX1.CalendarBorderColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarDayRectTickness = 2F;
            this.dateTimePickerX1.CalendarDaysBackColor = System.Drawing.Color.White;
            this.dateTimePickerX1.CalendarDaysFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerX1.CalendarDaysForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarEnglishAnnuallyBoldedDates = new System.DateTime[0];
            this.dateTimePickerX1.CalendarEnglishBoldedDates = new System.DateTime[0];
            this.dateTimePickerX1.CalendarEnglishHolidayDates = new System.DateTime[0];
            this.dateTimePickerX1.CalendarEnglishMonthlyBoldedDates = new System.DateTime[0];
            this.dateTimePickerX1.CalendarHolidayForeColor = System.Drawing.Color.Red;
            this.dateTimePickerX1.CalendarHolidayWeekly = BehComponents.MonthCalendarX.DayOfWeekForHoliday.Friday;
            this.dateTimePickerX1.CalendarLineWeekColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarPersianAnnuallyBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX1.CalendarPersianBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX1.CalendarPersianHolidayDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX1.CalendarPersianMonthlyBoldedDates = new BehComponents.PersianDateTime[0];
            this.dateTimePickerX1.CalendarShowToday = true;
            this.dateTimePickerX1.CalendarShowTodayRect = true;
            this.dateTimePickerX1.CalendarShowToolTips = false;
            this.dateTimePickerX1.CalendarShowTrailing = true;
            this.dateTimePickerX1.CalendarStyle_DaysButton = BehComponents.ButtonX.ButtonStyles.Simple;
            this.dateTimePickerX1.CalendarStyle_GotoTodayButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX1.CalendarStyle_MonthButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.dateTimePickerX1.CalendarStyle_NextMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX1.CalendarStyle_PreviousMonthButton = BehComponents.ButtonX.ButtonStyles.Green;
            this.dateTimePickerX1.CalendarStyle_YearButton = BehComponents.ButtonX.ButtonStyles.Blue;
            this.dateTimePickerX1.CalendarTitleBackColor = System.Drawing.Color.IndianRed;
            this.dateTimePickerX1.CalendarTitleFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimePickerX1.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarTodayBackColor = System.Drawing.Color.Gainsboro;
            this.dateTimePickerX1.CalendarTodayFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.dateTimePickerX1.CalendarTodayForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarTodayRectColor = System.Drawing.Color.Coral;
            this.dateTimePickerX1.CalendarTodayRectTickness = 2F;
            this.dateTimePickerX1.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dateTimePickerX1.CalendarType = BehComponents.CalendarTypes.Persian;
            this.dateTimePickerX1.CalendarWeekDaysBackColor = System.Drawing.Color.Linen;
            this.dateTimePickerX1.CalendarWeekDaysFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.dateTimePickerX1.CalendarWeekDaysForeColor = System.Drawing.Color.Black;
            this.dateTimePickerX1.CalendarWeekStartsOn = BehComponents.MonthCalendarX.WeekDays.Saturday;
            this.dateTimePickerX1.ClearButtonAlignment = BehComponents.DropDownEmpty.Alignments.Left;
            this.dateTimePickerX1.ClearButtonBackColor = System.Drawing.Color.White;
            this.dateTimePickerX1.ClearButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.dateTimePickerX1.ClearButtonImage = null;
            this.dateTimePickerX1.ClearButtonImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateTimePickerX1.ClearButtonImageFixedSize = new System.Drawing.Size(0, 0);
            this.dateTimePickerX1.ClearButtonImageSizeMode = BehComponents.DropDownEmpty.ImageSizeModes.Zoom;
            this.dateTimePickerX1.ClearButtonText = "";
            this.dateTimePickerX1.ClearButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateTimePickerX1.ClearButtonToolTip = "";
            this.dateTimePickerX1.ClearButtonWidth = 17;
            this.dateTimePickerX1.ClearDateTimeWhenDownDeleteKey = true;
            this.dateTimePickerX1.CustomFormat = "";
            this.dateTimePickerX1.DockSide = BehComponents.DropDownEmpty.Alignments.Right;
            this.dateTimePickerX1.DropDownClosedWhenClickOnDays = true;
            this.dateTimePickerX1.DropDownClosedWhenSelectedDateChanged = false;
            this.dateTimePickerX1.Format = BehComponents.DateTimePickerX.FormatDate.Long;
            this.dateTimePickerX1.Format4Binding = "yyyy/MM/dd";
            this.dateTimePickerX1.Location = new System.Drawing.Point(82, 53);
            this.dateTimePickerX1.Name = "dateTimePickerX1";
            this.dateTimePickerX1.RightToLeftLayout = true;
            this.dateTimePickerX1.ShowClearButton = false;
            this.dateTimePickerX1.Size = new System.Drawing.Size(147, 25);
            this.dateTimePickerX1.TabIndex = 1;
            this.dateTimePickerX1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.dateTimePickerX1.TextWhenClearButtonClicked = "";
            // 
            // AdvancedSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(285, 142);
            this.Controls.Add(this.dateTimePickerX1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePickerX2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdvancedSearchForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "پیشرفته";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AdvancedSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private BehComponents.DateTimePickerX dateTimePickerX2;
        private System.Windows.Forms.Button button1;
        private BehComponents.DateTimePickerX dateTimePickerX1;
    }
}