﻿Imports System.ComponentModel
Imports MySql.Data.MySqlClient
Public Class FormStudentsRegistration
    Dim course_dept_idr As Integer = 1 '
    Dim session_idr As String = "2018/2019"
    Dim strSQL As String
    Dim strConnectionString As String
    Dim ref As Integer

    Dim tmpDS As DataSet
    Dim dsStudents, dsReg As New DataSet

    'forced to do this
    Dim glbRegConn As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString32)
    Dim glbRegConnFORM As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString32)
    Dim glbAdapter As New OleDb.OleDbDataAdapter()
    Dim glbAdapterFORM As New OleDb.OleDbDataAdapter()
    Dim glbDTReg As DataTable
    Dim glbBND As New BindingSource




    Private Sub FormStudentsRegistration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Me.BackColor = RGBColors.colorBackground
        Me.dgvStudents.BackgroundColor = RGBColors.colorBackground
        Me.dgvStudents.RowsDefaultCellStyle.BackColor = RGBColors.colorForeground
        Me.dgvStudents.RowsDefaultCellStyle.ForeColor = RGBColors.colorBackground

        Me.dgvImportCourses.BackgroundColor = RGBColors.colorBackground
        Me.dgvImportCourses.RowsDefaultCellStyle.BackColor = RGBColors.colorForeground
        Me.dgvImportCourses.RowsDefaultCellStyle.ForeColor = RGBColors.colorBackground

        bindcontrolsToReg()
    End Sub
    Private Sub FormStudentsRegistration_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        On Error Resume Next
        txtStudentMATNO.Text = ""
        If dictDepts.Count < 1 Then
            bgwLoad.RunWorkerAsync(1)
        Else
            bgwLoad.RunWorkerAsync(2)
        End If
        'BgWProcess.RunWorkerAsync(1)  'runs GetData()
    End Sub

    Public Sub GetData()
        Dim dDept As Integer = 1
        Try
            'mappDB.Dept = 1 'TODO
            If CInt(TextBoxstudent_dept_idr.Text) > 0 Then
                dDept = CInt(TextBoxstudent_dept_idr.Text) 'TODO
            Else

            End If
            'tmpDS = mappDB.GetDataWhere(String.Format(STR_SQL_ALL_STUDENTS_IN_DEPT, dDept.ToString), "students")
            fillRegGridUsingdataAdapter()   'ComboBoxSessions.SelectedIndex, CInt(TextBoxdept_idr.Text), CInt(ComboBoxLevel.SelectedIndex))

                'TODO:
                If dictAllCourseCodeKeyAndCourseUnitVal.Count = 0 Then mappDB.getAllCourses()
            CheckedListBoxCourses.Items.Clear()
            For Each key In dictAllCourseCodeKeyAndCourseUnitVal.Keys
                CheckedListBoxCourses.Items.Add(key)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub resizeDatagrids(dGrid As String)
        If DataGridViewAlReg.Rows.Count > 0 And dGrid = "Courses" Then

            For Each col As DataGridViewColumn In DataGridViewAlReg.Columns
                col.Width = 0
                col.Visible = False
                If col.HeaderText = "matno" Then
                    col.Width = 70
                    col.Visible = True
                ElseIf col.HeaderText = "CourseCode_1" Then
                    col.Width = 200
                    col.Visible = True
                ElseIf col.HeaderText = "CourseCode_2" Then
                    col.Width = 200
                    col.Visible = True
                End If
            Next
        ElseIf dgvStudents.Rows.Count > 0 And dGrid = "Students" Then
            dgvStudents.Columns("matno").Frozen = True
            For Each col As DataGridViewColumn In dgvStudents.Columns
                col.Width = 50
                If col.HeaderText = "matno" Then
                    col.Width = 100
                ElseIf col.HeaderText = "first_name" Then
                    col.Width = 150
                ElseIf col.HeaderText = "surname" Then
                    col.Width = 100
                End If
            Next
        End If
    End Sub
    Public Sub getRegisteredCoursesForStudent(dMATNO As String)
        'Try
        '    Dim tmpDSCourses As DataSet
        '    mappDB.MATNO = dMATNO
        '    tmpDSCourses = mappDB.GetDataWhere(String.Format(STR_SQL_COURSES_REG_WHERE, dMATNO), "Courses") 'todo
        '    dgvCourses.DataSource = tmpDSCourses.Tables("Courses").DefaultView

        '    dgvCourses.Refresh()
        '    resizeDatagrids("courses")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Private Sub txtStudentMATNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStudentMATNO.TextChanged
        Dim strSearch As String = txtStudentMATNO.Text
        If txtStudentMATNO.Text.Length > 3 And dgvStudents.Rows.Count = 0 Then
            'Dim tmpDSStudents = mappDB.GetDataWhere(String.Format(STR_SQL_SEARCH_STUDENTS_BY_MATNO_SURNAME_FIRSTNAME, strSearch, strSearch, strSearch), "Students")
            'dgvStudents.DataSource = tmpDSStudents.Tables("Students").DefaultView
        ElseIf dgvStudents.Rows.Count > 0 Then
            'just filter
            On Error Resume Next
            If Not dgvStudents.SelectedRows(0).Cells("matno").Value = Nothing Then
                filterStudents(strSearch)   'for gridiew

            End If
        End If
        filterStudentsFORM(strSearch)   'for FormView
    End Sub


    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        dgvStudents.RefreshEdit()
        'btnReset.Enabled = False
        'Me.ProgressBarBS.Value = 5
        'TimerBS.Enabled = True
        'TimerBS.Start()

        'bgwLoad.RunWorkerAsync(1)  'runs GetData()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub CaptureCourses()
        Dim units As Integer
        Dim courseCodes1 As String() = TextBoxCourseCode_1.Text.Split(";")
        Dim courseCodes2 As String() = TextBoxCourseCode_2.Text.Split(";")
        Dim sumUnits As Integer = 0

        'todo check if dictionary is lready loaded if not load
        If dictAllCourseCodeKeyAndCourseUnitVal.Count = 0 Then
            'todo:
        End If

        For Each c1 In courseCodes1
            If dictAllCourseCodeKeyAndCourseUnitVal.ContainsKey(c1) Then
                units = dictAllCourseCodeKeyAndCourseUnitVal(c1)
                sumUnits = sumUnits + units
            End If
        Next
        For Each c2 In courseCodes2
            If dictAllCourseCodeKeyAndCourseUnitVal.ContainsKey(c2) Then
                units = dictAllCourseCodeKeyAndCourseUnitVal(c2)
                sumUnits = sumUnits + units
            End If
        Next

        'Me.TextBoxCourseCode.Text = courseCode.ToString
        'Me.TextBoxSemester.Text = semester.ToString
        'Me.TextBoxUnits.Text = sumUnits.ToString
        Me.TextBoxTotalCredits.Text = sumUnits.ToString
        If CInt(TextBoxTotalCredits.Text) > 50 Then
            TextBoxTotalCredits.BackColor = Color.Pink
        Else
            TextBoxTotalCredits.BackColor = Color.White
        End If

    End Sub

    Sub filterReg(dMATNO As String)
        If DataGridViewAlReg.Rows.Count > 0 Then
            DataGridViewAlReg.DataSource.RowFilter = String.Format(STR_FILTER_REG_BY_MATNO, dMATNO)
        End If
    End Sub
    Sub filterStudents(dMATNO As String)
        If dgvStudents.Rows.Count > 0 Then
            dgvStudents.DataSource.RowFilter = String.Format(STR_FILTER_STUDENTS, dMATNO, dMATNO, dMATNO)
        End If
    End Sub
    Sub filterStudentsFORM(dMATNO As String)
        BindingSourceStudents.DataSource.RowFilter = String.Format(STR_FILTER_REG_BY_MATNO_LIKE, dMATNO)
    End Sub
    Public Sub unregisterStudent()
        Dim oldLen As Integer = 0
        If TextBoxCourseCode_1.Text.Contains(TextBoxCourseCode.Text) Then
            'If dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 1 Then
            'If TextBoxCourse_1.Text.Contains(TextBoxCourseCode.Text) Then
            'MsgBox("Already Registered")
            'Else
            'If TextBoxCourse_1.Text = "" Then
            oldLen = TextBoxCourseCode_1.Text.Length
            TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text.Replace(TextBoxCourseCode.Text, "")
            TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text.Replace(";;", "")
            If TextBoxCourseCode_1.Text.Length = oldLen Then
                TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text.Replace(TextBoxCourseCode.Text, "")    'try again incase it is the last course
            End If
            If TextBoxCourseCode_1.Text.EndsWith(";") Then
                TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text.TrimEnd(";"c)
            ElseIf TextBoxCourseCode_1.Text.StartsWith(";") Then
                TextBoxCourseCode_1.Text = TextBoxCourseCode_2.Text.TrimStart(";"c)
            End If

        ElseIf TextBoxCourseCode_2.Text.Contains(TextBoxCourseCode.Text) Then
            oldLen = TextBoxCourseCode_2.Text.Length
            TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text.Replace(TextBoxCourseCode.Text, "")
            TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text.Replace(";;", ";")     'just in case its not last course, correct
            If TextBoxCourseCode_2.Text.Length = oldLen Then
                TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text.Replace(TextBoxCourseCode.Text, "")    'try again incase it is the last course
            End If
            'todo remove trailing delimiter

            If TextBoxCourseCode_2.Text.EndsWith(";") Then
                TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text.TrimEnd(";"c)
            ElseIf TextBoxCourseCode_2.Text.StartsWith(";") Then
                TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text.TrimStart(";"c)
            End If
        Else

        End If

    End Sub
    Sub importReg()
        Try
            'Algorithm
            'Check database if result already exist to avoid duplicates
            'Write into Database
            'Get dataset from displayed datagrid
            'parse dataset record by record
            'insert record by record

            Dim dt As DataTable
            dgvImportCourses.EndEdit()
            dgvImportCourses.Update()
            If Not (IsDBNull(dgvImportCourses.DataSource) Or (dgvImportCourses.Rows.Count = 0)) Then
                dt = dgvImportCourses.DataSource 'causes error if dirty
            Else
                MsgBox("Empty Registration Records")
                Exit Sub
            End If

            '#method 1 manual Insert or bulkInsert
            TextBoxImport.Text = mappDB.manualRegInsertDB(dt)

            'status
            If TextBoxImport.Text.Length > 40 Then
                TextBoxImport.Visible = True
                logError(TextBoxImport.Text.Length)
            Else
                TextBoxImport.Visible = False
            End If

            'ElseIf dSession.Length > 10 Then
            'MsgBox("Import file with the right format")

            'End If
            MsgBox("Reg Uploaded into Database Successfully! Cross check what was uploaded below")
            'dgvImportCourses.Visible = True
            'strSQL = "SELECT * from Reg WHERE (session_idr = '{0}'  AND department_idr={1})"
            'dgvImportCourses.DataSource = mappDB.GetDataWhere(String.Format(strSQL, dSession, dDeptID)).Tables(0).DefaultView
            'dgvImportCourses.Top = dgvImportCourses.Top + dgvImportCourses.Height
            'dgvImportCourses.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Function importRegUsingdataAdapter() As Boolean
        Try
            Dim strSQL As String
            Dim dv As DataView = dgvImportCourses.DataSource
            Dim dtSource As DataTable
            Dim dtDestination As New DataTable
            Dim dSReg As New DataSet ' = dv.ToTable
            dtSource = dv.ToTable

            'createBroadsheetTables()
            strSQL = "SELECT * FROM Reg" ' WHERE session_idr={1}"

            Using xconn As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString32)
                xconn.ConnectionString = mappDB.getCorrectConnectionstring()
                xconn.Open()
                Dim adapter As New OleDb.OleDbDataAdapter(strSQL, xconn)
                Dim builder As New OleDb.OleDbCommandBuilder(adapter)       'easy way for single table
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                builder.QuotePrefix = "["
                builder.QuoteSuffix = "]"
                'adapter.UpdateCommand = ""
                'adapter.InsertCommand = ""
                '1. fill it
                adapter.Fill(dsReg)
                '2. put it in a datagrid view and all the manipulations can happen there, afterwards an update is used to save in database
                dgvImportCourses.DataSource = dSReg.Tables(0)
                'MsgBox("After fresh fill")


                dSReg.Tables(0).Clear()  'empty table
                adapter.Update(dSReg)    'persist in db

                Dim dRow As DataRow
                'MsgBox("After empty db")
                '3. edit it
                For i = 0 To dtSource.Rows.Count - 1
                    dRow = dSReg.Tables(0).Rows.Add("MOCK00" & i.ToString) 'add mock row
                    For j = 0 To dSReg.Tables(0).Columns.Count - 1       'Take as much as we have cols for to avoid errors
                        If j > dtSource.Columns.Count - 1 Then Exit For
                        dSReg.Tables(0).Rows(i).Item(j) = dtSource.Rows(i).Item(j)   'update the row with data
                        'strColNames = strColNames & "," & dtSource.Columns(j).ColumnName
                    Next
                Next

                '4. load the mock data  in another datagridview
                dgvImportCourses.DataSource = dSReg.Tables(0)
                'MsgBox("After add to datatable")

                '5. use datagridview tecnique to capture it as edited
                dgvImportCourses.Refresh()
                dgvImportCourses.EndEdit()
                ' MsgBox("After refresh")

                '6. save the underlying data (change from mock to real) to database (works bcos of datagridview technique)
                adapter.Update(dSReg) 'save
            End Using
            Return True
        Catch ex As Exception
            MsgBox("Error occured, see log for details" & vbCrLf & ex.Message)
            logError(ex.ToString)
            Return False
        End Try
    End Function
    Public Sub updatePix()
        'todo: get from ser doc
        Dim TMPileNAME As String = Application.StartupPath & "\photos\" & dgvStudents.SelectedRows(0).Cells("matno").Value & ".jpg"
        Dim TMP_PIC_FILE_NAME2 As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\photos\" & dgvStudents.SelectedRows(0).Cells("matno").Value & ".jpg"
        Dim tmpileName3 As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\photos\" & dgvStudents.SelectedRows(0).Cells("matno").Value & ".jpg"


        Try

            If My.Computer.FileSystem.FileExists(TMPileNAME) Then
                PictureBox1.Image = Image.FromFile(TMPileNAME)
            ElseIf My.Computer.FileSystem.FileExists(TMP_PIC_FILE_NAME2) Then
                PictureBox1.Image = Image.FromFile(TMP_PIC_FILE_NAME2)
            ElseIf My.Computer.FileSystem.FileExists(tmpileName3) Then
                PictureBox1.Image = Image.FromFile(tmpileName3)
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function fillRegGridUsingdataAdapter() As Boolean 'dSess As String, dDeptID As Integer, dLvl As Integer) As Boolean
        Try
            Dim strSQL As String
            strSQL = String.Format("SELECT * FROM Reg") ' WHERE session_idr='{1}',dept_idr={2},[level]={3}", dSess, dDeptID, dLvl)

            If glbRegConn.State = ConnectionState.Open Then glbRegConn.Close()
            glbRegConn.ConnectionString = mappDB.getCorrectConnectionstring()

            glbRegConn.Open()
            glbDTReg = mappDB.GetDataWhere(strSQL).Tables(0)
            glbAdapter = New OleDb.OleDbDataAdapter(strSQL, glbRegConn)
            glbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

            '1. fill it
            glbAdapter.Fill(glbDTReg)
            glbBND.DataSource = glbDTReg
            Return True
        Catch ex As Exception
            MsgBox("Error occured, see log for details" & vbCrLf & ex.Message)
            logError(ex.ToString)
            Return False
        End Try
    End Function
    Private Function fillRegFORMUsingdataAdapter() As Boolean 'dSess As String, dDeptID As Integer, dLvl As Integer) As Boolean
        Try
            Dim strSQL As String
            strSQL = String.Format("SELECT * FROM Reg") ' WHERE session_idr='{1}',dept_idr={2},[level]={3}", dSess, dDeptID, dLvl)

            If glbRegConnFORM.State = ConnectionState.Open Then glbRegConn.Close()
            glbRegConnFORM.ConnectionString = mappDB.getCorrectConnectionstring()

            glbRegConnFORM.Open()
            dsStudents = mappDB.GetDataWhere(strSQL)
            glbAdapterFORM = New OleDb.OleDbDataAdapter(strSQL, glbRegConn)
            glbAdapterFORM.MissingSchemaAction = MissingSchemaAction.AddWithKey

            '1. fill it
            glbAdapterFORM.Fill(dsStudents.Tables(0))

            Return True
        Catch ex As Exception
            MsgBox("Error occured, see log for details" & vbCrLf & ex.Message)
            logError(ex.ToString)
            Return False
        End Try
    End Function
    Private Function updateRegGridUsingdataAdapter() As Boolean
        Try
            Dim strSQL As String

            strSQL = "SELECT * FROM Reg" ' WHERE session_idr={1}"

            Dim builder As New OleDb.OleDbCommandBuilder(glbAdapter)
            builder.QuotePrefix = "["
            builder.QuoteSuffix = "]"
            glbAdapter.Update(glbDTReg)    'persist in db
            Return True
        Catch ex As Exception
            MsgBox("Error occured, see log for details" & vbCrLf & ex.Message)
            logError(ex.ToString)
            Return False
        End Try
    End Function

    Private Sub ButtonUnregister_Click(sender As Object, e As EventArgs) Handles ButtonUnregister.Click
        unregisterStudent()
    End Sub

    Private Sub dgvStudents_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellContentDoubleClick
        ButtonFormView.PerformClick()
        If e.RowIndex >= 0 Then
            captureReg(e.RowIndex)
        End If
    End Sub



    Private Sub dgvStudents_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvStudents.RowsAdded
        On Error Resume Next
        dgvStudents.Rows(e.RowIndex).Cells("session_idr") = ComboBoxSessions.SelectedItem

        dgvStudents.Rows(e.RowIndex).Cells("status").Value = CATEGORY_DESCRIPTION_REGISTERED
        dgvStudents.Rows(e.RowIndex).Cells("level").Value = ComboBoxLevel.SelectedItem
        dgvStudents.Rows(e.RowIndex).Cells("dept_idr").Value = mappDB.getDeptID(ComboBoxDepartments.SelectedItem)

        dgvStudents.Rows(e.RowIndex).Cells("mode_of_entry").Value = MODE_OF_ENTRY_UME



    End Sub
    Private Sub dgvStudents_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.RowEnter
        On Error Resume Next
        If e.RowIndex >= 0 Then
            captureReg(e.RowIndex)
            CapturePicture(dgvStudents.Rows(e.RowIndex).Cells("matno").Value)
        End If

    End Sub

    Private Function computeCredits() As Integer
        Try
            'for each row
            'sum =sum + row(units)
            Return 0
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub FormStudentsRegistration_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        On Error Resume Next
        MainForm.doCloseForm()

        glbRegConn.Close()
        glbRegConnFORM.Close()
        glbRegConn = Nothing
        glbRegConnFORM = Nothing
    End Sub
    Private Sub TimerBS_Tick(sender As Object, e As EventArgs) Handles TimerBS.Tick
        If ProgressBarBS.Value < 97 Then ProgressBarBS.Value = (ProgressBarBS.Value + 3)
    End Sub


    Private Sub ButtonRegister_DataGridVersion(sender As Object, e As EventArgs)
        'Dim dv As DataView
        'Dim dt As DataTable
        'dv = dgvCourses.DataSource
        'dt = dv.ToTable
        'If dgvCourses.Rows.Count > 0 Then
        '    If dictAllCourseCodeKeyAndCourseSemesterVal.ContainsKey(TextBoxCourseCode.Text) Then
        '        If dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 1 Then
        '            If dt.Rows(0).Item("CourseCode_1").ToString.Contains(TextBoxCourseCode.Text) Then
        '                MsgBox("Already Registered")
        '            Else
        '                dt.Rows(0).Item("CourseCode_1") = dt.Rows(0).Item("CourseCode_2").Value.ToString & ";" & TextBoxCourseCode.Text
        '            End If
        '        ElseIf dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 2 Then
        '            If dt.Rows(0).Item("CourseCode_2").ToString.Contains(TextBoxCourseCode.Text) Then
        '                MsgBox("Already Registered")
        '            Else
        '                dt.Rows(0).Item("CourseCode_2").Value = dt.Rows(0).Item("CourseCode_1").ToString & ";" & TextBoxCourseCode.Text
        '            End If
        '        End If
        '        dgvCourses.DataSource = dt.DefaultView
        '    End If
        'Else    'no course reg entry before
        '    If dictAllCourseCodeKeyAndCourseSemesterVal.ContainsKey(TextBoxCourseCode.Text) Then
        '        If dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 2 Then
        '            dt.Rows.Add({mappDB.MATNO, "", TextBoxCourseCode.Text}) '2nd sem
        '        ElseIf dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 1 Then
        '            dt.Rows.Add({mappDB.MATNO, TextBoxCourseCode.Text, ""})
        '        End If
        '        dt.Rows(0).Item("session_idr").Value = TextBoxsession_idr.Text

        '        dgvCourses.DataSource = dt.DefaultView
        '    End If
        'End If
    End Sub

    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click

        If dictAllCourseCodeKeyAndCourseSemesterVal.ContainsKey(TextBoxCourseCode.Text) Then
            If dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 1 Then
                If TextBoxCourseCode_1.Text.Contains(TextBoxCourseCode.Text) Then
                    MsgBox("Already Registered")
                Else
                    If TextBoxCourseCode_1.Text = "" Then
                        TextBoxCourseCode_1.Text = TextBoxCourseCode.Text
                    Else
                        TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text & ";" & TextBoxCourseCode.Text
                    End If
                End If
            ElseIf dictAllCourseCodeKeyAndCourseSemesterVal(TextBoxCourseCode.Text) = 2 Then
                If TextBoxCourseCode_2.Text.Contains(TextBoxCourseCode.Text) Then
                    MsgBox("Already Registered")
                Else
                    If TextBoxCourseCode_2.Text = "" Then
                        TextBoxCourseCode_2.Text = TextBoxCourseCode.Text
                    Else
                        TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text & ";" & TextBoxCourseCode.Text
                    End If
                End If
            End If

        End If

    End Sub

    Private Sub ButtonImportStudentsFromExcel_Click(sender As Object, e As EventArgs) Handles ButtonImportStudentsFromExcel.Click
        MainForm.ChangeMenu("Student")
    End Sub

    Sub captureReg(dRowIndex As Integer)
        Try
            TextBoxFancyDisplayCourse1.Text = ""
            TextBoxFancyDisplayCourse1.Text = dgvStudents.Rows(dRowIndex).Cells("CourseCode_1").Value
            TextBoxFancyDisplayCourse1.Text = TextBoxFancyDisplayCourse1.Text.Replace(";", vbCrLf)

            TextBoxFancyDisplayCourse2.Text = ""
            TextBoxFancyDisplayCourse2.Text = dgvStudents.Rows(dRowIndex).Cells("CourseCode_2").Value
            TextBoxFancyDisplayCourse2.Text = TextBoxFancyDisplayCourse1.Text.Replace(";", vbCrLf)

        Catch ex As Exception

            logError(ex.ToString)
        End Try
    End Sub
    Sub showCoursesList()
        PanelCourses.Visible = True
        For i = 0 To CheckedListBoxCourses.Items.Count - 1
            If TextBoxCourseCode_1.Text.Contains(CheckedListBoxCourses.Items(i).ToString()) Then
                CheckedListBoxCourses.SetItemChecked(i, True)
            ElseIf TextBoxCourseCode_2.Text.Contains(CheckedListBoxCourses.Items(i).ToString()) Then
                CheckedListBoxCourses.SetItemChecked(i, True)
            End If
        Next
    End Sub



    Private Sub ButtonImportRegFERMA_Click(sender As Object, e As EventArgs) Handles ButtonImportRegFERMAExcel.Click
        Dim FileOpenDialogBroadsheet As New OpenFileDialog()
        Dim resultFileName As String = ""
        Dim tmpDS As New DataSet
        Dim dt As DataTable
        Dim dDept As String = "Computer Engineering"
        Dim dLevel As Integer = 100
        Dim dSession As String = "2018/2019"

        dDept = ComboBoxDepartments.SelectedItem
        dLevel = CInt(ComboBoxLevel.SelectedItem)
        dSession = ComboBoxSessions.SelectedItem
        Try
            If Not FileOpenDialogBroadsheet.ShowDialog = DialogResult.Cancel Then
                resultFileName = FileOpenDialogBroadsheet.FileName()
                objExcelFile.excelFileName = resultFileName
                tmpDS = objExcelFile.readResultFile()
                'Do some check
                dt = tmpDS.Tables(0)
                If dt.Rows(0).ItemArray.Contains("MatNo") Or dt.Rows(0).ItemArray.Contains("Mat No") Then
                    For j = 0 To dt.Columns.Count - 1
                        If IsDBNull(dt.Rows(0).Item(j)) Then
                            Try
                                dt.Columns.Remove(dt.Columns(j).ColumnName)
                            Catch ex As Exception

                            End Try
                        ElseIf dt.Rows(0).Item(j) = "Mat No" Then
                            dt.Columns(j).ColumnName = "matno"
                        ElseIf dt.Rows(0).Item(j) = "Fees Status" Then
                            dt.Columns(j).ColumnName = "Fees_Status"
                        ElseIf dt.Rows(0).Item(j) = "Other Names" Then
                            dt.Columns(j).ColumnName = "Other_Names"

                        Else
                            dt.Columns(j).ColumnName = dt.Rows(0).Item(j).ToString
                        End If
                    Next
                    dt.Rows(0).Delete()
                    dt.AcceptChanges()
                Else
                    MsgBox("On first check, the file you selected Is Not In the FERMA format" & vbCrLf & "Some tips copy content only (not entire sheet) to a new workbook and save")
                End If

                'FERMA fields as at 2021
                'MatNo	Surname	Other_Names	Department	Level	Year	Mode	Sex	txtImageName	CourseCode_1	CourseCode_2	Fees_Status	Pix	txtImageName1

                dt.AcceptChanges()
                dgvImportCourses.DataSource = dt.DefaultView



                dgvImportCourses.Tag = "FERMA"
                dgvImportCourses.BringToFront()


                If MsgBox("Do you want To save the imported Registration data into the database (cannot be undone)." &
                          vbCrLf & "You can also do it later by clicking the Save Imported button" &
                          vbCrLf & "Tip: Select the correct session, and department for the students. Yo have to manually update mode of entry after import", MsgBoxStyle.YesNo) = vbYes Then
                    ButtonSaveReg.PerformClick()
                End If
            End If
        Catch ex As Exception
            logError(ex.ToString)
            MsgBox("Something went wrong!" & vbCrLf & ex.ToString)
        End Try

    End Sub
    Private Sub ComboBoxDepartments_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxDepartments.SelectedIndexChanged
        Try
            'Dim dtTemp As DataTable
            If dictDepts.Count > 0 Then
                TextBoxstudent_dept_idr.Text = dictDepts.Keys(ComboBoxDepartments.SelectedIndex).ToString
                TextBoxdept_idr.Text = dictDepts.Keys(ComboBoxDepartments.SelectedIndex).ToString
                'filter rg
                'fillRegGridUsingdataAdapter(ComboBoxSessions.SelectedItem, CInt(TextBoxdept_idr.Text), CInt(ComboBoxLevel.SelectedItem))
                BindingSourceStudents.Filter = "dept_idr=" & CInt(TextBoxdept_idr.Text)
            Else
                TextBoxstudent_dept_idr.Text = "99"
                TextBoxstudent_dept_idr.Text = "99"
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub bgwLoad_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgwLoad.DoWork
        Select Case e.Argument
            Case 1
                mappDB.getDeptSessionsIntoDictionaries()
                GetData()

            Case Else
                mappDB.getDeptSessionsIntoDictionaries()
                GetData()

        End Select
    End Sub

    Private Sub bgwLoad_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwLoad.RunWorkerCompleted
        'for dictonaries
        ComboBoxDepartments.Items.Clear()
        For Each key In dictDepts.Keys
            ComboBoxDepartments.Items.Add(dictDepts(key))
        Next
        If ComboBoxDepartments.Items.Count > 0 Then ComboBoxDepartments.SelectedIndex = 0
        TextBoxstudent_dept_idr.Text = dictDepts.Keys(0).ToString
        ComboBoxSessions.Items.Clear()
        For Each key In dictSessions.Keys
            ComboBoxSessions.Items.Add(dictSessions(key))
        Next

        If ComboBoxSessions.Items.Count > 0 Then ComboBoxSessions.SelectedIndex = 0
        ComboBoxCourseCode.Items.Clear()
        CheckedListBoxCourses.Items.Clear()
        For Each key In dictAllCourses.Keys
            ComboBoxCourseCode.Items.Add(dictAllCourses(key))
            CheckedListBoxCourses.Items.Add(dictAllCourses(key))
        Next
        ComboBoxCourseCode.SelectedIndex = 0

        dgvStudents.DataSource = glbBND
        If dgvStudents.Rows.Count > 0 Then
            resizeDatagrids("students")
        End If

        TimerBS.Stop()
        btnReset.Enabled = True
        Me.ProgressBarBS.Value = 100
    End Sub

    Private Sub ButtonSaveReg_Click(sender As Object, e As EventArgs) Handles ButtonSaveReg.Click
        'save to db 
        If dgvImportCourses.Tag = "RTPS" Then
            MsgBox("Registration data will now be inserted into database")
            'importRegUsingdataAdapter() 'METHOD 1: issues
            TextBoxImport.Text = mappDB.manualRegInsertDB(dgvImportCourses.DataSource.totable)         'METHOD 2
            'status
            If TextBoxImport.Text.Length > 5 Then
                TextBoxImport.Visible = True
                logError(TextBoxImport.Text.Length)
            Else
                TextBoxImport.Visible = False
                dgvImportCourses.SendToBack()
                MsgBox("Saved successfully")
            End If



        Else    'FERMA
            MsgBox("A lot has to be done to convert from this format to the required format for Registration")
            If checkRegTransformFromFERMA_To_RTPS() = False Then
                dgvImportCourses.SendToBack()
                MsgBox("Could Not convert format")
                Exit Sub
            End If
            'importReg() 'import reg manually

            If Not mappDB.bulkInsertDBUsingDataAdapter(dgvImportCourses.DataSource.totable, "Reg") Is Nothing Then  'mthd2
                CaptureCourses()
                dgvImportCourses.SendToBack()
                MsgBox("Saved successfully using generic insert method")
            ElseIf importRegUsingdataAdapter() Then 'mthd1
                CaptureCourses()
                dgvImportCourses.SendToBack()
                MsgBox("Saved successfully")
            Else

                MsgBox("Could Not Save")
            End If

        End If
    End Sub
    Function checkRegTransformFromFERMA_To_RTPS() As Boolean     'not required
        Dim tmpDV As DataView
        Dim tmpDT As DataTable
        Dim snRow As Integer = 0
        Dim emptyRow As Integer = 0
        Dim emptyRowFound As Boolean = False
        Dim rowCount As Integer = 0
        Dim colCount As Integer = 0
        Dim lstCols As New List(Of Integer)
        Dim listcolNames As New List(Of String)
        Try
            tmpDV = Me.dgvImportCourses.DataSource 'TODO: causes error if dirty
            tmpDT = tmpDV.ToTable()
            'FERMA fields as at 2021
            'MatNo	Surname	Other_Names	Department	Level	Year	Mode	Sex	txtImageName	CourseCode_1	CourseCode_2	Fees_Status	Pix	txtImageName1
            'RTPS Format
            'matno   student_firstname	student_surname	student_othernames	student_dept_idr	status	year_of_entry	session_idr_of_entry	mode_of_entry	dob	phone	email	gender	session_idr	CourseCode_1	CourseCode_2	Fees_Status	level	dept_idr
            Dim dtCorrectFormat As DataTable
            Dim dRow As DataRow
            Dim dDeprID As Integer = 1
            'Dim dv As DataView
            dtCorrectFormat = mappDB.GetDataWhere("SELECT * FROM Reg WHERE matno=''").Tables(0)
            If dtCorrectFormat.Rows.Count > 0 Then dtCorrectFormat.Rows.Clear()  'we dont need the rows
            dtCorrectFormat.AcceptChanges()

            For i = 0 To tmpDT.Rows.Count - 1    'for each row in data table that has the records we want
                dRow = dtCorrectFormat.Rows.Add
                For j = 0 To dtCorrectFormat.Columns.Count - 1 'for each col of datatable that has the structure(format) we want
                    'If tmpDT.Columns(j).ColumnName.Contains("matno") Then
                    'End If
                    dRow.Item("matno") = tmpDT.Rows(i).Item("matno")
                    dRow.Item("student_firstname") = tmpDT.Rows(i).Item("Other_Names")
                    dRow.Item("student_surname") = tmpDT.Rows(i).Item("Surname")
                    dRow.Item("student_othernames") = ""
                    dDeprID = mappDB.getDeptID(tmpDT.Rows(i).Item("Department").ToString.ToUpper)
                    'check if it as a fluke
                    If mappDB.getDeptName(dDeprID) = tmpDT.Rows(i).Item("Department").ToString.ToUpper Then
                        'all good, not a fluke
                    Else
                        'use default
                        dDeprID = mappDB.getDeptID(ComboBoxDepartments.SelectedIndex)
                    End If
                    dRow.Item("student_dept_idr") = dDeprID.ToString
                    dRow.Item("status") = CATEGORY_DESCRIPTION_SUCCESSFUL   ' "SUCCESSFUL"
                    dRow.Item("year_of_entry") = Now.Year       'todo fancy prompt user
                    dRow.Item("session_idr_of_entry") = getSessionOfEntry(ComboBoxSessions.SelectedItem, CInt(tmpDT.Rows(i).Item("level")), MODE_OF_ENTRY_UME)
                    dRow.Item("year_of_entry") = dRow.Item("session_idr_of_entry").ToString.Substring(0, 4)       'todo fancy prompt user

                    'ComboBoxSessions.SelectedItem
                    dRow.Item("mode_of_entry") = MODE_OF_ENTRY_UME
                    dRow.Item("dob") = Now.ToShortDateString
                    dRow.Item("phone") = "080"
                    'MatNo	Surname	Other_Names	Department	Level	Year	Mode	Sex	txtImageName	CourseCode_1	CourseCode_2	Fees_Status	Pix	txtImageName1
                    dRow.Item("email") = "Nil"
                    dRow.Item("gender") = tmpDT.Rows(i).Item("Sex") ' "male"
                    dRow.Item("session_idr") = ComboBoxSessions.SelectedItem

                    dRow.Item("CourseCode_1") = tmpDT.Rows(i).Item("CourseCode_1")
                    dRow.Item("CourseCode_2") = tmpDT.Rows(i).Item("CourseCode_2")
                    dRow.Item("Fees_Status") = "True"
                    dRow.Item("level") = tmpDT.Rows(i).Item("level")
                    dRow.Item("dept_idr") = dDeprID

                Next
                dtCorrectFormat.AcceptChanges()
            Next
            dtCorrectFormat.AcceptChanges()
            dgvImportCourses.DataSource = Nothing
            dgvImportCourses.Columns.Clear()
            dgvImportCourses.Refresh()
            dgvImportCourses.DataSource = dtCorrectFormat.DefaultView
            dgvImportCourses.Refresh()
            Return True
        Catch ex As Exception
            MessageBox.Show("Result is not in the correct format, please correct ant try again")
            logError(ex.ToString)
            Return False
        End Try
    End Function
    Function importRegFromFERMAUsingAccess(AccessFileName As String) As DataTable
        Dim dt As New DataTable
        Try

            Using xConn As New OleDb.OleDbConnection(ModuleGeneral.STR_AccessFileConnectionString)
                xConn.ConnectionString = mappDB.getCorrectConnectionstringFromAccessFile(AccessFileName)
                xConn.Open()
                dt = mappDB.GetDataWhere("SELECT * FROM SPD").Tables(0)
                Return dt
            End Using

        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function exportRegToFERMA(Optional internal As Boolean = True, Optional AccessFileName As String = "") As Boolean
        Try
            'Algorithm: 
            'Check database if result already exist to avoid duplicates
            'Write into Database;    'Get dataset from displayed datagrid;             'parse dataset record by record  'insert record by record
            Dim dt As New DataTable
            Dim dv As New DataView
            dgvImportCourses.EndEdit()
            dgvImportCourses.Update()
            If Not (IsDBNull(dgvImportCourses.DataSource) Or (dgvImportCourses.Rows.Count = 0)) Then
                If TypeOf (dgvImportCourses.DataSource) Is DataTable Then
                    ' dgvImportCourses.DataSource.AcceptChanges 'TODO: dataTable or dataView? lazy loading issues
                    dt = dgvImportCourses.DataSource 'causes error if dirty
                ElseIf TypeOf (dgvImportCourses.DataSource) Is DataView Then
                    dv = dgvImportCourses.DataSource
                    dt = dv.ToTable
                End If
                mappDB.bulkInsertFERMAUsingDataAdapter(dt, "SPD", AccessFileName)
            Else
                MsgBox("Empty Registration Records")
                Return False
                Exit Function
            End If


            '#method 1 manual Insert or bulkInsert
            If internal = True Then
                mappDB.manualRegExportToEmbeddedAccessSPD(dt)
            Else
                mappDB.manualRegExportToExternalAccess(dt, AccessFileName)
            End If


            MsgBox("Reg Uploaded into Database Successfully! Cross check what was uploaded below")

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

    End Function
    Private Sub dgvStudents_Click(sender As Object, e As EventArgs) Handles dgvStudents.Click

    End Sub







    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
        'TODO: create a user control for these combo box. it should have events that are aware o dictionary storing sessions, new session added, auto load, auto update etc
        Try
            TextBoxsession_idr.Text = ComboBoxSessions.SelectedItem.ToString

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ButtonRegToExcel_Click(sender As Object, e As EventArgs) Handles ButtonRegToExcel.Click
        Dim retFileName As String
        retFileName = objExcelFile.exportRegToExcelFile_NPOI(dgvStudents.DataSource, My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\ExportedStudents" & ComboBoxLevel.Text & ".xlsx")
        MsgBox("File exported to: " & retFileName)
    End Sub

    Private Sub ButtonAccess_Click(sender As Object, e As EventArgs) Handles ButtonAccess.Click
        Dim FileOpenDialogBroadsheet As New OpenFileDialog()
        Dim resultFileName As String = ""

        If Not FileOpenDialogBroadsheet.ShowDialog = DialogResult.Cancel Then
            resultFileName = FileOpenDialogBroadsheet.FileName()
            If exportRegToFERMA(False, resultFileName) Then
                MsgBox("Exported to FERMA")
            Else
                MsgBox("Something went wrong, note that FERMA is an Access-based db used in University of Benin")
            End If
        Else
            MsgBox("The export will be done and save internally, You can export to excel afterwards")
            If exportRegToFERMA() Then
                MsgBox("Saved in database (FERMA Format. Yo can export to Excel later)")
            Else
                MsgBox("Something went wrong, note that FERMA is an Access-based db used in University of Benin")
            End If
        End If


    End Sub

    Private Sub ButtonImportRegRTPS_Click(sender As Object, e As EventArgs) Handles ButtonImportRegRTPS.Click
        Dim FileOpenDialogBroadsheet As New OpenFileDialog()
        Dim resultFileName As String = ""
        Dim tmpDS As New DataSet
        Dim dt As DataTable
        If Not FileOpenDialogBroadsheet.ShowDialog = DialogResult.Cancel Then
            resultFileName = FileOpenDialogBroadsheet.FileName()
            objExcelFile.excelFileName = resultFileName
            tmpDS = objExcelFile.readResultFile()
            'Do some check
            dt = tmpDS.Tables(0)
            If dt.Rows(0).Item(0).ToString.ToUpper = "MATNO" Then 'can cause error: Object reference not set to an instance of an object.
                For j = 0 To dt.Columns.Count - 1
                    dt.Columns(j).ColumnName = dt.Rows(0).Item(j).ToString
                Next
                dt.Rows(0).Delete()
                dgvImportCourses.DataSource = dt.DefaultView
                dgvImportCourses.Tag = "RTPS"
                'checkReg()  'todo no need for this insist on rigt format
                dgvImportCourses.BringToFront()
            Else
                MsgBox("The file you selected is not in the proper format. Download and use the correct template")
            End If

        End If

        If MsgBox("Do you want to save the imported Registration data into the database (cannot be undone)." & vbCrLf & "You can also do it later by clicking the Save Imported button", MsgBoxStyle.YesNo) = vbYes Then
            ButtonSaveReg.PerformClick()
        End If
    End Sub

    Private Sub ComboBoxCourseCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCourseCode.SelectedIndexChanged
        If Not ComboBoxCourseCode.SelectedItem = Nothing Then TextBoxCourseCode.Text = ComboBoxCourseCode.SelectedItem.ToString

    End Sub

    Private Sub ComboBoxSessions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxSessions.SelectedIndexChanged
        If Not ComboBoxSessions.SelectedItem = Nothing Then TextBoxsession_idr.Text = ComboBoxSessions.SelectedItem.ToString

    End Sub


    Private Sub ComboBoxLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLevel.SelectedIndexChanged
        'TODO: ComboBoxCourseCode.filter(level)
        If Not ComboBoxLevel.SelectedItem = Nothing Then TextBoxlevel.Text = ComboBoxLevel.SelectedItem.ToString

    End Sub

    Private Sub ButtonOKReg_Click(sender As Object, e As EventArgs) Handles ButtonOKReg.Click
        Dim strReg1 As String = ""
        Dim strReg2 As String = ""
        'Dim col As Collection
        'col = CheckedListBoxCourses.CheckedItems
        For Each col In CheckedListBoxCourses.CheckedItems
            If dictAllCourseCodeKeyAndCourseSemesterVal.ContainsKey(col) Then
                If dictAllCourseCodeKeyAndCourseSemesterVal(col) = 1 Then
                    If strReg1 = "" Then
                        strReg1 = col
                    Else
                        strReg1 = strReg1 & ";" & col
                    End If
                Else
                    If strReg2 = "" Then
                        strReg2 = col
                    Else
                        strReg2 = strReg2 & ";" & col
                    End If
                End If
            End If
        Next
        'TODO Sessions

        If MsgBox("Are the courses corectly displayed" & vbCrLf & strReg1 & vbCrLf & vbCrLf & strReg2, MsgBoxStyle.YesNo) = vbYes Then
            PanelCourses.Visible = False
            TextBoxCourseCode_1.Text = strReg1
            TextBoxCourseCode_2.Text = strReg2
        End If
    End Sub



    Private Sub ButtonCancelReg_Click(sender As Object, e As EventArgs) Handles ButtonCancelReg.Click
        PanelCourses.Visible = False

        For Each itm In CheckedListBoxCourses.CheckedIndices
            CheckedListBoxCourses.SetItemCheckState(itm, False)
        Next
    End Sub

    Private Sub ButtonShowAllReg_Click(sender As Object, e As EventArgs)

        If PanelAllReg.Visible = False Then
            DataGridViewAlReg.DataSource = mappDB.GetDataWhere(STR_SQL_ALL_REG).Tables(0).DefaultView
            Debug.Print(STR_SQL_ALL_REG)
            PanelAllReg.BringToFront()
            PanelAllReg.Visible = True
        Else
            PanelAllReg.SendToBack()
            PanelAllReg.Visible = False
        End If

    End Sub

    Private Sub ButtonDownloadTemplate_Click(sender As Object, e As EventArgs) Handles ButtonDownloadTemplate.Click
        Try

            'objResult.resultTemplateFileName
            Using svDia As New SaveFileDialog
                'filter=Excel Files|*.xltx
                If svDia.ShowDialog = DialogResult.OK Then
                    My.Computer.FileSystem.CopyFile(My.Application.Info.DirectoryPath & "\templates\registration.xltx", svDia.FileName & ".xltx")
                End If
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvStudents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellContentClick
        On Error Resume Next
        If e.RowIndex >= 0 Then
            captureReg(e.RowIndex)
        End If
    End Sub


    Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefreshFormview.Click

        bindcontrolsToReg()
    End Sub
    Sub bindcontrolsToReg()
        fillRegFORMUsingdataAdapter()
        'OR
        'dsStudents = mappDB.GetDataWhere("SELECT * FROM Reg")
        'glbAdapterFORM.Fill(dsStudents.Tables(0))
        'glbAdapterFORM = New OleDb.OleDbDataAdapter("SELECT * FROM Reg", glbRegConn)
        'glbAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey


        BindingSourceStudents.DataSource = dsStudents.Tables(0)
        BindingNavigator1.BindingSource = BindingSourceStudents

        If TextBoxMATNO.DataBindings.Count = 0 Then
            TextBoxMATNO.DataBindings.Add("Text", BindingSourceStudents, "matno")
            TextBoxstudent_surname.DataBindings.Add("Text", BindingSourceStudents, "student_surname")
            TextBoxstudent_firstname.DataBindings.Add("Text", BindingSourceStudents, "student_firstname")
            TextBoxstudent_othernames.DataBindings.Add("Text", BindingSourceStudents, "student_othernames")
            TextBoxstudent_dept_idr.DataBindings.Add("Text", BindingSourceStudents, "student_dept_idr")
            TextBoxstatus.DataBindings.Add("Text", BindingSourceStudents, "status")
            TextBoxyear_of_entry.DataBindings.Add("Text", BindingSourceStudents, "year_of_entry")
            TextBoxsession_idr_of_entry.DataBindings.Add("Text", BindingSourceStudents, "session_idr_of_entry")
            TextBoxmode_of_entry.DataBindings.Add("Text", BindingSourceStudents, "mode_of_entry")
            TextBoxdob.DataBindings.Add("Text", BindingSourceStudents, "dob")
            TextBoxphone.DataBindings.Add("Text", BindingSourceStudents, "phone")
            TextBoxemail.DataBindings.Add("Text", BindingSourceStudents, "email")
            TextBoxgender.DataBindings.Add("Text", BindingSourceStudents, "gender")
            TextBoxsession_idr.DataBindings.Add("Text", BindingSourceStudents, "session_idr")
            TextBoxCourseCode_1.DataBindings.Add("Text", BindingSourceStudents, "CourseCode_1")
            TextBoxCourseCode_2.DataBindings.Add("Text", BindingSourceStudents, "CourseCode_2")
            TextBoxNA_CourseCode.DataBindings.Add("Text", BindingSourceStudents, "NA_CourseCode")


            TextBoxFees_Status.DataBindings.Add("Text", BindingSourceStudents, "Fees_Status")
            TextBoxlevel.DataBindings.Add("Text", BindingSourceStudents, "level")
            TextBoxdept_idr.DataBindings.Add("Text", BindingSourceStudents, "dept_idr")

        End If
    End Sub
    Private Function UpdateDBromBindinsourcesingDataAdapter(dt As DataTable) As Boolean
        Try
            Using xConn As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString)
                xConn.ConnectionString = mappDB.getCorrectConnectionstring()
                xConn.Open()

                'Insert, update And delete queries
                Dim updateQuery As String = STR_SQL_UPDATESTUDENTS_WITH_PARAMS ' "UPDATE Reg SET student_firstname=@first,student_othernames=@middle,student_surname=@last WHERE matno=@matno"
                Dim deleteQuery As String = STR_SQL_DELETE_STUDENTS_WITH_PARAMS '"DELETE FROM Reg WHERE matno=@matno"
                Dim insertQuery As String = STR_SQL_INSERT_STUDENTS_WITH_PARAMS ' "INSERT INTO Reg (`student_firstname`, `student_othernames`, `student_surname`, matno) VALUES(@first,@middle,@last,@matno)"

                'Create the parameters for the queries above
                'Call getInsertParamsRegForm()          'Dim insertParams As New OleDb.OleDbParameter()

                Dim DeleteParams As New OleDb.OleDbParameter("@matno", OleDb.OleDbType.Integer, 100, "matno")

                ' Create the SqlCommand objects that will be used by the DataAdapter to modify the source table
                Dim insertComm As New OleDb.OleDbCommand(insertQuery, xConn)
                Dim updateComm As New OleDb.OleDbCommand(updateQuery, xConn)
                Dim deleteComm As New OleDb.OleDbCommand(deleteQuery, xConn)

                ' Associate the parameters with the proper SqlCommand object
                insertComm.Parameters.AddRange(getInsertParamsRegForm.ToArray)
                updateComm.Parameters.AddRange(getUpdateParamsRegForm.ToArray)
                deleteComm.Parameters.Add(DeleteParams)

                'Give the DataAdapter the commands it needs to be able to properly update your database table
                Dim dataAdapter As New OleDb.OleDbDataAdapter() '(insertComm, updateComm, deleteComm)
                dataAdapter.InsertCommand = insertComm
                dataAdapter.UpdateCommand = updateComm
                dataAdapter.DeleteCommand = deleteComm
                '// Calling the Update method executes the proper command based on the modifications to the specified
                '// DataTable object then commits these changes to the database
                dataAdapter.Update(dt)
                xConn.Close()
            End Using
            Return True
        Catch ex As Exception
            MsgBox("Could not save records. Probably othing else to save" & vbCrLf & ex.Message)
            Return False
        End Try
    End Function
    Public Sub InsertOrUpdateUsingDataAdapter(dMATno As String, insert As Boolean)
        Try
            Using xConn As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString)
                xConn.ConnectionString = mappDB.getCorrectConnectionstring()
                xConn.Open()

                Dim myDataSet As DataSet = New DataSet
                Dim dStrSQL As String = "SELECT matno, session_idr, CourseCode_1, CourseCode_2 FROM Reg"
                Dim dStrSQLUpdate As String = "UPDATE Reg SET matno='ENG50', CourseCode_1='GST112', CourseCode_2='GST122' WHERE matno = '" & dMATno & "'"


                dStrSQL = "SELECT matno, session_idr, CourseCode_1, CourseCode_2 FROM Reg"
                dStrSQLUpdate = "UPDATE Reg SET matno='ENG50', CourseCode_1='GST112', CourseCode_2='GST122' WHERE matno = '" & dMATno & "'"

                Dim cmdLocal As New OleDb.OleDbCommand(dStrSQL, xConn)
                Dim myAdapterInsert As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(dStrSQL, xConn)
                Dim myAdapterUpdate As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(dStrSQLUpdate, xConn)


                If insert Then
                    myAdapterInsert.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    myAdapterInsert.Fill(myDataSet, "Table")
                Else
                    myAdapterUpdate.MissingSchemaAction = MissingSchemaAction.AddWithKey
                    myAdapterUpdate.UpdateCommand = New OleDb.OleDbCommand(dStrSQLUpdate, xConn)
                    myAdapterUpdate.UpdateCommand.Parameters.Add("dMATNO", OleDb.OleDbType.VarChar, 50, "matno")
                    myAdapterUpdate.Update(myDataSet, "Table")
                End If

                xConn.Close()
            End Using
        Catch ex As Exception
            Throw New Exception("Database access problem, connect and try again" & vbCrLf & ex.Message)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Sub InsertUsingDataAdapter(dMATno As String)
        Try
            Using xConn As New OleDb.OleDbConnection(ModuleGeneral.STR_connectionString)
                xConn.ConnectionString = mappDB.getCorrectConnectionstring()
                xConn.Open()

                Dim dStrSQL As String = "SELECT matno, session_idr, CourseCode_1, CourseCode_2 FROM Reg"
                Dim dStrSQLInsert As String = "INSERT INTO Reg ( matno, session_idr, CourseCode_1, CourseCode_2) VALUES (:dMATNO, '2018/2019', 'MEE211', 'MEE211' )"
                Dim dStrSQLUpdate As String = "UPDATE Reg SET matno='ENG50', CourseCode_1='GST112', CourseCode_2='GST122' WHERE matno = '" & dMATno & "'"

                Dim cmdLocal As New OleDb.OleDbCommand(dStrSQL, xConn)
                Dim myAdapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(dStrSQL, xConn)
                myAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey
                Dim myDataSet As DataSet = New DataSet
                myAdapter.Fill(myDataSet, "Reg")
                Dim rowVals(0 To 3) As Object
                rowVals(0) = dMATno
                rowVals(1) = "2018/2019"
                rowVals(2) = "GST111"   'kole werk bcos query overides
                rowVals(3) = "GST111"
                myDataSet.Tables("Reg").Rows.Add(rowVals)
                myAdapter.InsertCommand = New OleDb.OleDbCommand(dStrSQLInsert, xConn)
                myAdapter.InsertCommand.Parameters.Add("dMATNO", OleDb.OleDbType.VarChar, 50, "matno")

                myAdapter.UpdateCommand = New OleDb.OleDbCommand(dStrSQLUpdate, xConn)
                myAdapter.UpdateCommand.Parameters.Add("dMATNO", OleDb.OleDbType.VarChar, 50, "matno")


                myAdapter.Update(myDataSet, "Reg")
                Dim myTable As DataTable
                Dim myRow As DataRow
                Dim myColumn As DataColumn
                ' Get all data from all tables within the dataset
                For Each myTable In myDataSet.Tables
                    For Each myRow In myTable.Rows
                        For Each myColumn In myTable.Columns
                            Debug.Print(myRow(myColumn) & Chr(9))
                        Next myColumn
                        Debug.Print("")
                    Next myRow
                    Debug.Print("-")
                Next myTable

                xConn.Close()

            End Using
        Catch ex As Exception
            Throw New Exception("Database access problem, connect and try again" & vbCrLf & ex.Message)
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click
        BindingSourceStudents.MoveNext()

    End Sub

    Private Sub ButtonFormView_Click(sender As Object, e As EventArgs) Handles ButtonFormView.Click
        If PanelForm.Visible = False Then
            PanelForm.Visible = True
            PanelForm.Top = 51
            dgvStudents.ReadOnly = True
            dgvStudents.Visible = False
            ButtonFormView.Text = "Grid View"
            Me.ButtonRefreshFormview.PerformClick()
            TextBoxFancyDisplayCourse1.Visible = False
            TextBoxFancyDisplayCourse2.Visible = False
        Else

            PanelForm.Visible = False
            dgvStudents.ReadOnly = False '

            dgvStudents.Visible = True

            ButtonFormView.Text = "Form View"
            TextBoxFancyDisplayCourse1.Visible = True
            TextBoxFancyDisplayCourse2.Visible = True
        End If
    End Sub

    Private Sub ButtonClosePanelForm_Click(sender As Object, e As EventArgs) Handles ButtonClosePanelForm.Click
        ButtonFormView.PerformClick()
    End Sub


    Private Sub TextBoxCourse_1_Click(sender As Object, e As EventArgs) Handles TextBoxCourseCode_1.Click
        showCoursesList()
    End Sub

    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles BindingSourceStudents.CurrentChanged
        'first save changes to studens 
        'dsStudents.Tables(0).update?   'todo
        Try
            For Each itm In ComboBoxEntryMode.Items
                If itm.ToString.Contains(TextBoxmode_of_entry.Text) Then
                    ComboBoxEntryMode.SelectedItem = itm
                End If
            Next
            For Each itm In ComboBoxStatus.Items
                If itm.ToString.Contains(TextBoxstatus.Text) Then
                    ComboBoxStatus.SelectedItem = itm
                End If
            Next
            For Each itm In ComboBoxGender.Items
                If itm.ToString.Contains(TextBoxgender.Text) Then
                    ComboBoxGender.SelectedItem = itm
                End If
            Next
            'CaptureCourses() moved to textbox changed event
            CapturePicture(TextBoxMATNO.Text)
            BindingSourceStudents.EndEdit()
        Catch ex As Exception
            logError(ex.ToString)
        End Try
    End Sub
    Sub CapturePicture(dMATNO As String)
        Try


            Dim TMPileNAME As String = Application.StartupPath & "\photos\" & dMATNO & ".jpg"
            Dim TMP_PIC_FILE_NAME2 As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\photos\" & dMATNO & ".jpg"
            Dim tmpileName3 As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData & "\photos\" & dMATNO & ".jpg"
            Dim TMPileNAME4 As String = Application.StartupPath & "\photos\photo_female.jpg"




            If My.Computer.FileSystem.FileExists(TMPileNAME) Then
                PictureBox1.Image = Image.FromFile(TMPileNAME)
            ElseIf My.Computer.FileSystem.FileExists(TMP_PIC_FILE_NAME2) Then
                PictureBox1.Image = Image.FromFile(TMP_PIC_FILE_NAME2)
            ElseIf My.Computer.FileSystem.FileExists(tmpileName3) Then
                PictureBox1.Image = Image.FromFile(tmpileName3)
            Else
                PictureBox1.Image = Image.FromFile(TMPileNAME4)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonSaveRecord_Click(sender As Object, e As EventArgs) Handles ButtonSaveRecord.Click
        Dim retFrFxn As Boolean = False
        Try
            'updateRegFORMUsingdataAdapter()        not a workable options due to textbox bindings and params
            'always update  table on save

            'retFrFxn = UpdateDBromBindinsourcesingDataAdapter(BindingSourceStudents.DataSource)'didnt work
            If retFrFxn Then
                'MsgBox("Saved Successfully")
                'ATTEMPT save again
            ElseIf Not mappDB.bulkInsertDBUsingDataAdapter(BindingSourceStudents.DataSource, "Reg") Is Nothing Then 'worked provided datagridview does not interfere and connection is open
                MsgBox("Saved Successfully using bulk insert mode")
            Else
                MsgBox("Could not save the records ")
            End If

        Catch ex As Exception
            MsgBox("Could not save the records " & vbCrLf & ex.Message)
        End Try

    End Sub

    Private Sub ComboBoxShortCuts2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxShortCuts2.SelectedIndexChanged
        '        Add All 100L Courses
        'Add All 200L Courses
        'Add All 300L Courses
        'Add All 400L Courses
        'Add All 500L Courses
        'Add All Departmetal Courses
        'Add All Faculty Courses
        If CheckedListBoxCourses.Items.Count < 1 Then
            If dictAllCourseCodeKeyAndCourseUnitVal.Count = 0 Then mappDB.getAllCourses()
            CheckedListBoxCourses.Items.Clear()
            For Each key In dictAllCourseCodeKeyAndCourseUnitVal.Keys
                CheckedListBoxCourses.Items.Add(key)
            Next
        End If



    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorAddNewItem.Click
        BindingSourceStudents.AddNew()
        'todo: insert
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton1.Click
        Me.Validate()
        Me.BindingSourceStudents.EndEdit()
        'Me.tableadaptermanager.updateall()
    End Sub

    Private Sub BindingSourcereg_CurrentChanged(sender As Object, e As EventArgs)
        'todo

    End Sub

    Private Sub ButtonMovePrevious_Click(sender As Object, e As EventArgs) Handles ButtonMovePrevious.Click
        BindingSourceStudents.MovePrevious()
    End Sub

    Private Sub ComboBoxShortCuts1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxShortCuts1.SelectedIndexChanged
        'Todo: improe code remove multipe exit sub
        Dim dLevel, dSession, dDeptID As String
        dLevel = "100"
        Select Case ComboBoxShortCuts1.SelectedItem
            Case "Add All 100L Courses"
                dLevel = "100"
            Case "Add All 200L Courses"
                dLevel = "200"
            Case "Add All 300L Courses"
                dLevel = "300"
            Case "Add All 400L Courses"
                dLevel = "400"
            Case "Add All 500L Courses"
                dLevel = "500"
            Case "Add All Departmetal Courses"
                MsgBox("Haba! fear God now :)")
                For i = 0 To CheckedListBoxCourses.Items.Count - 1
                    If dictAllCourseCodeKeyAndCourseLevelVal.ContainsKey(CheckedListBoxCourses.Items(i).ToString) Then
                        If dictAllCourseCodeKeyAndCourseLevelVal(CheckedListBoxCourses.Items(i).ToString) = 100 Then CheckedListBoxCourses.SetItemChecked(i, True)
                    End If
                Next
                ButtonOKReg.PerformClick()
                Exit Sub
            Case "Add All Faculty Courses"
                MsgBox("Haba! fear God now")
                For i = 0 To CheckedListBoxCourses.Items.Count - 1
                    If dictAllCourseCodeKeyAndCourseLevelVal.ContainsKey(CheckedListBoxCourses.Items(i).ToString) Then
                        If dictAllCourseCodeKeyAndCourseLevelVal(CheckedListBoxCourses.Items(i).ToString) = 100 Then CheckedListBoxCourses.SetItemChecked(i, True)
                    End If
                Next
                ButtonOKReg.PerformClick()
                Exit Sub
            Case "Clear all/Unregister All"
                TextBoxCourseCode_1.Text = ""
                TextBoxCourseCode_2.Text = ""
                Exit Sub
        End Select

        session_idr = ComboBoxSessions.SelectedItem
        course_dept_idr = mappDB.getDeptID(ComboBoxDepartments.SelectedItem.ToString)


        'If dictCoursesOrderFS.Count = 0 Then
        If mappDB.getCoursesOrderIntoDictionaries(session_idr, course_dept_idr, dLevel) = False Then
            MsgBox("Cannot load authorized course list for this session and level")
            Exit Sub
        End If
        'End If

        If dictCoursesOrderFS.Count > 0 Then
            For Each cVal In dictCoursesOrderFS.Values
                If TextBoxCourseCode_1.Text = "" Then
                    TextBoxCourseCode_1.Text = cVal
                Else
                    TextBoxCourseCode_1.Text = TextBoxCourseCode_1.Text & ";" & cVal
                End If
            Next
        End If
        If dictCoursesOrderFS.Count > 0 Then
            For Each cVal In dictCoursesOrderSS.Values
                If TextBoxCourseCode_2.Text = "" Then
                    TextBoxCourseCode_2.Text = cVal
                Else
                    TextBoxCourseCode_2.Text = TextBoxCourseCode_2.Text & ";" & cVal
                End If
            Next
        End If


    End Sub

    Private Sub ButtonSaveGrid_Click(sender As Object, e As EventArgs) Handles ButtonSaveGrid.Click
        If updateRegGridUsingdataAdapter() Then
            MsgBox("Saved Successfully")
        Else
            MsgBox("Changes could not be saved. Please check the input and try again")
        End If

    End Sub



    Private Sub ComboBoxStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxStatus.SelectedIndexChanged
        TextBoxstatus.Text = ComboBoxStatus.SelectedItem
    End Sub

    Private Sub TextBoxmode_of_entry_TextChanged(sender As Object, e As EventArgs) Handles TextBoxmode_of_entry.TextChanged

    End Sub

    Private Sub ComboBoxGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxGender.SelectedIndexChanged
        TextBoxgender.Text = ComboBoxGender.SelectedItem
    End Sub

    Private Sub TextBoxCourseCode_1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCourseCode_1.TextChanged
        CaptureCourses()
    End Sub

    Private Sub TextBoxCourseCode_2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCourseCode_2.TextChanged
        CaptureCourses()
    End Sub

    Private Sub ButtonImportRegFERMAAccess_Click(sender As Object, e As EventArgs) Handles ButtonImportRegFERMAAccess.Click
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "Access Files|*.accdb|Older version Access Files|*.mdb"
        Try
            If dlg.ShowDialog = DialogResult.OK Then
                dgvImportCourses.DataSource = importRegFromFERMAUsingAccess(dlg.FileName).DefaultView
                dgvImportCourses.BringToFront()
            End If
        Catch ex As Exception
            MsgBox("An error occured" & vbCrLf & ex.ToString)
        End Try
    End Sub

    Private Sub ButtonAddNewRecordInFORM_Click(sender As Object, e As EventArgs) Handles ButtonAddNewRecordInFORM.Click
        BindingNavigatorAddNewItem.PerformClick()
    End Sub

    Private Sub ButtonFirst_Click(sender As Object, e As EventArgs) Handles ButtonFirst.Click
        BindingNavigatorMoveFirstItem.PerformClick()
    End Sub

    Private Sub ButtonLast_Click(sender As Object, e As EventArgs) Handles ButtonLast.Click
        BindingNavigatorMoveLastItem.PerformClick()
    End Sub

    Private Sub TextBoxCourse_2_Click(sender As Object, e As EventArgs) Handles TextBoxCourseCode_2.Click
        showCoursesList()
    End Sub
End Class