
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


    // Implements application logic using the ViewEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class ViewDomainService : LinqToEntitiesDomainService<ViewEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_Block' query.
        public IQueryable<vwJamiat_Block> GetVwJamiat_Block()
        {
            return this.ObjectContext.vwJamiat_Block;
        }

        public void InsertVwJamiat_Block(vwJamiat_Block vwJamiat_Block)
        {
            if ((vwJamiat_Block.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Block, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_Block.AddObject(vwJamiat_Block);
            }
        }

        public void UpdateVwJamiat_Block(vwJamiat_Block currentvwJamiat_Block)
        {
            this.ObjectContext.vwJamiat_Block.AttachAsModified(currentvwJamiat_Block, this.ChangeSet.GetOriginal(currentvwJamiat_Block));
        }

        public void DeleteVwJamiat_Block(vwJamiat_Block vwJamiat_Block)
        {
            if ((vwJamiat_Block.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Block, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_Block.Attach(vwJamiat_Block);
                this.ObjectContext.vwJamiat_Block.DeleteObject(vwJamiat_Block);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_Eghamat' query.
        public IQueryable<vwJamiat_Eghamat> GetVwJamiat_Eghamat()
        {
            return this.ObjectContext.vwJamiat_Eghamat;
        }

        public void InsertVwJamiat_Eghamat(vwJamiat_Eghamat vwJamiat_Eghamat)
        {
            if ((vwJamiat_Eghamat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Eghamat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_Eghamat.AddObject(vwJamiat_Eghamat);
            }
        }

        public void UpdateVwJamiat_Eghamat(vwJamiat_Eghamat currentvwJamiat_Eghamat)
        {
            this.ObjectContext.vwJamiat_Eghamat.AttachAsModified(currentvwJamiat_Eghamat, this.ChangeSet.GetOriginal(currentvwJamiat_Eghamat));
        }

        public void DeleteVwJamiat_Eghamat(vwJamiat_Eghamat vwJamiat_Eghamat)
        {
            if ((vwJamiat_Eghamat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Eghamat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_Eghamat.Attach(vwJamiat_Eghamat);
                this.ObjectContext.vwJamiat_Eghamat.DeleteObject(vwJamiat_Eghamat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_Jensiat' query.
        public IQueryable<vwJamiat_Jensiat> GetVwJamiat_Jensiat()
        {
            return this.ObjectContext.vwJamiat_Jensiat;
        }

        public void InsertVwJamiat_Jensiat(vwJamiat_Jensiat vwJamiat_Jensiat)
        {
            if ((vwJamiat_Jensiat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Jensiat, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_Jensiat.AddObject(vwJamiat_Jensiat);
            }
        }

        public void UpdateVwJamiat_Jensiat(vwJamiat_Jensiat currentvwJamiat_Jensiat)
        {
            this.ObjectContext.vwJamiat_Jensiat.AttachAsModified(currentvwJamiat_Jensiat, this.ChangeSet.GetOriginal(currentvwJamiat_Jensiat));
        }

        public void DeleteVwJamiat_Jensiat(vwJamiat_Jensiat vwJamiat_Jensiat)
        {
            if ((vwJamiat_Jensiat.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Jensiat, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_Jensiat.Attach(vwJamiat_Jensiat);
                this.ObjectContext.vwJamiat_Jensiat.DeleteObject(vwJamiat_Jensiat);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_MahaleKarYaTahsil' query.
        public IQueryable<vwJamiat_MahaleKarYaTahsil> GetVwJamiat_MahaleKarYaTahsil()
        {
            return this.ObjectContext.vwJamiat_MahaleKarYaTahsil;
        }

        public void InsertVwJamiat_MahaleKarYaTahsil(vwJamiat_MahaleKarYaTahsil vwJamiat_MahaleKarYaTahsil)
        {
            if ((vwJamiat_MahaleKarYaTahsil.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_MahaleKarYaTahsil, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_MahaleKarYaTahsil.AddObject(vwJamiat_MahaleKarYaTahsil);
            }
        }

        public void UpdateVwJamiat_MahaleKarYaTahsil(vwJamiat_MahaleKarYaTahsil currentvwJamiat_MahaleKarYaTahsil)
        {
            this.ObjectContext.vwJamiat_MahaleKarYaTahsil.AttachAsModified(currentvwJamiat_MahaleKarYaTahsil, this.ChangeSet.GetOriginal(currentvwJamiat_MahaleKarYaTahsil));
        }

        public void DeleteVwJamiat_MahaleKarYaTahsil(vwJamiat_MahaleKarYaTahsil vwJamiat_MahaleKarYaTahsil)
        {
            if ((vwJamiat_MahaleKarYaTahsil.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_MahaleKarYaTahsil, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_MahaleKarYaTahsil.Attach(vwJamiat_MahaleKarYaTahsil);
                this.ObjectContext.vwJamiat_MahaleKarYaTahsil.DeleteObject(vwJamiat_MahaleKarYaTahsil);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_MahaleTavalod' query.
        public IQueryable<vwJamiat_MahaleTavalod> GetVwJamiat_MahaleTavalod()
        {
            return this.ObjectContext.vwJamiat_MahaleTavalod;
        }

        public void InsertVwJamiat_MahaleTavalod(vwJamiat_MahaleTavalod vwJamiat_MahaleTavalod)
        {
            if ((vwJamiat_MahaleTavalod.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_MahaleTavalod, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_MahaleTavalod.AddObject(vwJamiat_MahaleTavalod);
            }
        }

        public void UpdateVwJamiat_MahaleTavalod(vwJamiat_MahaleTavalod currentvwJamiat_MahaleTavalod)
        {
            this.ObjectContext.vwJamiat_MahaleTavalod.AttachAsModified(currentvwJamiat_MahaleTavalod, this.ChangeSet.GetOriginal(currentvwJamiat_MahaleTavalod));
        }

        public void DeleteVwJamiat_MahaleTavalod(vwJamiat_MahaleTavalod vwJamiat_MahaleTavalod)
        {
            if ((vwJamiat_MahaleTavalod.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_MahaleTavalod, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_MahaleTavalod.Attach(vwJamiat_MahaleTavalod);
                this.ObjectContext.vwJamiat_MahaleTavalod.DeleteObject(vwJamiat_MahaleTavalod);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_savad' query.
        public IQueryable<vwJamiat_savad> GetVwJamiat_savad()
        {
            return this.ObjectContext.vwJamiat_savad;
        }

        public void InsertVwJamiat_savad(vwJamiat_savad vwJamiat_savad)
        {
            if ((vwJamiat_savad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_savad, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_savad.AddObject(vwJamiat_savad);
            }
        }

        public void UpdateVwJamiat_savad(vwJamiat_savad currentvwJamiat_savad)
        {
            this.ObjectContext.vwJamiat_savad.AttachAsModified(currentvwJamiat_savad, this.ChangeSet.GetOriginal(currentvwJamiat_savad));
        }

        public void DeleteVwJamiat_savad(vwJamiat_savad vwJamiat_savad)
        {
            if ((vwJamiat_savad.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_savad, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_savad.Attach(vwJamiat_savad);
                this.ObjectContext.vwJamiat_savad.DeleteObject(vwJamiat_savad);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_ShahrYaDehestan' query.
        public IQueryable<vwJamiat_ShahrYaDehestan> GetVwJamiat_ShahrYaDehestan()
        {
            return this.ObjectContext.vwJamiat_ShahrYaDehestan;
        }

        public void InsertVwJamiat_ShahrYaDehestan(vwJamiat_ShahrYaDehestan vwJamiat_ShahrYaDehestan)
        {
            if ((vwJamiat_ShahrYaDehestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_ShahrYaDehestan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_ShahrYaDehestan.AddObject(vwJamiat_ShahrYaDehestan);
            }
        }

        public void UpdateVwJamiat_ShahrYaDehestan(vwJamiat_ShahrYaDehestan currentvwJamiat_ShahrYaDehestan)
        {
            this.ObjectContext.vwJamiat_ShahrYaDehestan.AttachAsModified(currentvwJamiat_ShahrYaDehestan, this.ChangeSet.GetOriginal(currentvwJamiat_ShahrYaDehestan));
        }

        public void DeleteVwJamiat_ShahrYaDehestan(vwJamiat_ShahrYaDehestan vwJamiat_ShahrYaDehestan)
        {
            if ((vwJamiat_ShahrYaDehestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_ShahrYaDehestan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_ShahrYaDehestan.Attach(vwJamiat_ShahrYaDehestan);
                this.ObjectContext.vwJamiat_ShahrYaDehestan.DeleteObject(vwJamiat_ShahrYaDehestan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_Shoghl' query.
        public IQueryable<vwJamiat_Shoghl> GetVwJamiat_Shoghl()
        {
            return this.ObjectContext.vwJamiat_Shoghl;
        }

        public void InsertVwJamiat_Shoghl(vwJamiat_Shoghl vwJamiat_Shoghl)
        {
            if ((vwJamiat_Shoghl.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Shoghl, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_Shoghl.AddObject(vwJamiat_Shoghl);
            }
        }

        public void UpdateVwJamiat_Shoghl(vwJamiat_Shoghl currentvwJamiat_Shoghl)
        {
            this.ObjectContext.vwJamiat_Shoghl.AttachAsModified(currentvwJamiat_Shoghl, this.ChangeSet.GetOriginal(currentvwJamiat_Shoghl));
        }

        public void DeleteVwJamiat_Shoghl(vwJamiat_Shoghl vwJamiat_Shoghl)
        {
            if ((vwJamiat_Shoghl.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Shoghl, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_Shoghl.Attach(vwJamiat_Shoghl);
                this.ObjectContext.vwJamiat_Shoghl.DeleteObject(vwJamiat_Shoghl);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiat_Taahol' query.
        public IQueryable<vwJamiat_Taahol> GetVwJamiat_Taahol()
        {
            return this.ObjectContext.vwJamiat_Taahol;
        }

        public void InsertVwJamiat_Taahol(vwJamiat_Taahol vwJamiat_Taahol)
        {
            if ((vwJamiat_Taahol.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Taahol, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiat_Taahol.AddObject(vwJamiat_Taahol);
            }
        }

        public void UpdateVwJamiat_Taahol(vwJamiat_Taahol currentvwJamiat_Taahol)
        {
            this.ObjectContext.vwJamiat_Taahol.AttachAsModified(currentvwJamiat_Taahol, this.ChangeSet.GetOriginal(currentvwJamiat_Taahol));
        }

        public void DeleteVwJamiat_Taahol(vwJamiat_Taahol vwJamiat_Taahol)
        {
            if ((vwJamiat_Taahol.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiat_Taahol, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiat_Taahol.Attach(vwJamiat_Taahol);
                this.ObjectContext.vwJamiat_Taahol.DeleteObject(vwJamiat_Taahol);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiatKol_Sen' query.
        public IQueryable<vwJamiatKol_Sen> GetVwJamiatKol_Sen()
        {
            return this.ObjectContext.vwJamiatKol_Sen;
        }

        public void InsertVwJamiatKol_Sen(vwJamiatKol_Sen vwJamiatKol_Sen)
        {
            if ((vwJamiatKol_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatKol_Sen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiatKol_Sen.AddObject(vwJamiatKol_Sen);
            }
        }

        public void UpdateVwJamiatKol_Sen(vwJamiatKol_Sen currentvwJamiatKol_Sen)
        {
            this.ObjectContext.vwJamiatKol_Sen.AttachAsModified(currentvwJamiatKol_Sen, this.ChangeSet.GetOriginal(currentvwJamiatKol_Sen));
        }

        public void DeleteVwJamiatKol_Sen(vwJamiatKol_Sen vwJamiatKol_Sen)
        {
            if ((vwJamiatKol_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatKol_Sen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiatKol_Sen.Attach(vwJamiatKol_Sen);
                this.ObjectContext.vwJamiatKol_Sen.DeleteObject(vwJamiatKol_Sen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiatMard_Sen' query.
        public IQueryable<vwJamiatMard_Sen> GetVwJamiatMard_Sen()
        {
            return this.ObjectContext.vwJamiatMard_Sen;
        }

        public void InsertVwJamiatMard_Sen(vwJamiatMard_Sen vwJamiatMard_Sen)
        {
            if ((vwJamiatMard_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatMard_Sen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiatMard_Sen.AddObject(vwJamiatMard_Sen);
            }
        }

        public void UpdateVwJamiatMard_Sen(vwJamiatMard_Sen currentvwJamiatMard_Sen)
        {
            this.ObjectContext.vwJamiatMard_Sen.AttachAsModified(currentvwJamiatMard_Sen, this.ChangeSet.GetOriginal(currentvwJamiatMard_Sen));
        }

        public void DeleteVwJamiatMard_Sen(vwJamiatMard_Sen vwJamiatMard_Sen)
        {
            if ((vwJamiatMard_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatMard_Sen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiatMard_Sen.Attach(vwJamiatMard_Sen);
                this.ObjectContext.vwJamiatMard_Sen.DeleteObject(vwJamiatMard_Sen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwJamiatZan_Sen' query.
        public IQueryable<vwJamiatZan_Sen> GetVwJamiatZan_Sen()
        {
            return this.ObjectContext.vwJamiatZan_Sen;
        }

        public void InsertVwJamiatZan_Sen(vwJamiatZan_Sen vwJamiatZan_Sen)
        {
            if ((vwJamiatZan_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatZan_Sen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwJamiatZan_Sen.AddObject(vwJamiatZan_Sen);
            }
        }

        public void UpdateVwJamiatZan_Sen(vwJamiatZan_Sen currentvwJamiatZan_Sen)
        {
            this.ObjectContext.vwJamiatZan_Sen.AttachAsModified(currentvwJamiatZan_Sen, this.ChangeSet.GetOriginal(currentvwJamiatZan_Sen));
        }

        public void DeleteVwJamiatZan_Sen(vwJamiatZan_Sen vwJamiatZan_Sen)
        {
            if ((vwJamiatZan_Sen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwJamiatZan_Sen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwJamiatZan_Sen.Attach(vwJamiatZan_Sen);
                this.ObjectContext.vwJamiatZan_Sen.DeleteObject(vwJamiatZan_Sen);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwKhanevar_ShahryaDehestan' query.
        public IQueryable<vwKhanevar_ShahryaDehestan> GetVwKhanevar_ShahryaDehestan()
        {
            return this.ObjectContext.vwKhanevar_ShahryaDehestan;
        }

        public void InsertVwKhanevar_ShahryaDehestan(vwKhanevar_ShahryaDehestan vwKhanevar_ShahryaDehestan)
        {
            if ((vwKhanevar_ShahryaDehestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwKhanevar_ShahryaDehestan, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwKhanevar_ShahryaDehestan.AddObject(vwKhanevar_ShahryaDehestan);
            }
        }

        public void UpdateVwKhanevar_ShahryaDehestan(vwKhanevar_ShahryaDehestan currentvwKhanevar_ShahryaDehestan)
        {
            this.ObjectContext.vwKhanevar_ShahryaDehestan.AttachAsModified(currentvwKhanevar_ShahryaDehestan, this.ChangeSet.GetOriginal(currentvwKhanevar_ShahryaDehestan));
        }

        public void DeleteVwKhanevar_ShahryaDehestan(vwKhanevar_ShahryaDehestan vwKhanevar_ShahryaDehestan)
        {
            if ((vwKhanevar_ShahryaDehestan.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwKhanevar_ShahryaDehestan, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwKhanevar_ShahryaDehestan.Attach(vwKhanevar_ShahryaDehestan);
                this.ObjectContext.vwKhanevar_ShahryaDehestan.DeleteObject(vwKhanevar_ShahryaDehestan);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'vwMasahatZirBana' query.
        public IQueryable<vwMasahatZirBana> GetVwMasahatZirBana()
        {
            return this.ObjectContext.vwMasahatZirBana;
        }

        public void InsertVwMasahatZirBana(vwMasahatZirBana vwMasahatZirBana)
        {
            if ((vwMasahatZirBana.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMasahatZirBana, EntityState.Added);
            }
            else
            {
                this.ObjectContext.vwMasahatZirBana.AddObject(vwMasahatZirBana);
            }
        }

        public void UpdateVwMasahatZirBana(vwMasahatZirBana currentvwMasahatZirBana)
        {
            this.ObjectContext.vwMasahatZirBana.AttachAsModified(currentvwMasahatZirBana, this.ChangeSet.GetOriginal(currentvwMasahatZirBana));
        }

        public void DeleteVwMasahatZirBana(vwMasahatZirBana vwMasahatZirBana)
        {
            if ((vwMasahatZirBana.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(vwMasahatZirBana, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.vwMasahatZirBana.Attach(vwMasahatZirBana);
                this.ObjectContext.vwMasahatZirBana.DeleteObject(vwMasahatZirBana);
            }
        }
    }
}


