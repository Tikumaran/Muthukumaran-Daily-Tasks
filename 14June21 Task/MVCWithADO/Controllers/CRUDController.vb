Imports System.Web.Mvc

Namespace Controllers
    Public Class CRUDController
        Inherits Controller

        ' GET: CRUD
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace