﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGenerateBroadsheet
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridViewBroadSheet = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpgradeTo40ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpgradeWith1MarkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpgradeWith2MarksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ApplyChangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxTemplateFileName = New System.Windows.Forms.TextBox()
        Me.SidePanel = New System.Windows.Forms.Panel()
        Me.ButtonTest = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonExportPDF = New System.Windows.Forms.Button()
        Me.ButtonExportToExcel = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonSaveBroadsheet = New System.Windows.Forms.Button()
        Me.ButtonCloud = New System.Windows.Forms.Button()
        Me.ButtonGrades = New System.Windows.Forms.Button()
        Me.ButtonProcessBroadsheet = New System.Windows.Forms.Button()
        Me.LabelProgress = New System.Windows.Forms.Label()
        Me.PanelModify = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxSecondSemester = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFirsrSemester = New System.Windows.Forms.CheckBox()
        Me.RadioButtonGrades = New System.Windows.Forms.RadioButton()
        Me.RadioButtonScores = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBoxDean = New System.Windows.Forms.TextBox()
        Me.TextBoxHOD = New System.Windows.Forms.TextBox()
        Me.TextBoxCourseAdviser = New System.Windows.Forms.TextBox()
        Me.RadioButtonUseBuiltInFormula = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUseExcelWithFormula = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUseBuiltIn = New System.Windows.Forms.RadioButton()
        Me.RadioButtonUseExcel = New System.Windows.Forms.RadioButton()
        Me.ProgressBarBS = New System.Windows.Forms.ProgressBar()
        Me.TimerBS = New System.Windows.Forms.Timer(Me.components)
        Me.BgWProcess = New System.ComponentModel.BackgroundWorker()
        Me.DataGridViewBroadsheetAudit = New System.Windows.Forms.DataGridView()
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.bgwExportToExcel = New System.ComponentModel.BackgroundWorker()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.bgwLoad = New System.ComponentModel.BackgroundWorker()
        Me.DataGridViewTemp = New System.Windows.Forms.DataGridView()
        Me.ButtonOpen = New System.Windows.Forms.Button()
        Me.ComboBoxRegisteredStudents = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioButtonDIP = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ButtonLoadSavedBS = New System.Windows.Forms.Button()
        CType(Me.DataGridViewBroadSheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SidePanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelModify.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridViewBroadsheetAudit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewTemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridViewBroadSheet
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewBroadSheet.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewBroadSheet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewBroadSheet.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewBroadSheet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewBroadSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewBroadSheet.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewBroadSheet.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewBroadSheet.GridColor = System.Drawing.Color.Gray
        Me.DataGridViewBroadSheet.Location = New System.Drawing.Point(29, 158)
        Me.DataGridViewBroadSheet.Name = "DataGridViewBroadSheet"
        Me.DataGridViewBroadSheet.Size = New System.Drawing.Size(778, 255)
        Me.DataGridViewBroadSheet.TabIndex = 9
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpgradeTo40ToolStripMenuItem, Me.UpgradeWith1MarkToolStripMenuItem, Me.UpgradeWith2MarksToolStripMenuItem, Me.ChangeToToolStripMenuItem, Me.ToolStripTextBox1, Me.ApplyChangeToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(190, 139)
        Me.ContextMenuStrip1.Text = "Action"
        '
        'UpgradeTo40ToolStripMenuItem
        '
        Me.UpgradeTo40ToolStripMenuItem.Name = "UpgradeTo40ToolStripMenuItem"
        Me.UpgradeTo40ToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.UpgradeTo40ToolStripMenuItem.Text = "Upgrade to 40"
        '
        'UpgradeWith1MarkToolStripMenuItem
        '
        Me.UpgradeWith1MarkToolStripMenuItem.Name = "UpgradeWith1MarkToolStripMenuItem"
        Me.UpgradeWith1MarkToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.UpgradeWith1MarkToolStripMenuItem.Text = "Upgrade with 1 mark"
        '
        'UpgradeWith2MarksToolStripMenuItem
        '
        Me.UpgradeWith2MarksToolStripMenuItem.Name = "UpgradeWith2MarksToolStripMenuItem"
        Me.UpgradeWith2MarksToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.UpgradeWith2MarksToolStripMenuItem.Text = "Upgrade with 2 marks"
        '
        'ChangeToToolStripMenuItem
        '
        Me.ChangeToToolStripMenuItem.Name = "ChangeToToolStripMenuItem"
        Me.ChangeToToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ChangeToToolStripMenuItem.Text = "Change to:"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 23)
        '
        'ApplyChangeToolStripMenuItem
        '
        Me.ApplyChangeToolStripMenuItem.Name = "ApplyChangeToolStripMenuItem"
        Me.ApplyChangeToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ApplyChangeToolStripMenuItem.Text = "Apply Change"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 481)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Filename (Excel file .xlsx)"
        '
        'TextBoxTemplateFileName
        '
        Me.TextBoxTemplateFileName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TextBoxTemplateFileName.Location = New System.Drawing.Point(29, 602)
        Me.TextBoxTemplateFileName.Name = "TextBoxTemplateFileName"
        Me.TextBoxTemplateFileName.Size = New System.Drawing.Size(636, 20)
        Me.TextBoxTemplateFileName.TabIndex = 18
        '
        'SidePanel
        '
        Me.SidePanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(39, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.SidePanel.Controls.Add(Me.ButtonTest)
        Me.SidePanel.Controls.Add(Me.Panel2)
        Me.SidePanel.Controls.Add(Me.ButtonClose)
        Me.SidePanel.Controls.Add(Me.ButtonExportPDF)
        Me.SidePanel.Controls.Add(Me.ButtonExportToExcel)
        Me.SidePanel.Controls.Add(Me.Button3)
        Me.SidePanel.Controls.Add(Me.ButtonSaveBroadsheet)
        Me.SidePanel.Controls.Add(Me.ButtonCloud)
        Me.SidePanel.Controls.Add(Me.ButtonGrades)
        Me.SidePanel.Controls.Add(Me.ButtonProcessBroadsheet)
        Me.SidePanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.SidePanel.Location = New System.Drawing.Point(816, 0)
        Me.SidePanel.Name = "SidePanel"
        Me.SidePanel.Size = New System.Drawing.Size(134, 660)
        Me.SidePanel.TabIndex = 27
        '
        'ButtonTest
        '
        Me.ButtonTest.FlatAppearance.BorderSize = 0
        Me.ButtonTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonTest.ForeColor = System.Drawing.Color.White
        Me.ButtonTest.Location = New System.Drawing.Point(6, 598)
        Me.ButtonTest.Name = "ButtonTest"
        Me.ButtonTest.Size = New System.Drawing.Size(128, 55)
        Me.ButtonTest.TabIndex = 75
        Me.ButtonTest.Text = "Test Template"
        Me.ButtonTest.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.RoyalBlue
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(139, 33)
        Me.Panel2.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Broadsheets"
        '
        'ButtonClose
        '
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonClose.ForeColor = System.Drawing.Color.White
        Me.ButtonClose.Location = New System.Drawing.Point(6, 495)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(128, 55)
        Me.ButtonClose.TabIndex = 36
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonExportPDF
        '
        Me.ButtonExportPDF.FlatAppearance.BorderSize = 0
        Me.ButtonExportPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportPDF.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonExportPDF.ForeColor = System.Drawing.Color.White
        Me.ButtonExportPDF.Location = New System.Drawing.Point(3, 240)
        Me.ButtonExportPDF.Name = "ButtonExportPDF"
        Me.ButtonExportPDF.Size = New System.Drawing.Size(128, 55)
        Me.ButtonExportPDF.TabIndex = 8
        Me.ButtonExportPDF.Text = "Export to PDF"
        Me.ButtonExportPDF.UseVisualStyleBackColor = True
        '
        'ButtonExportToExcel
        '
        Me.ButtonExportToExcel.FlatAppearance.BorderSize = 0
        Me.ButtonExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonExportToExcel.ForeColor = System.Drawing.Color.White
        Me.ButtonExportToExcel.Location = New System.Drawing.Point(3, 185)
        Me.ButtonExportToExcel.Name = "ButtonExportToExcel"
        Me.ButtonExportToExcel.Size = New System.Drawing.Size(128, 55)
        Me.ButtonExportToExcel.TabIndex = 7
        Me.ButtonExportToExcel.Text = "Export to Excel"
        Me.ButtonExportToExcel.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(6, 439)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 55)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Cancel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonSaveBroadsheet
        '
        Me.ButtonSaveBroadsheet.FlatAppearance.BorderSize = 0
        Me.ButtonSaveBroadsheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSaveBroadsheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonSaveBroadsheet.ForeColor = System.Drawing.Color.White
        Me.ButtonSaveBroadsheet.Location = New System.Drawing.Point(3, 302)
        Me.ButtonSaveBroadsheet.Name = "ButtonSaveBroadsheet"
        Me.ButtonSaveBroadsheet.Size = New System.Drawing.Size(128, 55)
        Me.ButtonSaveBroadsheet.TabIndex = 4
        Me.ButtonSaveBroadsheet.Text = "Save"
        Me.ButtonSaveBroadsheet.UseVisualStyleBackColor = True
        '
        'ButtonCloud
        '
        Me.ButtonCloud.FlatAppearance.BorderSize = 0
        Me.ButtonCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCloud.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonCloud.ForeColor = System.Drawing.Color.White
        Me.ButtonCloud.Location = New System.Drawing.Point(3, 378)
        Me.ButtonCloud.Name = "ButtonCloud"
        Me.ButtonCloud.Size = New System.Drawing.Size(128, 55)
        Me.ButtonCloud.TabIndex = 3
        Me.ButtonCloud.Text = "Sync Cloud"
        Me.ButtonCloud.UseVisualStyleBackColor = True
        '
        'ButtonGrades
        '
        Me.ButtonGrades.FlatAppearance.BorderSize = 0
        Me.ButtonGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGrades.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonGrades.ForeColor = System.Drawing.Color.White
        Me.ButtonGrades.Location = New System.Drawing.Point(3, 118)
        Me.ButtonGrades.Name = "ButtonGrades"
        Me.ButtonGrades.Size = New System.Drawing.Size(128, 55)
        Me.ButtonGrades.TabIndex = 2
        Me.ButtonGrades.Text = "Grades"
        Me.ButtonGrades.UseVisualStyleBackColor = True
        '
        'ButtonProcessBroadsheet
        '
        Me.ButtonProcessBroadsheet.FlatAppearance.BorderSize = 0
        Me.ButtonProcessBroadsheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonProcessBroadsheet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonProcessBroadsheet.ForeColor = System.Drawing.Color.White
        Me.ButtonProcessBroadsheet.Location = New System.Drawing.Point(3, 54)
        Me.ButtonProcessBroadsheet.Name = "ButtonProcessBroadsheet"
        Me.ButtonProcessBroadsheet.Size = New System.Drawing.Size(128, 55)
        Me.ButtonProcessBroadsheet.TabIndex = 1
        Me.ButtonProcessBroadsheet.Text = "Process"
        Me.ButtonProcessBroadsheet.UseVisualStyleBackColor = True
        '
        'LabelProgress
        '
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.Location = New System.Drawing.Point(28, 416)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(437, 18)
        Me.LabelProgress.TabIndex = 28
        Me.LabelProgress.Text = "This broadsheet can be used to make final adjustments to scores"
        '
        'PanelModify
        '
        Me.PanelModify.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelModify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelModify.Controls.Add(Me.GroupBox1)
        Me.PanelModify.Controls.Add(Me.Button1)
        Me.PanelModify.Controls.Add(Me.TextBoxDean)
        Me.PanelModify.Controls.Add(Me.TextBoxHOD)
        Me.PanelModify.Controls.Add(Me.TextBoxCourseAdviser)
        Me.PanelModify.Controls.Add(Me.RadioButtonUseBuiltInFormula)
        Me.PanelModify.Controls.Add(Me.RadioButtonUseExcelWithFormula)
        Me.PanelModify.Controls.Add(Me.RadioButtonUseBuiltIn)
        Me.PanelModify.Controls.Add(Me.RadioButtonUseExcel)
        Me.PanelModify.Location = New System.Drawing.Point(407, 31)
        Me.PanelModify.Name = "PanelModify"
        Me.PanelModify.Size = New System.Drawing.Size(400, 124)
        Me.PanelModify.TabIndex = 30
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxSecondSemester)
        Me.GroupBox1.Controls.Add(Me.CheckBoxFirsrSemester)
        Me.GroupBox1.Controls.Add(Me.RadioButtonGrades)
        Me.GroupBox1.Controls.Add(Me.RadioButtonScores)
        Me.GroupBox1.Location = New System.Drawing.Point(381, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(126, 100)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Export Options"
        '
        'CheckBoxSecondSemester
        '
        Me.CheckBoxSecondSemester.AutoSize = True
        Me.CheckBoxSecondSemester.Checked = True
        Me.CheckBoxSecondSemester.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSecondSemester.Location = New System.Drawing.Point(8, 77)
        Me.CheckBoxSecondSemester.Name = "CheckBoxSecondSemester"
        Me.CheckBoxSecondSemester.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxSecondSemester.TabIndex = 19
        Me.CheckBoxSecondSemester.Text = "Second Semester"
        Me.CheckBoxSecondSemester.UseVisualStyleBackColor = True
        '
        'CheckBoxFirsrSemester
        '
        Me.CheckBoxFirsrSemester.AutoSize = True
        Me.CheckBoxFirsrSemester.Checked = True
        Me.CheckBoxFirsrSemester.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxFirsrSemester.Location = New System.Drawing.Point(8, 59)
        Me.CheckBoxFirsrSemester.Name = "CheckBoxFirsrSemester"
        Me.CheckBoxFirsrSemester.Size = New System.Drawing.Size(92, 17)
        Me.CheckBoxFirsrSemester.TabIndex = 18
        Me.CheckBoxFirsrSemester.Text = "First Semester"
        Me.CheckBoxFirsrSemester.UseVisualStyleBackColor = True
        '
        'RadioButtonGrades
        '
        Me.RadioButtonGrades.AutoSize = True
        Me.RadioButtonGrades.Location = New System.Drawing.Point(8, 35)
        Me.RadioButtonGrades.Name = "RadioButtonGrades"
        Me.RadioButtonGrades.Size = New System.Drawing.Size(59, 17)
        Me.RadioButtonGrades.TabIndex = 17
        Me.RadioButtonGrades.Text = "Grades"
        Me.RadioButtonGrades.UseVisualStyleBackColor = True
        '
        'RadioButtonScores
        '
        Me.RadioButtonScores.AutoSize = True
        Me.RadioButtonScores.Checked = True
        Me.RadioButtonScores.Location = New System.Drawing.Point(8, 16)
        Me.RadioButtonScores.Name = "RadioButtonScores"
        Me.RadioButtonScores.Size = New System.Drawing.Size(58, 17)
        Me.RadioButtonScores.TabIndex = 16
        Me.RadioButtonScores.TabStop = True
        Me.RadioButtonScores.Text = "Scores"
        Me.RadioButtonScores.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(189, 92)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(128, 23)
        Me.Button1.TabIndex = 37
        Me.Button1.Text = "Customized Template"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBoxDean
        '
        Me.TextBoxDean.Location = New System.Drawing.Point(189, 64)
        Me.TextBoxDean.Name = "TextBoxDean"
        Me.TextBoxDean.Size = New System.Drawing.Size(186, 20)
        Me.TextBoxDean.TabIndex = 28
        Me.TextBoxDean.Text = "Name of Dean"
        '
        'TextBoxHOD
        '
        Me.TextBoxHOD.Location = New System.Drawing.Point(189, 37)
        Me.TextBoxHOD.Name = "TextBoxHOD"
        Me.TextBoxHOD.Size = New System.Drawing.Size(186, 20)
        Me.TextBoxHOD.TabIndex = 27
        Me.TextBoxHOD.Text = "Name of HOD"
        '
        'TextBoxCourseAdviser
        '
        Me.TextBoxCourseAdviser.Location = New System.Drawing.Point(189, 11)
        Me.TextBoxCourseAdviser.Name = "TextBoxCourseAdviser"
        Me.TextBoxCourseAdviser.Size = New System.Drawing.Size(186, 20)
        Me.TextBoxCourseAdviser.TabIndex = 26
        Me.TextBoxCourseAdviser.Text = "Name of Course Adviser"
        '
        'RadioButtonUseBuiltInFormula
        '
        Me.RadioButtonUseBuiltInFormula.AutoSize = True
        Me.RadioButtonUseBuiltInFormula.Location = New System.Drawing.Point(8, 35)
        Me.RadioButtonUseBuiltInFormula.Name = "RadioButtonUseBuiltInFormula"
        Me.RadioButtonUseBuiltInFormula.Size = New System.Drawing.Size(153, 17)
        Me.RadioButtonUseBuiltInFormula.TabIndex = 15
        Me.RadioButtonUseBuiltInFormula.Text = "UseBuilt-in Ap with Formula"
        Me.RadioButtonUseBuiltInFormula.UseVisualStyleBackColor = True
        '
        'RadioButtonUseExcelWithFormula
        '
        Me.RadioButtonUseExcelWithFormula.AutoSize = True
        Me.RadioButtonUseExcelWithFormula.Location = New System.Drawing.Point(8, 95)
        Me.RadioButtonUseExcelWithFormula.Name = "RadioButtonUseExcelWithFormula"
        Me.RadioButtonUseExcelWithFormula.Size = New System.Drawing.Size(154, 17)
        Me.RadioButtonUseExcelWithFormula.TabIndex = 14
        Me.RadioButtonUseExcelWithFormula.Text = "Use Excel App with Fomula"
        Me.RadioButtonUseExcelWithFormula.UseVisualStyleBackColor = True
        '
        'RadioButtonUseBuiltIn
        '
        Me.RadioButtonUseBuiltIn.AutoSize = True
        Me.RadioButtonUseBuiltIn.Checked = True
        Me.RadioButtonUseBuiltIn.Location = New System.Drawing.Point(8, 12)
        Me.RadioButtonUseBuiltIn.Name = "RadioButtonUseBuiltIn"
        Me.RadioButtonUseBuiltIn.Size = New System.Drawing.Size(100, 17)
        Me.RadioButtonUseBuiltIn.TabIndex = 13
        Me.RadioButtonUseBuiltIn.TabStop = True
        Me.RadioButtonUseBuiltIn.Text = "Use Built-in App"
        Me.RadioButtonUseBuiltIn.UseVisualStyleBackColor = True
        '
        'RadioButtonUseExcel
        '
        Me.RadioButtonUseExcel.AutoSize = True
        Me.RadioButtonUseExcel.Location = New System.Drawing.Point(8, 71)
        Me.RadioButtonUseExcel.Name = "RadioButtonUseExcel"
        Me.RadioButtonUseExcel.Size = New System.Drawing.Size(95, 17)
        Me.RadioButtonUseExcel.TabIndex = 12
        Me.RadioButtonUseExcel.Text = "Use Excel App"
        Me.RadioButtonUseExcel.UseVisualStyleBackColor = True
        '
        'ProgressBarBS
        '
        Me.ProgressBarBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProgressBarBS.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ProgressBarBS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ProgressBarBS.Location = New System.Drawing.Point(32, 434)
        Me.ProgressBarBS.Name = "ProgressBarBS"
        Me.ProgressBarBS.Size = New System.Drawing.Size(774, 23)
        Me.ProgressBarBS.TabIndex = 31
        Me.ProgressBarBS.Value = 1
        '
        'TimerBS
        '
        Me.TimerBS.Enabled = True
        Me.TimerBS.Interval = 500
        '
        'BgWProcess
        '
        Me.BgWProcess.WorkerSupportsCancellation = True
        '
        'DataGridViewBroadsheetAudit
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewBroadsheetAudit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewBroadsheetAudit.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewBroadsheetAudit.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewBroadsheetAudit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewBroadsheetAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewBroadsheetAudit.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewBroadsheetAudit.GridColor = System.Drawing.Color.Gray
        Me.DataGridViewBroadsheetAudit.Location = New System.Drawing.Point(29, 158)
        Me.DataGridViewBroadsheetAudit.Name = "DataGridViewBroadsheetAudit"
        Me.DataGridViewBroadsheetAudit.Size = New System.Drawing.Size(778, 187)
        Me.DataGridViewBroadsheetAudit.TabIndex = 32
        '
        'ButtonDownload
        '
        Me.ButtonDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownload.ForeColor = System.Drawing.Color.White
        Me.ButtonDownload.Location = New System.Drawing.Point(671, 601)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(75, 23)
        Me.ButtonDownload.TabIndex = 34
        Me.ButtonDownload.Text = "Download"
        Me.ButtonDownload.UseVisualStyleBackColor = False
        '
        'bgwExportToExcel
        '
        Me.bgwExportToExcel.WorkerSupportsCancellation = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Excel Files|*.xlsx"
        Me.SaveFileDialog1.RestoreDirectory = True
        '
        'bgwLoad
        '
        '
        'DataGridViewTemp
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black
        Me.DataGridViewTemp.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridViewTemp.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTemp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTemp.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTemp.GridColor = System.Drawing.Color.Gray
        Me.DataGridViewTemp.Location = New System.Drawing.Point(32, 463)
        Me.DataGridViewTemp.Name = "DataGridViewTemp"
        Me.DataGridViewTemp.Size = New System.Drawing.Size(771, 130)
        Me.DataGridViewTemp.TabIndex = 35
        '
        'ButtonOpen
        '
        Me.ButtonOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonOpen.ForeColor = System.Drawing.Color.White
        Me.ButtonOpen.Location = New System.Drawing.Point(671, 630)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOpen.TabIndex = 36
        Me.ButtonOpen.Text = "Open"
        Me.ButtonOpen.UseVisualStyleBackColor = False
        '
        'ComboBoxRegisteredStudents
        '
        Me.ComboBoxRegisteredStudents.FormattingEnabled = True
        Me.ComboBoxRegisteredStudents.Items.AddRange(New Object() {"Computer Engineering, 100, 2018/2019", "Computer and Computing Technology, 100, 2018/2019"})
        Me.ComboBoxRegisteredStudents.Location = New System.Drawing.Point(6, 15)
        Me.ComboBoxRegisteredStudents.Name = "ComboBoxRegisteredStudents"
        Me.ComboBoxRegisteredStudents.Size = New System.Drawing.Size(358, 21)
        Me.ComboBoxRegisteredStudents.TabIndex = 37
        Me.ComboBoxRegisteredStudents.Text = "--Registered Students List---"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonLoadSavedBS)
        Me.GroupBox2.Controls.Add(Me.RadioButtonDIP)
        Me.GroupBox2.Controls.Add(Me.RadioButton2)
        Me.GroupBox2.Controls.Add(Me.ComboBoxRegisteredStudents)
        Me.GroupBox2.Location = New System.Drawing.Point(31, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 121)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Select Registered Students"
        '
        'RadioButtonDIP
        '
        Me.RadioButtonDIP.AutoSize = True
        Me.RadioButtonDIP.Location = New System.Drawing.Point(6, 80)
        Me.RadioButtonDIP.Name = "RadioButtonDIP"
        Me.RadioButtonDIP.Size = New System.Drawing.Size(43, 17)
        Me.RadioButtonDIP.TabIndex = 17
        Me.RadioButtonDIP.Text = "DIP"
        Me.RadioButtonDIP.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 49)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(49, 17)
        Me.RadioButton2.TabIndex = 16
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "UME"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ButtonLoadSavedBS
        '
        Me.ButtonLoadSavedBS.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ButtonLoadSavedBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoadSavedBS.ForeColor = System.Drawing.Color.White
        Me.ButtonLoadSavedBS.Location = New System.Drawing.Point(192, 47)
        Me.ButtonLoadSavedBS.Name = "ButtonLoadSavedBS"
        Me.ButtonLoadSavedBS.Size = New System.Drawing.Size(172, 23)
        Me.ButtonLoadSavedBS.TabIndex = 38
        Me.ButtonLoadSavedBS.Text = "Load Saved Broadsheet"
        Me.ButtonLoadSavedBS.UseVisualStyleBackColor = False
        '
        'FormGenerateBroadsheet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 660)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.DataGridViewTemp)
        Me.Controls.Add(Me.ButtonDownload)
        Me.Controls.Add(Me.ProgressBarBS)
        Me.Controls.Add(Me.PanelModify)
        Me.Controls.Add(Me.LabelProgress)
        Me.Controls.Add(Me.SidePanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxTemplateFileName)
        Me.Controls.Add(Me.DataGridViewBroadSheet)
        Me.Controls.Add(Me.DataGridViewBroadsheetAudit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormGenerateBroadsheet"
        Me.Text = "Generate Broadsheet"
        CType(Me.DataGridViewBroadSheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip1.PerformLayout()
        Me.SidePanel.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelModify.ResumeLayout(False)
        Me.PanelModify.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridViewBroadsheetAudit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewTemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewBroadSheet As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxTemplateFileName As TextBox
    Friend WithEvents SidePanel As Panel
    Friend WithEvents ButtonSaveBroadsheet As Button
    Friend WithEvents ButtonCloud As Button
    Friend WithEvents ButtonGrades As Button
    Friend WithEvents ButtonProcessBroadsheet As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents LabelProgress As Label
    Friend WithEvents PanelModify As Panel
    Friend WithEvents ProgressBarBS As ProgressBar
    Friend WithEvents TimerBS As Timer
    Friend WithEvents BgWProcess As System.ComponentModel.BackgroundWorker
    Friend WithEvents DataGridViewBroadsheetAudit As DataGridView
    Friend WithEvents ButtonExportToExcel As Button
    Friend WithEvents ButtonDownload As Button
    Friend WithEvents bgwExportToExcel As System.ComponentModel.BackgroundWorker
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents bgwLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents ButtonExportPDF As Button
    Friend WithEvents DataGridViewTemp As DataGridView
    Friend WithEvents ButtonClose As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents UpgradeTo40ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpgradeWith1MarkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpgradeWith2MarksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ApplyChangeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RadioButtonUseBuiltInFormula As RadioButton
    Friend WithEvents RadioButtonUseExcelWithFormula As RadioButton
    Friend WithEvents RadioButtonUseBuiltIn As RadioButton
    Friend WithEvents RadioButtonUseExcel As RadioButton
    Friend WithEvents TextBoxDean As TextBox
    Friend WithEvents TextBoxHOD As TextBox
    Friend WithEvents TextBoxCourseAdviser As TextBox
    Friend WithEvents ButtonOpen As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBoxSecondSemester As CheckBox
    Friend WithEvents CheckBoxFirsrSemester As CheckBox
    Friend WithEvents RadioButtonGrades As RadioButton
    Friend WithEvents RadioButtonScores As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents ButtonTest As Button
    Friend WithEvents ComboBoxRegisteredStudents As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RadioButtonDIP As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents ButtonLoadSavedBS As Button
End Class
