
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


    // Implements application logic using the DBEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class DBDomainService : LinqToEntitiesDomainService<DBEntities>
    {
        public void GenerateDataForms(string username, string org)
        {
            this.ObjectContext.GenerateDataForms(username, org);
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankKeshavarzi35' query.
        public IQueryable<BankKeshavarzi35> GetBankKeshavarzi35()
        {
            return this.ObjectContext.BankKeshavarzi35;
        }

        public void InsertBankKeshavarzi35(BankKeshavarzi35 bankKeshavarzi35)
        {
            if ((bankKeshavarzi35.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankKeshavarzi35, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankKeshavarzi35.AddObject(bankKeshavarzi35);
            }
        }

        public void UpdateBankKeshavarzi35(BankKeshavarzi35 currentBankKeshavarzi35)
        {
            this.ObjectContext.BankKeshavarzi35.AttachAsModified(currentBankKeshavarzi35, this.ChangeSet.GetOriginal(currentBankKeshavarzi35));
        }

        public void DeleteBankKeshavarzi35(BankKeshavarzi35 bankKeshavarzi35)
        {
            if ((bankKeshavarzi35.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankKeshavarzi35, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankKeshavarzi35.Attach(bankKeshavarzi35);
                this.ObjectContext.BankKeshavarzi35.DeleteObject(bankKeshavarzi35);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankMaskan30' query.
        public IQueryable<BankMaskan30> GetBankMaskan30()
        {
            return this.ObjectContext.BankMaskan30;
        }

        public void InsertBankMaskan30(BankMaskan30 bankMaskan30)
        {
            if ((bankMaskan30.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMaskan30, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankMaskan30.AddObject(bankMaskan30);
            }
        }

        public void UpdateBankMaskan30(BankMaskan30 currentBankMaskan30)
        {
            this.ObjectContext.BankMaskan30.AttachAsModified(currentBankMaskan30, this.ChangeSet.GetOriginal(currentBankMaskan30));
        }

        public void DeleteBankMaskan30(BankMaskan30 bankMaskan30)
        {
            if ((bankMaskan30.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMaskan30, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankMaskan30.Attach(bankMaskan30);
                this.ObjectContext.BankMaskan30.DeleteObject(bankMaskan30);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankMellat33' query.
        public IQueryable<BankMellat33> GetBankMellat33()
        {
            return this.ObjectContext.BankMellat33;
        }

        public void InsertBankMellat33(BankMellat33 bankMellat33)
        {
            if ((bankMellat33.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMellat33, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankMellat33.AddObject(bankMellat33);
            }
        }

        public void UpdateBankMellat33(BankMellat33 currentBankMellat33)
        {
            this.ObjectContext.BankMellat33.AttachAsModified(currentBankMellat33, this.ChangeSet.GetOriginal(currentBankMellat33));
        }

        public void DeleteBankMellat33(BankMellat33 bankMellat33)
        {
            if ((bankMellat33.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMellat33, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankMellat33.Attach(bankMellat33);
                this.ObjectContext.BankMellat33.DeleteObject(bankMellat33);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankMelli32' query.
        public IQueryable<BankMelli32> GetBankMelli32()
        {
            return this.ObjectContext.BankMelli32;
        }

        public void InsertBankMelli32(BankMelli32 bankMelli32)
        {
            if ((bankMelli32.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMelli32, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankMelli32.AddObject(bankMelli32);
            }
        }

        public void UpdateBankMelli32(BankMelli32 currentBankMelli32)
        {
            this.ObjectContext.BankMelli32.AttachAsModified(currentBankMelli32, this.ChangeSet.GetOriginal(currentBankMelli32));
        }

        public void DeleteBankMelli32(BankMelli32 bankMelli32)
        {
            if ((bankMelli32.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankMelli32, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankMelli32.Attach(bankMelli32);
                this.ObjectContext.BankMelli32.DeleteObject(bankMelli32);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankRefah31' query.
        public IQueryable<BankRefah31> GetBankRefah31()
        {
            return this.ObjectContext.BankRefah31;
        }

        public void InsertBankRefah31(BankRefah31 bankRefah31)
        {
            if ((bankRefah31.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankRefah31, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankRefah31.AddObject(bankRefah31);
            }
        }

        public void UpdateBankRefah31(BankRefah31 currentBankRefah31)
        {
            this.ObjectContext.BankRefah31.AttachAsModified(currentBankRefah31, this.ChangeSet.GetOriginal(currentBankRefah31));
        }

        public void DeleteBankRefah31(BankRefah31 bankRefah31)
        {
            if ((bankRefah31.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankRefah31, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankRefah31.Attach(bankRefah31);
                this.ObjectContext.BankRefah31.DeleteObject(bankRefah31);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankSaderat38' query.
        public IQueryable<BankSaderat38> GetBankSaderat38()
        {
            return this.ObjectContext.BankSaderat38;
        }

        public void InsertBankSaderat38(BankSaderat38 bankSaderat38)
        {
            if ((bankSaderat38.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSaderat38, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankSaderat38.AddObject(bankSaderat38);
            }
        }

        public void UpdateBankSaderat38(BankSaderat38 currentBankSaderat38)
        {
            this.ObjectContext.BankSaderat38.AttachAsModified(currentBankSaderat38, this.ChangeSet.GetOriginal(currentBankSaderat38));
        }

        public void DeleteBankSaderat38(BankSaderat38 bankSaderat38)
        {
            if ((bankSaderat38.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSaderat38, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankSaderat38.Attach(bankSaderat38);
                this.ObjectContext.BankSaderat38.DeleteObject(bankSaderat38);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankSanatoMadan37' query.
        public IQueryable<BankSanatoMadan37> GetBankSanatoMadan37()
        {
            return this.ObjectContext.BankSanatoMadan37;
        }

        public void InsertBankSanatoMadan37(BankSanatoMadan37 bankSanatoMadan37)
        {
            if ((bankSanatoMadan37.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSanatoMadan37, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankSanatoMadan37.AddObject(bankSanatoMadan37);
            }
        }

        public void UpdateBankSanatoMadan37(BankSanatoMadan37 currentBankSanatoMadan37)
        {
            this.ObjectContext.BankSanatoMadan37.AttachAsModified(currentBankSanatoMadan37, this.ChangeSet.GetOriginal(currentBankSanatoMadan37));
        }

        public void DeleteBankSanatoMadan37(BankSanatoMadan37 bankSanatoMadan37)
        {
            if ((bankSanatoMadan37.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSanatoMadan37, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankSanatoMadan37.Attach(bankSanatoMadan37);
                this.ObjectContext.BankSanatoMadan37.DeleteObject(bankSanatoMadan37);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankSepah34' query.
        public IQueryable<BankSepah34> GetBankSepah34()
        {
            return this.ObjectContext.BankSepah34;
        }

        public void InsertBankSepah34(BankSepah34 bankSepah34)
        {
            if ((bankSepah34.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSepah34, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankSepah34.AddObject(bankSepah34);
            }
        }

        public void UpdateBankSepah34(BankSepah34 currentBankSepah34)
        {
            this.ObjectContext.BankSepah34.AttachAsModified(currentBankSepah34, this.ChangeSet.GetOriginal(currentBankSepah34));
        }

        public void DeleteBankSepah34(BankSepah34 bankSepah34)
        {
            if ((bankSepah34.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankSepah34, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankSepah34.Attach(bankSepah34);
                this.ObjectContext.BankSepah34.DeleteObject(bankSepah34);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BankTejarat36' query.
        public IQueryable<BankTejarat36> GetBankTejarat36()
        {
            return this.ObjectContext.BankTejarat36;
        }

        public void InsertBankTejarat36(BankTejarat36 bankTejarat36)
        {
            if ((bankTejarat36.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankTejarat36, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BankTejarat36.AddObject(bankTejarat36);
            }
        }

        public void UpdateBankTejarat36(BankTejarat36 currentBankTejarat36)
        {
            this.ObjectContext.BankTejarat36.AttachAsModified(currentBankTejarat36, this.ChangeSet.GetOriginal(currentBankTejarat36));
        }

        public void DeleteBankTejarat36(BankTejarat36 bankTejarat36)
        {
            if ((bankTejarat36.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bankTejarat36, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BankTejarat36.Attach(bankTejarat36);
                this.ObjectContext.BankTejarat36.DeleteObject(bankTejarat36);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Behzisti21' query.
        public IQueryable<Behzisti21> GetBehzisti21()
        {
            return this.ObjectContext.Behzisti21;
        }

        public void InsertBehzisti21(Behzisti21 behzisti21)
        {
            if ((behzisti21.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(behzisti21, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Behzisti21.AddObject(behzisti21);
            }
        }

        public void UpdateBehzisti21(Behzisti21 currentBehzisti21)
        {
            this.ObjectContext.Behzisti21.AttachAsModified(currentBehzisti21, this.ChangeSet.GetOriginal(currentBehzisti21));
        }

        public void DeleteBehzisti21(Behzisti21 behzisti21)
        {
            if ((behzisti21.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(behzisti21, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Behzisti21.Attach(behzisti21);
                this.ObjectContext.Behzisti21.DeleteObject(behzisti21);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'BimeSalamat23' query.
        public IQueryable<BimeSalamat23> GetBimeSalamat23()
        {
            return this.ObjectContext.BimeSalamat23;
        }

        public void InsertBimeSalamat23(BimeSalamat23 bimeSalamat23)
        {
            if ((bimeSalamat23.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bimeSalamat23, EntityState.Added);
            }
            else
            {
                this.ObjectContext.BimeSalamat23.AddObject(bimeSalamat23);
            }
        }

        public void UpdateBimeSalamat23(BimeSalamat23 currentBimeSalamat23)
        {
            this.ObjectContext.BimeSalamat23.AttachAsModified(currentBimeSalamat23, this.ChangeSet.GetOriginal(currentBimeSalamat23));
        }

        public void DeleteBimeSalamat23(BimeSalamat23 bimeSalamat23)
        {
            if ((bimeSalamat23.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(bimeSalamat23, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.BimeSalamat23.Attach(bimeSalamat23);
                this.ObjectContext.BimeSalamat23.DeleteObject(bimeSalamat23);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'DataForms' query.
        public IQueryable<DataForms> GetDataForms()
        {
            return this.ObjectContext.DataForms;
        }

        public void InsertDataForms(DataForms dataForms)
        {
            if ((dataForms.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dataForms, EntityState.Added);
            }
            else
            {
                this.ObjectContext.DataForms.AddObject(dataForms);
            }
        }

        public void UpdateDataForms(DataForms currentDataForms)
        {
            this.ObjectContext.DataForms.AttachAsModified(currentDataForms, this.ChangeSet.GetOriginal(currentDataForms));
        }

        public void DeleteDataForms(DataForms dataForms)
        {
            if ((dataForms.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(dataForms, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.DataForms.Attach(dataForms);
                this.ObjectContext.DataForms.DeleteObject(dataForms);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnergyAbRoostaei10' query.
        public IQueryable<EnergyAbRoostaei10> GetEnergyAbRoostaei10()
        {
            return this.ObjectContext.EnergyAbRoostaei10;
        }

        public void InsertEnergyAbRoostaei10(EnergyAbRoostaei10 energyAbRoostaei10)
        {
            if ((energyAbRoostaei10.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyAbRoostaei10, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnergyAbRoostaei10.AddObject(energyAbRoostaei10);
            }
        }

        public void UpdateEnergyAbRoostaei10(EnergyAbRoostaei10 currentEnergyAbRoostaei10)
        {
            this.ObjectContext.EnergyAbRoostaei10.AttachAsModified(currentEnergyAbRoostaei10, this.ChangeSet.GetOriginal(currentEnergyAbRoostaei10));
        }

        public void DeleteEnergyAbRoostaei10(EnergyAbRoostaei10 energyAbRoostaei10)
        {
            if ((energyAbRoostaei10.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyAbRoostaei10, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnergyAbRoostaei10.Attach(energyAbRoostaei10);
                this.ObjectContext.EnergyAbRoostaei10.DeleteObject(energyAbRoostaei10);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnergyAbShahri9' query.
        public IQueryable<EnergyAbShahri9> GetEnergyAbShahri9()
        {
            return this.ObjectContext.EnergyAbShahri9;
        }

        public void InsertEnergyAbShahri9(EnergyAbShahri9 energyAbShahri9)
        {
            if ((energyAbShahri9.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyAbShahri9, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnergyAbShahri9.AddObject(energyAbShahri9);
            }
        }

        public void UpdateEnergyAbShahri9(EnergyAbShahri9 currentEnergyAbShahri9)
        {
            this.ObjectContext.EnergyAbShahri9.AttachAsModified(currentEnergyAbShahri9, this.ChangeSet.GetOriginal(currentEnergyAbShahri9));
        }

        public void DeleteEnergyAbShahri9(EnergyAbShahri9 energyAbShahri9)
        {
            if ((energyAbShahri9.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyAbShahri9, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnergyAbShahri9.Attach(energyAbShahri9);
                this.ObjectContext.EnergyAbShahri9.DeleteObject(energyAbShahri9);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnergyBargh6' query.
        public IQueryable<EnergyBargh6> GetEnergyBargh6()
        {
            return this.ObjectContext.EnergyBargh6;
        }

        public void InsertEnergyBargh6(EnergyBargh6 energyBargh6)
        {
            if ((energyBargh6.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyBargh6, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnergyBargh6.AddObject(energyBargh6);
            }
        }

        public void UpdateEnergyBargh6(EnergyBargh6 currentEnergyBargh6)
        {
            this.ObjectContext.EnergyBargh6.AttachAsModified(currentEnergyBargh6, this.ChangeSet.GetOriginal(currentEnergyBargh6));
        }

        public void DeleteEnergyBargh6(EnergyBargh6 energyBargh6)
        {
            if ((energyBargh6.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyBargh6, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnergyBargh6.Attach(energyBargh6);
                this.ObjectContext.EnergyBargh6.DeleteObject(energyBargh6);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnergyGas8' query.
        public IQueryable<EnergyGas8> GetEnergyGas8()
        {
            return this.ObjectContext.EnergyGas8;
        }

        public void InsertEnergyGas8(EnergyGas8 energyGas8)
        {
            if ((energyGas8.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyGas8, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnergyGas8.AddObject(energyGas8);
            }
        }

        public void UpdateEnergyGas8(EnergyGas8 currentEnergyGas8)
        {
            this.ObjectContext.EnergyGas8.AttachAsModified(currentEnergyGas8, this.ChangeSet.GetOriginal(currentEnergyGas8));
        }

        public void DeleteEnergyGas8(EnergyGas8 energyGas8)
        {
            if ((energyGas8.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyGas8, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnergyGas8.Attach(energyGas8);
                this.ObjectContext.EnergyGas8.DeleteObject(energyGas8);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'EnergyNaft7' query.
        public IQueryable<EnergyNaft7> GetEnergyNaft7()
        {
            return this.ObjectContext.EnergyNaft7;
        }

        public void InsertEnergyNaft7(EnergyNaft7 energyNaft7)
        {
            if ((energyNaft7.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyNaft7, EntityState.Added);
            }
            else
            {
                this.ObjectContext.EnergyNaft7.AddObject(energyNaft7);
            }
        }

        public void UpdateEnergyNaft7(EnergyNaft7 currentEnergyNaft7)
        {
            this.ObjectContext.EnergyNaft7.AttachAsModified(currentEnergyNaft7, this.ChangeSet.GetOriginal(currentEnergyNaft7));
        }

        public void DeleteEnergyNaft7(EnergyNaft7 energyNaft7)
        {
            if ((energyNaft7.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(energyNaft7, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.EnergyNaft7.Attach(energyNaft7);
                this.ObjectContext.EnergyNaft7.DeleteObject(energyNaft7);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ertebatat12' query.
        public IQueryable<Ertebatat12> GetErtebatat12()
        {
            return this.ObjectContext.Ertebatat12;
        }

        public void InsertErtebatat12(Ertebatat12 ertebatat12)
        {
            if ((ertebatat12.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat12, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ertebatat12.AddObject(ertebatat12);
            }
        }

        public void UpdateErtebatat12(Ertebatat12 currentErtebatat12)
        {
            this.ObjectContext.Ertebatat12.AttachAsModified(currentErtebatat12, this.ChangeSet.GetOriginal(currentErtebatat12));
        }

        public void DeleteErtebatat12(Ertebatat12 ertebatat12)
        {
            if ((ertebatat12.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat12, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ertebatat12.Attach(ertebatat12);
                this.ObjectContext.Ertebatat12.DeleteObject(ertebatat12);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ertebatat13' query.
        public IQueryable<Ertebatat13> GetErtebatat13()
        {
            return this.ObjectContext.Ertebatat13;
        }

        public void InsertErtebatat13(Ertebatat13 ertebatat13)
        {
            if ((ertebatat13.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat13, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ertebatat13.AddObject(ertebatat13);
            }
        }

        public void UpdateErtebatat13(Ertebatat13 currentErtebatat13)
        {
            this.ObjectContext.Ertebatat13.AttachAsModified(currentErtebatat13, this.ChangeSet.GetOriginal(currentErtebatat13));
        }

        public void DeleteErtebatat13(Ertebatat13 ertebatat13)
        {
            if ((ertebatat13.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat13, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ertebatat13.Attach(ertebatat13);
                this.ObjectContext.Ertebatat13.DeleteObject(ertebatat13);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ertebatat14' query.
        public IQueryable<Ertebatat14> GetErtebatat14()
        {
            return this.ObjectContext.Ertebatat14;
        }

        public void InsertErtebatat14(Ertebatat14 ertebatat14)
        {
            if ((ertebatat14.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat14, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ertebatat14.AddObject(ertebatat14);
            }
        }

        public void UpdateErtebatat14(Ertebatat14 currentErtebatat14)
        {
            this.ObjectContext.Ertebatat14.AttachAsModified(currentErtebatat14, this.ChangeSet.GetOriginal(currentErtebatat14));
        }

        public void DeleteErtebatat14(Ertebatat14 ertebatat14)
        {
            if ((ertebatat14.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ertebatat14, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ertebatat14.Attach(ertebatat14);
                this.ObjectContext.Ertebatat14.DeleteObject(ertebatat14);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Farhangi26' query.
        public IQueryable<Farhangi26> GetFarhangi26()
        {
            return this.ObjectContext.Farhangi26;
        }

        public void InsertFarhangi26(Farhangi26 farhangi26)
        {
            if ((farhangi26.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(farhangi26, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Farhangi26.AddObject(farhangi26);
            }
        }

        public void UpdateFarhangi26(Farhangi26 currentFarhangi26)
        {
            this.ObjectContext.Farhangi26.AttachAsModified(currentFarhangi26, this.ChangeSet.GetOriginal(currentFarhangi26));
        }

        public void DeleteFarhangi26(Farhangi26 farhangi26)
        {
            if ((farhangi26.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(farhangi26, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Farhangi26.Attach(farhangi26);
                this.ObjectContext.Farhangi26.DeleteObject(farhangi26);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Farhangi27' query.
        public IQueryable<Farhangi27> GetFarhangi27()
        {
            return this.ObjectContext.Farhangi27;
        }

        public void InsertFarhangi27(Farhangi27 farhangi27)
        {
            if ((farhangi27.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(farhangi27, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Farhangi27.AddObject(farhangi27);
            }
        }

        public void UpdateFarhangi27(Farhangi27 currentFarhangi27)
        {
            this.ObjectContext.Farhangi27.AttachAsModified(currentFarhangi27, this.ChangeSet.GetOriginal(currentFarhangi27));
        }

        public void DeleteFarhangi27(Farhangi27 farhangi27)
        {
            if ((farhangi27.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(farhangi27, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Farhangi27.Attach(farhangi27);
                this.ObjectContext.Farhangi27.DeleteObject(farhangi27);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ghazaei18' query.
        public IQueryable<Ghazaei18> GetGhazaei18()
        {
            return this.ObjectContext.Ghazaei18;
        }

        public void InsertGhazaei18(Ghazaei18 ghazaei18)
        {
            if ((ghazaei18.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei18, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ghazaei18.AddObject(ghazaei18);
            }
        }

        public void UpdateGhazaei18(Ghazaei18 currentGhazaei18)
        {
            this.ObjectContext.Ghazaei18.AttachAsModified(currentGhazaei18, this.ChangeSet.GetOriginal(currentGhazaei18));
        }

        public void DeleteGhazaei18(Ghazaei18 ghazaei18)
        {
            if ((ghazaei18.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei18, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ghazaei18.Attach(ghazaei18);
                this.ObjectContext.Ghazaei18.DeleteObject(ghazaei18);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ghazaei19' query.
        public IQueryable<Ghazaei19> GetGhazaei19()
        {
            return this.ObjectContext.Ghazaei19;
        }

        public void InsertGhazaei19(Ghazaei19 ghazaei19)
        {
            if ((ghazaei19.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei19, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ghazaei19.AddObject(ghazaei19);
            }
        }

        public void UpdateGhazaei19(Ghazaei19 currentGhazaei19)
        {
            this.ObjectContext.Ghazaei19.AttachAsModified(currentGhazaei19, this.ChangeSet.GetOriginal(currentGhazaei19));
        }

        public void DeleteGhazaei19(Ghazaei19 ghazaei19)
        {
            if ((ghazaei19.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei19, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ghazaei19.Attach(ghazaei19);
                this.ObjectContext.Ghazaei19.DeleteObject(ghazaei19);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Ghazaei20' query.
        public IQueryable<Ghazaei20> GetGhazaei20()
        {
            return this.ObjectContext.Ghazaei20;
        }

        public void InsertGhazaei20(Ghazaei20 ghazaei20)
        {
            if ((ghazaei20.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei20, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Ghazaei20.AddObject(ghazaei20);
            }
        }

        public void UpdateGhazaei20(Ghazaei20 currentGhazaei20)
        {
            this.ObjectContext.Ghazaei20.AttachAsModified(currentGhazaei20, this.ChangeSet.GetOriginal(currentGhazaei20));
        }

        public void DeleteGhazaei20(Ghazaei20 ghazaei20)
        {
            if ((ghazaei20.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(ghazaei20, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Ghazaei20.Attach(ghazaei20);
                this.ObjectContext.Ghazaei20.DeleteObject(ghazaei20);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'HajoZiarat28' query.
        public IQueryable<HajoZiarat28> GetHajoZiarat28()
        {
            return this.ObjectContext.HajoZiarat28;
        }

        public void InsertHajoZiarat28(HajoZiarat28 hajoZiarat28)
        {
            if ((hajoZiarat28.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(hajoZiarat28, EntityState.Added);
            }
            else
            {
                this.ObjectContext.HajoZiarat28.AddObject(hajoZiarat28);
            }
        }

        public void UpdateHajoZiarat28(HajoZiarat28 currentHajoZiarat28)
        {
            this.ObjectContext.HajoZiarat28.AttachAsModified(currentHajoZiarat28, this.ChangeSet.GetOriginal(currentHajoZiarat28));
        }

        public void DeleteHajoZiarat28(HajoZiarat28 hajoZiarat28)
        {
            if ((hajoZiarat28.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(hajoZiarat28, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.HajoZiarat28.Attach(hajoZiarat28);
                this.ObjectContext.HajoZiarat28.DeleteObject(hajoZiarat28);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'HamloNaghlJaddei11' query.
        public IQueryable<HamloNaghlJaddei11> GetHamloNaghlJaddei11()
        {
            return this.ObjectContext.HamloNaghlJaddei11;
        }

        public void InsertHamloNaghlJaddei11(HamloNaghlJaddei11 hamloNaghlJaddei11)
        {
            if ((hamloNaghlJaddei11.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(hamloNaghlJaddei11, EntityState.Added);
            }
            else
            {
                this.ObjectContext.HamloNaghlJaddei11.AddObject(hamloNaghlJaddei11);
            }
        }

        public void UpdateHamloNaghlJaddei11(HamloNaghlJaddei11 currentHamloNaghlJaddei11)
        {
            this.ObjectContext.HamloNaghlJaddei11.AttachAsModified(currentHamloNaghlJaddei11, this.ChangeSet.GetOriginal(currentHamloNaghlJaddei11));
        }

        public void DeleteHamloNaghlJaddei11(HamloNaghlJaddei11 hamloNaghlJaddei11)
        {
            if ((hamloNaghlJaddei11.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(hamloNaghlJaddei11, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.HamloNaghlJaddei11.Attach(hamloNaghlJaddei11);
                this.ObjectContext.HamloNaghlJaddei11.DeleteObject(hamloNaghlJaddei11);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'ImageMetadatas' query.
        public IQueryable<ImageMetadatas> GetImageMetadatas()
        {
            return this.ObjectContext.ImageMetadatas;
        }

        public void InsertImageMetadatas(ImageMetadatas imageMetadatas)
        {
            if ((imageMetadatas.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(imageMetadatas, EntityState.Added);
            }
            else
            {
                this.ObjectContext.ImageMetadatas.AddObject(imageMetadatas);
            }
        }

        public void UpdateImageMetadatas(ImageMetadatas currentImageMetadatas)
        {
            this.ObjectContext.ImageMetadatas.AttachAsModified(currentImageMetadatas, this.ChangeSet.GetOriginal(currentImageMetadatas));
        }

        public void DeleteImageMetadatas(ImageMetadatas imageMetadatas)
        {
            if ((imageMetadatas.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(imageMetadatas, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.ImageMetadatas.Attach(imageMetadatas);
                this.ObjectContext.ImageMetadatas.DeleteObject(imageMetadatas);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Jameiyati5' query.
        public IQueryable<Jameiyati5> GetJameiyati5()
        {
            return this.ObjectContext.Jameiyati5;
        }

        public void InsertJameiyati5(Jameiyati5 jameiyati5)
        {
            if ((jameiyati5.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(jameiyati5, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Jameiyati5.AddObject(jameiyati5);
            }
        }

        public void UpdateJameiyati5(Jameiyati5 currentJameiyati5)
        {
            this.ObjectContext.Jameiyati5.AttachAsModified(currentJameiyati5, this.ChangeSet.GetOriginal(currentJameiyati5));
        }

        public void DeleteJameiyati5(Jameiyati5 jameiyati5)
        {
            if ((jameiyati5.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(jameiyati5, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Jameiyati5.Attach(jameiyati5);
                this.ObjectContext.Jameiyati5.DeleteObject(jameiyati5);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Keshavarzi17' query.
        public IQueryable<Keshavarzi17> GetKeshavarzi17()
        {
            return this.ObjectContext.Keshavarzi17;
        }

        public void InsertKeshavarzi17(Keshavarzi17 keshavarzi17)
        {
            if ((keshavarzi17.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(keshavarzi17, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Keshavarzi17.AddObject(keshavarzi17);
            }
        }

        public void UpdateKeshavarzi17(Keshavarzi17 currentKeshavarzi17)
        {
            this.ObjectContext.Keshavarzi17.AttachAsModified(currentKeshavarzi17, this.ChangeSet.GetOriginal(currentKeshavarzi17));
        }

        public void DeleteKeshavarzi17(Keshavarzi17 keshavarzi17)
        {
            if ((keshavarzi17.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(keshavarzi17, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Keshavarzi17.Attach(keshavarzi17);
                this.ObjectContext.Keshavarzi17.DeleteObject(keshavarzi17);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'KomiteEmdad22' query.
        public IQueryable<KomiteEmdad22> GetKomiteEmdad22()
        {
            return this.ObjectContext.KomiteEmdad22;
        }

        public void InsertKomiteEmdad22(KomiteEmdad22 komiteEmdad22)
        {
            if ((komiteEmdad22.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(komiteEmdad22, EntityState.Added);
            }
            else
            {
                this.ObjectContext.KomiteEmdad22.AddObject(komiteEmdad22);
            }
        }

        public void UpdateKomiteEmdad22(KomiteEmdad22 currentKomiteEmdad22)
        {
            this.ObjectContext.KomiteEmdad22.AttachAsModified(currentKomiteEmdad22, this.ChangeSet.GetOriginal(currentKomiteEmdad22));
        }

        public void DeleteKomiteEmdad22(KomiteEmdad22 komiteEmdad22)
        {
            if ((komiteEmdad22.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(komiteEmdad22, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.KomiteEmdad22.Attach(komiteEmdad22);
                this.ObjectContext.KomiteEmdad22.DeleteObject(komiteEmdad22);
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
        // To support paging you will need to add ordering to the 'Pooli1' query.
        public IQueryable<Pooli1> GetPooli1()
        {
            return this.ObjectContext.Pooli1;
        }

        public void InsertPooli1(Pooli1 pooli1)
        {
            if ((pooli1.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli1, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli1.AddObject(pooli1);
            }
        }

        public void UpdatePooli1(Pooli1 currentPooli1)
        {
            this.ObjectContext.Pooli1.AttachAsModified(currentPooli1, this.ChangeSet.GetOriginal(currentPooli1));
        }

        public void DeletePooli1(Pooli1 pooli1)
        {
            if ((pooli1.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli1, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli1.Attach(pooli1);
                this.ObjectContext.Pooli1.DeleteObject(pooli1);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli2' query.
        public IQueryable<Pooli2> GetPooli2()
        {
            return this.ObjectContext.Pooli2;
        }

        public void InsertPooli2(Pooli2 pooli2)
        {
            if ((pooli2.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli2, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli2.AddObject(pooli2);
            }
        }

        public void UpdatePooli2(Pooli2 currentPooli2)
        {
            this.ObjectContext.Pooli2.AttachAsModified(currentPooli2, this.ChangeSet.GetOriginal(currentPooli2));
        }

        public void DeletePooli2(Pooli2 pooli2)
        {
            if ((pooli2.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli2, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli2.Attach(pooli2);
                this.ObjectContext.Pooli2.DeleteObject(pooli2);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli3' query.
        public IQueryable<Pooli3> GetPooli3()
        {
            return this.ObjectContext.Pooli3;
        }

        public void InsertPooli3(Pooli3 pooli3)
        {
            if ((pooli3.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli3, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli3.AddObject(pooli3);
            }
        }

        public void UpdatePooli3(Pooli3 currentPooli3)
        {
            this.ObjectContext.Pooli3.AttachAsModified(currentPooli3, this.ChangeSet.GetOriginal(currentPooli3));
        }

        public void DeletePooli3(Pooli3 pooli3)
        {
            if ((pooli3.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli3, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli3.Attach(pooli3);
                this.ObjectContext.Pooli3.DeleteObject(pooli3);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4' query.
        public IQueryable<Pooli4> GetPooli4()
        {
            return this.ObjectContext.Pooli4;
        }

        public void InsertPooli4(Pooli4 pooli4)
        {
            if ((pooli4.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4.AddObject(pooli4);
            }
        }

        public void UpdatePooli4(Pooli4 currentPooli4)
        {
            this.ObjectContext.Pooli4.AttachAsModified(currentPooli4, this.ChangeSet.GetOriginal(currentPooli4));
        }

        public void DeletePooli4(Pooli4 pooli4)
        {
            if ((pooli4.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4.Attach(pooli4);
                this.ObjectContext.Pooli4.DeleteObject(pooli4);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Alborz' query.
        public IQueryable<Pooli4Alborz> GetPooli4Alborz()
        {
            return this.ObjectContext.Pooli4Alborz;
        }

        public void InsertPooli4Alborz(Pooli4Alborz pooli4Alborz)
        {
            if ((pooli4Alborz.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Alborz, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Alborz.AddObject(pooli4Alborz);
            }
        }

        public void UpdatePooli4Alborz(Pooli4Alborz currentPooli4Alborz)
        {
            this.ObjectContext.Pooli4Alborz.AttachAsModified(currentPooli4Alborz, this.ChangeSet.GetOriginal(currentPooli4Alborz));
        }

        public void DeletePooli4Alborz(Pooli4Alborz pooli4Alborz)
        {
            if ((pooli4Alborz.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Alborz, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Alborz.Attach(pooli4Alborz);
                this.ObjectContext.Pooli4Alborz.DeleteObject(pooli4Alborz);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Asia' query.
        public IQueryable<Pooli4Asia> GetPooli4Asia()
        {
            return this.ObjectContext.Pooli4Asia;
        }

        public void InsertPooli4Asia(Pooli4Asia pooli4Asia)
        {
            if ((pooli4Asia.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Asia, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Asia.AddObject(pooli4Asia);
            }
        }

        public void UpdatePooli4Asia(Pooli4Asia currentPooli4Asia)
        {
            this.ObjectContext.Pooli4Asia.AttachAsModified(currentPooli4Asia, this.ChangeSet.GetOriginal(currentPooli4Asia));
        }

        public void DeletePooli4Asia(Pooli4Asia pooli4Asia)
        {
            if ((pooli4Asia.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Asia, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Asia.Attach(pooli4Asia);
                this.ObjectContext.Pooli4Asia.DeleteObject(pooli4Asia);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Dana' query.
        public IQueryable<Pooli4Dana> GetPooli4Dana()
        {
            return this.ObjectContext.Pooli4Dana;
        }

        public void InsertPooli4Dana(Pooli4Dana pooli4Dana)
        {
            if ((pooli4Dana.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Dana, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Dana.AddObject(pooli4Dana);
            }
        }

        public void UpdatePooli4Dana(Pooli4Dana currentPooli4Dana)
        {
            this.ObjectContext.Pooli4Dana.AttachAsModified(currentPooli4Dana, this.ChangeSet.GetOriginal(currentPooli4Dana));
        }

        public void DeletePooli4Dana(Pooli4Dana pooli4Dana)
        {
            if ((pooli4Dana.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Dana, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Dana.Attach(pooli4Dana);
                this.ObjectContext.Pooli4Dana.DeleteObject(pooli4Dana);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Iran' query.
        public IQueryable<Pooli4Iran> GetPooli4Iran()
        {
            return this.ObjectContext.Pooli4Iran;
        }

        public void InsertPooli4Iran(Pooli4Iran pooli4Iran)
        {
            if ((pooli4Iran.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Iran, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Iran.AddObject(pooli4Iran);
            }
        }

        public void UpdatePooli4Iran(Pooli4Iran currentPooli4Iran)
        {
            this.ObjectContext.Pooli4Iran.AttachAsModified(currentPooli4Iran, this.ChangeSet.GetOriginal(currentPooli4Iran));
        }

        public void DeletePooli4Iran(Pooli4Iran pooli4Iran)
        {
            if ((pooli4Iran.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Iran, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Iran.Attach(pooli4Iran);
                this.ObjectContext.Pooli4Iran.DeleteObject(pooli4Iran);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Karafarin' query.
        public IQueryable<Pooli4Karafarin> GetPooli4Karafarin()
        {
            return this.ObjectContext.Pooli4Karafarin;
        }

        public void InsertPooli4Karafarin(Pooli4Karafarin pooli4Karafarin)
        {
            if ((pooli4Karafarin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Karafarin, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Karafarin.AddObject(pooli4Karafarin);
            }
        }

        public void UpdatePooli4Karafarin(Pooli4Karafarin currentPooli4Karafarin)
        {
            this.ObjectContext.Pooli4Karafarin.AttachAsModified(currentPooli4Karafarin, this.ChangeSet.GetOriginal(currentPooli4Karafarin));
        }

        public void DeletePooli4Karafarin(Pooli4Karafarin pooli4Karafarin)
        {
            if ((pooli4Karafarin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Karafarin, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Karafarin.Attach(pooli4Karafarin);
                this.ObjectContext.Pooli4Karafarin.DeleteObject(pooli4Karafarin);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Kosar' query.
        public IQueryable<Pooli4Kosar> GetPooli4Kosar()
        {
            return this.ObjectContext.Pooli4Kosar;
        }

        public void InsertPooli4Kosar(Pooli4Kosar pooli4Kosar)
        {
            if ((pooli4Kosar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Kosar, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Kosar.AddObject(pooli4Kosar);
            }
        }

        public void UpdatePooli4Kosar(Pooli4Kosar currentPooli4Kosar)
        {
            this.ObjectContext.Pooli4Kosar.AttachAsModified(currentPooli4Kosar, this.ChangeSet.GetOriginal(currentPooli4Kosar));
        }

        public void DeletePooli4Kosar(Pooli4Kosar pooli4Kosar)
        {
            if ((pooli4Kosar.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Kosar, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Kosar.Attach(pooli4Kosar);
                this.ObjectContext.Pooli4Kosar.DeleteObject(pooli4Kosar);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Mellat' query.
        public IQueryable<Pooli4Mellat> GetPooli4Mellat()
        {
            return this.ObjectContext.Pooli4Mellat;
        }

        public void InsertPooli4Mellat(Pooli4Mellat pooli4Mellat)
        {
            if ((pooli4Mellat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Mellat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Mellat.AddObject(pooli4Mellat);
            }
        }

        public void UpdatePooli4Mellat(Pooli4Mellat currentPooli4Mellat)
        {
            this.ObjectContext.Pooli4Mellat.AttachAsModified(currentPooli4Mellat, this.ChangeSet.GetOriginal(currentPooli4Mellat));
        }

        public void DeletePooli4Mellat(Pooli4Mellat pooli4Mellat)
        {
            if ((pooli4Mellat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Mellat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Mellat.Attach(pooli4Mellat);
                this.ObjectContext.Pooli4Mellat.DeleteObject(pooli4Mellat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Mihan' query.
        public IQueryable<Pooli4Mihan> GetPooli4Mihan()
        {
            return this.ObjectContext.Pooli4Mihan;
        }

        public void InsertPooli4Mihan(Pooli4Mihan pooli4Mihan)
        {
            if ((pooli4Mihan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Mihan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Mihan.AddObject(pooli4Mihan);
            }
        }

        public void UpdatePooli4Mihan(Pooli4Mihan currentPooli4Mihan)
        {
            this.ObjectContext.Pooli4Mihan.AttachAsModified(currentPooli4Mihan, this.ChangeSet.GetOriginal(currentPooli4Mihan));
        }

        public void DeletePooli4Mihan(Pooli4Mihan pooli4Mihan)
        {
            if ((pooli4Mihan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Mihan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Mihan.Attach(pooli4Mihan);
                this.ObjectContext.Pooli4Mihan.DeleteObject(pooli4Mihan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Moalem' query.
        public IQueryable<Pooli4Moalem> GetPooli4Moalem()
        {
            return this.ObjectContext.Pooli4Moalem;
        }

        public void InsertPooli4Moalem(Pooli4Moalem pooli4Moalem)
        {
            if ((pooli4Moalem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Moalem, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Moalem.AddObject(pooli4Moalem);
            }
        }

        public void UpdatePooli4Moalem(Pooli4Moalem currentPooli4Moalem)
        {
            this.ObjectContext.Pooli4Moalem.AttachAsModified(currentPooli4Moalem, this.ChangeSet.GetOriginal(currentPooli4Moalem));
        }

        public void DeletePooli4Moalem(Pooli4Moalem pooli4Moalem)
        {
            if ((pooli4Moalem.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Moalem, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Moalem.Attach(pooli4Moalem);
                this.ObjectContext.Pooli4Moalem.DeleteObject(pooli4Moalem);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Novin' query.
        public IQueryable<Pooli4Novin> GetPooli4Novin()
        {
            return this.ObjectContext.Pooli4Novin;
        }

        public void InsertPooli4Novin(Pooli4Novin pooli4Novin)
        {
            if ((pooli4Novin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Novin, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Novin.AddObject(pooli4Novin);
            }
        }

        public void UpdatePooli4Novin(Pooli4Novin currentPooli4Novin)
        {
            this.ObjectContext.Pooli4Novin.AttachAsModified(currentPooli4Novin, this.ChangeSet.GetOriginal(currentPooli4Novin));
        }

        public void DeletePooli4Novin(Pooli4Novin pooli4Novin)
        {
            if ((pooli4Novin.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Novin, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Novin.Attach(pooli4Novin);
                this.ObjectContext.Pooli4Novin.DeleteObject(pooli4Novin);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Parsian' query.
        public IQueryable<Pooli4Parsian> GetPooli4Parsian()
        {
            return this.ObjectContext.Pooli4Parsian;
        }

        public void InsertPooli4Parsian(Pooli4Parsian pooli4Parsian)
        {
            if ((pooli4Parsian.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Parsian, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Parsian.AddObject(pooli4Parsian);
            }
        }

        public void UpdatePooli4Parsian(Pooli4Parsian currentPooli4Parsian)
        {
            this.ObjectContext.Pooli4Parsian.AttachAsModified(currentPooli4Parsian, this.ChangeSet.GetOriginal(currentPooli4Parsian));
        }

        public void DeletePooli4Parsian(Pooli4Parsian pooli4Parsian)
        {
            if ((pooli4Parsian.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Parsian, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Parsian.Attach(pooli4Parsian);
                this.ObjectContext.Pooli4Parsian.DeleteObject(pooli4Parsian);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Pasargad' query.
        public IQueryable<Pooli4Pasargad> GetPooli4Pasargad()
        {
            return this.ObjectContext.Pooli4Pasargad;
        }

        public void InsertPooli4Pasargad(Pooli4Pasargad pooli4Pasargad)
        {
            if ((pooli4Pasargad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Pasargad, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Pasargad.AddObject(pooli4Pasargad);
            }
        }

        public void UpdatePooli4Pasargad(Pooli4Pasargad currentPooli4Pasargad)
        {
            this.ObjectContext.Pooli4Pasargad.AttachAsModified(currentPooli4Pasargad, this.ChangeSet.GetOriginal(currentPooli4Pasargad));
        }

        public void DeletePooli4Pasargad(Pooli4Pasargad pooli4Pasargad)
        {
            if ((pooli4Pasargad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Pasargad, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Pasargad.Attach(pooli4Pasargad);
                this.ObjectContext.Pooli4Pasargad.DeleteObject(pooli4Pasargad);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Razi' query.
        public IQueryable<Pooli4Razi> GetPooli4Razi()
        {
            return this.ObjectContext.Pooli4Razi;
        }

        public void InsertPooli4Razi(Pooli4Razi pooli4Razi)
        {
            if ((pooli4Razi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Razi, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Razi.AddObject(pooli4Razi);
            }
        }

        public void UpdatePooli4Razi(Pooli4Razi currentPooli4Razi)
        {
            this.ObjectContext.Pooli4Razi.AttachAsModified(currentPooli4Razi, this.ChangeSet.GetOriginal(currentPooli4Razi));
        }

        public void DeletePooli4Razi(Pooli4Razi pooli4Razi)
        {
            if ((pooli4Razi.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Razi, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Razi.Attach(pooli4Razi);
                this.ObjectContext.Pooli4Razi.DeleteObject(pooli4Razi);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Saman' query.
        public IQueryable<Pooli4Saman> GetPooli4Saman()
        {
            return this.ObjectContext.Pooli4Saman;
        }

        public void InsertPooli4Saman(Pooli4Saman pooli4Saman)
        {
            if ((pooli4Saman.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Saman, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Saman.AddObject(pooli4Saman);
            }
        }

        public void UpdatePooli4Saman(Pooli4Saman currentPooli4Saman)
        {
            this.ObjectContext.Pooli4Saman.AttachAsModified(currentPooli4Saman, this.ChangeSet.GetOriginal(currentPooli4Saman));
        }

        public void DeletePooli4Saman(Pooli4Saman pooli4Saman)
        {
            if ((pooli4Saman.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Saman, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Saman.Attach(pooli4Saman);
                this.ObjectContext.Pooli4Saman.DeleteObject(pooli4Saman);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Sina' query.
        public IQueryable<Pooli4Sina> GetPooli4Sina()
        {
            return this.ObjectContext.Pooli4Sina;
        }

        public void InsertPooli4Sina(Pooli4Sina pooli4Sina)
        {
            if ((pooli4Sina.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Sina, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Sina.AddObject(pooli4Sina);
            }
        }

        public void UpdatePooli4Sina(Pooli4Sina currentPooli4Sina)
        {
            this.ObjectContext.Pooli4Sina.AttachAsModified(currentPooli4Sina, this.ChangeSet.GetOriginal(currentPooli4Sina));
        }

        public void DeletePooli4Sina(Pooli4Sina pooli4Sina)
        {
            if ((pooli4Sina.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Sina, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Sina.Attach(pooli4Sina);
                this.ObjectContext.Pooli4Sina.DeleteObject(pooli4Sina);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Pooli4Tosee' query.
        public IQueryable<Pooli4Tosee> GetPooli4Tosee()
        {
            return this.ObjectContext.Pooli4Tosee;
        }

        public void InsertPooli4Tosee(Pooli4Tosee pooli4Tosee)
        {
            if ((pooli4Tosee.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Tosee, EntityState.Added);
            }
            else
            {
                this.ObjectContext.Pooli4Tosee.AddObject(pooli4Tosee);
            }
        }

        public void UpdatePooli4Tosee(Pooli4Tosee currentPooli4Tosee)
        {
            this.ObjectContext.Pooli4Tosee.AttachAsModified(currentPooli4Tosee, this.ChangeSet.GetOriginal(currentPooli4Tosee));
        }

        public void DeletePooli4Tosee(Pooli4Tosee pooli4Tosee)
        {
            if ((pooli4Tosee.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(pooli4Tosee, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.Pooli4Tosee.Attach(pooli4Tosee);
                this.ObjectContext.Pooli4Tosee.DeleteObject(pooli4Tosee);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SanatMadan16' query.
        public IQueryable<SanatMadan16> GetSanatMadan16()
        {
            return this.ObjectContext.SanatMadan16;
        }

        public void InsertSanatMadan16(SanatMadan16 sanatMadan16)
        {
            if ((sanatMadan16.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sanatMadan16, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SanatMadan16.AddObject(sanatMadan16);
            }
        }

        public void UpdateSanatMadan16(SanatMadan16 currentSanatMadan16)
        {
            this.ObjectContext.SanatMadan16.AttachAsModified(currentSanatMadan16, this.ChangeSet.GetOriginal(currentSanatMadan16));
        }

        public void DeleteSanatMadan16(SanatMadan16 sanatMadan16)
        {
            if ((sanatMadan16.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sanatMadan16, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SanatMadan16.Attach(sanatMadan16);
                this.ObjectContext.SanatMadan16.DeleteObject(sanatMadan16);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SedaSima15' query.
        public IQueryable<SedaSima15> GetSedaSima15()
        {
            return this.ObjectContext.SedaSima15;
        }

        public void InsertSedaSima15(SedaSima15 sedaSima15)
        {
            if ((sedaSima15.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sedaSima15, EntityState.Added);
            }
            else
            {
                this.ObjectContext.SedaSima15.AddObject(sedaSima15);
            }
        }

        public void UpdateSedaSima15(SedaSima15 currentSedaSima15)
        {
            this.ObjectContext.SedaSima15.AttachAsModified(currentSedaSima15, this.ChangeSet.GetOriginal(currentSedaSima15));
        }

        public void DeleteSedaSima15(SedaSima15 sedaSima15)
        {
            if ((sedaSima15.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(sedaSima15, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.SedaSima15.Attach(sedaSima15);
                this.ObjectContext.SedaSima15.DeleteObject(sedaSima15);
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
        // To support paging you will need to add ordering to the 'TaminEjtemaei24' query.
        public IQueryable<TaminEjtemaei24> GetTaminEjtemaei24()
        {
            return this.ObjectContext.TaminEjtemaei24;
        }

        public void InsertTaminEjtemaei24(TaminEjtemaei24 taminEjtemaei24)
        {
            if ((taminEjtemaei24.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(taminEjtemaei24, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TaminEjtemaei24.AddObject(taminEjtemaei24);
            }
        }

        public void UpdateTaminEjtemaei24(TaminEjtemaei24 currentTaminEjtemaei24)
        {
            this.ObjectContext.TaminEjtemaei24.AttachAsModified(currentTaminEjtemaei24, this.ChangeSet.GetOriginal(currentTaminEjtemaei24));
        }

        public void DeleteTaminEjtemaei24(TaminEjtemaei24 taminEjtemaei24)
        {
            if ((taminEjtemaei24.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(taminEjtemaei24, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TaminEjtemaei24.Attach(taminEjtemaei24);
                this.ObjectContext.TaminEjtemaei24.DeleteObject(taminEjtemaei24);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TaminEjtemaei25' query.
        public IQueryable<TaminEjtemaei25> GetTaminEjtemaei25()
        {
            return this.ObjectContext.TaminEjtemaei25;
        }

        public void InsertTaminEjtemaei25(TaminEjtemaei25 taminEjtemaei25)
        {
            if ((taminEjtemaei25.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(taminEjtemaei25, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TaminEjtemaei25.AddObject(taminEjtemaei25);
            }
        }

        public void UpdateTaminEjtemaei25(TaminEjtemaei25 currentTaminEjtemaei25)
        {
            this.ObjectContext.TaminEjtemaei25.AttachAsModified(currentTaminEjtemaei25, this.ChangeSet.GetOriginal(currentTaminEjtemaei25));
        }

        public void DeleteTaminEjtemaei25(TaminEjtemaei25 taminEjtemaei25)
        {
            if ((taminEjtemaei25.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(taminEjtemaei25, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TaminEjtemaei25.Attach(taminEjtemaei25);
                this.ObjectContext.TaminEjtemaei25.DeleteObject(taminEjtemaei25);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TarbiatBadani29' query.
        public IQueryable<TarbiatBadani29> GetTarbiatBadani29()
        {
            return this.ObjectContext.TarbiatBadani29;
        }

        public void InsertTarbiatBadani29(TarbiatBadani29 tarbiatBadani29)
        {
            if ((tarbiatBadani29.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tarbiatBadani29, EntityState.Added);
            }
            else
            {
                this.ObjectContext.TarbiatBadani29.AddObject(tarbiatBadani29);
            }
        }

        public void UpdateTarbiatBadani29(TarbiatBadani29 currentTarbiatBadani29)
        {
            this.ObjectContext.TarbiatBadani29.AttachAsModified(currentTarbiatBadani29, this.ChangeSet.GetOriginal(currentTarbiatBadani29));
        }

        public void DeleteTarbiatBadani29(TarbiatBadani29 tarbiatBadani29)
        {
            if ((tarbiatBadani29.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(tarbiatBadani29, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.TarbiatBadani29.Attach(tarbiatBadani29);
                this.ObjectContext.TarbiatBadani29.DeleteObject(tarbiatBadani29);
            }
        }
    }
}


