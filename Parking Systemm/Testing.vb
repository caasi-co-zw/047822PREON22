Module Test

    Public Lots(5) As String
    Sub Main()
        If Lots Is Nothing Then
            Console.WriteLine("Array would throw a NE")
        End If

        Try
            Lots(0) = "Something"
            Console.WriteLine("This works of-course")

            If HasFreeSpaces() Then
                Console.WriteLine("Everything works as expected")
            Else
                Console.WriteLine("Umm...we may need to pay attention to this")
            End If

            If Lots(1) Is Nothing Then
                Console.WriteLine(":)")
            End If
        Catch Ex As Exception
            Console.WriteLine("Something seems to be a bit off :(")
            Console.WriteLine(Ex.Message)
        End Try
        Console.ReadLine()
    End Sub

    Function HasFreeSpaces() As Boolean
        For Index As Integer = 0 To 5-1
            If Lots(Index) Is Nothing Then
                Return True
            End If
        Next Index
    End Function
End Module