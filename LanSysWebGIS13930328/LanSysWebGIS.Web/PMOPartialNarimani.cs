using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel.DomainServices.Server;
using System.Web;
using System.Linq.Dynamic;
using System.Data;
using Newtonsoft.Json;

namespace LanSysWebGIS.Web
{
    public partial class PMOService
    {
        [Query]
        public IQueryable<DocFile> GetDocFilesFor(int subjectId)
        {
            return this.ObjectContext.DocFile.Where(i => i.SubjectID == subjectId);
        }

        [Query]
        public IQueryable<DocFile> GetDocFilesBy(string username)
        {
            return this.ObjectContext.DocFile.Where(i => i.AddedByUserName == username);
        }

        [Query]
        public IQueryable<DocTitleUserFilter> GetTitlesFor(int userId)
        {
            return this.ObjectContext.DocTitleUserFilter.Where(i => i.UserId == userId);
        }

        public IQueryable<DocSubjectUserFilter> GetSubjectsFor(int userId)
        {
            return this.ObjectContext.DocSubjectUserFilter.Where(i => i.UserId == userId);
        }

        Random rnd = new Random();

        [Invoke]
        public int GetDocTitleWithMaxId()
        {
            return this.ObjectContext.DocTitleTree.Max(i => i.TitleId) + rnd.Next(1, 200);
        }

        [Invoke]
        public int GetDocSubjectWithMaxId()
        {
            return this.ObjectContext.DocSubjectTree.Max(i => i.SubjectID) + rnd.Next(1, 200);
        }

        [Invoke]
        public int GetKeywordListMaxId()
        {
            return this.ObjectContext.KeyWordList.Max(i => i.Id) + rnd.Next(1, 200);
        }

        [Invoke]
        public int GetDocFileWithMaxId()
        {
            return this.ObjectContext.DocFile.Max(i => i.FileID) + rnd.Next(1, 200);
        }

        [Invoke]
        public int GetAdminUser()
        {
            return this.ObjectContext.tblUsers.Single(i => i.UserID == "aarabsalmani").UsersID;
        }

        [Invoke]
        public void SaveDocSubjectTree(String docSubjectTree, List<int> ostanId, List<int> tblDataTypeId,
            List<int> tblInfoTypeId, List<int> tblPortsId, List<int> zoneId)
        {
            DocSubjectTree currentEntity = JsonConvert.DeserializeObject<DocSubjectTree>(docSubjectTree);

            PMOManageEntities pmoManageEntities = new PMOManageEntities();

            foreach (var item in ostanId)
            {
                currentEntity.Ostan.Add(pmoManageEntities.Ostan.FirstOrDefault(i => i.ID == item));
            }

            foreach (var item in tblDataTypeId)
            {
                currentEntity.tblDataType.Add(pmoManageEntities.tblDataType.FirstOrDefault(i => i.ID == item));
            }

            foreach (var item in tblInfoTypeId)
            {
                currentEntity.tblInfoType.Add(pmoManageEntities.tblInfoType.FirstOrDefault(i => i.ID == item));
            }

            foreach (var item in tblPortsId)
            {
                currentEntity.tblPorts.Add(pmoManageEntities.tblPorts.FirstOrDefault(i => i.ID == item));
            }

            foreach (var item in zoneId)
            {
                currentEntity.Zone.Add(pmoManageEntities.Zone.FirstOrDefault(i => i.ID == item));
            }

            pmoManageEntities.DocSubjectTree.AddObject(currentEntity);

            pmoManageEntities.SaveChanges();

            //return JsonConvert.SerializeObject(currentEntity);
        }


        #region این متد ها رو از پی ام اُ سرویس باید حذف کنی
        public void DeleteDocTitleTree(DocTitleTree docTitleTree)
        {
            if ((docTitleTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTitleTree, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocTitleTree.Attach(docTitleTree);
                this.ObjectContext.DocTitleTree.DeleteObject(docTitleTree);

                var items = this.ObjectContext.DocTitleUserFilter.Where(i => i.TitleId == docTitleTree.TitleId);

                foreach (var item in items)
                {
                    DeleteDocTitleUserFilter(item);
                }
                //this.ObjectContext.DocTitleUserFilter.DeleteObject
            }
        }

        public void InsertDocTitleTree(DocTitleTree docTitleTree)
        {
            if ((docTitleTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTitleTree, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocTitleTree.AddObject(docTitleTree);

                //this.InsertDocTitleUserFilter(new DocTitleUserFilter() { TitleId = docTitleTree.TitleId, UserId = GetAdminUser() });
            }
        }

        public void InsertDocSubjectTree(DocSubjectTree docSubjectTree)
        {
            if ((docSubjectTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectTree, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocSubjectTree.AddObject(docSubjectTree);

                //this.InsertDocSubjectUserFilter(new DocSubjectUserFilter() { SubjectId = docSubjectTree.SubjectID, UserId = GetAdminUser() });
            }
        }

        public void DeleteDocSubjectTree(DocSubjectTree docSubjectTree)
        {
            if ((docSubjectTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectTree, EntityState.Deleted);
            }
            else
            {
                var temp = this.ObjectContext.DocSubjectTree.Single(i => i.SubjectID == docSubjectTree.SubjectID);

                //Removing for FK constraints
                temp.Ostan.Clear();
                temp.tblDataType.Clear();
                temp.tblInfoType.Clear();
                temp.tblPorts.Clear();
                temp.Zone.Clear();

                this.ObjectContext.DocSubjectTree.Attach(temp);

                this.ObjectContext.DocSubjectTree.DeleteObject(temp);

                var items0 = this.ObjectContext.DocSubjectUserFilter.Where(i => i.SubjectId == docSubjectTree.SubjectID);

                foreach (var item in items0)
                {
                    DeleteDocSubjectUserFilter(item);
                }
            }
        }

        public IQueryable<DocSubjectTree> GetDocSubjectTree()
        {
            return this.ObjectContext.DocSubjectTree
                .Include("Ostan").Include("tblDataType").Include("tblInfoType").Include("tblPorts").Include("Zone");
        }

        public IQueryable<tblAdminUsers> GettblAdminUsers()
        {
            return this.ObjectContext.tblAdminUsers;
        }

        public void DeleteDocFile(DocFile docFile)
        {
            if ((docFile.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docFile, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocFile.Attach(docFile);
                this.ObjectContext.DocFile.DeleteObject(docFile);


                var items = this.ObjectContext.DocKeyWord.Where(i => i.FileId == docFile.FileID);

                foreach (var item in items)
                {
                    DeleteDocKeyWord(item);
                }
            }
        }
        #endregion

    }
}