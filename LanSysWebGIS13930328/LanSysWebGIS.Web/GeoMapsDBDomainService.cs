
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


    // Implements application logic using the GeoMapsDBEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public class GeoMapsDBDomainService : LinqToEntitiesDomainService<GeoMapsDBEntities>
    {

        public void ClearSelectedLayers()
        {
            this.ObjectContext.ClearSelectedLayers();
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'LayersWithDoc' query.
        public IQueryable<LayersWithDoc> GetLayersWithDoc()
        {
            return this.ObjectContext.LayersWithDoc;
        }

        public void InsertLayersWithDoc(LayersWithDoc layersWithDoc)
        {
            if ((layersWithDoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(layersWithDoc, EntityState.Added);
            }
            else
            {
                this.ObjectContext.LayersWithDoc.AddObject(layersWithDoc);
            }
        }

        public void UpdateLayersWithDoc(LayersWithDoc currentLayersWithDoc)
        {
            this.ObjectContext.LayersWithDoc.AttachAsModified(currentLayersWithDoc, this.ChangeSet.GetOriginal(currentLayersWithDoc));
        }

        public void DeleteLayersWithDoc(LayersWithDoc layersWithDoc)
        {
            if ((layersWithDoc.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(layersWithDoc, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.LayersWithDoc.Attach(layersWithDoc);
                this.ObjectContext.LayersWithDoc.DeleteObject(layersWithDoc);
            }
        }
    }
}


