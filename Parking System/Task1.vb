Imports System.Collections.Generic

Module Task1
    Dim MAX_DAYS As Integer = 14
    Dim MAX_SLOTS As Integer = 20
    Dim LotsIndex(MAX_DAYS) As Integer
    Dim NamesIndex(MAX_DAYS) As Integer
    Dim Names(MAX_DAYS,MAX_SLOTS) As String
    Dim Lots(MAX_DAYS,MAX_SLOTS) As String

    'ENTRY POINT
    'Responsible for the menu
    Sub Main()
        Dim MenuOption As Integer = 1

        'While the user's option is not 3, show menu
        While MenuOption < 3

            'Make sure value is in range
            If MenuOption < 1 Then
                MenuOption = 4
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
        Dim AddAnother As String = "Y"

        'While the user has entered y/Y continue to add more data
        While AddAnother.ToUpper = "Y"

            'Get reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            If Day < 1 OrElse Day > MAX_DAYS Then
                Console.WriteLine("Day {0} must be between 1 and 14.",Day)

                'If day is invalid restart loop ;)
                Continue While
            End If

            If Lots IsNot Nothing Then
                If IsFullyBooked(Day) Then
                    Console.WriteLine("Day {0} is fully booked. Try another day.",Day)
                    Continue While
                End If
            End If

            'Get name
            Console.WriteLine("Full name: ")
            Name = Console.ReadLine()

            'Get license
            Console.WriteLine("License no: ")
            License = Console.ReadLine()

            RecordReservation(Day,Name,License)

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        End While
    End Sub

    Sub ClearReservations()
        For i As Integer = 0 To 13
            NamesIndex(i) = 0
            LotsIndex(i) = 0
        Next i
        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String)
        Dim Index As Integer
        Index = Day-1
        Lots(Day,LotsIndex(Index)) = License
        Names(Day,NamesIndex(Index)) = Name

        LotsIndex(Index) += 1
        NamesIndex(Index) += 1

        Console.WriteLine("Records Saved!")
        Console.WriteLine("You have been assigned to parking lot no {0}",CInt(LotsIndex(Index)))
    End Sub

    Function IsFullyBooked(Day As Integer) As Boolean
        If IsNull(Names) Then
            Return False
        End If
        Return If (LotsIndex(Day-1) < MAX_SLOTS -1,False,True)
    End Function

    Function IsNull(Arr As Array) As Boolean
        Return If(Arr IsNot Nothing,False,True)
    End Function
End Module