@Html.DevExpress().FormLayout(Sub(fs)

                                  fs.Name = "formlayout"
                                  fs.ColCount = 2
                                  fs.Items.Add(Sub(item)
    
                                                   item.Name = "ShowAll"
                                                   item.NestedExtensionType = FormLayoutNestedExtensionItemType.CheckBox
                                                   item.ShowCaption = DefaultBoolean.False
                                                   item.ColSpan = 2
                                                   item.RowSpan = 1
                                                   item.SetNestedContent(Sub()
                                                                             Html.DevExpress().CheckBox(Sub(chs)
                                                                                                            chs.Name = "ShowAllCheckBox"
                                                                                                            chs.Text = "Show All"
                                                                                                            chs.Checked = True
                                                                                                            chs.Properties.ClientSideEvents.Init = "OnInit"
                                                                                                            chs.Properties.ClientSideEvents.CheckedChanged = "OnFilterOptionChanged"
                                                                                                        End Sub).Render()
                                                                         End Sub)
                                               End Sub)
                                  fs.Items.Add(Sub(item)
                                                   item.Name = "FilterByDate"
                                                   item.NestedExtensionType = FormLayoutNestedExtensionItemType.CheckBox
                                                   item.ShowCaption = DefaultBoolean.False
                                                   item.ColSpan = 2
                                                   item.RowSpan = 1
                                                   item.SetNestedContent(Sub()
                                                                             Html.DevExpress().CheckBox(Sub(chs)
            
                                                                                                            chs.Name = "FilterByDateCheckBox"
                                                                                                            chs.Text = "Filter by specific date"
                                                                                                            chs.Properties.ClientSideEvents.Init = "OnInit"
                                                                                                            chs.Properties.ClientSideEvents.CheckedChanged = "OnFilterOptionChanged"
                                                                                                        End Sub).Render()
                                                                         End Sub)
                                               End Sub)
                                  Dim i As EmptyLayoutItem = fs.Items.AddEmptyItem()
                                  i.ColSpan = 1
                                  fs.Items.Add(Sub(item)
    

                                                   item.Name = "CalendarItem"
                                                   item.ShowCaption = DefaultBoolean.False
                                                   item.ColSpan = 1
                                                   item.ParentContainerStyle.Paddings.PaddingLeft = Unit.Pixel(15)
                                                   item.RowSpan = 1
                                                   item.SetNestedContent(Sub()
        
                                                                             Html.DevExpress().Calendar(Sub(cs)
        
                                                                                                            cs.Name = "Calendar"
                                                                                                            cs.Properties.ClientSideEvents.SelectionChanged = "OnDateChanged"
                                                                                                            cs.Properties.ShowTodayButton = False
                                                                                                            cs.Properties.ShowClearButton = False
                                                                                                        End Sub).Render()
                                                                         End Sub)
                                               End Sub)
                                  fs.Items.Add(Sub(item)
    
                                                   item.Name = "LastMonth"
                                                   item.NestedExtensionType = FormLayoutNestedExtensionItemType.CheckBox
                                                   item.ShowCaption = DefaultBoolean.False
                                                   item.ColSpan = 2
                                                   item.RowSpan = 1
                                                   item.SetNestedContent(Sub()
        
                                                                             Html.DevExpress().CheckBox(Sub(chs)
            
                                                                                                            chs.Name = "LastMonthCheckBox"
                                                                                                            chs.Text = "Last Month"
                                                                                                            chs.Properties.ClientSideEvents.Init = "OnInit"
                                                                                                            chs.Properties.ClientSideEvents.CheckedChanged = "OnFilterOptionChanged"
                                                                                                        End Sub).Render()
                                                                         End Sub)
                                               End Sub)
                                  fs.Items.Add(Sub(item)
                                                   item.Name = "NextMonth"
                                                   item.NestedExtensionType = FormLayoutNestedExtensionItemType.CheckBox
                                                   item.ShowCaption = DefaultBoolean.False
                                                   item.ColSpan = 2
                                                   item.RowSpan = 1
                                                   item.SetNestedContent(Sub()
                                                                             Html.DevExpress().CheckBox(Sub(chs)
                                                                                                            chs.Name = "NextMonthCheckBox"
                                                                                                            chs.Text = "Next month"
                                                                                                            chs.Properties.ClientSideEvents.Init = "OnInit"
                                                                                                            chs.Properties.ClientSideEvents.CheckedChanged = "OnFilterOptionChanged"
                                                                                                        End Sub).Render()
                                                                         End Sub)
                                               End Sub)
                              End Sub).GetHtml()