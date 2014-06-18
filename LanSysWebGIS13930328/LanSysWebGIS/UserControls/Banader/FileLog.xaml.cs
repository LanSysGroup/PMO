using LanSysWebGIS.Presenter;
using LanSysWebGIS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LanSysWebGIS.Models.Banader;

namespace LanSysWebGIS.UserControls.Banader
{
    public partial class FileLog : UserControl
    {
        MainCategoryPresenter presenter;

        List<FileLogModel> LogDataSource = new List<FileLogModel>();

        public FileLog(MainCategoryPresenter presenter)
        {
            InitializeComponent();

            this.presenter = presenter;

            PMOContext context = new PMOContext();

            txtTitle.Text += " : " + presenter.SelectedFile.FileName;

            try
            {
                txtCreatedBy.Text = presenter.SelectedFile.AddedByUserName;

                txtDateAdded.Text = presenter.SelectedFile.DateAdded.ToString();
            }
            catch (Exception)
            {

            }
            

            context.Load(context.GetDocFileUserLogForQuery(presenter.SelectedFile.FileId), System.ServiceModel.DomainServices.Client.LoadBehavior.MergeIntoCurrent,
                callback =>
                {
                    foreach (var item in context.DocFileUserLogs)
                    {
                        FileLogModel fileLog = new FileLogModel()
                        {
                            FileID = presenter.SelectedFile.FileId,
                            FileName = presenter.SelectedFile.FileName,
                            UserID = (int)item.UserId,
                            AddedByUserName = presenter.SelectedFile.AddedByUserName,
                            DateAdded = presenter.SelectedFile.DateAdded,
                            DateViewed = (DateTime)item.DateVisited
                        };

                        LogDataSource.Add(fileLog);
                    }

                    EntityDataGrid.ItemsSource = LogDataSource;
                }, null);
        }
    }
}
