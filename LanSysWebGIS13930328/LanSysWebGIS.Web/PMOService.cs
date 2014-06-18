
namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // Implements application logic using the PMOManageEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class PMOService : LinqToEntitiesDomainService<PMOManageEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Applications' query.
        public IQueryable<Applications> GetApplications()
        {
            return this.ObjectContext.Applications;
        }

        public void InsertApplications(Applications applications)
        {
            if ((applications.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(applications, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Applications.AddObject(applications);
            }
        }

        public void UpdateApplications(Applications currentApplications)
        {
            this.ObjectContext.Applications.AttachAsModified(currentApplications, this.ChangeSet.GetOriginal(currentApplications));
        }

        public void DeleteApplications(Applications applications)
        {
            if ((applications.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(applications, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Applications.Attach(applications);
                this.ObjectContext.Applications.DeleteObject(applications);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_DelHgDetail' query.
        public IQueryable<Deliver_DelHgDetail> GetDeliver_DelHgDetail()
        {
            return this.ObjectContext.Deliver_DelHgDetail;
        }

        public void InsertDeliver_DelHgDetail(Deliver_DelHgDetail deliver_DelHgDetail)
        {
            if ((deliver_DelHgDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelHgDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_DelHgDetail.AddObject(deliver_DelHgDetail);
            }
        }

        public void UpdateDeliver_DelHgDetail(Deliver_DelHgDetail currentDeliver_DelHgDetail)
        {
            this.ObjectContext.Deliver_DelHgDetail.AttachAsModified(currentDeliver_DelHgDetail, this.ChangeSet.GetOriginal(currentDeliver_DelHgDetail));
        }

        public void DeleteDeliver_DelHgDetail(Deliver_DelHgDetail deliver_DelHgDetail)
        {
            if ((deliver_DelHgDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelHgDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_DelHgDetail.Attach(deliver_DelHgDetail);
                this.ObjectContext.Deliver_DelHgDetail.DeleteObject(deliver_DelHgDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_DelHoghooghi' query.
        public IQueryable<Deliver_DelHoghooghi> GetDeliver_DelHoghooghi()
        {
            return this.ObjectContext.Deliver_DelHoghooghi;
        }

        public void InsertDeliver_DelHoghooghi(Deliver_DelHoghooghi deliver_DelHoghooghi)
        {
            if ((deliver_DelHoghooghi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelHoghooghi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_DelHoghooghi.AddObject(deliver_DelHoghooghi);
            }
        }

        public void UpdateDeliver_DelHoghooghi(Deliver_DelHoghooghi currentDeliver_DelHoghooghi)
        {
            this.ObjectContext.Deliver_DelHoghooghi.AttachAsModified(currentDeliver_DelHoghooghi, this.ChangeSet.GetOriginal(currentDeliver_DelHoghooghi));
        }

        public void DeleteDeliver_DelHoghooghi(Deliver_DelHoghooghi deliver_DelHoghooghi)
        {
            if ((deliver_DelHoghooghi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelHoghooghi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_DelHoghooghi.Attach(deliver_DelHoghooghi);
                this.ObjectContext.Deliver_DelHoghooghi.DeleteObject(deliver_DelHoghooghi);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_DelStu' query.
        public IQueryable<Deliver_DelStu> GetDeliver_DelStu()
        {
            return this.ObjectContext.Deliver_DelStu;
        }

        public void InsertDeliver_DelStu(Deliver_DelStu deliver_DelStu)
        {
            if ((deliver_DelStu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelStu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_DelStu.AddObject(deliver_DelStu);
            }
        }

        public void UpdateDeliver_DelStu(Deliver_DelStu currentDeliver_DelStu)
        {
            this.ObjectContext.Deliver_DelStu.AttachAsModified(currentDeliver_DelStu, this.ChangeSet.GetOriginal(currentDeliver_DelStu));
        }

        public void DeleteDeliver_DelStu(Deliver_DelStu deliver_DelStu)
        {
            if ((deliver_DelStu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelStu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_DelStu.Attach(deliver_DelStu);
                this.ObjectContext.Deliver_DelStu.DeleteObject(deliver_DelStu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_DelStuDetail' query.
        public IQueryable<Deliver_DelStuDetail> GetDeliver_DelStuDetail()
        {
            return this.ObjectContext.Deliver_DelStuDetail;
        }

        public void InsertDeliver_DelStuDetail(Deliver_DelStuDetail deliver_DelStuDetail)
        {
            if ((deliver_DelStuDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelStuDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_DelStuDetail.AddObject(deliver_DelStuDetail);
            }
        }

        public void UpdateDeliver_DelStuDetail(Deliver_DelStuDetail currentDeliver_DelStuDetail)
        {
            this.ObjectContext.Deliver_DelStuDetail.AttachAsModified(currentDeliver_DelStuDetail, this.ChangeSet.GetOriginal(currentDeliver_DelStuDetail));
        }

        public void DeleteDeliver_DelStuDetail(Deliver_DelStuDetail deliver_DelStuDetail)
        {
            if ((deliver_DelStuDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_DelStuDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_DelStuDetail.Attach(deliver_DelStuDetail);
                this.ObjectContext.Deliver_DelStuDetail.DeleteObject(deliver_DelStuDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_ReqHgDetail' query.
        public IQueryable<Deliver_ReqHgDetail> GetDeliver_ReqHgDetail()
        {
            return this.ObjectContext.Deliver_ReqHgDetail;
        }

        public void InsertDeliver_ReqHgDetail(Deliver_ReqHgDetail deliver_ReqHgDetail)
        {
            if ((deliver_ReqHgDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqHgDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_ReqHgDetail.AddObject(deliver_ReqHgDetail);
            }
        }

        public void UpdateDeliver_ReqHgDetail(Deliver_ReqHgDetail currentDeliver_ReqHgDetail)
        {
            this.ObjectContext.Deliver_ReqHgDetail.AttachAsModified(currentDeliver_ReqHgDetail, this.ChangeSet.GetOriginal(currentDeliver_ReqHgDetail));
        }

        public void DeleteDeliver_ReqHgDetail(Deliver_ReqHgDetail deliver_ReqHgDetail)
        {
            if ((deliver_ReqHgDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqHgDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_ReqHgDetail.Attach(deliver_ReqHgDetail);
                this.ObjectContext.Deliver_ReqHgDetail.DeleteObject(deliver_ReqHgDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_ReqHoghoghi' query.
        public IQueryable<Deliver_ReqHoghoghi> GetDeliver_ReqHoghoghi()
        {
            return this.ObjectContext.Deliver_ReqHoghoghi;
        }

        public void InsertDeliver_ReqHoghoghi(Deliver_ReqHoghoghi deliver_ReqHoghoghi)
        {
            if ((deliver_ReqHoghoghi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqHoghoghi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_ReqHoghoghi.AddObject(deliver_ReqHoghoghi);
            }
        }

        public void UpdateDeliver_ReqHoghoghi(Deliver_ReqHoghoghi currentDeliver_ReqHoghoghi)
        {
            this.ObjectContext.Deliver_ReqHoghoghi.AttachAsModified(currentDeliver_ReqHoghoghi, this.ChangeSet.GetOriginal(currentDeliver_ReqHoghoghi));
        }

        public void DeleteDeliver_ReqHoghoghi(Deliver_ReqHoghoghi deliver_ReqHoghoghi)
        {
            if ((deliver_ReqHoghoghi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqHoghoghi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_ReqHoghoghi.Attach(deliver_ReqHoghoghi);
                this.ObjectContext.Deliver_ReqHoghoghi.DeleteObject(deliver_ReqHoghoghi);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_ReqStu' query.
        public IQueryable<Deliver_ReqStu> GetDeliver_ReqStu()
        {
            return this.ObjectContext.Deliver_ReqStu;
        }

        public void InsertDeliver_ReqStu(Deliver_ReqStu deliver_ReqStu)
        {
            if ((deliver_ReqStu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqStu, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_ReqStu.AddObject(deliver_ReqStu);
            }
        }

        public void UpdateDeliver_ReqStu(Deliver_ReqStu currentDeliver_ReqStu)
        {
            this.ObjectContext.Deliver_ReqStu.AttachAsModified(currentDeliver_ReqStu, this.ChangeSet.GetOriginal(currentDeliver_ReqStu));
        }

        public void DeleteDeliver_ReqStu(Deliver_ReqStu deliver_ReqStu)
        {
            if ((deliver_ReqStu.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqStu, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_ReqStu.Attach(deliver_ReqStu);
                this.ObjectContext.Deliver_ReqStu.DeleteObject(deliver_ReqStu);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Deliver_ReqStuDetail' query.
        public IQueryable<Deliver_ReqStuDetail> GetDeliver_ReqStuDetail()
        {
            return this.ObjectContext.Deliver_ReqStuDetail;
        }

        public void InsertDeliver_ReqStuDetail(Deliver_ReqStuDetail deliver_ReqStuDetail)
        {
            if ((deliver_ReqStuDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqStuDetail, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Deliver_ReqStuDetail.AddObject(deliver_ReqStuDetail);
            }
        }

        public void UpdateDeliver_ReqStuDetail(Deliver_ReqStuDetail currentDeliver_ReqStuDetail)
        {
            this.ObjectContext.Deliver_ReqStuDetail.AttachAsModified(currentDeliver_ReqStuDetail, this.ChangeSet.GetOriginal(currentDeliver_ReqStuDetail));
        }

        public void DeleteDeliver_ReqStuDetail(Deliver_ReqStuDetail deliver_ReqStuDetail)
        {
            if ((deliver_ReqStuDetail.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(deliver_ReqStuDetail, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Deliver_ReqStuDetail.Attach(deliver_ReqStuDetail);
                this.ObjectContext.Deliver_ReqStuDetail.DeleteObject(deliver_ReqStuDetail);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocFile' query.
        public IQueryable<DocFile> GetDocFile()
        {
            return this.ObjectContext.DocFile;
        }

        public void InsertDocFile(DocFile docFile)
        {
            if ((docFile.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docFile, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocFile.AddObject(docFile);
            }
        }

        public void UpdateDocFile(DocFile currentDocFile)
        {
            this.ObjectContext.DocFile.AttachAsModified(currentDocFile, this.ChangeSet.GetOriginal(currentDocFile));
        }

        //public void DeleteDocFile(DocFile docFile)
        //{
        //    if ((docFile.EntityState != EntityState.Detached))
        //    {
        //        this.ObjectContext.ObjectStateManager.ChangeObjectState(docFile, EntityState.Deleted);
        //    }
        //    else
        //    {
        //        this.ObjectContext.DocFile.Attach(docFile);
        //        this.ObjectContext.DocFile.DeleteObject(docFile);
        //    }
        //}

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocKeyWord' query.
        public IQueryable<DocKeyWord> GetDocKeyWord()
        {
            return this.ObjectContext.DocKeyWord;
        }

        public void InsertDocKeyWord(DocKeyWord docKeyWord)
        {
            if ((docKeyWord.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docKeyWord, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocKeyWord.AddObject(docKeyWord);
            }
        }

        public void UpdateDocKeyWord(DocKeyWord currentDocKeyWord)
        {
            this.ObjectContext.DocKeyWord.AttachAsModified(currentDocKeyWord, this.ChangeSet.GetOriginal(currentDocKeyWord));
        }

        public void DeleteDocKeyWord(DocKeyWord docKeyWord)
        {
            if ((docKeyWord.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docKeyWord, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocKeyWord.Attach(docKeyWord);
                this.ObjectContext.DocKeyWord.DeleteObject(docKeyWord);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocLocationTree' query.
        public IQueryable<DocLocationTree> GetDocLocationTree()
        {
            return this.ObjectContext.DocLocationTree;
        }

        public void InsertDocLocationTree(DocLocationTree docLocationTree)
        {
            if ((docLocationTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docLocationTree, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocLocationTree.AddObject(docLocationTree);
            }
        }

        public void UpdateDocLocationTree(DocLocationTree currentDocLocationTree)
        {
            this.ObjectContext.DocLocationTree.AttachAsModified(currentDocLocationTree, this.ChangeSet.GetOriginal(currentDocLocationTree));
        }

        public void DeleteDocLocationTree(DocLocationTree docLocationTree)
        {
            if ((docLocationTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docLocationTree, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocLocationTree.Attach(docLocationTree);
                this.ObjectContext.DocLocationTree.DeleteObject(docLocationTree);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocLocationType' query.
        public IQueryable<DocLocationType> GetDocLocationType()
        {
            return this.ObjectContext.DocLocationType;
        }

        public void InsertDocLocationType(DocLocationType docLocationType)
        {
            if ((docLocationType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docLocationType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocLocationType.AddObject(docLocationType);
            }
        }

        public void UpdateDocLocationType(DocLocationType currentDocLocationType)
        {
            this.ObjectContext.DocLocationType.AttachAsModified(currentDocLocationType, this.ChangeSet.GetOriginal(currentDocLocationType));
        }

        public void DeleteDocLocationType(DocLocationType docLocationType)
        {
            if ((docLocationType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docLocationType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocLocationType.Attach(docLocationType);
                this.ObjectContext.DocLocationType.DeleteObject(docLocationType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocSubjectLocationFilter' query.
        public IQueryable<DocSubjectLocationFilter> GetDocSubjectLocationFilter()
        {
            return this.ObjectContext.DocSubjectLocationFilter;
        }

        public void InsertDocSubjectLocationFilter(DocSubjectLocationFilter docSubjectLocationFilter)
        {
            if ((docSubjectLocationFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectLocationFilter, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocSubjectLocationFilter.AddObject(docSubjectLocationFilter);
            }
        }

        public void UpdateDocSubjectLocationFilter(DocSubjectLocationFilter currentDocSubjectLocationFilter)
        {
            this.ObjectContext.DocSubjectLocationFilter.AttachAsModified(currentDocSubjectLocationFilter, this.ChangeSet.GetOriginal(currentDocSubjectLocationFilter));
        }

        public void DeleteDocSubjectLocationFilter(DocSubjectLocationFilter docSubjectLocationFilter)
        {
            if ((docSubjectLocationFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectLocationFilter, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocSubjectLocationFilter.Attach(docSubjectLocationFilter);
                this.ObjectContext.DocSubjectLocationFilter.DeleteObject(docSubjectLocationFilter);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocSubjectTree' query.
        //public IQueryable<DocSubjectTree> GetDocSubjectTree()
        //{
        //    return this.ObjectContext.DocSubjectTree;
        //}

        public void UpdateDocSubjectTree(DocSubjectTree currentDocSubjectTree)
        {
            this.ObjectContext.DocSubjectTree.AttachAsModified(currentDocSubjectTree, this.ChangeSet.GetOriginal(currentDocSubjectTree));
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocSubjectUserFilter' query.
        public IQueryable<DocSubjectUserFilter> GetDocSubjectUserFilter()
        {
            return this.ObjectContext.DocSubjectUserFilter;
        }

        public void InsertDocSubjectUserFilter(DocSubjectUserFilter docSubjectUserFilter)
        {
            if ((docSubjectUserFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectUserFilter, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocSubjectUserFilter.AddObject(docSubjectUserFilter);
            }
        }

        public void UpdateDocSubjectUserFilter(DocSubjectUserFilter currentDocSubjectUserFilter)
        {
            this.ObjectContext.DocSubjectUserFilter.AttachAsModified(currentDocSubjectUserFilter, this.ChangeSet.GetOriginal(currentDocSubjectUserFilter));
        }

        public void DeleteDocSubjectUserFilter(DocSubjectUserFilter docSubjectUserFilter)
        {
            if ((docSubjectUserFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docSubjectUserFilter, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocSubjectUserFilter.Attach(docSubjectUserFilter);
                this.ObjectContext.DocSubjectUserFilter.DeleteObject(docSubjectUserFilter);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocTitleTree' query.
        public IQueryable<DocTitleTree> GetDocTitleTree()
        {
            return this.ObjectContext.DocTitleTree;
        }

        public void UpdateDocTitleTree(DocTitleTree currentDocTitleTree)
        {
            this.ObjectContext.DocTitleTree.AttachAsModified(currentDocTitleTree, this.ChangeSet.GetOriginal(currentDocTitleTree));
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocTitleUserFilter' query.
        public IQueryable<DocTitleUserFilter> GetDocTitleUserFilter()
        {
            return this.ObjectContext.DocTitleUserFilter;
        }

        public void InsertDocTitleUserFilter(DocTitleUserFilter docTitleUserFilter)
        {
            if ((docTitleUserFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTitleUserFilter, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocTitleUserFilter.AddObject(docTitleUserFilter);
            }
        }

        public void UpdateDocTitleUserFilter(DocTitleUserFilter currentDocTitleUserFilter)
        {
            this.ObjectContext.DocTitleUserFilter.AttachAsModified(currentDocTitleUserFilter, this.ChangeSet.GetOriginal(currentDocTitleUserFilter));
        }

        public void DeleteDocTitleUserFilter(DocTitleUserFilter docTitleUserFilter)
        {
            if ((docTitleUserFilter.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTitleUserFilter, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocTitleUserFilter.Attach(docTitleUserFilter);
                this.ObjectContext.DocTitleUserFilter.DeleteObject(docTitleUserFilter);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocTree' query.
        public IQueryable<DocTree> GetDocTree()
        {
            return this.ObjectContext.DocTree;
        }

        public void InsertDocTree(DocTree docTree)
        {
            if ((docTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTree, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocTree.AddObject(docTree);
            }
        }

        public void UpdateDocTree(DocTree currentDocTree)
        {
            this.ObjectContext.DocTree.AttachAsModified(currentDocTree, this.ChangeSet.GetOriginal(currentDocTree));
        }

        public void DeleteDocTree(DocTree docTree)
        {
            if ((docTree.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docTree, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocTree.Attach(docTree);
                this.ObjectContext.DocTree.DeleteObject(docTree);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EskelehStrucType' query.
        public IQueryable<EskelehStrucType> GetEskelehStrucType()
        {
            return this.ObjectContext.EskelehStrucType;
        }

        public void InsertEskelehStrucType(EskelehStrucType eskelehStrucType)
        {
            if ((eskelehStrucType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(eskelehStrucType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EskelehStrucType.AddObject(eskelehStrucType);
            }
        }

        public void UpdateEskelehStrucType(EskelehStrucType currentEskelehStrucType)
        {
            this.ObjectContext.EskelehStrucType.AttachAsModified(currentEskelehStrucType, this.ChangeSet.GetOriginal(currentEskelehStrucType));
        }

        public void DeleteEskelehStrucType(EskelehStrucType eskelehStrucType)
        {
            if ((eskelehStrucType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(eskelehStrucType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EskelehStrucType.Attach(eskelehStrucType);
                this.ObjectContext.EskelehStrucType.DeleteObject(eskelehStrucType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Attach' query.
        public IQueryable<ICOPMAS_Attach> GetICOPMAS_Attach()
        {
            return this.ObjectContext.ICOPMAS_Attach;
        }

        public void InsertICOPMAS_Attach(ICOPMAS_Attach iCOPMAS_Attach)
        {
            if ((iCOPMAS_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Attach, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Attach.AddObject(iCOPMAS_Attach);
            }
        }

        public void UpdateICOPMAS_Attach(ICOPMAS_Attach currentICOPMAS_Attach)
        {
            this.ObjectContext.ICOPMAS_Attach.AttachAsModified(currentICOPMAS_Attach, this.ChangeSet.GetOriginal(currentICOPMAS_Attach));
        }

        public void DeleteICOPMAS_Attach(ICOPMAS_Attach iCOPMAS_Attach)
        {
            if ((iCOPMAS_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Attach, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Attach.Attach(iCOPMAS_Attach);
                this.ObjectContext.ICOPMAS_Attach.DeleteObject(iCOPMAS_Attach);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Keyword' query.
        public IQueryable<ICOPMAS_Keyword> GetICOPMAS_Keyword()
        {
            return this.ObjectContext.ICOPMAS_Keyword;
        }

        public void InsertICOPMAS_Keyword(ICOPMAS_Keyword iCOPMAS_Keyword)
        {
            if ((iCOPMAS_Keyword.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Keyword, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Keyword.AddObject(iCOPMAS_Keyword);
            }
        }

        public void UpdateICOPMAS_Keyword(ICOPMAS_Keyword currentICOPMAS_Keyword)
        {
            this.ObjectContext.ICOPMAS_Keyword.AttachAsModified(currentICOPMAS_Keyword, this.ChangeSet.GetOriginal(currentICOPMAS_Keyword));
        }

        public void DeleteICOPMAS_Keyword(ICOPMAS_Keyword iCOPMAS_Keyword)
        {
            if ((iCOPMAS_Keyword.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Keyword, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Keyword.Attach(iCOPMAS_Keyword);
                this.ObjectContext.ICOPMAS_Keyword.DeleteObject(iCOPMAS_Keyword);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Season' query.
        public IQueryable<ICOPMAS_Season> GetICOPMAS_Season()
        {
            return this.ObjectContext.ICOPMAS_Season;
        }

        public void InsertICOPMAS_Season(ICOPMAS_Season iCOPMAS_Season)
        {
            if ((iCOPMAS_Season.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Season, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Season.AddObject(iCOPMAS_Season);
            }
        }

        public void UpdateICOPMAS_Season(ICOPMAS_Season currentICOPMAS_Season)
        {
            this.ObjectContext.ICOPMAS_Season.AttachAsModified(currentICOPMAS_Season, this.ChangeSet.GetOriginal(currentICOPMAS_Season));
        }

        public void DeleteICOPMAS_Season(ICOPMAS_Season iCOPMAS_Season)
        {
            if ((iCOPMAS_Season.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Season, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Season.Attach(iCOPMAS_Season);
                this.ObjectContext.ICOPMAS_Season.DeleteObject(iCOPMAS_Season);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Spec' query.
        public IQueryable<ICOPMAS_Spec> GetICOPMAS_Spec()
        {
            return this.ObjectContext.ICOPMAS_Spec;
        }

        public void InsertICOPMAS_Spec(ICOPMAS_Spec iCOPMAS_Spec)
        {
            if ((iCOPMAS_Spec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Spec, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Spec.AddObject(iCOPMAS_Spec);
            }
        }

        public void UpdateICOPMAS_Spec(ICOPMAS_Spec currentICOPMAS_Spec)
        {
            this.ObjectContext.ICOPMAS_Spec.AttachAsModified(currentICOPMAS_Spec, this.ChangeSet.GetOriginal(currentICOPMAS_Spec));
        }

        public void DeleteICOPMAS_Spec(ICOPMAS_Spec iCOPMAS_Spec)
        {
            if ((iCOPMAS_Spec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Spec, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Spec.Attach(iCOPMAS_Spec);
                this.ObjectContext.ICOPMAS_Spec.DeleteObject(iCOPMAS_Spec);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Type' query.
        public IQueryable<ICOPMAS_Type> GetICOPMAS_Type()
        {
            return this.ObjectContext.ICOPMAS_Type;
        }

        public void InsertICOPMAS_Type(ICOPMAS_Type iCOPMAS_Type)
        {
            if ((iCOPMAS_Type.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Type, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Type.AddObject(iCOPMAS_Type);
            }
        }

        public void UpdateICOPMAS_Type(ICOPMAS_Type currentICOPMAS_Type)
        {
            this.ObjectContext.ICOPMAS_Type.AttachAsModified(currentICOPMAS_Type, this.ChangeSet.GetOriginal(currentICOPMAS_Type));
        }

        public void DeleteICOPMAS_Type(ICOPMAS_Type iCOPMAS_Type)
        {
            if ((iCOPMAS_Type.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Type, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Type.Attach(iCOPMAS_Type);
                this.ObjectContext.ICOPMAS_Type.DeleteObject(iCOPMAS_Type);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ICOPMAS_Writer' query.
        public IQueryable<ICOPMAS_Writer> GetICOPMAS_Writer()
        {
            return this.ObjectContext.ICOPMAS_Writer;
        }

        public void InsertICOPMAS_Writer(ICOPMAS_Writer iCOPMAS_Writer)
        {
            if ((iCOPMAS_Writer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Writer, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Writer.AddObject(iCOPMAS_Writer);
            }
        }

        public void UpdateICOPMAS_Writer(ICOPMAS_Writer currentICOPMAS_Writer)
        {
            this.ObjectContext.ICOPMAS_Writer.AttachAsModified(currentICOPMAS_Writer, this.ChangeSet.GetOriginal(currentICOPMAS_Writer));
        }

        public void DeleteICOPMAS_Writer(ICOPMAS_Writer iCOPMAS_Writer)
        {
            if ((iCOPMAS_Writer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(iCOPMAS_Writer, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ICOPMAS_Writer.Attach(iCOPMAS_Writer);
                this.ObjectContext.ICOPMAS_Writer.DeleteObject(iCOPMAS_Writer);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'KeyWordList' query.
        public IQueryable<KeyWordList> GetKeyWordList()
        {
            return this.ObjectContext.KeyWordList;
        }

        public void InsertKeyWordList(KeyWordList keyWordList)
        {
            if ((keyWordList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(keyWordList, EntityState.Added);
            }
            else
            {
                this.ObjectContext.KeyWordList.AddObject(keyWordList);
            }
        }

        public void UpdateKeyWordList(KeyWordList currentKeyWordList)
        {
            this.ObjectContext.KeyWordList.AttachAsModified(currentKeyWordList, this.ChangeSet.GetOriginal(currentKeyWordList));
        }

        public void DeleteKeyWordList(KeyWordList keyWordList)
        {
            if ((keyWordList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(keyWordList, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.KeyWordList.Attach(keyWordList);
                this.ObjectContext.KeyWordList.DeleteObject(keyWordList);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Log_UserAction' query.
        public IQueryable<Log_UserAction> GetLog_UserAction()
        {
            return this.ObjectContext.Log_UserAction;
        }

        public void InsertLog_UserAction(Log_UserAction log_UserAction)
        {
            if ((log_UserAction.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(log_UserAction, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Log_UserAction.AddObject(log_UserAction);
            }
        }

        public void UpdateLog_UserAction(Log_UserAction currentLog_UserAction)
        {
            this.ObjectContext.Log_UserAction.AttachAsModified(currentLog_UserAction, this.ChangeSet.GetOriginal(currentLog_UserAction));
        }

        public void DeleteLog_UserAction(Log_UserAction log_UserAction)
        {
            if ((log_UserAction.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(log_UserAction, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Log_UserAction.Attach(log_UserAction);
                this.ObjectContext.Log_UserAction.DeleteObject(log_UserAction);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Log_UserInOut' query.
        public IQueryable<Log_UserInOut> GetLog_UserInOut()
        {
            return this.ObjectContext.Log_UserInOut;
        }

        public void InsertLog_UserInOut(Log_UserInOut log_UserInOut)
        {
            if ((log_UserInOut.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(log_UserInOut, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Log_UserInOut.AddObject(log_UserInOut);
            }
        }

        public void UpdateLog_UserInOut(Log_UserInOut currentLog_UserInOut)
        {
            this.ObjectContext.Log_UserInOut.AttachAsModified(currentLog_UserInOut, this.ChangeSet.GetOriginal(currentLog_UserInOut));
        }

        public void DeleteLog_UserInOut(Log_UserInOut log_UserInOut)
        {
            if ((log_UserInOut.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(log_UserInOut, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Log_UserInOut.Attach(log_UserInOut);
                this.ObjectContext.Log_UserInOut.DeleteObject(log_UserInOut);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Memberships' query.
        public IQueryable<Memberships> GetMemberships()
        {
            return this.ObjectContext.Memberships;
        }

        public void InsertMemberships(Memberships memberships)
        {
            if ((memberships.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(memberships, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Memberships.AddObject(memberships);
            }
        }

        public void UpdateMemberships(Memberships currentMemberships)
        {
            this.ObjectContext.Memberships.AttachAsModified(currentMemberships, this.ChangeSet.GetOriginal(currentMemberships));
        }

        public void DeleteMemberships(Memberships memberships)
        {
            if ((memberships.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(memberships, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Memberships.Attach(memberships);
                this.ObjectContext.Memberships.DeleteObject(memberships);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_Attach' query.
        public IQueryable<Mojavez_Attach> GetMojavez_Attach()
        {
            return this.ObjectContext.Mojavez_Attach;
        }

        public void InsertMojavez_Attach(Mojavez_Attach mojavez_Attach)
        {
            if ((mojavez_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_Attach, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_Attach.AddObject(mojavez_Attach);
            }
        }

        public void UpdateMojavez_Attach(Mojavez_Attach currentMojavez_Attach)
        {
            this.ObjectContext.Mojavez_Attach.AttachAsModified(currentMojavez_Attach, this.ChangeSet.GetOriginal(currentMojavez_Attach));
        }

        public void DeleteMojavez_Attach(Mojavez_Attach mojavez_Attach)
        {
            if ((mojavez_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_Attach, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_Attach.Attach(mojavez_Attach);
                this.ObjectContext.Mojavez_Attach.DeleteObject(mojavez_Attach);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_Attach_Files' query.
        public IQueryable<Mojavez_Attach_Files> GetMojavez_Attach_Files()
        {
            return this.ObjectContext.Mojavez_Attach_Files;
        }

        public void InsertMojavez_Attach_Files(Mojavez_Attach_Files mojavez_Attach_Files)
        {
            if ((mojavez_Attach_Files.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_Attach_Files, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_Attach_Files.AddObject(mojavez_Attach_Files);
            }
        }

        public void UpdateMojavez_Attach_Files(Mojavez_Attach_Files currentMojavez_Attach_Files)
        {
            this.ObjectContext.Mojavez_Attach_Files.AttachAsModified(currentMojavez_Attach_Files, this.ChangeSet.GetOriginal(currentMojavez_Attach_Files));
        }

        public void DeleteMojavez_Attach_Files(Mojavez_Attach_Files mojavez_Attach_Files)
        {
            if ((mojavez_Attach_Files.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_Attach_Files, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_Attach_Files.Attach(mojavez_Attach_Files);
                this.ObjectContext.Mojavez_Attach_Files.DeleteObject(mojavez_Attach_Files);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_DocType' query.
        public IQueryable<Mojavez_DocType> GetMojavez_DocType()
        {
            return this.ObjectContext.Mojavez_DocType;
        }

        public void InsertMojavez_DocType(Mojavez_DocType mojavez_DocType)
        {
            if ((mojavez_DocType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_DocType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_DocType.AddObject(mojavez_DocType);
            }
        }

        public void UpdateMojavez_DocType(Mojavez_DocType currentMojavez_DocType)
        {
            this.ObjectContext.Mojavez_DocType.AttachAsModified(currentMojavez_DocType, this.ChangeSet.GetOriginal(currentMojavez_DocType));
        }

        public void DeleteMojavez_DocType(Mojavez_DocType mojavez_DocType)
        {
            if ((mojavez_DocType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_DocType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_DocType.Attach(mojavez_DocType);
                this.ObjectContext.Mojavez_DocType.DeleteObject(mojavez_DocType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_DocTypeRelation' query.
        public IQueryable<Mojavez_DocTypeRelation> GetMojavez_DocTypeRelation()
        {
            return this.ObjectContext.Mojavez_DocTypeRelation;
        }

        public void InsertMojavez_DocTypeRelation(Mojavez_DocTypeRelation mojavez_DocTypeRelation)
        {
            if ((mojavez_DocTypeRelation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_DocTypeRelation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_DocTypeRelation.AddObject(mojavez_DocTypeRelation);
            }
        }

        public void UpdateMojavez_DocTypeRelation(Mojavez_DocTypeRelation currentMojavez_DocTypeRelation)
        {
            this.ObjectContext.Mojavez_DocTypeRelation.AttachAsModified(currentMojavez_DocTypeRelation, this.ChangeSet.GetOriginal(currentMojavez_DocTypeRelation));
        }

        public void DeleteMojavez_DocTypeRelation(Mojavez_DocTypeRelation mojavez_DocTypeRelation)
        {
            if ((mojavez_DocTypeRelation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_DocTypeRelation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_DocTypeRelation.Attach(mojavez_DocTypeRelation);
                this.ObjectContext.Mojavez_DocTypeRelation.DeleteObject(mojavez_DocTypeRelation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_PlanDoc' query.
        public IQueryable<Mojavez_PlanDoc> GetMojavez_PlanDoc()
        {
            return this.ObjectContext.Mojavez_PlanDoc;
        }

        public void InsertMojavez_PlanDoc(Mojavez_PlanDoc mojavez_PlanDoc)
        {
            if ((mojavez_PlanDoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_PlanDoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_PlanDoc.AddObject(mojavez_PlanDoc);
            }
        }

        public void UpdateMojavez_PlanDoc(Mojavez_PlanDoc currentMojavez_PlanDoc)
        {
            this.ObjectContext.Mojavez_PlanDoc.AttachAsModified(currentMojavez_PlanDoc, this.ChangeSet.GetOriginal(currentMojavez_PlanDoc));
        }

        public void DeleteMojavez_PlanDoc(Mojavez_PlanDoc mojavez_PlanDoc)
        {
            if ((mojavez_PlanDoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_PlanDoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_PlanDoc.Attach(mojavez_PlanDoc);
                this.ObjectContext.Mojavez_PlanDoc.DeleteObject(mojavez_PlanDoc);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_PlanSpec' query.
        public IQueryable<Mojavez_PlanSpec> GetMojavez_PlanSpec()
        {
            return this.ObjectContext.Mojavez_PlanSpec;
        }

        public void InsertMojavez_PlanSpec(Mojavez_PlanSpec mojavez_PlanSpec)
        {
            if ((mojavez_PlanSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_PlanSpec, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_PlanSpec.AddObject(mojavez_PlanSpec);
            }
        }

        public void UpdateMojavez_PlanSpec(Mojavez_PlanSpec currentMojavez_PlanSpec)
        {
            this.ObjectContext.Mojavez_PlanSpec.AttachAsModified(currentMojavez_PlanSpec, this.ChangeSet.GetOriginal(currentMojavez_PlanSpec));
        }

        public void DeleteMojavez_PlanSpec(Mojavez_PlanSpec mojavez_PlanSpec)
        {
            if ((mojavez_PlanSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_PlanSpec, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_PlanSpec.Attach(mojavez_PlanSpec);
                this.ObjectContext.Mojavez_PlanSpec.DeleteObject(mojavez_PlanSpec);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_RequestType' query.
        public IQueryable<Mojavez_RequestType> GetMojavez_RequestType()
        {
            return this.ObjectContext.Mojavez_RequestType;
        }

        public void InsertMojavez_RequestType(Mojavez_RequestType mojavez_RequestType)
        {
            if ((mojavez_RequestType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_RequestType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_RequestType.AddObject(mojavez_RequestType);
            }
        }

        public void UpdateMojavez_RequestType(Mojavez_RequestType currentMojavez_RequestType)
        {
            this.ObjectContext.Mojavez_RequestType.AttachAsModified(currentMojavez_RequestType, this.ChangeSet.GetOriginal(currentMojavez_RequestType));
        }

        public void DeleteMojavez_RequestType(Mojavez_RequestType mojavez_RequestType)
        {
            if ((mojavez_RequestType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_RequestType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_RequestType.Attach(mojavez_RequestType);
                this.ObjectContext.Mojavez_RequestType.DeleteObject(mojavez_RequestType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Mojavez_UsageType' query.
        public IQueryable<Mojavez_UsageType> GetMojavez_UsageType()
        {
            return this.ObjectContext.Mojavez_UsageType;
        }

        public void InsertMojavez_UsageType(Mojavez_UsageType mojavez_UsageType)
        {
            if ((mojavez_UsageType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_UsageType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Mojavez_UsageType.AddObject(mojavez_UsageType);
            }
        }

        public void UpdateMojavez_UsageType(Mojavez_UsageType currentMojavez_UsageType)
        {
            this.ObjectContext.Mojavez_UsageType.AttachAsModified(currentMojavez_UsageType, this.ChangeSet.GetOriginal(currentMojavez_UsageType));
        }

        public void DeleteMojavez_UsageType(Mojavez_UsageType mojavez_UsageType)
        {
            if ((mojavez_UsageType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojavez_UsageType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Mojavez_UsageType.Attach(mojavez_UsageType);
                this.ObjectContext.Mojavez_UsageType.DeleteObject(mojavez_UsageType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'MojshekanStrucType' query.
        public IQueryable<MojshekanStrucType> GetMojshekanStrucType()
        {
            return this.ObjectContext.MojshekanStrucType;
        }

        public void InsertMojshekanStrucType(MojshekanStrucType mojshekanStrucType)
        {
            if ((mojshekanStrucType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojshekanStrucType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MojshekanStrucType.AddObject(mojshekanStrucType);
            }
        }

        public void UpdateMojshekanStrucType(MojshekanStrucType currentMojshekanStrucType)
        {
            this.ObjectContext.MojshekanStrucType.AttachAsModified(currentMojshekanStrucType, this.ChangeSet.GetOriginal(currentMojshekanStrucType));
        }

        public void DeleteMojshekanStrucType(MojshekanStrucType mojshekanStrucType)
        {
            if ((mojshekanStrucType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mojshekanStrucType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MojshekanStrucType.Attach(mojshekanStrucType);
                this.ObjectContext.MojshekanStrucType.DeleteObject(mojshekanStrucType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Organizations' query.
        public IQueryable<Organizations> GetOrganizations()
        {
            return this.ObjectContext.Organizations;
        }

        public void InsertOrganizations(Organizations organizations)
        {
            if ((organizations.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(organizations, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Organizations.AddObject(organizations);
            }
        }

        public void UpdateOrganizations(Organizations currentOrganizations)
        {
            this.ObjectContext.Organizations.AttachAsModified(currentOrganizations, this.ChangeSet.GetOriginal(currentOrganizations));
        }

        public void DeleteOrganizations(Organizations organizations)
        {
            if ((organizations.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(organizations, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Organizations.Attach(organizations);
                this.ObjectContext.Organizations.DeleteObject(organizations);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ostan' query.
        public IQueryable<Ostan> GetOstan()
        {
            return this.ObjectContext.Ostan;
        }

        public void InsertOstan(Ostan ostan)
        {
            if ((ostan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ostan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ostan.AddObject(ostan);
            }
        }

        public void UpdateOstan(Ostan currentOstan)
        {
            this.ObjectContext.Ostan.AttachAsModified(currentOstan, this.ChangeSet.GetOriginal(currentOstan));
        }

        public void DeleteOstan(Ostan ostan)
        {
            if ((ostan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ostan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ostan.Attach(ostan);
                this.ObjectContext.Ostan.DeleteObject(ostan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ParamDefinition' query.
        public IQueryable<ParamDefinition> GetParamDefinition()
        {
            return this.ObjectContext.ParamDefinition;
        }

        public void InsertParamDefinition(ParamDefinition paramDefinition)
        {
            if ((paramDefinition.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(paramDefinition, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ParamDefinition.AddObject(paramDefinition);
            }
        }

        public void UpdateParamDefinition(ParamDefinition currentParamDefinition)
        {
            this.ObjectContext.ParamDefinition.AttachAsModified(currentParamDefinition, this.ChangeSet.GetOriginal(currentParamDefinition));
        }

        public void DeleteParamDefinition(ParamDefinition paramDefinition)
        {
            if ((paramDefinition.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(paramDefinition, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ParamDefinition.Attach(paramDefinition);
                this.ObjectContext.ParamDefinition.DeleteObject(paramDefinition);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PortEskeleh' query.
        public IQueryable<PortEskeleh> GetPortEskeleh()
        {
            return this.ObjectContext.PortEskeleh;
        }

        public void InsertPortEskeleh(PortEskeleh portEskeleh)
        {
            if ((portEskeleh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portEskeleh, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PortEskeleh.AddObject(portEskeleh);
            }
        }

        public void UpdatePortEskeleh(PortEskeleh currentPortEskeleh)
        {
            this.ObjectContext.PortEskeleh.AttachAsModified(currentPortEskeleh, this.ChangeSet.GetOriginal(currentPortEskeleh));
        }

        public void DeletePortEskeleh(PortEskeleh portEskeleh)
        {
            if ((portEskeleh.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portEskeleh, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PortEskeleh.Attach(portEskeleh);
                this.ObjectContext.PortEskeleh.DeleteObject(portEskeleh);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PortInfo' query.
        public IQueryable<PortInfo> GetPortInfo()
        {
            return this.ObjectContext.PortInfo;
        }

        public void InsertPortInfo(PortInfo portInfo)
        {
            if ((portInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portInfo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PortInfo.AddObject(portInfo);
            }
        }

        public void UpdatePortInfo(PortInfo currentPortInfo)
        {
            this.ObjectContext.PortInfo.AttachAsModified(currentPortInfo, this.ChangeSet.GetOriginal(currentPortInfo));
        }

        public void DeletePortInfo(PortInfo portInfo)
        {
            if ((portInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portInfo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PortInfo.Attach(portInfo);
                this.ObjectContext.PortInfo.DeleteObject(portInfo);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PortMojshekan' query.
        public IQueryable<PortMojshekan> GetPortMojshekan()
        {
            return this.ObjectContext.PortMojshekan;
        }

        public void InsertPortMojshekan(PortMojshekan portMojshekan)
        {
            if ((portMojshekan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portMojshekan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PortMojshekan.AddObject(portMojshekan);
            }
        }

        public void UpdatePortMojshekan(PortMojshekan currentPortMojshekan)
        {
            this.ObjectContext.PortMojshekan.AttachAsModified(currentPortMojshekan, this.ChangeSet.GetOriginal(currentPortMojshekan));
        }

        public void DeletePortMojshekan(PortMojshekan portMojshekan)
        {
            if ((portMojshekan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portMojshekan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PortMojshekan.Attach(portMojshekan);
                this.ObjectContext.PortMojshekan.DeleteObject(portMojshekan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PortSpec' query.
        public IQueryable<PortSpec> GetPortSpec()
        {
            return this.ObjectContext.PortSpec;
        }

        public void InsertPortSpec(PortSpec portSpec)
        {
            if ((portSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portSpec, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PortSpec.AddObject(portSpec);
            }
        }

        public void UpdatePortSpec(PortSpec currentPortSpec)
        {
            this.ObjectContext.PortSpec.AttachAsModified(currentPortSpec, this.ChangeSet.GetOriginal(currentPortSpec));
        }

        public void DeletePortSpec(PortSpec portSpec)
        {
            if ((portSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portSpec, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PortSpec.Attach(portSpec);
                this.ObjectContext.PortSpec.DeleteObject(portSpec);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PortStructure' query.
        public IQueryable<PortStructure> GetPortStructure()
        {
            return this.ObjectContext.PortStructure;
        }

        public void InsertPortStructure(PortStructure portStructure)
        {
            if ((portStructure.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portStructure, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PortStructure.AddObject(portStructure);
            }
        }

        public void UpdatePortStructure(PortStructure currentPortStructure)
        {
            this.ObjectContext.PortStructure.AttachAsModified(currentPortStructure, this.ChangeSet.GetOriginal(currentPortStructure));
        }

        public void DeletePortStructure(PortStructure portStructure)
        {
            if ((portStructure.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(portStructure, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PortStructure.Attach(portStructure);
                this.ObjectContext.PortStructure.DeleteObject(portStructure);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Profiles' query.
        public IQueryable<Profiles> GetProfiles()
        {
            return this.ObjectContext.Profiles;
        }

        public void InsertProfiles(Profiles profiles)
        {
            if ((profiles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(profiles, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Profiles.AddObject(profiles);
            }
        }

        public void UpdateProfiles(Profiles currentProfiles)
        {
            this.ObjectContext.Profiles.AttachAsModified(currentProfiles, this.ChangeSet.GetOriginal(currentProfiles));
        }

        public void DeleteProfiles(Profiles profiles)
        {
            if ((profiles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(profiles, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Profiles.Attach(profiles);
                this.ObjectContext.Profiles.DeleteObject(profiles);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Projects' query.
        public IQueryable<Projects> GetProjects()
        {
            return this.ObjectContext.Projects;
        }

        public void InsertProjects(Projects projects)
        {
            if ((projects.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(projects, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Projects.AddObject(projects);
            }
        }

        public void UpdateProjects(Projects currentProjects)
        {
            this.ObjectContext.Projects.AttachAsModified(currentProjects, this.ChangeSet.GetOriginal(currentProjects));
        }

        public void DeleteProjects(Projects projects)
        {
            if ((projects.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(projects, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Projects.Attach(projects);
                this.ObjectContext.Projects.DeleteObject(projects);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'RoadType' query.
        public IQueryable<RoadType> GetRoadType()
        {
            return this.ObjectContext.RoadType;
        }

        public void InsertRoadType(RoadType roadType)
        {
            if ((roadType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(roadType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.RoadType.AddObject(roadType);
            }
        }

        public void UpdateRoadType(RoadType currentRoadType)
        {
            this.ObjectContext.RoadType.AttachAsModified(currentRoadType, this.ChangeSet.GetOriginal(currentRoadType));
        }

        public void DeleteRoadType(RoadType roadType)
        {
            if ((roadType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(roadType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.RoadType.Attach(roadType);
                this.ObjectContext.RoadType.DeleteObject(roadType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Shahrestan' query.
        public IQueryable<Shahrestan> GetShahrestan()
        {
            return this.ObjectContext.Shahrestan;
        }

        public void InsertShahrestan(Shahrestan shahrestan)
        {
            if ((shahrestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(shahrestan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Shahrestan.AddObject(shahrestan);
            }
        }

        public void UpdateShahrestan(Shahrestan currentShahrestan)
        {
            this.ObjectContext.Shahrestan.AttachAsModified(currentShahrestan, this.ChangeSet.GetOriginal(currentShahrestan));
        }

        public void DeleteShahrestan(Shahrestan shahrestan)
        {
            if ((shahrestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(shahrestan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Shahrestan.Attach(shahrestan);
                this.ObjectContext.Shahrestan.DeleteObject(shahrestan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SpatialServices' query.
        public IQueryable<SpatialServices> GetSpatialServices()
        {
            return this.ObjectContext.SpatialServices;
        }

        public void InsertSpatialServices(SpatialServices spatialServices)
        {
            if ((spatialServices.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(spatialServices, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SpatialServices.AddObject(spatialServices);
            }
        }

        public void UpdateSpatialServices(SpatialServices currentSpatialServices)
        {
            this.ObjectContext.SpatialServices.AttachAsModified(currentSpatialServices, this.ChangeSet.GetOriginal(currentSpatialServices));
        }

        public void DeleteSpatialServices(SpatialServices spatialServices)
        {
            if ((spatialServices.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(spatialServices, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SpatialServices.Attach(spatialServices);
                this.ObjectContext.SpatialServices.DeleteObject(spatialServices);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SubjectLink' query.
        public IQueryable<SubjectLink> GetSubjectLink()
        {
            return this.ObjectContext.SubjectLink;
        }

        public void InsertSubjectLink(SubjectLink subjectLink)
        {
            if ((subjectLink.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(subjectLink, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SubjectLink.AddObject(subjectLink);
            }
        }

        public void UpdateSubjectLink(SubjectLink currentSubjectLink)
        {
            this.ObjectContext.SubjectLink.AttachAsModified(currentSubjectLink, this.ChangeSet.GetOriginal(currentSubjectLink));
        }

        public void DeleteSubjectLink(SubjectLink subjectLink)
        {
            if ((subjectLink.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(subjectLink, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SubjectLink.Attach(subjectLink);
                this.ObjectContext.SubjectLink.DeleteObject(subjectLink);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblDataType' query.
        public IQueryable<tblDataType> GetTblDataType()
        {
            return this.ObjectContext.tblDataType;
        }

        public void InsertTblDataType(tblDataType tblDataType)
        {
            if ((tblDataType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblDataType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblDataType.AddObject(tblDataType);
            }
        }

        public void UpdateTblDataType(tblDataType currenttblDataType)
        {
            this.ObjectContext.tblDataType.AttachAsModified(currenttblDataType, this.ChangeSet.GetOriginal(currenttblDataType));
        }

        public void DeleteTblDataType(tblDataType tblDataType)
        {
            if ((tblDataType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblDataType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblDataType.Attach(tblDataType);
                this.ObjectContext.tblDataType.DeleteObject(tblDataType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblInfoType' query.
        public IQueryable<tblInfoType> GetTblInfoType()
        {
            return this.ObjectContext.tblInfoType;
        }

        public void InsertTblInfoType(tblInfoType tblInfoType)
        {
            if ((tblInfoType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblInfoType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblInfoType.AddObject(tblInfoType);
            }
        }

        public void UpdateTblInfoType(tblInfoType currenttblInfoType)
        {
            this.ObjectContext.tblInfoType.AttachAsModified(currenttblInfoType, this.ChangeSet.GetOriginal(currenttblInfoType));
        }

        public void DeleteTblInfoType(tblInfoType tblInfoType)
        {
            if ((tblInfoType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblInfoType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblInfoType.Attach(tblInfoType);
                this.ObjectContext.tblInfoType.DeleteObject(tblInfoType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblMission' query.
        public IQueryable<tblMission> GetTblMission()
        {
            return this.ObjectContext.tblMission;
        }

        public void InsertTblMission(tblMission tblMission)
        {
            if ((tblMission.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMission, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblMission.AddObject(tblMission);
            }
        }

        public void UpdateTblMission(tblMission currenttblMission)
        {
            this.ObjectContext.tblMission.AttachAsModified(currenttblMission, this.ChangeSet.GetOriginal(currenttblMission));
        }

        public void DeleteTblMission(tblMission tblMission)
        {
            if ((tblMission.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblMission, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblMission.Attach(tblMission);
                this.ObjectContext.tblMission.DeleteObject(tblMission);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblOstan' query.
        public IQueryable<tblOstan> GetTblOstan()
        {
            return this.ObjectContext.tblOstan;
        }

        public void InsertTblOstan(tblOstan tblOstan)
        {
            if ((tblOstan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblOstan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblOstan.AddObject(tblOstan);
            }
        }

        public void UpdateTblOstan(tblOstan currenttblOstan)
        {
            this.ObjectContext.tblOstan.AttachAsModified(currenttblOstan, this.ChangeSet.GetOriginal(currenttblOstan));
        }

        public void DeleteTblOstan(tblOstan tblOstan)
        {
            if ((tblOstan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblOstan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblOstan.Attach(tblOstan);
                this.ObjectContext.tblOstan.DeleteObject(tblOstan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblPorts' query.
        public IQueryable<tblPorts> GetTblPorts()
        {
            return this.ObjectContext.tblPorts;
        }

        public void InsertTblPorts(tblPorts tblPorts)
        {
            if ((tblPorts.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblPorts, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblPorts.AddObject(tblPorts);
            }
        }

        public void UpdateTblPorts(tblPorts currenttblPorts)
        {
            this.ObjectContext.tblPorts.AttachAsModified(currenttblPorts, this.ChangeSet.GetOriginal(currenttblPorts));
        }

        public void DeleteTblPorts(tblPorts tblPorts)
        {
            if ((tblPorts.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblPorts, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblPorts.Attach(tblPorts);
                this.ObjectContext.tblPorts.DeleteObject(tblPorts);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblProjectMap' query.
        public IQueryable<tblProjectMap> GetTblProjectMap()
        {
            return this.ObjectContext.tblProjectMap;
        }

        public void InsertTblProjectMap(tblProjectMap tblProjectMap)
        {
            if ((tblProjectMap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblProjectMap, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblProjectMap.AddObject(tblProjectMap);
            }
        }

        public void UpdateTblProjectMap(tblProjectMap currenttblProjectMap)
        {
            this.ObjectContext.tblProjectMap.AttachAsModified(currenttblProjectMap, this.ChangeSet.GetOriginal(currenttblProjectMap));
        }

        public void DeleteTblProjectMap(tblProjectMap tblProjectMap)
        {
            if ((tblProjectMap.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblProjectMap, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblProjectMap.Attach(tblProjectMap);
                this.ObjectContext.tblProjectMap.DeleteObject(tblProjectMap);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'tblUsers' query.
        public IQueryable<tblUsers> GetTblUsers()
        {
            return this.ObjectContext.tblUsers;
        }

        public void InsertTblUsers(tblUsers tblUsers)
        {
            if ((tblUsers.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUsers, EntityState.Added);
            }
            else
            {
                this.ObjectContext.tblUsers.AddObject(tblUsers);
            }
        }

        public void UpdateTblUsers(tblUsers currenttblUsers)
        {
            this.ObjectContext.tblUsers.AttachAsModified(currenttblUsers, this.ChangeSet.GetOriginal(currenttblUsers));
        }

        public void DeleteTblUsers(tblUsers tblUsers)
        {
            if ((tblUsers.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tblUsers, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.tblUsers.Attach(tblUsers);
                this.ObjectContext.tblUsers.DeleteObject(tblUsers);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TitleLocation' query.
        public IQueryable<TitleLocation> GetTitleLocation()
        {
            return this.ObjectContext.TitleLocation;
        }

        public void InsertTitleLocation(TitleLocation titleLocation)
        {
            if ((titleLocation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(titleLocation, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TitleLocation.AddObject(titleLocation);
            }
        }

        public void UpdateTitleLocation(TitleLocation currentTitleLocation)
        {
            this.ObjectContext.TitleLocation.AttachAsModified(currentTitleLocation, this.ChangeSet.GetOriginal(currentTitleLocation));
        }

        public void DeleteTitleLocation(TitleLocation titleLocation)
        {
            if ((titleLocation.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(titleLocation, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TitleLocation.Attach(titleLocation);
                this.ObjectContext.TitleLocation.DeleteObject(titleLocation);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TitleSpec' query.
        public IQueryable<TitleSpec> GetTitleSpec()
        {
            return this.ObjectContext.TitleSpec;
        }

        public void InsertTitleSpec(TitleSpec titleSpec)
        {
            if ((titleSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(titleSpec, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TitleSpec.AddObject(titleSpec);
            }
        }

        public void UpdateTitleSpec(TitleSpec currentTitleSpec)
        {
            this.ObjectContext.TitleSpec.AttachAsModified(currentTitleSpec, this.ChangeSet.GetOriginal(currentTitleSpec));
        }

        public void DeleteTitleSpec(TitleSpec titleSpec)
        {
            if ((titleSpec.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(titleSpec, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TitleSpec.Attach(titleSpec);
                this.ObjectContext.TitleSpec.DeleteObject(titleSpec);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TreeLayer' query.
        public IQueryable<TreeLayer> GetTreeLayer()
        {
            return this.ObjectContext.TreeLayer;
        }

        public void InsertTreeLayer(TreeLayer treeLayer)
        {
            if ((treeLayer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(treeLayer, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TreeLayer.AddObject(treeLayer);
            }
        }

        public void UpdateTreeLayer(TreeLayer currentTreeLayer)
        {
            this.ObjectContext.TreeLayer.AttachAsModified(currentTreeLayer, this.ChangeSet.GetOriginal(currentTreeLayer));
        }

        public void DeleteTreeLayer(TreeLayer treeLayer)
        {
            if ((treeLayer.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(treeLayer, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TreeLayer.Attach(treeLayer);
                this.ObjectContext.TreeLayer.DeleteObject(treeLayer);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserAccess' query.
        public IQueryable<UserAccess> GetUserAccess()
        {
            return this.ObjectContext.UserAccess;
        }

        public void InsertUserAccess(UserAccess userAccess)
        {
            if ((userAccess.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userAccess, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserAccess.AddObject(userAccess);
            }
        }

        public void UpdateUserAccess(UserAccess currentUserAccess)
        {
            this.ObjectContext.UserAccess.AttachAsModified(currentUserAccess, this.ChangeSet.GetOriginal(currentUserAccess));
        }

        public void DeleteUserAccess(UserAccess userAccess)
        {
            if ((userAccess.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userAccess, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserAccess.Attach(userAccess);
                this.ObjectContext.UserAccess.DeleteObject(userAccess);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UsersInRoles' query.
        public IQueryable<UsersInRoles> GetUsersInRoles()
        {
            return this.ObjectContext.UsersInRoles;
        }

        public void InsertUsersInRoles(UsersInRoles usersInRoles)
        {
            if ((usersInRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usersInRoles, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UsersInRoles.AddObject(usersInRoles);
            }
        }

        public void UpdateUsersInRoles(UsersInRoles currentUsersInRoles)
        {
            this.ObjectContext.UsersInRoles.AttachAsModified(currentUsersInRoles, this.ChangeSet.GetOriginal(currentUsersInRoles));
        }

        public void DeleteUsersInRoles(UsersInRoles usersInRoles)
        {
            if ((usersInRoles.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(usersInRoles, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UsersInRoles.Attach(usersInRoles);
                this.ObjectContext.UsersInRoles.DeleteObject(usersInRoles);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'UserType' query.
        public IQueryable<UserType> GetUserType()
        {
            return this.ObjectContext.UserType;
        }

        public void InsertUserType(UserType userType)
        {
            if ((userType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.UserType.AddObject(userType);
            }
        }

        public void UpdateUserType(UserType currentUserType)
        {
            this.ObjectContext.UserType.AttachAsModified(currentUserType, this.ChangeSet.GetOriginal(currentUserType));
        }

        public void DeleteUserType(UserType userType)
        {
            if ((userType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(userType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.UserType.Attach(userType);
                this.ObjectContext.UserType.DeleteObject(userType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vport' query.
        public IQueryable<vport> GetVport()
        {
            return this.ObjectContext.vport;
        }

        public void InsertVport(vport vport)
        {
            if ((vport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vport, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vport.AddObject(vport);
            }
        }

        public void UpdateVport(vport currentvport)
        {
            this.ObjectContext.vport.AttachAsModified(currentvport, this.ChangeSet.GetOriginal(currentvport));
        }

        public void DeleteVport(vport vport)
        {
            if ((vport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vport, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vport.Attach(vport);
                this.ObjectContext.vport.DeleteObject(vport);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwAllPlan' query.
        public IQueryable<vwAllPlan> GetVwAllPlan()
        {
            return this.ObjectContext.vwAllPlan;
        }

        public void InsertVwAllPlan(vwAllPlan vwAllPlan)
        {
            if ((vwAllPlan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwAllPlan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwAllPlan.AddObject(vwAllPlan);
            }
        }

        public void UpdateVwAllPlan(vwAllPlan currentvwAllPlan)
        {
            this.ObjectContext.vwAllPlan.AttachAsModified(currentvwAllPlan, this.ChangeSet.GetOriginal(currentvwAllPlan));
        }

        public void DeleteVwAllPlan(vwAllPlan vwAllPlan)
        {
            if ((vwAllPlan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwAllPlan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwAllPlan.Attach(vwAllPlan);
                this.ObjectContext.vwAllPlan.DeleteObject(vwAllPlan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwDocFileList' query.
        public IQueryable<vwDocFileList> GetVwDocFileList()
        {
            return this.ObjectContext.vwDocFileList;
        }

        public void InsertVwDocFileList(vwDocFileList vwDocFileList)
        {
            if ((vwDocFileList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwDocFileList, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwDocFileList.AddObject(vwDocFileList);
            }
        }

        public void UpdateVwDocFileList(vwDocFileList currentvwDocFileList)
        {
            this.ObjectContext.vwDocFileList.AttachAsModified(currentvwDocFileList, this.ChangeSet.GetOriginal(currentvwDocFileList));
        }

        public void DeleteVwDocFileList(vwDocFileList vwDocFileList)
        {
            if ((vwDocFileList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwDocFileList, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwDocFileList.Attach(vwDocFileList);
                this.ObjectContext.vwDocFileList.DeleteObject(vwDocFileList);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwFileList' query.
        public IQueryable<vwFileList> GetVwFileList()
        {
            return this.ObjectContext.vwFileList;
        }

        public void InsertVwFileList(vwFileList vwFileList)
        {
            if ((vwFileList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwFileList, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwFileList.AddObject(vwFileList);
            }
        }

        public void UpdateVwFileList(vwFileList currentvwFileList)
        {
            this.ObjectContext.vwFileList.AttachAsModified(currentvwFileList, this.ChangeSet.GetOriginal(currentvwFileList));
        }

        public void DeleteVwFileList(vwFileList vwFileList)
        {
            if ((vwFileList.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwFileList, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwFileList.Attach(vwFileList);
                this.ObjectContext.vwFileList.DeleteObject(vwFileList);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwIcopmasReport' query.
        public IQueryable<vwIcopmasReport> GetVwIcopmasReport()
        {
            return this.ObjectContext.vwIcopmasReport;
        }

        public void InsertVwIcopmasReport(vwIcopmasReport vwIcopmasReport)
        {
            if ((vwIcopmasReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwIcopmasReport, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwIcopmasReport.AddObject(vwIcopmasReport);
            }
        }

        public void UpdateVwIcopmasReport(vwIcopmasReport currentvwIcopmasReport)
        {
            this.ObjectContext.vwIcopmasReport.AttachAsModified(currentvwIcopmasReport, this.ChangeSet.GetOriginal(currentvwIcopmasReport));
        }

        public void DeleteVwIcopmasReport(vwIcopmasReport vwIcopmasReport)
        {
            if ((vwIcopmasReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwIcopmasReport, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwIcopmasReport.Attach(vwIcopmasReport);
                this.ObjectContext.vwIcopmasReport.DeleteObject(vwIcopmasReport);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwLinkDocs' query.
        public IQueryable<vwLinkDocs> GetVwLinkDocs()
        {
            return this.ObjectContext.vwLinkDocs;
        }

        public void InsertVwLinkDocs(vwLinkDocs vwLinkDocs)
        {
            if ((vwLinkDocs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwLinkDocs, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwLinkDocs.AddObject(vwLinkDocs);
            }
        }

        public void UpdateVwLinkDocs(vwLinkDocs currentvwLinkDocs)
        {
            this.ObjectContext.vwLinkDocs.AttachAsModified(currentvwLinkDocs, this.ChangeSet.GetOriginal(currentvwLinkDocs));
        }

        public void DeleteVwLinkDocs(vwLinkDocs vwLinkDocs)
        {
            if ((vwLinkDocs.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwLinkDocs, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwLinkDocs.Attach(vwLinkDocs);
                this.ObjectContext.vwLinkDocs.DeleteObject(vwLinkDocs);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwMojavez_Attach' query.
        public IQueryable<vwMojavez_Attach> GetVwMojavez_Attach()
        {
            return this.ObjectContext.vwMojavez_Attach;
        }

        public void InsertVwMojavez_Attach(vwMojavez_Attach vwMojavez_Attach)
        {
            if ((vwMojavez_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMojavez_Attach, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwMojavez_Attach.AddObject(vwMojavez_Attach);
            }
        }

        public void UpdateVwMojavez_Attach(vwMojavez_Attach currentvwMojavez_Attach)
        {
            this.ObjectContext.vwMojavez_Attach.AttachAsModified(currentvwMojavez_Attach, this.ChangeSet.GetOriginal(currentvwMojavez_Attach));
        }

        public void DeleteVwMojavez_Attach(vwMojavez_Attach vwMojavez_Attach)
        {
            if ((vwMojavez_Attach.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMojavez_Attach, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwMojavez_Attach.Attach(vwMojavez_Attach);
                this.ObjectContext.vwMojavez_Attach.DeleteObject(vwMojavez_Attach);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwMojavezReport' query.
        public IQueryable<vwMojavezReport> GetVwMojavezReport()
        {
            return this.ObjectContext.vwMojavezReport;
        }

        public void InsertVwMojavezReport(vwMojavezReport vwMojavezReport)
        {
            if ((vwMojavezReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMojavezReport, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwMojavezReport.AddObject(vwMojavezReport);
            }
        }

        public void UpdateVwMojavezReport(vwMojavezReport currentvwMojavezReport)
        {
            this.ObjectContext.vwMojavezReport.AttachAsModified(currentvwMojavezReport, this.ChangeSet.GetOriginal(currentvwMojavezReport));
        }

        public void DeleteVwMojavezReport(vwMojavezReport vwMojavezReport)
        {
            if ((vwMojavezReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMojavezReport, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwMojavezReport.Attach(vwMojavezReport);
                this.ObjectContext.vwMojavezReport.DeleteObject(vwMojavezReport);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwPlanReport' query.
        public IQueryable<vwPlanReport> GetVwPlanReport()
        {
            return this.ObjectContext.vwPlanReport;
        }

        public void InsertVwPlanReport(vwPlanReport vwPlanReport)
        {
            if ((vwPlanReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwPlanReport, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwPlanReport.AddObject(vwPlanReport);
            }
        }

        public void UpdateVwPlanReport(vwPlanReport currentvwPlanReport)
        {
            this.ObjectContext.vwPlanReport.AttachAsModified(currentvwPlanReport, this.ChangeSet.GetOriginal(currentvwPlanReport));
        }

        public void DeleteVwPlanReport(vwPlanReport vwPlanReport)
        {
            if ((vwPlanReport.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwPlanReport, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwPlanReport.Attach(vwPlanReport);
                this.ObjectContext.vwPlanReport.DeleteObject(vwPlanReport);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwUsageType' query.
        public IQueryable<vwUsageType> GetVwUsageType()
        {
            return this.ObjectContext.vwUsageType;
        }

        public void InsertVwUsageType(vwUsageType vwUsageType)
        {
            if ((vwUsageType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwUsageType, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwUsageType.AddObject(vwUsageType);
            }
        }

        public void UpdateVwUsageType(vwUsageType currentvwUsageType)
        {
            this.ObjectContext.vwUsageType.AttachAsModified(currentvwUsageType, this.ChangeSet.GetOriginal(currentvwUsageType));
        }

        public void DeleteVwUsageType(vwUsageType vwUsageType)
        {
            if ((vwUsageType.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwUsageType, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwUsageType.Attach(vwUsageType);
                this.ObjectContext.vwUsageType.DeleteObject(vwUsageType);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Zone' query.
        public IQueryable<Zone> GetZone()
        {
            return this.ObjectContext.Zone;
        }

        public void InsertZone(Zone zone)
        {
            if ((zone.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(zone, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Zone.AddObject(zone);
            }
        }

        public void UpdateZone(Zone currentZone)
        {
            this.ObjectContext.Zone.AttachAsModified(currentZone, this.ChangeSet.GetOriginal(currentZone));
        }

        public void DeleteZone(Zone zone)
        {
            if ((zone.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(zone, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Zone.Attach(zone);
                this.ObjectContext.Zone.DeleteObject(zone);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DocFileUserLog' query.
        public IQueryable<DocFileUserLog> GetDocFileUserLog()
        {
            return this.ObjectContext.DocFileUserLog;
        }

        public void InsertDocFileUserLog(DocFileUserLog docFileUserLog)
        {
            if ((docFileUserLog.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docFileUserLog, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DocFileUserLog.AddObject(docFileUserLog);
            }
        }

        public void UpdateDocFileUserLog(DocFileUserLog currentDocFileUserLog)
        {
            this.ObjectContext.DocFileUserLog.AttachAsModified(currentDocFileUserLog, this.ChangeSet.GetOriginal(currentDocFileUserLog));
        }

        public void DeleteDocFileUserLog(DocFileUserLog docFileUserLog)
        {
            if ((docFileUserLog.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(docFileUserLog, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DocFileUserLog.Attach(docFileUserLog);
                this.ObjectContext.DocFileUserLog.DeleteObject(docFileUserLog);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EmployeesInfo' query.
        public IQueryable<EmployeesInfo> GetEmployeesInfo()
        {
            return this.ObjectContext.EmployeesInfo;
        }

        public void InsertEmployeesInfo(EmployeesInfo employeesInfo)
        {
            if ((employeesInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(employeesInfo, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EmployeesInfo.AddObject(employeesInfo);
            }
        }

        public void UpdateEmployeesInfo(EmployeesInfo currentEmployeesInfo)
        {
            this.ObjectContext.EmployeesInfo.AttachAsModified(currentEmployeesInfo, this.ChangeSet.GetOriginal(currentEmployeesInfo));
        }

        public void DeleteEmployeesInfo(EmployeesInfo employeesInfo)
        {
            if ((employeesInfo.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(employeesInfo, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EmployeesInfo.Attach(employeesInfo);
                this.ObjectContext.EmployeesInfo.DeleteObject(employeesInfo);
            }
        }
    }
}


