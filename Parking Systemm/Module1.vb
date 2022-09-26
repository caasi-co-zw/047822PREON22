Module Module1

    Sub Main()
        Menu()
    End Sub

    Function Menu()
        Dim MenuOption As Integer
        Do
            Console.WriteLine("SYSTEM MENU")
            Console.WriteLine("1. Add Reservation")
            Console.WriteLine("2. Check Reservation")
            Console.WriteLine("3. Exit System")
            MenuOption = Console.Read()
            Select Case MenuOption
                Case 1
                    AddReservation()
                Case 2
                    CheckReservation()
                Case Is >= 3
                    Exit Do
            End Select
        Loop
        Console.WriteLine("System terminated.")
    End Function

End Module
