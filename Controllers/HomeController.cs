using carouselCore.Models;
using carouselCore.App_Code;
using Microsoft.AspNetCore.Mvc;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace carouselCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult searchFstData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchFstModels(userData, clientip));
        }

        [HttpPost]
        public JsonResult searchSndData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchSndModels(userData, clientip));
        }

        [HttpPost]
        public JsonResult searchTrdData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchTrdModels(userData, clientip));
        }

        [HttpPost]
        public JsonResult searchFthData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchFthModels(userData, clientip));
        }

        [HttpPost]
        public JsonResult searchFifData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchFifModels(userData, clientip));
        }

        [HttpPost]
        public JsonResult searchSixData([FromBody] userData userData)
        {
            string clientip = Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd() == "::1" ? "127.0.0.1" : Request.HttpContext.Connection.RemoteIpAddress.ToString().TrimEnd();
            return Json(new HomeClass().GetSearchSixModels(userData, clientip));
        }

        public ActionResult execelData()
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            XSSFSheet sheet = (XSSFSheet)workbook.CreateSheet("KIOSK + PC");
            XSSFRow row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("KIOSK + PC");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("Description");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("ID");
            row.CreateCell(4).SetCellValue("Mockup Sample");
            row.CreateCell(5).SetCellValue("TS");
            row.CreateCell(6).SetCellValue("T1");
            row.CreateCell(7).SetCellValue("T1 Sample");
            row.CreateCell(8).SetCellValue("TR Sample");
            database database = new database();
            CheckClass CheckClass = new CheckClass();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "KIOSK"));
            dbparamlist.Add(new dbparam("@category1", "PC POS"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            int i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category in (@category,@category1) and mark = @mark;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd())));
                i++;
            }
            sheet = (XSSFSheet)workbook.CreateSheet("MOBILE");
            row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("MOBILE");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("Description");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("ID");
            row.CreateCell(4).SetCellValue("Mockup Sample");
            row.CreateCell(5).SetCellValue("TS");
            row.CreateCell(6).SetCellValue("T1");
            row.CreateCell(7).SetCellValue("T1 Sample");
            row.CreateCell(8).SetCellValue("TR Sample");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@category", "Mobile"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd())));
                i++;
            }
            sheet = (XSSFSheet)workbook.CreateSheet("POS");
            row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("POS");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("Description");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("ID");
            row.CreateCell(4).SetCellValue("Mockup Sample");
            row.CreateCell(5).SetCellValue("TS");
            row.CreateCell(6).SetCellValue("T1");
            row.CreateCell(7).SetCellValue("T1 Sample");
            row.CreateCell(8).SetCellValue("TR Sample");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@category", "POS"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd())));
                i++;
            }
            sheet = (XSSFSheet)workbook.CreateSheet("PPC");
            row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("PPC");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("Description");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("ID");
            row.CreateCell(4).SetCellValue("Mockup Sample");
            row.CreateCell(5).SetCellValue("TS");
            row.CreateCell(6).SetCellValue("T1");
            row.CreateCell(7).SetCellValue("T1 Sample");
            row.CreateCell(8).SetCellValue("TR Sample");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@category", "PPC"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd())));
                i++;
            }
            sheet = (XSSFSheet)workbook.CreateSheet("PROJECT");
            row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("PROJECT");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("Description");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("ID");
            row.CreateCell(4).SetCellValue("Mockup Sample");
            row.CreateCell(5).SetCellValue("TS");
            row.CreateCell(6).SetCellValue("T1");
            row.CreateCell(7).SetCellValue("T1 Sample");
            row.CreateCell(8).SetCellValue("TR Sample");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@category", "MB / FB"));
            dbparamlist.Add(new dbparam("@mark", "2"));
            dbparamlist.Add(new dbparam("@closedate", ""));
            i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category != @category and mark = @mark and closedate = @closedate;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd())));
                i++;
            }
            sheet = (XSSFSheet)workbook.CreateSheet("MB");
            row = (XSSFRow)sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("MB");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 8));
            row = (XSSFRow)sheet.CreateRow(1);
            row.CreateCell(0).SetCellValue("MODEL");
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(1, 1, 0, 1));
            row.CreateCell(2).SetCellValue("Date");
            row.CreateCell(3).SetCellValue("GERBER OUT V0.9A");
            row.CreateCell(4).SetCellValue("SMT/DIP");
            row.CreateCell(5).SetCellValue("GERBER OUT V0.9B");
            row.CreateCell(6).SetCellValue("SMT/DIP");
            row.CreateCell(7).SetCellValue("GERBER OUT V1.0");
            row.CreateCell(8).SetCellValue("SMT/DIP");
            dbparamlist.Clear();
            dbparamlist.Add(new dbparam("@category", "MB / FB"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            i = 2;
            foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,cino,inpd from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows)
            {
                row = (XSSFRow)sheet.CreateRow(i);
                row.CreateCell(0).SetCellValue(CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(1).SetCellValue(CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()));
                row.CreateCell(2).SetCellValue(CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")));
                row.CreateCell(3).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd())));
                row.CreateCell(4).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty1"].ToString().TrimEnd())));
                row.CreateCell(5).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["qty2t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty2"].ToString().TrimEnd())));
                row.CreateCell(6).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["qty3t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty3"].ToString().TrimEnd())));
                row.CreateCell(7).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["qty4t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty4"].ToString().TrimEnd())));
                row.CreateCell(8).SetCellValue(CheckClass.checkNewObjects(CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd())));
                i++;
            }
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            byte[] bytes = ms.ToArray();
            return File(bytes, "application/vnd.ms-excel", "FLYTECH匯入表單範本.xlsx");
        }
    }
}
