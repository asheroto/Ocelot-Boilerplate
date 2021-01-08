Imports Microsoft.AspNetCore.Mvc

<Route("api/[controller]")>
Public Class CustomersController
    Inherits Controller

    <HttpGet>
    Public Function [Get]() As IEnumerable(Of String)
        Return New String() {"Catcher Wong", "James Li"}
    End Function

    <HttpGet("{id}")>
    Public Function [Get](ByVal id As Integer) As String
        Return $"Catcher Wong - {id}"
    End Function
End Class
