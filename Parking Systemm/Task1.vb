Module Task1
    'Dim Names as New List(of String)
    'Dim Licenses as New List(of String)
    'Dim Lots as New List(of String)

    Sub Main()
        Menu()
    End Sub

    Sub Menu()
        Dim MenuOption As Integer = 1
        Do While MenuOption < 3

            'Make sure value is in range
            If MenuOption < 1 Then
                MenuOption = 3
            End If

            Console.WriteLine("SYSTEM MENU")
            Console.WriteLine("1. Add Reservation")
            Console.WriteLine("2. Check Reservation")
            Console.WriteLine("3. Exit System")
            MenuOption = Console.Read()
            Select Case MenuOption
                Case 1
                    AddReservation()
                    Continue
                Case 2
                    CheckReservation()
                Case Is >= 3
                    Exit Do
            End Select
        Loop

        'Exit app
        Console.WriteLine("System terminated. Have a good day!")
    End Sub

    Sub AddReservation()
        Dim AddAnother As Integer = 1
        Do While AddAnother = 1
            'Record reservation

            'Ask if they want another reservation
            Console.WriteLine("1. Add another reservation")
            AddAnother = Console.Read()
        Loop
    End Sub

    Sub CheckReservation()
        Dim CheckAnother As Integer = 1
        Do While CheckAnother = 1
            'Check reservation

            'Ask if they want another reservation
            Console.WriteLine("1. Check another reservation")
            CheckAnother = Console.Read()
        Loop
    End Sub
End Module