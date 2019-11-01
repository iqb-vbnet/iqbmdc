﻿Public Class TestMDControlsDialog
    'Public XCat As XDocument = Nothing

    Private Sub Me_Loaded() Handles Me.Loaded
        Me.AddHandler(iqb.mdc.components.LinkEditControl.DefaultFolderChangedEvent, New RoutedEventHandler(AddressOf HandleDefaultFolderChanged))
        TBInfo.Text = iqb.mdc.components.LinkEditControl.DefaultFolder
        Me.AddHandler(iqb.mdc.components.MDListControl.MDChangedEvent, New RoutedEventHandler(AddressOf MDChangedEventHandler))
        Me.MDLC.MDCatList = New List(Of String) From {"file:\\huiqb39c.user.hu-berlin.de\IQBProjekte\MDC\GitHub\mdc-test.xml"}
    End Sub

    Private Sub HandleDefaultFolderChanged()
        TBInfo.Text = iqb.mdc.components.LinkEditControl.DefaultFolder
    End Sub
    Private Sub BtnOK_Clicked(sender As Object, e As RoutedEventArgs) Handles BtnOK.Click
        Me.DialogResult = True
    End Sub

    Private Sub BtnGo_Clicked(sender As Object, e As RoutedEventArgs)
        If Not String.IsNullOrEmpty(Me.TBXML.Text) Then
            Try
                Me.MDLC.XMDList = XElement.Parse(Me.TBXML.Text)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If

        If Not String.IsNullOrEmpty(Me.TBStdXML.Text) Then
            Try
                Dim xe As XElement = XElement.Parse(Me.TBStdXML.Text)
                Me.MDLC.MDDefaultList = xe.Elements.ToList
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnDebugChange_Clicked(sender As Object, e As RoutedEventArgs)
        'Dim XMD As XElement = Me.DPX.DataContext
        'For Each xe As XElement In XMD.Elements
        '    If xe.Value = "True" Then
        '        xe.Value = "False"
        '    Else
        '        xe.Value = "True"
        '    End If
        'Next
    End Sub
    Private Sub BtnDebugView_Clicked(sender As Object, e As RoutedEventArgs)
        Dim XMD As XElement = Me.MDLC.XMDList
        Me.TBDebug.Text = XMD.ToString
    End Sub

    Private Sub MDChangedEventHandler(sender As Object, e As RoutedEventArgs)
        Debug.Print("MDChangedEvent fired")
    End Sub

End Class
