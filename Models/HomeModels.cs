using System;
using System.Collections.Generic;
using carouselCore.App_Code;
using System.Data;

namespace carouselCore.Models
{
    public class HomeClass
    {
        public IEnumerable<sDefaModels> GetSearchFstModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "KIOSK"));
            dbparamlist.Add(new dbparam("@category1", "PC POS"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category in (@category,@category1) and mark = @mark;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "KIOSK"));
                dbparamlist.Add(new dbparam("@category1", "PC POS"));
                dbparamlist.Add(new dbparam("@mark", "1"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.market,m.markett,m.t2,m.t2t,m.mp,m.mpt,m.cino,m.t1smpl,m.t1smplt,m.trsmpl,m.trsmplt,m.t1ship,m.t1shipt,m.tr,m.trt,m.inpd from ( select row_number()over(order by category asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category in (@category,@category1) and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    string c0 = dr["c0t"].ToString().TrimEnd().Length < 8 && dr["c0"].ToString().TrimEnd().Length < 8 ? "N" : "Y", c1 = dr["c1t"].ToString().TrimEnd().Length < 8 && dr["c1"].ToString().TrimEnd().Length < 8 ? "N" : "Y";
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0 ? true : dr["qty3"].ToString().TrimEnd().Length > 0 ? true : dr["qty2"].ToString().TrimEnd().Length > 0 ? true : dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd()), dr["t1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd()), dr["t1smpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd()), dr["trsmpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }

        public IEnumerable<sDefaModels> GetSearchSndModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "Mobile"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "Mobile"));
                dbparamlist.Add(new dbparam("@mark", "1"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.market,m.markett,m.t2,m.t2t,m.mp,m.mpt,m.cino,m.t1smpl,m.t1smplt,m.trsmpl,m.trsmplt,m.t1ship,m.t1shipt,m.tr,m.trt,m.inpd from ( select row_number()over(order by category asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    string c0 = dr["c0t"].ToString().TrimEnd().Length < 8 && dr["c0"].ToString().TrimEnd().Length < 8 ? "N" : "Y", c1 = dr["c1t"].ToString().TrimEnd().Length < 8 && dr["c1"].ToString().TrimEnd().Length < 8 ? "N" : "Y";
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0 ? true : dr["qty3"].ToString().TrimEnd().Length > 0 ? true : dr["qty2"].ToString().TrimEnd().Length > 0 ? true : dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd()), dr["t1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd()), dr["t1smpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd()), dr["trsmpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }

        public IEnumerable<sDefaModels> GetSearchTrdModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "POS"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "POS"));
                dbparamlist.Add(new dbparam("@mark", "1"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.market,m.markett,m.t2,m.t2t,m.mp,m.mpt,m.cino,m.t1smpl,m.t1smplt,m.trsmpl,m.trsmplt,m.t1ship,m.t1shipt,m.tr,m.trt,m.inpd from ( select row_number()over(order by category asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    string c0 = dr["c0t"].ToString().TrimEnd().Length < 8 && dr["c0"].ToString().TrimEnd().Length < 8 ? "N" : "Y", c1 = dr["c1t"].ToString().TrimEnd().Length < 8 && dr["c1"].ToString().TrimEnd().Length < 8 ? "N" : "Y";
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0 ? true : dr["qty3"].ToString().TrimEnd().Length > 0 ? true : dr["qty2"].ToString().TrimEnd().Length > 0 ? true : dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd()), dr["t1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd()), dr["t1smpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd()), dr["trsmpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }

        public IEnumerable<sDefaModels> GetSearchFthModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "PPC"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "PPC"));
                dbparamlist.Add(new dbparam("@mark", "1"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.market,m.markett,m.t2,m.t2t,m.mp,m.mpt,m.cino,m.t1smpl,m.t1smplt,m.trsmpl,m.trsmplt,m.t1ship,m.t1shipt,m.tr,m.trt,m.inpd from ( select row_number()over(order by category asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category = @category and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    string c0 = dr["c0t"].ToString().TrimEnd().Length < 8 && dr["c0"].ToString().TrimEnd().Length < 8 ? "N" : "Y", c1 = dr["c1t"].ToString().TrimEnd().Length < 8 && dr["c1"].ToString().TrimEnd().Length < 8 ? "N" : "Y";
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0 ? true : dr["qty3"].ToString().TrimEnd().Length > 0 ? true : dr["qty2"].ToString().TrimEnd().Length > 0 ? true : dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd()), dr["t1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd()), dr["t1smpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd()), dr["trsmpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }

        public IEnumerable<sDefaModels> GetSearchFifModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "MB / FB"));
            dbparamlist.Add(new dbparam("@mark", "2"));
            dbparamlist.Add(new dbparam("@closedate", ""));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category != @category and mark = @mark and closedate = @closedate;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "MB / FB"));
                dbparamlist.Add(new dbparam("@mark", "2"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.market,m.markett,m.t2,m.t2t,m.mp,m.mpt,m.cino,m.t1smpl,m.t1smplt,m.trsmpl,m.trsmplt,m.t1ship,m.t1shipt,m.tr,m.trt,m.inpd from ( select row_number()over(order by category asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,market,markett,t2,t2t,mp,mpt,cino,t1smpl,t1smplt,trsmpl,trsmplt,t1ship,t1shipt,tr,trt,inpd from Web.pmfilem where category != @category and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    string c0 = dr["c0t"].ToString().TrimEnd().Length < 8 && dr["c0"].ToString().TrimEnd().Length < 8 ? "N" : "Y", c1 = dr["c1t"].ToString().TrimEnd().Length < 8 && dr["c1"].ToString().TrimEnd().Length < 8 ? "N" : "Y";
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checktwovalues(dr["qty4"].ToString().TrimEnd(), dr["qty3"].ToString().TrimEnd(), dr["qty2"].ToString().TrimEnd(), dr["qty1"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0 ? true : dr["qty3"].ToString().TrimEnd().Length > 0 ? true : dr["qty2"].ToString().TrimEnd().Length > 0 ? true : dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checktwovalues(dr["qty4t"].ToString().TrimEnd(), dr["qty3t"].ToString().TrimEnd(), dr["qty2t"].ToString().TrimEnd(), dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1"].ToString().TrimEnd()), dr["t1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["t1smpl"].ToString().TrimEnd()), dr["t1smpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["t1smplt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["trsmpl"].ToString().TrimEnd()), dr["trsmpl"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["trsmplt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }

        public IEnumerable<sDefaModels> GetSearchSixModels(userData userData, string cuurip)
        {
            CheckClass CheckClass = new CheckClass();
            database database = new database();
            List<dbparam> dbparamlist = new List<dbparam>();
            dbparamlist.Add(new dbparam("@category", "MB / FB"));
            dbparamlist.Add(new dbparam("@mark", "1"));
            List<object[]> items = new List<object[]>();
            //t: plan / not t: update
            int y = 0, total = int.Parse(database.checkSelectSql("mssql", "flyplmstring", "select count(pmPn) as total from Web.pmfilem where category = @category and mark = @mark;", dbparamlist).Rows[0]["total"].ToString().TrimEnd()), allCount = total % 10 > 0 ? total / 10 + 1 : total / 10;
            bool lineColors = false;
            string beforevalue = "";
            for (int i = 0; i < allCount; i++)
            {
                dbparamlist.Clear();
                dbparamlist.Add(new dbparam("@category", "MB / FB"));
                dbparamlist.Add(new dbparam("@mark", "1"));
                dbparamlist.Add(new dbparam("@closedate", ""));
                dbparamlist.Add(new dbparam("@startid", 10 * i));
                dbparamlist.Add(new dbparam("@endid", 10 * (i + 1)));
                List<object[]> cateitems = new List<object[]>();
                foreach (DataRow dr in database.checkSelectSql("mssql", "flyplmstring", "select m.category,m.pmName,m.customid,m.c0,m.c0t,m.c1,m.c1t,m.idfinal,m.idfinalt,m.qty1,m.qty1t,m.qty2,m.qty2t,m.qty3,m.qty3t,m.qty4,m.qty4t,m.tooling,m.toolingt,m.t1,m.t1t,m.cino,m.inpd from ( select row_number()over(order by inpd+inpt asc) as rowid,category,pmName,customid,c0,c0t,c1,c1t,idfinal,idfinalt,qty1,qty1t,qty2,qty2t,qty3,qty3t,qty4,qty4t,tooling,toolingt,t1,t1t,cino,inpd from Web.pmfilem where category = @category and mark = @mark and closedate = @closedate ) as m where m.rowid between @startid and @endid;", dbparamlist).Rows)
                {
                    lineColors = beforevalue != dr["category"].ToString().TrimEnd();
                    if (beforevalue != dr["category"].ToString().TrimEnd())
                    {
                        beforevalue = dr["category"].ToString().TrimEnd();
                    }
                    cateitems.Add(new object[] { lineColors, CheckClass.checkfstitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checksndtitle(dr["pmName"].ToString().TrimEnd()), CheckClass.checkvalues(dr["inpd"].ToString().TrimEnd().Replace("/", "")), CheckClass.checkvalues(dr["idfinal"].ToString().TrimEnd()), dr["idfinal"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["idfinalt"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty1"].ToString().TrimEnd()), dr["qty1"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["qty1t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty2"].ToString().TrimEnd()), dr["qty2"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["qty2t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty3"].ToString().TrimEnd()), dr["qty3"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["qty3t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["qty4"].ToString().TrimEnd()), dr["qty4"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["qty4t"].ToString().TrimEnd()), CheckClass.checkvalues(dr["tooling"].ToString().TrimEnd()), dr["tooling"].ToString().TrimEnd().Length > 0, CheckClass.checkvalues(dr["toolingt"].ToString().TrimEnd()) });
                    y++;
                }
                items.Add(new object[] { cateitems.ToArray() });
            }
            return new List<sDefaModels> { new sDefaModels() { allCount = allCount == 0 ? 0 : allCount - 1, items = items, status = "istrue" } };
        }
    }
}