Module Task1

    'Global Variables
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20

    ' Names are indexed by day and license
    Dim Names(MAX_DAYS) As New Dictionary(Of String, String)

    'Licenses and Lots are indexed by day
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
        Dim AddAnother As String = "Y"

        Do While AddAnother.ToUpper = "Y"
            'Record reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            If Day > 0 AndAlso Day <= MAX_DAYS Then
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

            RecordReservation(Day,Names,License)

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        Loop
    End Sub

    ' Clears all records
    Sub ClearReservations()
        ReDim Names(MAX_DAYS) As New Dictionary(Of String, String)
        ReDim Licenses(MAX_DAYS) As List(of String)
        ReDim Lots(MAX_DAYS) As List(of String)
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Names As String,ByVal License As String)
        Lots(Day).Add(License)
        Names(Day).Add(License,Names)
        Console.WriteLine("Records Saved")
    End Sub

    Function SlotsAvailable(ByVal Day As Integer)
        Return Lots(Day).Count == MAX_SLOTS
    End Function
End Module