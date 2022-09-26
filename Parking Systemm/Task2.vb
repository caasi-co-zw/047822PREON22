Module Task1

    'Global Variables
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20

    'Licenses and Lots are indexed by day
    Dim Names(MAX_DAYS) As List(Of String)
    Dim Licenses(MAX_DAYS) As List(of String)
    Dim Lots(MAX_DAYS) As List(of String)

    Sub Main()
        Dim MenuOption As Integer = 1
        Do While MenuOption < 3

            'Make sure value is in range
            If MenuOption < 1 Then
                MenuOption = 3
            End If

            Console.WriteLine("|=================================|")
            Console.WriteLine("|            SYSTEM MENU          |")
            Console.WriteLine("|=================================|")
            Console.WriteLine("| [1] Add Reservation             |")
            Console.WriteLine("| [2] Clear Reservations          |")
            Console.WriteLine("| [3] Exit System                 |")
            Console.WriteLine("|=================================|")

            MenuOption = Console.ReadLine()

            Select Case MenuOption
                Case 1
                    AddReservation()
                Case 2
                    ClearReservations()
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
        Dim Accessible As String
        Dim AddAnother As String = "Y"

        Do While AddAnother.ToUpper = "Y"
            'Record reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            If Day < 1 Or Day > MAX_DAYS Then
                Console.WriteLine("{0} must be between 1 and 14.",Day)
                Continue
            End If

            'Check for availableslots for the day
            If SlotsAvailable(Day) <> True Then
                Console.WriteLine("{0} is fully booked. Try another day.",Day)
                Continue
            End If

            'Record name
            Console.WriteLine("Full name: ")
            Name = Console.ReadLine()

            'Record license
            Console.WriteLine("License no: ")
            License = Console.ReadLine()

            Console.WriteLine("Do you want an accessible space? [Y/N]")
            Accessible = Console.ReadLine()

            RecordReservation(Day,Names,License,Accessible.ToUpper = "Y" )

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        Loop
    End Sub

    ' Clears all records
    Sub ClearReservations()
        Names(MAX_DAYS).Clear()
        Licenses(MAX_DAYS).Clear()
        Lots(MAX_DAYS).Clear()
        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String,Accessible As Boolean)
        Lots(Day).Add(License)
        Names(Day).Add(Name)
        Console.WriteLine("Records Saved")
        Console.WriteLine("You have been assigned to parking lot no {0}",Lots(Day).Count)
    End Sub

    Function SlotsAvailable(ByVal Day As Integer)
        Return Lots(Day).Count = MAX_SLOTS
    End Function
End Module