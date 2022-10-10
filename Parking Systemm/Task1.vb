'   ATTENTION-------------------------------------------------------------------|
'   My assumptions are that it will work ;) BUT                                 |
'   Please test this task thoroughly. You may want look out for the following   |
'   ----------------------------------------------------------------------------|
'   TEST       = Test the feature or function                                   |
'   BONUS TIP  = Incase you find yourself in a different situation              |
'   All this should however be applied to the three tasks separately - DRY      |
'   ----------------------------------------------------------------------------|

Imports System.Collections.Generic

Module Task1

    'Global Variables
    Public MAX_DAYS As Integer = 14
    Public MAX_SLOTS As Integer = 20
    Public LotsIndex(MAX_DAYS) As Integer
    Public NamesIndex(MAX_DAYS) As Integer
    Public Names(MAX_DAYS,MAX_SLOTS) As String
    Public Lots(MAX_DAYS,MAX_SLOTS) As String

    Sub Main()
        Dim MenuOption As Integer = 1

        'While the user's option is not 3, show menu
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
        Dim AddAnother As String = "Y"

        'While the user has entered y/Y continue to add more data
        While AddAnother.ToUpper = "Y"

            'Record reservation day
            Console.WriteLine("Day to reserve: ")
            Day = Console.ReadLine()

            If Day < 1 OrElse Day > MAX_DAYS Then
                Console.WriteLine("Day {0} must be between 1 and 14.",Day)
                Continue While
            End If

            'BONUS TIP
            '   If you have to use real dates & use a real database,
            '   you can convert the date to a timestamp and add all the details to the day
            '   timestamped.
            '   To check if there's any available spaces,
            '   Simply query to check if you have less than 15 results (ie. Results < 15)
            '
            'Check for availableslots for the day
            If Lots IsNot Nothing Then
                If IsFullyBooked(Day) Then
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

            RecordReservation(Day,Name,License)

            'Ask if they want another reservation
            Console.WriteLine("Add another reservation? [Y/N]")
            AddAnother = Console.ReadLine()
        End While
    End Sub

    ' Clears all records
    Sub ClearReservations()

        'TEST
        '   See if data is cleared for all days,
        '   because you may have to loop through each day, clearing records
        '   or simply redim the three variables like ReDim Names(MAX_DAYS,MAX_SLOTS) As String
        '   if it works.
        '   Also if data is not to be cleared on prompt - simply call this function on line 26 - in the loop
        '   but only if you have also switched to the timestamp version of the database or you'll have to call it on
        '   line 23 ;)
        Names = Nothing
        Lots = Nothing
        NamesIndex = Nothing
        LotsIndex = Nothing
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

        ' We shouldn't even get here since the array would be full already ;)
        If LotsIndex(Index) > MAX_SLOTS Then
            LotsIndex(Index) = 0
            NamesIndex(Index) = 0
        End If
    End Sub

    Function IsFullyBooked(Day As Integer) As Boolean
        If IsNull(Names) Then
            Return False
        End If
        For Index As Integer = 0 To MAX_SLOTS-1
            If Names(Day-1,Index) Is Nothing Then
                Return False
            End If
        Next Index
        Return True
    End Function

    Function GetDayIndex(Day As Integer) As Integer
        If Names Is Nothing Then
            NamesIndex(Day-1) = 0
            LotsIndex(Day-1) = 0
            Return 0
        End If
        For Index As Integer = 0 To MAX_SLOTS-1
            If Names(Day-1,Index) Is Nothing Then
                NamesIndex(Day) = Index
                LotsIndex(Day) = Index
                Return 0
            End If
        Next Index
        Return MAX_SLOTS
    End Function

    Function IsNull(Arr As Array) As Boolean
        Return If(Arr IsNot Nothing,False,True)
    End Function
End Module