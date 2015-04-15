Public Class ClassFormat
    'Purpose: To format the phone number
    'Parameters: 
    'Returns: strResult - formatted phone number
    'Author: Noureen Rojani
    'Date: February 11, 2015

    Public Function FormatPhone(dblPhone As Double) As String
        Dim strResult As String

        strResult = dblPhone.ToString("(###)###-####")

        Return strResult
    End Function
End Class
