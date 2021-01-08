Imports Microsoft.AspNetCore.Mvc

<Route("api/[controller]")>
Public Class ProductsController
    Inherits Controller

    <HttpGet>
    Public Function [Get]() As IEnumerable(Of String)
        Return New String() {"aaaa bbbb", "234234 234234"}
    End Function

    <HttpGet("{id}")>
    Public Function [Get](ByVal id As Integer) As String
        Return $"234234 234234 - {id}"
    End Function
End Class
