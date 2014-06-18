
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


    // Implements application logic using the PMOManageEntities1 context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class HydroService : LinqToEntitiesDomainService<PMOManageEntities1>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DetailsOfCO2' query.
        public IQueryable<DetailsOfCO2> GetDetailsOfCO2()
        {
            return this.ObjectContext.DetailsOfCO2.Include("DetailsOfCO2Chamical").Include("DetailsOfCO2InjectionWell");
        }

        public void InsertDetailsOfCO2(DetailsOfCO2 detailsOfCO2)
        {
            if ((detailsOfCO2.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2.AddObject(detailsOfCO2);
            }
        }

        public void UpdateDetailsOfCO2(DetailsOfCO2 currentDetailsOfCO2)
        {
            this.ObjectContext.DetailsOfCO2.AttachAsModified(currentDetailsOfCO2, this.ChangeSet.GetOriginal(currentDetailsOfCO2));
        }

        public void DeleteDetailsOfCO2(DetailsOfCO2 detailsOfCO2)
        {
            if ((detailsOfCO2.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2.Attach(detailsOfCO2);
                this.ObjectContext.DetailsOfCO2.DeleteObject(detailsOfCO2);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DetailsOfCO2Chamical' query.
        public IQueryable<DetailsOfCO2Chamical> GetDetailsOfCO2Chamical()
        {
            return this.ObjectContext.DetailsOfCO2Chamical;
        }

        public void InsertDetailsOfCO2Chamical(DetailsOfCO2Chamical detailsOfCO2Chamical)
        {
            if ((detailsOfCO2Chamical.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2Chamical, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2Chamical.AddObject(detailsOfCO2Chamical);
            }
        }

        public void UpdateDetailsOfCO2Chamical(DetailsOfCO2Chamical currentDetailsOfCO2Chamical)
        {
            this.ObjectContext.DetailsOfCO2Chamical.AttachAsModified(currentDetailsOfCO2Chamical, this.ChangeSet.GetOriginal(currentDetailsOfCO2Chamical));
        }

        public void DeleteDetailsOfCO2Chamical(DetailsOfCO2Chamical detailsOfCO2Chamical)
        {
            if ((detailsOfCO2Chamical.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2Chamical, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2Chamical.Attach(detailsOfCO2Chamical);
                this.ObjectContext.DetailsOfCO2Chamical.DeleteObject(detailsOfCO2Chamical);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DetailsOfCO2InjectionWell' query.
        public IQueryable<DetailsOfCO2InjectionWell> GetDetailsOfCO2InjectionWell()
        {
            return this.ObjectContext.DetailsOfCO2InjectionWell;
        }

        public void InsertDetailsOfCO2InjectionWell(DetailsOfCO2InjectionWell detailsOfCO2InjectionWell)
        {
            if ((detailsOfCO2InjectionWell.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2InjectionWell, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2InjectionWell.AddObject(detailsOfCO2InjectionWell);
            }
        }

        public void UpdateDetailsOfCO2InjectionWell(DetailsOfCO2InjectionWell currentDetailsOfCO2InjectionWell)
        {
            this.ObjectContext.DetailsOfCO2InjectionWell.AttachAsModified(currentDetailsOfCO2InjectionWell, this.ChangeSet.GetOriginal(currentDetailsOfCO2InjectionWell));
        }

        public void DeleteDetailsOfCO2InjectionWell(DetailsOfCO2InjectionWell detailsOfCO2InjectionWell)
        {
            if ((detailsOfCO2InjectionWell.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfCO2InjectionWell, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DetailsOfCO2InjectionWell.Attach(detailsOfCO2InjectionWell);
                this.ObjectContext.DetailsOfCO2InjectionWell.DeleteObject(detailsOfCO2InjectionWell);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DetailsOfDeposit' query.
        public IQueryable<DetailsOfDeposit> GetDetailsOfDeposit()
        {
            return this.ObjectContext.DetailsOfDeposit;
        }

        public void InsertDetailsOfDeposit(DetailsOfDeposit detailsOfDeposit)
        {
            if ((detailsOfDeposit.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfDeposit, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DetailsOfDeposit.AddObject(detailsOfDeposit);
            }
        }

        public void UpdateDetailsOfDeposit(DetailsOfDeposit currentDetailsOfDeposit)
        {
            this.ObjectContext.DetailsOfDeposit.AttachAsModified(currentDetailsOfDeposit, this.ChangeSet.GetOriginal(currentDetailsOfDeposit));
        }

        public void DeleteDetailsOfDeposit(DetailsOfDeposit detailsOfDeposit)
        {
            if ((detailsOfDeposit.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(detailsOfDeposit, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DetailsOfDeposit.Attach(detailsOfDeposit);
                this.ObjectContext.DetailsOfDeposit.DeleteObject(detailsOfDeposit);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'MashinAlatVaTajhizat' query.
        public IQueryable<MashinAlatVaTajhizat> GetMashinAlatVaTajhizat()
        {
            return this.ObjectContext.MashinAlatVaTajhizat;
        }

        public void InsertMashinAlatVaTajhizat(MashinAlatVaTajhizat mashinAlatVaTajhizat)
        {
            if ((mashinAlatVaTajhizat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mashinAlatVaTajhizat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.MashinAlatVaTajhizat.AddObject(mashinAlatVaTajhizat);
            }
        }

        public void UpdateMashinAlatVaTajhizat(MashinAlatVaTajhizat currentMashinAlatVaTajhizat)
        {
            this.ObjectContext.MashinAlatVaTajhizat.AttachAsModified(currentMashinAlatVaTajhizat, this.ChangeSet.GetOriginal(currentMashinAlatVaTajhizat));
        }

        public void DeleteMashinAlatVaTajhizat(MashinAlatVaTajhizat mashinAlatVaTajhizat)
        {
            if ((mashinAlatVaTajhizat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(mashinAlatVaTajhizat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.MashinAlatVaTajhizat.Attach(mashinAlatVaTajhizat);
                this.ObjectContext.MashinAlatVaTajhizat.DeleteObject(mashinAlatVaTajhizat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Persons' query.
        public IQueryable<Persons> GetPersons()
        {
            return this.ObjectContext.Persons.Include("PersonsSavabeg");
        }

        public void InsertPersons(Persons persons)
        {
            if ((persons.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(persons, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Persons.AddObject(persons);
            }
        }

        public void UpdatePersons(Persons currentPersons)
        {
            this.ObjectContext.Persons.AttachAsModified(currentPersons, this.ChangeSet.GetOriginal(currentPersons));
        }

        public void DeletePersons(Persons persons)
        {
            if ((persons.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(persons, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Persons.Attach(persons);
                this.ObjectContext.Persons.DeleteObject(persons);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'PersonsSavabeg' query.
        public IQueryable<PersonsSavabeg> GetPersonsSavabeg()
        {
            return this.ObjectContext.PersonsSavabeg;
        }

        public void InsertPersonsSavabeg(PersonsSavabeg personsSavabeg)
        {
            if ((personsSavabeg.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personsSavabeg, EntityState.Added);
            }
            else
            {
                this.ObjectContext.PersonsSavabeg.AddObject(personsSavabeg);
            }
        }

        public void UpdatePersonsSavabeg(PersonsSavabeg currentPersonsSavabeg)
        {
            this.ObjectContext.PersonsSavabeg.AttachAsModified(currentPersonsSavabeg, this.ChangeSet.GetOriginal(currentPersonsSavabeg));
        }

        public void DeletePersonsSavabeg(PersonsSavabeg personsSavabeg)
        {
            if ((personsSavabeg.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(personsSavabeg, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.PersonsSavabeg.Attach(personsSavabeg);
                this.ObjectContext.PersonsSavabeg.DeleteObject(personsSavabeg);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Peymanha' query.
        public IQueryable<Peymanha> GetPeymanha()
        {
            return this.ObjectContext.Peymanha;
        }

        public void InsertPeymanha(Peymanha peymanha)
        {
            if ((peymanha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(peymanha, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Peymanha.AddObject(peymanha);
            }
        }

        public void UpdatePeymanha(Peymanha currentPeymanha)
        {
            this.ObjectContext.Peymanha.AttachAsModified(currentPeymanha, this.ChangeSet.GetOriginal(currentPeymanha));
        }

        public void DeletePeymanha(Peymanha peymanha)
        {
            if ((peymanha.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(peymanha, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Peymanha.Attach(peymanha);
                this.ObjectContext.Peymanha.DeleteObject(peymanha);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Peymankar' query.
        public IQueryable<Peymankar> GetPeymankar()
        {
            return this.ObjectContext.Peymankar.Include("Persons")
                .Include("MashinAlatVaTajhizat")
                .Include("Peymanha")
                .Include("Persons.PersonsSavabeg"); ;
        }

        public void InsertPeymankar(Peymankar peymankar)
        {
            if ((peymankar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(peymankar, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Peymankar.AddObject(peymankar);
            }
        }

        public void UpdatePeymankar(Peymankar currentPeymankar)
        {
            this.ObjectContext.Peymankar.AttachAsModified(currentPeymankar, this.ChangeSet.GetOriginal(currentPeymankar));
        }

        public void DeletePeymankar(Peymankar peymankar)
        {
            if ((peymankar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(peymankar, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Peymankar.Attach(peymankar);
                this.ObjectContext.Peymankar.DeleteObject(peymankar);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ProjectIdentification' query.
        public IQueryable<ProjectIdentification> GetProjectIdentification()
        {
            return this.ObjectContext.ProjectIdentification;
        }

        public void InsertProjectIdentification(ProjectIdentification projectIdentification)
        {
            if ((projectIdentification.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(projectIdentification, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ProjectIdentification.AddObject(projectIdentification);
            }
        }

        public void UpdateProjectIdentification(ProjectIdentification currentProjectIdentification)
        {
            this.ObjectContext.ProjectIdentification.AttachAsModified(currentProjectIdentification, this.ChangeSet.GetOriginal(currentProjectIdentification));
        }

        public void DeleteProjectIdentification(ProjectIdentification projectIdentification)
        {
            if ((projectIdentification.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(projectIdentification, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ProjectIdentification.Attach(projectIdentification);
                this.ObjectContext.ProjectIdentification.DeleteObject(projectIdentification);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SummaryOfPermits' query.
        public IQueryable<SummaryOfPermits> GetSummaryOfPermits()
        {
            return this.ObjectContext.SummaryOfPermits;
        }

        public void InsertSummaryOfPermits(SummaryOfPermits summaryOfPermits)
        {
            if ((summaryOfPermits.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(summaryOfPermits, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SummaryOfPermits.AddObject(summaryOfPermits);
            }
        }

        public void UpdateSummaryOfPermits(SummaryOfPermits currentSummaryOfPermits)
        {
            this.ObjectContext.SummaryOfPermits.AttachAsModified(currentSummaryOfPermits, this.ChangeSet.GetOriginal(currentSummaryOfPermits));
        }

        public void DeleteSummaryOfPermits(SummaryOfPermits summaryOfPermits)
        {
            if ((summaryOfPermits.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(summaryOfPermits, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SummaryOfPermits.Attach(summaryOfPermits);
                this.ObjectContext.SummaryOfPermits.DeleteObject(summaryOfPermits);
            }
        }
    }
}


