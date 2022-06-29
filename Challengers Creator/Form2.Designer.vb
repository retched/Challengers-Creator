<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDialog
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
		Me.txtMain = New System.Windows.Forms.TextBox()
		Me.btnOK = New System.Windows.Forms.Button()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'txtMain
		'
		Me.txtMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtMain.Location = New System.Drawing.Point(97, 13)
		Me.txtMain.Multiline = true
		Me.txtMain.Name = "txtMain"
		Me.txtMain.ReadOnly = true
		Me.txtMain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtMain.Size = New System.Drawing.Size(691, 425)
		Me.txtMain.TabIndex = 1
		Me.txtMain.TabStop = false
		'
		'btnOK
		'
		Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
		Me.btnOK.Location = New System.Drawing.Point(13, 386)
		Me.btnOK.Name = "btnOK"
		Me.btnOK.Size = New System.Drawing.Size(78, 52)
		Me.btnOK.TabIndex = 2
		Me.btnOK.Text = "OK"
		Me.btnOK.UseVisualStyleBackColor = true
		'
		'PictureBox1
		'
		Me.PictureBox1.Image = Global.retched.challengers_create.My.Resources.Resources.help_icon
		Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(78, 77)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.PictureBox1.TabIndex = 0
		Me.PictureBox1.TabStop = false
		'
		'frmDialog
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(800, 450)
		Me.Controls.Add(Me.btnOK)
		Me.Controls.Add(Me.txtMain)
		Me.Controls.Add(Me.PictureBox1)
		Me.Name = "frmDialog"
		Me.ShowIcon = false
		Me.ShowInTaskbar = false
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "Form2"
		CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub

	Friend WithEvents PictureBox1 As PictureBox
	Friend WithEvents txtMain As TextBox
	Friend WithEvents btnOK As Button
End Class
