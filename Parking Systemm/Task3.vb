'   ATTENTION---------------------|
'   REFER TO TASK 1               |
'   ------------------------------|

Imports System.Collections.Generic

Module Task3

    'Global Variables
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20
    Dim GeneralSlotsIndex = 0;
    Dim AccessibleSlotsIndex = 0;
    Public Names(MAX_DAYS) As List(Of String) = New List(Of String)
    Public Licenses(MAX_DAYS) As List(Of String) = New List(Of String)
    Public Lots(MAX_DAYS) As List(Of String) = New List(Of String)

    Sub Main()
        Dim MenuOption As Integer = 1
        While MenuOption < 9

            'Make sure value is in range
            If MenuOption < 1 Then
                MenuOption = 9
            End If

            Console.WriteLine("|============================================================|")
            Console.WriteLine("|            SYSTEM MENU                                     |")
            Console.WriteLine("|============================================================|")
            Console.WriteLine("| [1] Add Reservation                                        |")
            Console.WriteLine("| [2] Clear Reservations                                     |")
            Console.WriteLine("| [3] Check Accessible Space Used on Day                     |")
            Console.WriteLine("| [4] Check General Space Used on Day                        |")
            Console.WriteLine("| [5] Check Total Space Used on Day                          |")
            Console.WriteLine("| [6] Check Total Accessible Space Used in the 14 Days       |")
            Console.WriteLine("| [7] Check Total General Space Used in the 14 Days          |")
            Console.WriteLine("| [8] Check Total Space Used in the 14 Days                  |")
            Console.WriteLine("| [9] Exit System                                            |")
            Console.WriteLine("|============================================================|")

            MenuOption = Console.ReadLine()

            Select Case MenuOption
                Case 1
                    AddReservation()
                Case 2
                    ClearReservations()
                Case 3
                    CheckAccessibleSpaceUsed(True)
                Case 4
                    CheckGeneralSpaceUsed(True)
                Case 5
                    CheckTotalSpaceUsed(True)
                Case 6
                    CheckAccessibleSpaceUsed(False)
                Case 7
                    CheckGeneralSpaceUsed(False)
                Case 8
                    CheckTotalSpaceUsed(False)
                Case Is >= 9
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

    Sub CheckAccessibleSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay  = True Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetAccessibleDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked accessible spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total = Total + GetAccessibleDaysForDay(Day)
            Next Index
            Console.WriteLine("You have {0} booked accessible spaces on all 14 days.",Total)
        End If
    End Sub

    Sub CheckGeneralSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay  = True Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetGeneralDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked general spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total = Total + GetGeneralDaysForDay(Day)
            Next Index
            Console.WriteLine("You have {0} booked general spaces on all 14 days.",Total)
        End If
    End Sub

    Sub CheckTotalSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay  = True Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetGeneralDaysForDay(Day-1) + GetAccessibleDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked general spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total = Total + GetGeneralDaysForDay(Day) + GetAccessibleDaysForDay(Day)
            Next Index
            Console.WriteLine("You have {0} booked general spaces on all 14 days.",Total)
        End If
    End Sub

    Function GetAccessibleDaysForDay(Day As Integer) As Integer
        Dim Total As Integer = 0

        For Index = 0 To 6
            If Lots(Day-1)(Index) IsNot Nothing Then
                Total = Total + 1
            End If
        Next Index

        Return Total
    End Function

    Function GetGeneralDaysForDay(Day As Integer) As Integer
        Dim Total As Integer = 0

        For Index = MAX_SLOTS - 1 To 6
            If Lots(Day-1)(Index) IsNot Nothing Then
                Total = Total + 1
            End If
        Next Index

        Return Total
    End Function

    Function AvailableAccessibleSlots(ByVal Day As Integer) As Boolean
        For Index = MAX_SLOTS-1 To 0 Step -1
            If Lots(Day)(Index) = Nothing Then
                AccessibleSlotsIndex = Index;
                Return True
            End If
        Next Index
        Return False
    End Function

    Function AvailableGeneralSlots(ByVal Day As Integer) As Boolean
        For Index = MAX_SLOTS-1 To 7 Step -1
            If Lots(Day)(Index) = Nothing Then
                Return True
            End If
        Next Index
        Return False
    End Function
End Module