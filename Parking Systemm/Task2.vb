'   ATTENTION---------------------|
'   REFER TO TASK 1               |
'   ------------------------------|

Imports System.Collections.Generic

Module Task2

    Public MAX_DAYS As Integer = 14
    Public MAX_SLOTS As Integer = 20
    Public LotsIndex As Integer = 0
    Public NamesIndex As Integer = 0
    Public GeneralSlotsIndex As Integer = 0
    Public AccessibleSlotsIndex As Integer = 0
    Public Names(MAX_DAYS,MAX_SLOTS) As String
    Public Licenses(MAX_DAYS,MAX_SLOTS) As String
    Public Lots(MAX_DAYS,MAX_SLOTS) As String

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

            If Day < 1 OrElse Day > MAX_DAYS Then
                Console.WriteLine("{0} must be between 1 and 14.",Day)
                Continue While
            End If

            Console.WriteLine("Do you want an accessible space? [Y/N]")
            Accessible = Console.ReadLine()

            If Accessible.ToUpper = "Y" Then
                'Check for availableslots for the day
                If AvailableAccessibleSlots(Day-1) <> True Then
                    Console.WriteLine("Day {0}, inaccessible is fully booked. Try another day.",Day)
                    Continue While
                End If
            Else
                'Check for availableslots for the day
                If AvailableGeneralSlots(Day-1) <> True Then
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

    ' Clears all records * (Bugs? RT1)
    Sub ClearReservations()
        Names(MAX_DAYS).Clear()
        Licenses(MAX_DAYS).Clear()
        Lots(MAX_DAYS).Clear()

        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String,Accessible As Boolean)
        If Accessible <> True Then
            Lots(Day-1).Insert(AccessibleSlotsIndex,License)
            Names(Day-1).Insert(AccessibleSlotsIndex,Name)
            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",AccessibleSlotsIndex)
        Else
            Lots(Day-1).Insert(GeneralSlotsIndex,License)
            Names(Day-1).Insert(GeneralSlotsIndex,Name)
            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",GeneralSlotsIndex)
            GeneralSlotsIndex = GeneralSlotsIndex-1
        End If
    End Sub

    Function DayHasFreeSpaces(Day As Integer) As Boolean
        If Names Is Nothing Then
            Return True
        End If
        For Index As Integer = 0 To MAX_SLOTS-1
            If Names(Day-1,Index) Is Nothing Then
                Return True
            End If
        Next Index
    End Function

    Function DayHasFreeAccessibleSpaces(Day As Integer) As Boolean
        If Names Is Nothing Then
            Return True
        End If
        For Index As Integer = 0 To 6-1
            If Names(Day-1,Index) Is Nothing Then
                Return True
            End If
        Next Index
    End Function

    Function DayHasFreeGeneralSpaces(Day As Integer) As Boolean
        If Names Is Nothing Then
            Return True
        End If
        For Index As Integer = MAX_SLOTS-1 To 6
            If Names(Day-1,Index) Is Nothing Then
                Return True
            End If
        Next Index
    End Function
End Module