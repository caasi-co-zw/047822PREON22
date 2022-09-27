Module Task1

    'Global Variables
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20
    Dim InaccessibleSlotIndex = 0;

    'Licenses and Lots are indexed by day
    Dim Names(MAX_DAYS) As ArrayList = New ArrayList()
    Dim Licenses(MAX_DAYS) As ArrayList = New ArrayList()
    Dim Lots(MAX_DAYS) As ArrayList = New ArrayList()

    Sub Main()
        Dim MenuOption As Integer = 1
        While MenuOption < 3

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
                    Exit While
            End Select
        End While

        'Exit app
        Console.WriteLine("System terminated. Have a good day!")
    End Sub

    Sub AddReservation()
        Dim Day As Integer
        Dim Name As String
        Dim License As String
        Dim Accessible As String
        Dim AddAnother As String = "Y"

        While AddAnother.ToUpper = "Y"
            'Record reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            If Day < 1 Or Day > MAX_DAYS Then
                Console.WriteLine("{0} must be between 1 and 14.",Day)
                Continue While
            End If

            Console.WriteLine("Do you want an accessible space? [Y/N]")
            Accessible = Console.ReadLine()

            If Accessible.ToUpper = "Y" Then
                'Check for availableslots for the day
                If CheckInaccessibleAvailableSlots(Day) <> True Then
                    Console.WriteLine("Day {0}, inaccessible is fully booked. Try another day.",Day)
                    Continue While
                End If
            Else
                'Check for availableslots for the day
                If Lots(Day).Count >= MAX_SLOTS Then
                    Console.WriteLine("Day {0}, accessible is fully booked. Try another day.",Day)
                    Continue While
                End If
            End If

            'Record name
            Console.WriteLine("Full name: ")
            Name = Console.ReadLine()

            'Record license
            Console.WriteLine("License no: ")
            License = Console.ReadLine()

            RecordReservation(Day,Names,License,Accessible.ToUpper = "Y" )

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        End While
    End Sub

    ' Clears all records
    Sub ClearReservations()
        Names(MAX_DAYS).Clear()
        Licenses(MAX_DAYS).Clear()
        Lots(MAX_DAYS).Clear()
        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String,Accessible As Boolean)
        If Accessible <> True Then
            Lots(Day).Add(License)
            Names(Day).Add(Name)
            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",Lots(Day).Index(License))
        Else
            Lots(Day).Insert(InaccessibleSlotIndex,License)
            Names(Day).Insert(InaccessibleSlotIndex,Name)
            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",InaccessibleSlotIndex)
            InaccessibleSlotIndex = InaccessibleSlotIndex-1
        End If
    End Sub

    Function CheckInaccessibleAvailableSlots(ByVal Day As Integer) As Boolean
        For Index = MAX_SLOTS To 0 Step -1
            If Lots(Day)(Index) = Nothing Then
                Return True
            End If
        Next Index
        Return False
    End Function
End Module