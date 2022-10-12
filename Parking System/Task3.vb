Imports System.Collections.Generic

Module Task3

    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20
    Dim Names(MAX_DAYS,MAX_SLOTS) As String
    Dim Lots(MAX_DAYS,MAX_SLOTS) As String

    Dim GeneralSlotsIndex(MAX_DAYS) As Integer
    Dim AccessibleSlotsIndex(MAX_DAYS) As Integer
    Dim EntriesCount(MAX_DAYS) As Integer
    Dim GeneralFrom As Integer = 6
    Dim AccessibleFrom As Integer = 0

    Sub Main()
        ClearReservations()
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
                    AddReservation() 'Error
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

            If Lots IsNot Nothing Then
                If IsFullyBooked(Day,Accessible.ToUpper = "Y") Then
                    Console.WriteLine("Day {0} is fully booked. Try another day.",Day)
                    Continue While
                End If
            End If

            'Record name
            Console.WriteLine("Full name: ")
            Name = Console.ReadLine()

            'Record license
            Console.WriteLine("License no: ")
            License = Console.ReadLine()

            RecordReservation(Day,Name,License,Accessible.ToUpper = "Y" )

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        End While
    End Sub

    Sub ClearReservations()
        For i As Integer = 0 To 13
            EntriesCount(i) = 0
            GeneralSlotsIndex(i) = 20
            AccessibleSlotsIndex(i) = 0
        Next i
        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String,Accessible As Boolean)
        Day -= 1

        If Accessible Then
            Lots(Day,AccessibleSlotsIndex(Day)) = License
            Names(Day,AccessibleSlotsIndex(Day)) = Name

            AccessibleSlotsIndex(Day) += 1

            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",CInt(AccessibleSlotsIndex(Day)))

        Else
            Lots(Day,GeneralSlotsIndex(Day)-1) = License
            Names(Day,GeneralSlotsIndex(Day)-1) = Name


            Console.WriteLine("Records Saved")
            Console.WriteLine("You have been assigned to parking lot no {0}",CInt(GeneralSlotsIndex(Day)))

            GeneralSlotsIndex(Day) -= 1
        End If

        EntriesCount(Day) += 1
    End Sub

    Sub CheckAccessibleSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetAccessibleDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked accessible spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total += GetAccessibleDaysForDay(Day)
            Next Day
            Console.WriteLine("You have {0} booked accessible spaces on all 14 days.",Total)
        End If
    End Sub

    Sub CheckGeneralSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetGeneralDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked general spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total += GetGeneralDaysForDay(Day)
            Next Day
            Console.WriteLine("You have {0} booked general spaces on all 14 days.",Total)
        End If
    End Sub

    Sub CheckTotalSpaceUsed(AskDay As Boolean)
        Dim Day As Integer
        Dim Total As Integer = 0

        If AskDay Then
            Console.WriteLine("Day number: ")
            Day = Console.ReadLine()

            Total = GetGeneralDaysForDay(Day-1) + GetAccessibleDaysForDay(Day-1)
            Console.WriteLine("You have {0} booked general spaces on {1}.",Total,Day)
        Else
            For Day = 0 To MAX_DAYS -1
                Total += GetGeneralDaysForDay(Day) + GetAccessibleDaysForDay(Day)
            Next Day
            Console.WriteLine("You have {0} booked general spaces on all 14 days.",Total)
        End If
    End Sub

    Function IsFullyBooked(Day As Integer,Accessible As Boolean) As Boolean
        If IsNull(Names) Then
            Return False
        End If

        If EntriesCount(Day - 1) > MAX_SLOTS Then
            Return True
        End If

        If Accessible Then
            Return If (AccessibleSlotsIndex(Day-1) < MAX_SLOTS - 1,False,True)
        Else
            Return If (GeneralSlotsIndex(Day-1) >= GeneralFrom - 1,False,True)
        End If
    End Function

    Function IsNull(Arr As Array) As Boolean
        Return If(Arr IsNot Nothing,False,True)
    End Function

    Function GetAccessibleDaysForDay(Day As Integer) As Integer
        Return AccessibleSlotsIndex(Day)
    End Function

    Function GetGeneralDaysForDay(Day As Integer) As Integer
        Return 20 - GeneralSlotsIndex(Day)
    End Function
End Module