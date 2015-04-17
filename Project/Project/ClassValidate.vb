Public Class ClassValidate
    Public Function CheckForDigits(strIN As String) As Boolean
        'Purpose: validate that a string is composed entirely of digits  
        'Arguments: strIN
        'Returns: boolean - true or false 
        'Author: Aida Mojica
        'Date: 16 February 2015

        'check to see that each character is 0-9
        Dim i As Integer
        Dim strOne As String

        For i = 0 To Len(strIN) - 1
            'get one character from the string
            strOne = strIN.Substring(i, 1)
            Select Case strOne
                'if the character is 0-9 then keep going
                Case "0" To "9"
                    'if the character is anything else stop looking and return false 
                Case Else
                    'if bad data retuen false
                    Return False
            End Select
        Next
        'if we made it through the loop return true
        Return True

    End Function

    Public Function CheckForAlpha(strIN As String) As Boolean
        'Purpose: validate that a string is composed entirely of alpha characters  
        'Arguments: strIN
        'Returns: boolean - true or false 
        'Author: Aida Mojica
        'Date: 16 February 2015

        'check to see that each character is a-z 
        Dim i As Integer
        Dim strOne As String

        For i = 0 To Len(strIN) - 1
            'get one character from the string
            strOne = strIN.Substring(i, 1).ToLower
            Select Case strOne
                'if the character is a-z then keep going
                Case "a" To "z"
                    'if the character is anything else stop looking and return false 
                Case Else
                    'if bad data retuen false
                    Return False
            End Select
        Next
        'if we made it through the loop return true
        Return True

    End Function

    Public Function CheckDecimal(ByVal strInput As String) As Decimal
        'Purpose: Validate is decimal input is numeric and greater than 0 
        'Arguments: strInput
        'Returns: -1 if number is valid, else strInput 
        'Author: Aida Mojica
        'Date: 22 January 2015

        'declare variables
        Dim decResult As Decimal

        'test for numeric
        Try
            decResult = Decimal.Parse(strInput, Globalization.NumberStyles.Currency)
        Catch ex As Exception
            'value is not numeric, so return -1 (flag that something is wrong)
            Return -1
        End Try

        'test for greater than zero
        If decResult <= 0 Then
            'value is less than or equal, so return -1 (flag that something is wrong)
            Return -1
        End If

        'if the code gets this far, the input is valid, so return the result
        Return decResult
    End Function


    Public Function CheckIfBlank(strIn As String) As Boolean
        'Purpose: check to see if input is blank 
        'Arguments: strIN
        'Returns: boolean - true if blank or false otherwise
        'Author: Aida Mojica
        'Date: 16 February 2015

        'check to see if input is blank 
        If strIn = "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CheckPhone(strInput As String) As Boolean
        'Purpose: Make sure input for phone is 10 characters and all numeric
        'Arguments: String
        'Returns: True/False
        'Author: Noureen Rojani
        'Date: March 2, 2015

        'Check to make sure length is equal to 10
        If strInput.Length <> 10 Then
            Return False
        End If

        'Check to make sure it's all digits (return false if no good, return true if passes check digits)
        Return CheckForDigits(strInput)
    End Function

    'Purpose: To check length of middle initial
    'Parameters: strInput
    'Returns: True/False
    'Author: Noureen Rojani
    'Date: February 18, 2015
    Public Function CheckMI(strInput As String) As Boolean
        If strInput.Length <> 1 Then
            Return False
        End If

        'Make sure the middle initial is only one letter
        If CheckForAlpha(strInput) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    'Purpose: To check length of zipcode
    'Parameters: strInput
    'Returns: True/False
    'Author: Noureen Rojani
    'Date: February 18, 2015
    Public Function CheckZip(strInput As String) As Boolean
        If strInput.Length < 5 Or strInput.Length > 9 Then
            Return False
        End If

        'Make sure zipcode is between 5 and 9 digits
        If CheckForDigits(strInput) = True Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
