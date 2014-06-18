using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows;

namespace LanSysWebGIS.Web
{
    /// <summary>
    /// Summary description for UploadService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UploadService : System.Web.Services.WebService
    {

        [WebMethod]
        public string Upload(string id, string mode, string path, string name, string filedata, bool overwrite, string tag, bool final)
        {
            string filename = string.Empty;

            path = path + DateTime.Now.Year + '-' + DateTime.Now.Month + '-' + DateTime.Now.Day + @"\";

            try
            {
                //filename = Server.MapPath("~") + @"\" + path.Replace("/", @"\") + name;

                filename = path + name;

                //MessageBox.Show(filename);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //MessageBox.Show("Directory Checked");

                //filename.Replace(@"\UploadService.asmx", "");

                if (mode == "new")
                {
                    if (File.Exists(filename) == true)
                    {
                        //MessageBox.Show("File Checked");

                        if (overwrite)
                        {
                            File.Delete(filename);

                            //MessageBox.Show("File Deleted");
                        }
                        else
                        {
                            return "File Already Exists";
                        }
                    }

                    WriteFile(filename, Convert.FromBase64String(filedata), FileMode.Create);
                }
                else
                {
                    WriteFile(filename, Convert.FromBase64String(filedata), FileMode.Append);
                }
            }
            catch (Exception ex)
            {
                File.Delete(filename);

                //MessageBox.Show(ex.Message);

                return "File Write Error: " + ex.Message;
            }

            return "ok";
        }

        private void WriteFile(string filename, byte[] content, FileMode fileMode)
        {
            Stream target = null;
            BinaryWriter writer = null;

            //MessageBox.Show("Write Started");

            try
            {
                target = File.Open(filename, fileMode);
                writer = new BinaryWriter(target);

                writer.Write(content);
            }
            catch (Exception ex)
            {
                throw new Exception("Could not write to file: " + filename + " - " + ex.Message);
            }
            finally
            {
                if (target != null)
                {
                    target.Close();
                }
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }
    }
}
