Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc
Imports MVCxGridViewDataBinding.Models
Imports DevExpress.Data.Filtering

Namespace T146465.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

		Public Function Index() As ActionResult
			Return View()
		End Function


		<ValidateInput(False)> _
		Public Function GridViewPartial() As ActionResult
			Dim model = MyModel.GetModelList()
			Return PartialView("_GridViewPartial", model)
		End Function
		Public Function CreateNextMonthFilter(ByVal field As String) As Object
			If String.IsNullOrWhiteSpace(field) Then
				Return String.Empty
			End If
			Dim startDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1)
			Dim endDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month + 2, 1)
			Dim filter = New BetweenOperator(field, startDate, endDate)
			Return filter
		End Function
		Public Function CreateLastMonthFilter(ByVal field As String) As Object
			If String.IsNullOrWhiteSpace(field) Then
				Return String.Empty
			End If
			Dim startDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1)
			Dim endDate = New DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
			Dim filter = New BetweenOperator(field, startDate, endDate)
			Return filter
		End Function
		Public Function CustomFilterProcessingAction(ByVal field As String, ByVal command As String) As ActionResult
		   ViewData("field") = field
		   Select Case command
			   Case "NextMonth"
				ViewData("filterExpression") = CreateNextMonthFilter(field)
			   Case "LastMonth"
				   ViewData("filterExpression") = CreateLastMonthFilter(field)
			   Case Else
				   ViewData("filterExpression") = String.Empty
		   End Select
			Dim model = MyModel.GetModelList()
			Return PartialView("_GridViewPartial", model)
		End Function
	End Class
End Namespace
