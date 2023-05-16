using Google.Apis.Sheets.v4.Data;
using PeopleForce.Models;
using PlanA.Web.Core.Helper;

namespace PeopleForce.Methods;

public class GoogleSheetsMethods
{
    public void Write(string spreadsheetId, List<InterviewDataModel> interviewList)
    {
        var googleSheetsHelper = new GoogleSheetsHelper("security-details.json", spreadsheetId);
        var rows = new List<GoogleSheetRow>();

        var headerAuthor = new GoogleSheetCell() { CellValue = "Author", IsBold = true };
        var headerDate = new GoogleSheetCell() { CellValue = "Date", IsBold = true };
        var headerLink = new GoogleSheetCell() { CellValue = "Link", IsBold = true };
        rows.Add(new GoogleSheetRow()
        {
            Cells = (new List<GoogleSheetCell>() { headerAuthor, headerDate, headerLink })
        });

        rows.AddRange(interviewList.Select(interview => new GoogleSheetRow()
        {
            Cells = (new List<GoogleSheetCell>()
            {
                new() { CellValue = interview.Author },
                new() { CellValue = interview.Date },
                new() { CellValue = interview.Link }
            })
        }));
        googleSheetsHelper.AddCells(new GoogleSheetParameters() { SheetName = "Interview", RangeColumnStart = 1, RangeRowStart = 1 }, rows);
    }
}