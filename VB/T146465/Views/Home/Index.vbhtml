@Code
    ViewBag.Title = "GridView - How to implement a custom HeaderFilter with a calendar for a date column"
End Code
<link href="~/Content/MyStyles.css" rel="stylesheet" />
<script>
    var currentField = "";
    function OnColumnClick(el, field) {
        currentField = field;
        PopupControl.ShowAtElement(el);
    }
    function CancelEvent(evt) {
        return ASPxClientUtils.PreventEventAndBubble(evt);
    }
    function OnDateChanged(s, e) {
        if (!FilterByDateCheckBox.GetChecked())
            return;
        var date = s.GetSelectedDate();
        var dateString = CreateGridViewFilterDate(date);
        GridView.AutoFilterByColumn(currentField, dateString);
        PopupControl.Hide();
    }
    function CreateGridViewFilterDate(date) {
        return "#" + date.getFullYear() + "/" + (date.getMonth() + 1).toString() + "/" + date.getDate() + "#";
    }
    function OnFilterOptionChanged(s, e) {
        var text = s.name;
        UnCheckOtherCheckBoxes(text);
        switch (text) {
            case "ShowAllCheckBox":
                GridView.AutoFilterByColumn(currentField, "");
                break;
            case "LastMonthCheckBox":
                GridView.PerformCallback({ command: "LastMonth", field: currentField });
                break;
            case "NextMonthCheckBox":
                GridView.PerformCallback({ command: "NextMonth", field: currentField });
                break;
            default:
                return;
        }
        PopupControl.Hide();
    }
    function UnCheckOtherCheckBoxes(currentCheckBox) {
        for (var i = 0; i < filterItems.length; i++) {
            if (filterItems[i] == currentCheckBox)
                continue;
            var checkBox = ASPxClientControl.GetControlCollection().GetByName(filterItems[i]);
            checkBox.SetChecked(false);
        }
    }
    var filterItems = new Array();
    function OnInit(s, e) {
        filterItems.push(s.name);
    }
</script>
Click on the "Model Date" column to check how this works
@Html.Action("GridViewPartial")
@Html.DevExpress().PopupControl(Sub(settings)
    settings.Name = "PopupControl"
    settings.ShowHeader = false
    settings.AllowDragging = false
    settings.AllowResize = false
    settings.SetContent(Sub()
    Html.RenderPartial("PartialContent")
    End Sub)
End Sub).GetHtml()
