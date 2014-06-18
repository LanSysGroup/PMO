
using System.Collections.ObjectModel;
using System.IO;
using System.Web;

namespace LanSysWebGIS.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using System.Windows;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class FileHandler : DomainService
    {
        [Invoke]
        public List<string> GetSubjects()
        {
            //string path = HttpContext.Current.Request.PhysicalApplicationPath + @"Files\";

            string path = basePath;

            return ProcessDirectory(path);

        }

        private string basePath = @"C:\inetpub\wwwroot\" + @"Files\";

        private static List<string> subdirectoryEntries;

        public List<string> ProcessDirectory(string targetDirectory)
        {
            subdirectoryEntries = new List<string>();

            List<string> compSubdirectoryEntries = Directory.GetDirectories(targetDirectory).ToList<string>();

            foreach (string compSubdirectoryEntry in compSubdirectoryEntries)
            {
                string[] sections = compSubdirectoryEntry.Split('\\');

                subdirectoryEntries.Add(sections.Last());
            }

            return subdirectoryEntries;
        }

        [Invoke]
        public List<FileDetails> GetFileDetails(ObservableCollection<GraphicFeatureDetails> gfdList)
        {
            List<FileDetails> fDetailsList = new List<FileDetails>();

            foreach (string directory in subdirectoryEntries)
            {
                string path = basePath + directory;

                //string path = @"http://localhost/" + @"Files/" + directory;

                List<string> fileNames = Directory.GetFiles(path).ToList<string>();

                foreach (GraphicFeatureDetails gfd in gfdList)
                {
                    //var selectedFiles = fileNames.Where(p => p.Contains(gfd.ObjectCode));

                    foreach (string fn in fileNames)
                    {
                        if (!string.IsNullOrWhiteSpace(gfd.ObjectCode) && fn.Contains(gfd.ObjectCode))
                        {
                            FileDetails fDetails = new FileDetails();

                            string[] sections = fn.Split('\\');

                            //string appPath = HttpContext.Current.Request.ApplicationPath.Last() == '/'
                            //               ? HttpContext.Current.Request.ApplicationPath
                            //               : HttpContext.Current.Request.ApplicationPath + "//";

                            //fDetails.FilePath = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
                            //appPath + "Files//" + directory + "//" + sections.Last();

                            fDetails.FilePath = @"http://localhost/Files/" + directory + "//" + sections.Last();

                            fDetails.Subject = directory;

                            fDetails.featureDetails = gfd;

                            fDetailsList.Add(fDetails);
                        }
                    }
                }
            }

            return fDetailsList;
        }

        //[Invoke]
        //public List<FileDetails> SearchFiles(List<FileDetails> fDetails)
        //{

        //}

    }
}


