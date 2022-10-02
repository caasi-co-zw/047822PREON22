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
    Public Names(MAX_DAYS) As List(Of String) = New List(Of String)
    Public Licenses(MAX_DAYS) As List(Of String) = New List(Of String)
    Public Lots(MAX_DAYS) As List(Of String) = New List(Of String)

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
            If Lots(Day-1) isNot Nothing  And Lots(Day-1).Count >= MAX_SLOTS Then
                Console.WriteLine("Day {0} is fully booked. Try another day.",Day)
                Continue While
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
        '   or simply redim the three variables like ReDim Names(MAX_DAYS) As List(Of String) = New List(Of String)
        '   if it works.
        '   Also if data is not to be cleared on prompt - simply call this function on line 26 - in the loop
        '   but only if you have also switched to the timestamp version of the database or you'll have to call it on
        '   line 23 ;)

        Names(MAX_DAYS).Clear()
        Licenses(MAX_DAYS).Clear()
        Lots(MAX_DAYS).Clear()
        Console.WriteLine("Records cleared.")
    End Sub

    Sub RecordReservation(ByVal Day As Integer,ByVal Name As String,ByVal License As String)
        Lots(Day-1).Add(License)
        Names(Day-1).Add(Name)
        Console.WriteLine("Records Saved!")
        Console.WriteLine("You have been assigned to parking lot no {0}",Lots(Day).Count)
    End Sub
End Module