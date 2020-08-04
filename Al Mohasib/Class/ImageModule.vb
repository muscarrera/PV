Imports System.Drawing.Imaging

Module ImageModule
    Public Function AppendBorder(ByVal original As Image, ByVal borderWidth As Integer) As Image
        Dim borderColor As Color = Color.WhiteSmoke
        Dim mypen As New Pen(borderColor, borderWidth * 2)
        Dim newSize As Size = New Size(original.Width + borderWidth * 2, original.Height + borderWidth * 2)

        Dim img As Bitmap = New Bitmap(newSize.Width, newSize.Height)
        Dim g As Graphics = Graphics.FromImage(img)

        'g.Clear(borderColor)   
        g.DrawImage(original, New Point(borderWidth, borderWidth))
        g.DrawRectangle(mypen, 0, 0, newSize.Width, newSize.Height)
        g.Dispose()

        Return img
    End Function

    Public Function translate(ByVal img As Image, ByVal red As Single, _
                       ByVal green As Single, ByVal blue As Single, _
                       Optional ByVal alpha As Single = 0) As Boolean


        Dim sr, sg, sb, sa As Single

        ' noramlize the color components to 1
        sr = red / 255
        sg = green / 255
        sb = blue / 255
        sa = alpha / 255

        ' create the color matrix
        Dim cm As New ColorMatrix(New Single()() _
                       {New Single() {1, 0, 0, 0, 0}, _
                        New Single() {0, 1, 0, 0, 0}, _
                        New Single() {0, 0, 1, 0, 0}, _
                        New Single() {0, 0, 0, 1, 0}, _
                        New Single() {sr, sg, sb, sa, 1}})

        '        ;Polaroid Color
        'ColorMatrix1=1.438;-0.062;-0.062;0;0
        'ColorMatrix2=-0.122;1.378;-0.122;0;0
        'ColorMatrix3=-0.016;-0.016;1.483;0;0
        'ColorMatrix5=-0.03;0.05;-0.02;0;1

        ' apply the matrix to the image
        Return draw_adjusted_image(img, cm)

    End Function


    Private Function draw_adjusted_image(ByVal img As Image, _
                    ByVal cm As ColorMatrix) As Boolean


        Try
            Dim bmp As New Bitmap(img) ' create a copy of the source image 
            Dim imgattr As New ImageAttributes()
            Dim rc As New Rectangle(0, 0, img.Width, img.Height)
            Dim g As Graphics = Graphics.FromImage(img)

            ' associate the ColorMatrix object with an ImageAttributes object
            imgattr.SetColorMatrix(cm)

            ' draw the copy of the source image back over the original image, 
            'applying the ColorMatrix
            g.DrawImage(bmp, rc, 0, 0, img.Width, img.Height, _
                        GraphicsUnit.Pixel, imgattr)

            g.Dispose()

            Return True

        Catch
            Return False
        End Try

    End Function


End Module
