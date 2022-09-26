Module Task1
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20

    Dim Names(MAX_DAYS,MAX_SLOTS) as List(of String)
    Dim Licenses(MAX_DAYS,MAX_SLOTS) as List(of String)
    Dim Lots(MAX_DAYS,MAX_SLOTS) as List(of String)

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
            MenuOption = Console.ReadLine()
            Select Case MenuOption
                Case 1
                    AddReservation()
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
        Dim Day As Integer
        Dim Name As String
        Dim License As String
        Dim AddAnother As Integer = 1

        Do While AddAnother = 1
            'Record reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            'Validate date

            'Record name
            Console.WriteLine("Full name: ")
            Name = Console.ReadLine()

            'Validate date

            'Record name
            Console.WriteLine("License no: ")
            License = Console.ReadLine()

            'Ask if they want another reservation
            Console.WriteLine("1. Add another reservation")
            AddAnother = Console.ReadLine()
        Loop
    End Sub

    Sub CheckReservation()
        Dim CheckAnother As Integer = 1
        Do While CheckAnother = 1
            'Check reservation

            'Ask if they want another reservation
            Console.WriteLine("1. Check another reservation")
            CheckAnother = Console.ReadLine()
        Loop
    End Sub
End Module