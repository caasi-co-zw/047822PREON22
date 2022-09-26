Module Task1
    Sub Main()

        ''' DB STRUCTURE
        ''' [ (An array of all the days (14))
        '''     [ (Each day is an array of Spaces available (20))
        '''         { (Each parking lot is a dictionary containing all the details needed)
        '''             "license": 123232,
        '''             "name": "Shaun K"
        '''         }
        '''     ]
        ''' ]
        '''
        Dim Bookings As New List(Of Dictionary(Of Integer,String))()
        Dim Days(14) As Integer
        Dim Spaces(20) As Integer

    End Sub
    Function isDayAvailable(Day As Int)
        For Each Booking In Bookings
            If Booking = Day Then
                If Not IsNothing i Then
                    Return True
                    Exit For
                Else
                    Return False
                    Exit For
                End If
            End If
        Next
    End Function

    Function getName(Day As Int,Space As Int)
        Days(Day)
    End Function

    Function getDay()

    End Function

    Function AddBooking(Day As Integer,Space As Integer,License As String)
        Bookings.Add(
            New Dictionary(Of Integer,String)() From {
                {"Day",Day}
                }
            )
    End Function
End Module