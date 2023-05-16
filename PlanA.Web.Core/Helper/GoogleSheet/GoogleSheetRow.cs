using System.Collections.Generic;

namespace PlanA.Web.Core.Helper;

public class GoogleSheetRow
{
    public GoogleSheetRow() => Cells = new List<GoogleSheetCell>();

    public List<GoogleSheetCell> Cells { get; set; }
}