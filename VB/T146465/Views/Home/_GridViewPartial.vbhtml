@Imports System.Linq
@Imports DevExpress.Data.Filtering
@Code
    Dim grid = Html.DevExpress().GridView(Sub(settings)
                                                  settings.Name = "GridView"
                                                  settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                                                  settings.CustomActionRouteValues = New With {.Controller = "Home", .Action = "CustomFilterProcessingAction"}
                                                  settings.KeyFieldName = "ModelID"
                                                  settings.SettingsPager.Visible = True
                                                  settings.Settings.ShowGroupPanel = True
                                                  settings.Settings.ShowFilterBar = GridViewStatusBarMode.Visible                                                   
                                                  settings.Settings.ShowHeaderFilterButton = True
                                                  settings.SettingsBehavior.AllowSelectByRowClick = False
                                                  settings.Columns.Add("ModelID")
                                                  settings.Columns.Add("ModelName")
                                                  settings.Columns.Add("ModelState")
                                                  settings.BeforeGetCallbackResult = Sub(sender, e)
                                                                                             Dim field As String = TryCast(ViewData("field"), String)
                                                                                             Dim filterExpression As BetweenOperator = TryCast(ViewData("filterExpression"), BetweenOperator)
                                                                                             If String.IsNullOrEmpty(field) Then
                                                                                                 Return
                                                                                             End If
                                                                                             Dim GridView As MVCxGridView = TryCast(sender, MVCxGridView)
                                                                                             Dim criterias = CriteriaColumnAffinityResolver.SplitByColumns(CriteriaOperator.Parse(GridView.FilterExpression))
                                                                                             Dim op As New OperandProperty(field)
                                                                                             If (Not criterias.Keys.Contains(New OperandProperty(field))) Then
                                                                                                 criterias.Add(op, filterExpression)
                                                                                             Else
                                                                                                 criterias(op) = filterExpression
                                                                                             End If
                                                                                             Dim expression = CriteriaOperator.ToString(GroupOperator.And(criterias.Values))
                                                                                             GridView.FilterExpression = expression
                                                                                     End Sub
                                                  settings.Columns.Add(Sub(c)
                                                                               c.FieldName = "ModelDate"
                                                                               c.Caption = "Model Date"
                                                                               c.Settings.AllowHeaderFilter = DefaultBoolean.False
                                                                               c.ColumnType = MVCxGridViewColumnType.DateEdit
                                                                               c.SetHeaderTemplateContent(Sub(content)
                                                                                                                  Dim column = TryCast(content.Column, GridViewDataColumn)
                                                                                                                  ViewContext.Writer.Write(String.Format(" <table cellspacing='0' cellpadding='0' style='width: 100%; border-collapse: collapse;'>" & ControlChars.CrLf & "<tbody>" & ControlChars.CrLf & "<tr>" & ControlChars.CrLf & "<td>{0}</td>" & ControlChars.CrLf & "<td style='width: 1px; text-align: right;'><span class='dx-vam'></span>", column.Caption))
                                                                                                                  If column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending Then
                                                                                                                      ViewContext.Writer.Write(String.Format("<img alt='[Sort arrow]' src='{0}' class='dxGridView_gvHeaderSortUp_DevEx dx-vam SortArrow' />", Url.Content("~/Content/img_trans.gif")))
                                                                                                                  ElseIf column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending Then
                                                                                                                      ViewContext.Writer.Write(String.Format("<img alt='[Sort arrow]' src='{0}' class='dxGridView_gvHeaderSortDown_DevEx dx-vam SortArrow' />", Url.Content("~/Content/img_trans.gif")))
                                                                                                                  End If
                                                                                                                  ViewContext.Writer.Write(String.Format("<img class='MyHeaderFilter' alt='[HeaderFilter]'  src='{0}'  style='cursor:default;' onmousedown='return CancelEvent(event);'  onclick=OnColumnClick(this,'{1}'); />", Url.Content("~/Content/img_trans.gif"), (CType(content.Column, GridViewDataColumn)).FieldName))
                                                                                                                  ViewContext.Writer.Write("</td>" & ControlChars.CrLf & "</tr>" & ControlChars.CrLf & "</tbody>" & ControlChars.CrLf & "</table>")
                                                                                                          End Sub)

                                                                       End Sub)
                                          End Sub)
End Code
@grid.Bind(Model).GetHtml()
