﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataListSelectorPanel
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container
        Me.m_grpBxDataList = New System.Windows.Forms.GroupBox
        Me.m_tblPnlDataList = New System.Windows.Forms.TableLayoutPanel
        Me.m_flwPnlListType = New System.Windows.Forms.FlowLayoutPanel
        Me.m_radBtnCurMxDoc = New System.Windows.Forms.RadioButton
        Me.m_radBtnMXD = New System.Windows.Forms.RadioButton
        Me.m_radBtnGDB = New System.Windows.Forms.RadioButton
        Me.m_radBtnDirectory = New System.Windows.Forms.RadioButton
        Me.m_chkBxRecurse = New System.Windows.Forms.CheckBox
        Me.m_btnBrowseDataList = New System.Windows.Forms.Button
        Me.m_txtBoxDataList = New System.Windows.Forms.TextBox
        Me.m_picBxDataListReadiness = New System.Windows.Forms.PictureBox
        Me.m_tblPnlOverall = New System.Windows.Forms.TableLayoutPanel
        Me.m_grpBoxDNCLT = New System.Windows.Forms.GroupBox
        Me.m_tblPnlDNCLTall = New System.Windows.Forms.TableLayoutPanel
        Me.m_tblPnlDNCLTlower = New System.Windows.Forms.TableLayoutPanel
        Me.m_btnBrowseDNCLT = New System.Windows.Forms.Button
        Me.m_txtBoxDNCL = New System.Windows.Forms.TextBox
        Me.m_picBxDNCLReadiness = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.m_flwPnl_DNCTOption = New System.Windows.Forms.FlowLayoutPanel
        Me.m_radBtn_AutoDNCLT = New System.Windows.Forms.RadioButton
        Me.m_radBtn_ManualDNCLT = New System.Windows.Forms.RadioButton
        Me.m_radBtn_FallbackDNCLT = New System.Windows.Forms.RadioButton
        Me.m_flwPlnDCNLmanualType = New System.Windows.Forms.FlowLayoutPanel
        Me.m_radBtnDNCL_Manual_GDB = New System.Windows.Forms.RadioButton
        Me.m_radBtnDCNL_Manual_MDB = New System.Windows.Forms.RadioButton
        Me.m_chkBxReadOnly = New System.Windows.Forms.CheckBox
        Me.m_ttpAutoDNCLT = New System.Windows.Forms.ToolTip(Me.components)
        Me.m_grpBxDataList.SuspendLayout()
        Me.m_tblPnlDataList.SuspendLayout()
        Me.m_flwPnlListType.SuspendLayout()
        CType(Me.m_picBxDataListReadiness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.m_tblPnlOverall.SuspendLayout()
        Me.m_grpBoxDNCLT.SuspendLayout()
        Me.m_tblPnlDNCLTall.SuspendLayout()
        Me.m_tblPnlDNCLTlower.SuspendLayout()
        CType(Me.m_picBxDNCLReadiness, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.m_flwPnl_DNCTOption.SuspendLayout()
        Me.m_flwPlnDCNLmanualType.SuspendLayout()
        Me.SuspendLayout()
        '
        'm_grpBxDataList
        '
        Me.m_grpBxDataList.Controls.Add(Me.m_tblPnlDataList)
        Me.m_grpBxDataList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_grpBxDataList.Location = New System.Drawing.Point(3, 3)
        Me.m_grpBxDataList.Name = "m_grpBxDataList"
        Me.m_grpBxDataList.Size = New System.Drawing.Size(597, 79)
        Me.m_grpBxDataList.TabIndex = 0
        Me.m_grpBxDataList.TabStop = False
        Me.m_grpBxDataList.Text = "Data Sources"
        '
        'm_tblPnlDataList
        '
        Me.m_tblPnlDataList.ColumnCount = 3
        Me.m_tblPnlDataList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlDataList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.m_tblPnlDataList.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.m_tblPnlDataList.Controls.Add(Me.m_flwPnlListType, 0, 0)
        Me.m_tblPnlDataList.Controls.Add(Me.m_chkBxRecurse, 1, 0)
        Me.m_tblPnlDataList.Controls.Add(Me.m_btnBrowseDataList, 1, 1)
        Me.m_tblPnlDataList.Controls.Add(Me.m_txtBoxDataList, 0, 1)
        Me.m_tblPnlDataList.Controls.Add(Me.m_picBxDataListReadiness, 2, 0)
        Me.m_tblPnlDataList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_tblPnlDataList.Location = New System.Drawing.Point(3, 16)
        Me.m_tblPnlDataList.Name = "m_tblPnlDataList"
        Me.m_tblPnlDataList.RowCount = 2
        Me.m_tblPnlDataList.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.m_tblPnlDataList.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.m_tblPnlDataList.Size = New System.Drawing.Size(591, 60)
        Me.m_tblPnlDataList.TabIndex = 0
        '
        'm_flwPnlListType
        '
        Me.m_flwPnlListType.Controls.Add(Me.m_radBtnCurMxDoc)
        Me.m_flwPnlListType.Controls.Add(Me.m_radBtnMXD)
        Me.m_flwPnlListType.Controls.Add(Me.m_radBtnGDB)
        Me.m_flwPnlListType.Controls.Add(Me.m_radBtnDirectory)
        Me.m_flwPnlListType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_flwPnlListType.Location = New System.Drawing.Point(0, 0)
        Me.m_flwPnlListType.Margin = New System.Windows.Forms.Padding(0)
        Me.m_flwPnlListType.Name = "m_flwPnlListType"
        Me.m_flwPnlListType.Size = New System.Drawing.Size(438, 23)
        Me.m_flwPnlListType.TabIndex = 0
        '
        'm_radBtnCurMxDoc
        '
        Me.m_radBtnCurMxDoc.AutoSize = True
        Me.m_radBtnCurMxDoc.Location = New System.Drawing.Point(8, 3)
        Me.m_radBtnCurMxDoc.Margin = New System.Windows.Forms.Padding(8, 3, 3, 3)
        Me.m_radBtnCurMxDoc.Name = "m_radBtnCurMxDoc"
        Me.m_radBtnCurMxDoc.Size = New System.Drawing.Size(83, 17)
        Me.m_radBtnCurMxDoc.TabIndex = 0
        Me.m_radBtnCurMxDoc.TabStop = True
        Me.m_radBtnCurMxDoc.Text = "Current Map"
        Me.m_radBtnCurMxDoc.UseVisualStyleBackColor = True
        '
        'm_radBtnMXD
        '
        Me.m_radBtnMXD.AutoSize = True
        Me.m_radBtnMXD.Location = New System.Drawing.Point(94, 3)
        Me.m_radBtnMXD.Margin = New System.Windows.Forms.Padding(0, 3, 3, 3)
        Me.m_radBtnMXD.Name = "m_radBtnMXD"
        Me.m_radBtnMXD.Size = New System.Drawing.Size(49, 17)
        Me.m_radBtnMXD.TabIndex = 1
        Me.m_radBtnMXD.TabStop = True
        Me.m_radBtnMXD.Text = "MXD"
        Me.m_radBtnMXD.UseVisualStyleBackColor = True
        '
        'm_radBtnGDB
        '
        Me.m_radBtnGDB.AutoSize = True
        Me.m_radBtnGDB.Location = New System.Drawing.Point(149, 3)
        Me.m_radBtnGDB.Name = "m_radBtnGDB"
        Me.m_radBtnGDB.Size = New System.Drawing.Size(89, 17)
        Me.m_radBtnGDB.TabIndex = 3
        Me.m_radBtnGDB.TabStop = True
        Me.m_radBtnGDB.Text = "Geodatabase"
        Me.m_radBtnGDB.UseVisualStyleBackColor = True
        '
        'm_radBtnDirectory
        '
        Me.m_radBtnDirectory.AutoSize = True
        Me.m_radBtnDirectory.Location = New System.Drawing.Point(241, 3)
        Me.m_radBtnDirectory.Margin = New System.Windows.Forms.Padding(0, 3, 8, 3)
        Me.m_radBtnDirectory.Name = "m_radBtnDirectory"
        Me.m_radBtnDirectory.Size = New System.Drawing.Size(67, 17)
        Me.m_radBtnDirectory.TabIndex = 2
        Me.m_radBtnDirectory.TabStop = True
        Me.m_radBtnDirectory.Text = "Directory"
        Me.m_radBtnDirectory.UseVisualStyleBackColor = True
        '
        'm_chkBxRecurse
        '
        Me.m_chkBxRecurse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_chkBxRecurse.Location = New System.Drawing.Point(446, 3)
        Me.m_chkBxRecurse.Margin = New System.Windows.Forms.Padding(8, 3, 8, 3)
        Me.m_chkBxRecurse.Name = "m_chkBxRecurse"
        Me.m_chkBxRecurse.Size = New System.Drawing.Size(99, 17)
        Me.m_chkBxRecurse.TabIndex = 1
        Me.m_chkBxRecurse.Text = "Recurse"
        Me.m_chkBxRecurse.UseVisualStyleBackColor = True
        '
        'm_btnBrowseDataList
        '
        Me.m_btnBrowseDataList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_btnBrowseDataList.Location = New System.Drawing.Point(446, 31)
        Me.m_btnBrowseDataList.Margin = New System.Windows.Forms.Padding(8)
        Me.m_btnBrowseDataList.Name = "m_btnBrowseDataList"
        Me.m_btnBrowseDataList.Size = New System.Drawing.Size(99, 21)
        Me.m_btnBrowseDataList.TabIndex = 2
        Me.m_btnBrowseDataList.Text = "Browse..."
        Me.m_btnBrowseDataList.UseVisualStyleBackColor = True
        '
        'm_txtBoxDataList
        '
        Me.m_txtBoxDataList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_txtBoxDataList.Location = New System.Drawing.Point(8, 31)
        Me.m_txtBoxDataList.Margin = New System.Windows.Forms.Padding(8)
        Me.m_txtBoxDataList.Name = "m_txtBoxDataList"
        Me.m_txtBoxDataList.Size = New System.Drawing.Size(422, 20)
        Me.m_txtBoxDataList.TabIndex = 3
        '
        'm_picBxDataListReadiness
        '
        Me.m_picBxDataListReadiness.BackColor = System.Drawing.Color.Transparent
        Me.m_picBxDataListReadiness.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_picBxDataListReadiness.ErrorImage = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDataListReadiness.Image = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDataListReadiness.InitialImage = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDataListReadiness.Location = New System.Drawing.Point(553, 0)
        Me.m_picBxDataListReadiness.Margin = New System.Windows.Forms.Padding(0)
        Me.m_picBxDataListReadiness.Name = "m_picBxDataListReadiness"
        Me.m_tblPnlDataList.SetRowSpan(Me.m_picBxDataListReadiness, 2)
        Me.m_picBxDataListReadiness.Size = New System.Drawing.Size(38, 60)
        Me.m_picBxDataListReadiness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.m_picBxDataListReadiness.TabIndex = 4
        Me.m_picBxDataListReadiness.TabStop = False
        '
        'm_tblPnlOverall
        '
        Me.m_tblPnlOverall.ColumnCount = 1
        Me.m_tblPnlOverall.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlOverall.Controls.Add(Me.m_grpBoxDNCLT, 0, 1)
        Me.m_tblPnlOverall.Controls.Add(Me.m_grpBxDataList, 0, 0)
        Me.m_tblPnlOverall.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_tblPnlOverall.Location = New System.Drawing.Point(0, 0)
        Me.m_tblPnlOverall.Name = "m_tblPnlOverall"
        Me.m_tblPnlOverall.RowCount = 2
        Me.m_tblPnlOverall.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85.0!))
        Me.m_tblPnlOverall.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlOverall.Size = New System.Drawing.Size(603, 170)
        Me.m_tblPnlOverall.TabIndex = 1
        '
        'm_grpBoxDNCLT
        '
        Me.m_grpBoxDNCLT.Controls.Add(Me.m_tblPnlDNCLTall)
        Me.m_grpBoxDNCLT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_grpBoxDNCLT.Enabled = False
        Me.m_grpBoxDNCLT.Location = New System.Drawing.Point(3, 88)
        Me.m_grpBoxDNCLT.Name = "m_grpBoxDNCLT"
        Me.m_grpBoxDNCLT.Size = New System.Drawing.Size(597, 79)
        Me.m_grpBoxDNCLT.TabIndex = 1
        Me.m_grpBoxDNCLT.TabStop = False
        Me.m_grpBoxDNCLT.Text = "Data Name Clause Lookup Tables"
        '
        'm_tblPnlDNCLTall
        '
        Me.m_tblPnlDNCLTall.ColumnCount = 2
        Me.m_tblPnlDNCLTall.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlDNCLTall.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
        Me.m_tblPnlDNCLTall.Controls.Add(Me.m_tblPnlDNCLTlower, 0, 1)
        Me.m_tblPnlDNCLTall.Controls.Add(Me.m_picBxDNCLReadiness, 1, 0)
        Me.m_tblPnlDNCLTall.Controls.Add(Me.SplitContainer1, 0, 0)
        Me.m_tblPnlDNCLTall.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_tblPnlDNCLTall.Location = New System.Drawing.Point(3, 16)
        Me.m_tblPnlDNCLTall.Name = "m_tblPnlDNCLTall"
        Me.m_tblPnlDNCLTall.RowCount = 2
        Me.m_tblPnlDNCLTall.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.m_tblPnlDNCLTall.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlDNCLTall.Size = New System.Drawing.Size(591, 60)
        Me.m_tblPnlDNCLTall.TabIndex = 5
        '
        'm_tblPnlDNCLTlower
        '
        Me.m_tblPnlDNCLTlower.ColumnCount = 2
        Me.m_tblPnlDNCLTlower.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.m_tblPnlDNCLTlower.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.m_tblPnlDNCLTlower.Controls.Add(Me.m_btnBrowseDNCLT, 1, 0)
        Me.m_tblPnlDNCLTlower.Controls.Add(Me.m_txtBoxDNCL, 0, 0)
        Me.m_tblPnlDNCLTlower.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_tblPnlDNCLTlower.Location = New System.Drawing.Point(0, 23)
        Me.m_tblPnlDNCLTlower.Margin = New System.Windows.Forms.Padding(0)
        Me.m_tblPnlDNCLTlower.Name = "m_tblPnlDNCLTlower"
        Me.m_tblPnlDNCLTlower.RowCount = 1
        Me.m_tblPnlDNCLTlower.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.m_tblPnlDNCLTlower.Size = New System.Drawing.Size(553, 37)
        Me.m_tblPnlDNCLTlower.TabIndex = 0
        '
        'm_btnBrowseDNCLT
        '
        Me.m_btnBrowseDNCLT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_btnBrowseDNCLT.Location = New System.Drawing.Point(446, 8)
        Me.m_btnBrowseDNCLT.Margin = New System.Windows.Forms.Padding(8)
        Me.m_btnBrowseDNCLT.Name = "m_btnBrowseDNCLT"
        Me.m_btnBrowseDNCLT.Size = New System.Drawing.Size(99, 21)
        Me.m_btnBrowseDNCLT.TabIndex = 2
        Me.m_btnBrowseDNCLT.Text = "Browse..."
        Me.m_btnBrowseDNCLT.UseVisualStyleBackColor = True
        '
        'm_txtBoxDNCL
        '
        Me.m_txtBoxDNCL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_txtBoxDNCL.Location = New System.Drawing.Point(8, 8)
        Me.m_txtBoxDNCL.Margin = New System.Windows.Forms.Padding(8)
        Me.m_txtBoxDNCL.Name = "m_txtBoxDNCL"
        Me.m_txtBoxDNCL.ReadOnly = True
        Me.m_txtBoxDNCL.Size = New System.Drawing.Size(422, 20)
        Me.m_txtBoxDNCL.TabIndex = 3
        '
        'm_picBxDNCLReadiness
        '
        Me.m_picBxDNCLReadiness.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_picBxDNCLReadiness.ErrorImage = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDNCLReadiness.Image = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDNCLReadiness.InitialImage = Global.mapaction.datanames.gui.My.Resources.Resources.icoTrafficLightRed
        Me.m_picBxDNCLReadiness.Location = New System.Drawing.Point(553, 0)
        Me.m_picBxDNCLReadiness.Margin = New System.Windows.Forms.Padding(0)
        Me.m_picBxDNCLReadiness.Name = "m_picBxDNCLReadiness"
        Me.m_tblPnlDNCLTall.SetRowSpan(Me.m_picBxDNCLReadiness, 2)
        Me.m_picBxDNCLReadiness.Size = New System.Drawing.Size(38, 60)
        Me.m_picBxDNCLReadiness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.m_picBxDNCLReadiness.TabIndex = 1
        Me.m_picBxDNCLReadiness.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.m_flwPnl_DNCTOption)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.m_flwPlnDCNLmanualType)
        Me.SplitContainer1.Size = New System.Drawing.Size(553, 23)
        Me.SplitContainer1.SplitterDistance = 270
        Me.SplitContainer1.TabIndex = 2
        '
        'm_flwPnl_DNCTOption
        '
        Me.m_flwPnl_DNCTOption.Controls.Add(Me.m_radBtn_AutoDNCLT)
        Me.m_flwPnl_DNCTOption.Controls.Add(Me.m_radBtn_ManualDNCLT)
        Me.m_flwPnl_DNCTOption.Controls.Add(Me.m_radBtn_FallbackDNCLT)
        Me.m_flwPnl_DNCTOption.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_flwPnl_DNCTOption.Location = New System.Drawing.Point(0, 0)
        Me.m_flwPnl_DNCTOption.Margin = New System.Windows.Forms.Padding(0)
        Me.m_flwPnl_DNCTOption.Name = "m_flwPnl_DNCTOption"
        Me.m_flwPnl_DNCTOption.Size = New System.Drawing.Size(270, 23)
        Me.m_flwPnl_DNCTOption.TabIndex = 6
        '
        'm_radBtn_AutoDNCLT
        '
        Me.m_radBtn_AutoDNCLT.AutoSize = True
        Me.m_radBtn_AutoDNCLT.Checked = True
        Me.m_radBtn_AutoDNCLT.Location = New System.Drawing.Point(3, 3)
        Me.m_radBtn_AutoDNCLT.Name = "m_radBtn_AutoDNCLT"
        Me.m_radBtn_AutoDNCLT.Size = New System.Drawing.Size(84, 17)
        Me.m_radBtn_AutoDNCLT.TabIndex = 6
        Me.m_radBtn_AutoDNCLT.TabStop = True
        Me.m_radBtn_AutoDNCLT.Text = "Auto Search"
        Me.m_ttpAutoDNCLT.SetToolTip(Me.m_radBtn_AutoDNCLT, "Automaticaly search for Data Name Clause " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lookup Tables based on the location of" & _
                "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the Data List")
        Me.m_radBtn_AutoDNCLT.UseVisualStyleBackColor = True
        '
        'm_radBtn_ManualDNCLT
        '
        Me.m_radBtn_ManualDNCLT.AutoSize = True
        Me.m_radBtn_ManualDNCLT.Location = New System.Drawing.Point(93, 3)
        Me.m_radBtn_ManualDNCLT.Name = "m_radBtn_ManualDNCLT"
        Me.m_radBtn_ManualDNCLT.Size = New System.Drawing.Size(93, 17)
        Me.m_radBtn_ManualDNCLT.TabIndex = 7
        Me.m_radBtn_ManualDNCLT.Text = "Manual Select"
        Me.m_ttpAutoDNCLT.SetToolTip(Me.m_radBtn_ManualDNCLT, "Manually select the location of the Data Name Clause Lookup Tables")
        Me.m_radBtn_ManualDNCLT.UseVisualStyleBackColor = True
        '
        'm_radBtn_FallbackDNCLT
        '
        Me.m_radBtn_FallbackDNCLT.AutoSize = True
        Me.m_radBtn_FallbackDNCLT.Location = New System.Drawing.Point(192, 3)
        Me.m_radBtn_FallbackDNCLT.Name = "m_radBtn_FallbackDNCLT"
        Me.m_radBtn_FallbackDNCLT.Size = New System.Drawing.Size(56, 17)
        Me.m_radBtn_FallbackDNCLT.TabIndex = 8
        Me.m_radBtn_FallbackDNCLT.Text = "Built-in"
        Me.m_ttpAutoDNCLT.SetToolTip(Me.m_radBtn_FallbackDNCLT, "Use the built-in read-only lookup example" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Data Name Clause Lookup Tables")
        Me.m_radBtn_FallbackDNCLT.UseVisualStyleBackColor = True
        '
        'm_flwPlnDCNLmanualType
        '
        Me.m_flwPlnDCNLmanualType.Controls.Add(Me.m_radBtnDNCL_Manual_GDB)
        Me.m_flwPlnDCNLmanualType.Controls.Add(Me.m_radBtnDCNL_Manual_MDB)
        Me.m_flwPlnDCNLmanualType.Controls.Add(Me.m_chkBxReadOnly)
        Me.m_flwPlnDCNLmanualType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.m_flwPlnDCNLmanualType.Enabled = False
        Me.m_flwPlnDCNLmanualType.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.m_flwPlnDCNLmanualType.Location = New System.Drawing.Point(0, 0)
        Me.m_flwPlnDCNLmanualType.Margin = New System.Windows.Forms.Padding(0)
        Me.m_flwPlnDCNLmanualType.Name = "m_flwPlnDCNLmanualType"
        Me.m_flwPlnDCNLmanualType.Size = New System.Drawing.Size(279, 23)
        Me.m_flwPlnDCNLmanualType.TabIndex = 5
        '
        'm_radBtnDNCL_Manual_GDB
        '
        Me.m_radBtnDNCL_Manual_GDB.AutoSize = True
        Me.m_radBtnDNCL_Manual_GDB.Location = New System.Drawing.Point(228, 3)
        Me.m_radBtnDNCL_Manual_GDB.Name = "m_radBtnDNCL_Manual_GDB"
        Me.m_radBtnDNCL_Manual_GDB.Size = New System.Drawing.Size(48, 17)
        Me.m_radBtnDNCL_Manual_GDB.TabIndex = 0
        Me.m_radBtnDNCL_Manual_GDB.TabStop = True
        Me.m_radBtnDNCL_Manual_GDB.Text = "GDB"
        Me.m_radBtnDNCL_Manual_GDB.UseVisualStyleBackColor = True
        '
        'm_radBtnDCNL_Manual_MDB
        '
        Me.m_radBtnDCNL_Manual_MDB.AutoSize = True
        Me.m_radBtnDCNL_Manual_MDB.Location = New System.Drawing.Point(162, 3)
        Me.m_radBtnDCNL_Manual_MDB.Name = "m_radBtnDCNL_Manual_MDB"
        Me.m_radBtnDCNL_Manual_MDB.Size = New System.Drawing.Size(60, 17)
        Me.m_radBtnDCNL_Manual_MDB.TabIndex = 1
        Me.m_radBtnDCNL_Manual_MDB.TabStop = True
        Me.m_radBtnDCNL_Manual_MDB.Text = "Access"
        Me.m_radBtnDCNL_Manual_MDB.UseVisualStyleBackColor = True
        '
        'm_chkBxReadOnly
        '
        Me.m_chkBxReadOnly.AutoSize = True
        Me.m_chkBxReadOnly.Location = New System.Drawing.Point(80, 3)
        Me.m_chkBxReadOnly.Name = "m_chkBxReadOnly"
        Me.m_chkBxReadOnly.Size = New System.Drawing.Size(76, 17)
        Me.m_chkBxReadOnly.TabIndex = 2
        Me.m_chkBxReadOnly.Text = "Read Only"
        Me.m_chkBxReadOnly.UseVisualStyleBackColor = True
        '
        'DataListSelectorPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.m_tblPnlOverall)
        Me.MaximumSize = New System.Drawing.Size(1000, 170)
        Me.MinimumSize = New System.Drawing.Size(450, 170)
        Me.Name = "DataListSelectorPanel"
        Me.Size = New System.Drawing.Size(603, 170)
        Me.m_grpBxDataList.ResumeLayout(False)
        Me.m_tblPnlDataList.ResumeLayout(False)
        Me.m_tblPnlDataList.PerformLayout()
        Me.m_flwPnlListType.ResumeLayout(False)
        Me.m_flwPnlListType.PerformLayout()
        CType(Me.m_picBxDataListReadiness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.m_tblPnlOverall.ResumeLayout(False)
        Me.m_grpBoxDNCLT.ResumeLayout(False)
        Me.m_tblPnlDNCLTall.ResumeLayout(False)
        Me.m_tblPnlDNCLTlower.ResumeLayout(False)
        Me.m_tblPnlDNCLTlower.PerformLayout()
        CType(Me.m_picBxDNCLReadiness, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.m_flwPnl_DNCTOption.ResumeLayout(False)
        Me.m_flwPnl_DNCTOption.PerformLayout()
        Me.m_flwPlnDCNLmanualType.ResumeLayout(False)
        Me.m_flwPlnDCNLmanualType.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents m_tblPnlOverall As System.Windows.Forms.TableLayoutPanel
    Private WithEvents m_grpBoxDNCLT As System.Windows.Forms.GroupBox
    Private WithEvents m_tblPnlDNCLTlower As System.Windows.Forms.TableLayoutPanel
    Private WithEvents m_btnBrowseDNCLT As System.Windows.Forms.Button
    Private WithEvents m_txtBoxDNCL As System.Windows.Forms.TextBox
    Private WithEvents m_radBtnGDB As System.Windows.Forms.RadioButton
    Private WithEvents m_grpBxDataList As System.Windows.Forms.GroupBox
    Private WithEvents m_tblPnlDataList As System.Windows.Forms.TableLayoutPanel
    Private WithEvents m_flwPnlListType As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents m_radBtnCurMxDoc As System.Windows.Forms.RadioButton
    Private WithEvents m_radBtnMXD As System.Windows.Forms.RadioButton
    Private WithEvents m_radBtnDirectory As System.Windows.Forms.RadioButton
    Private WithEvents m_chkBxRecurse As System.Windows.Forms.CheckBox
    Private WithEvents m_btnBrowseDataList As System.Windows.Forms.Button
    Private WithEvents m_txtBoxDataList As System.Windows.Forms.TextBox
    Private WithEvents m_tblPnlDNCLTall As System.Windows.Forms.TableLayoutPanel
    Private WithEvents m_flwPlnDCNLmanualType As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents m_radBtnDNCL_Manual_GDB As System.Windows.Forms.RadioButton
    Private WithEvents m_radBtnDCNL_Manual_MDB As System.Windows.Forms.RadioButton
    Friend WithEvents m_picBxDataListReadiness As System.Windows.Forms.PictureBox
    Friend WithEvents m_picBxDNCLReadiness As System.Windows.Forms.PictureBox
    Friend WithEvents m_flwPnl_DNCTOption As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents m_chkBxReadOnly As System.Windows.Forms.CheckBox
    Private WithEvents m_radBtn_AutoDNCLT As System.Windows.Forms.RadioButton
    Private WithEvents m_radBtn_ManualDNCLT As System.Windows.Forms.RadioButton
    Private WithEvents m_radBtn_FallbackDNCLT As System.Windows.Forms.RadioButton
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents m_ttpAutoDNCLT As System.Windows.Forms.ToolTip

End Class
