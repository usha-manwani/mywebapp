using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCresij.Mobile
{
    public partial class FaultInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData();
        }
        protected void FillData()
        {
            string query = "SELECT sno, IP, fault_knowledge as faultknow, cd.ClassName , priority, " +
                " Grade_Name as GradeName, distName as distName, "
                + "member_Name as memName , phone, description, time, LastUpdated, status as stat " +
                "FROM Fault_Info f   join Class_Details cd on cd.id = f.classID " +
                "join Grade_Details gd on gd.ID = cd.gradeId order by sno";
            DataTable dt = new DataTable();
            //string query = "SELECT [sno],IP,faultknow,cd.ClassName ,[priority],[GradeName],[distName], " +
            //    "[memName] ,[phone],[description],[time],LastUpdated,[stat] " +
            //    "FROM[dbo].[FaultInfo] f join Grade_Details gd on gd.GradeID = f.gradeId " +
            //    "join Class_Details cd on cd.ClassID = f.classID order by sno";
            dt = PopulateTree.ExecuteCommand(query);
            if (dt.Rows.Count > 0)
            {
                gv1Fault.DataSource = dt;
                gv1Fault.DataBind();
            }          
            ViewState["FaultCurrentTable"] = dt;

        }
        protected void Gv1Fault_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv1Fault.PageIndex = e.NewPageIndex;
            FillData();
        }
    }
    
}