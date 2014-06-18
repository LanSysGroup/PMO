using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.DomainServices.Server;
using System.Web;
using System.Linq.Dynamic;
using System.IO;

namespace LanSysWebGIS.Web
{
    public partial class PMOService
    {
        [Query]
        public List<vwLinkDocs> GetSearchResult(string criteria, string keyword)
        {
            if (!string.IsNullOrEmpty(criteria) && string.IsNullOrEmpty(keyword))
                return this.ObjectContext.vwLinkDocs.Where(criteria, new object[] { }).Take(100).ToList();
            else if (string.IsNullOrEmpty(criteria) && !string.IsNullOrEmpty(keyword))
                return this.ObjectContext.vwLinkDocs.Where(i => i.FullName.Contains(keyword)).Take(100).ToList();
            else if (!string.IsNullOrEmpty(criteria) && !string.IsNullOrEmpty(keyword))
                return this.ObjectContext.vwLinkDocs.Where(criteria, new object[] { }).Where(i => i.FullName.Contains(keyword)).Take(100).ToList();

            return this.ObjectContext.vwLinkDocs.Take(100).ToList();
        }

        [Query]
        public IQueryable<DocFileUserLog> GetDocFileUserLogFor(int fileId)
        {
            return this.ObjectContext.DocFileUserLog.Where(i => i.FileId == fileId);
        }

        public IQueryable<DocFileUserLog> GetDocFileUserLogBy(int userId)
        {
            return this.ObjectContext.DocFileUserLog.Where(i => i.UserId == userId);
        }

        public IQueryable<DocFile> GetDocFilesUnaccepted(int userId)
        {
            return this.ObjectContext.DocFile.Where(i => i.Flag == false).Take(100);
        }

        public IQueryable<DocFile> GetLatestDocFiles(int count)
        {
            return this.ObjectContext.DocFile.OrderByDescending(s => s.DateAdded).Take(100);
        }

        [Invoke]
        public byte[] DownloadFile(string FName)
        {
            System.IO.FileStream fs1 = null;
            fs1 = System.IO.File.Open(FName, FileMode.Open, FileAccess.Read);
            byte[] b1 = new byte[fs1.Length];
            fs1.Read(b1, 0, (int)fs1.Length);
            fs1.Close();
            return b1;
        }

    }
}