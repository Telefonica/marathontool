Public NotInheritable Class FormSplash

    Private Sub FormSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblVersion.Text = "Version " + My.Application.Info.Version.ToString
    End Sub

End Class
