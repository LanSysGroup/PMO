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
using System.Windows.Controls.Primitives;
using LanSysWebGIS.Web;
using LanSysWebGIS.Models;
using System.Windows.Browser;
using LanSysWebGIS.Views.UserManagement;
using LanSysWebGIS.WebMethodsService;
using System.ServiceModel.DomainServices.Client;
using System.IO;

namespace LanSysWebGIS
{
    public partial class MainCategory : UserControl
    {
        public MainCategory()
        {
            InitializeComponent();
        }

        int _userId;

        public Presenter.MainCategoryPresenter Presenter
        {
            get { return (Presenter.MainCategoryPresenter)this.DataContext; }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //یوزر آی دی پیش فرض
            //int userId = 8;
            try
            {
                this._userId = int.Parse(WebContext.Current.User.UserID);
            }
            catch (Exception)
            {
            }

            Presenter.MainCategoryPresenter presenter = new Presenter.MainCategoryPresenter(this._userId);

            this.DataContext = presenter;
        }

        private void docTitleTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.docTitleTree.SelectedItem == null)
            {
                return;
            }

            this.Presenter.SelectedTitle = ((Models.DocTitleTreeViewModel)(this.docTitleTree.SelectedItem));

            this.Presenter.RefreshDocSubjectTree();
        }

        private void docSubjectTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (this.docSubjectTree.SelectedItem == null)
            {
                return;
            }

            this.Presenter.SelectedSubject = ((Models.DocSubjectTreeViewModel)(this.docSubjectTree.SelectedItem));

            this.Presenter.RefreshDocFileList();
        }

        private void docFileList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.docFileList.SelectedItem == null)
            {
                return;
            }

            this.Presenter.SelectedFile = (Presenter.DocFileViewModel)this.docFileList.SelectedItem;
        }

        private void addMenu_Click(object sender, RoutedEventArgs e)
        {
            if (this.Presenter.SelectedTitle == null)
            {
                return;
            }

            AddTitle window = new AddTitle(this._userId, this.Presenter, this.Presenter.SelectedTitle);// this.Presenter.SelectedTitle.TitleFName,

            window.Show();
        }

        private void removeMenu_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
                 new Presenter.YesNoQuestionPresenter()
                 {
                     Message = Assets.Resources.ApplicationStrings.AreYouSureMessageForRemoveDocTitle,
                     Title = Assets.Resources.ApplicationStrings.AreYouSureTitleForRemoveDocTitle
                 });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveDocTitle();
                }
            };
        }

        private void subject_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.docSubjectTree.SelectItem(((TextBlock)sender).DataContext as Models.DocSubjectTreeViewModel);

            e.Handled = false;
        }

        private void title_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.docTitleTree.SelectItem(((TextBlock)sender).DataContext as Models.DocTitleTreeViewModel);

            e.Handled = false;
        }

        private void addSubject_Click(object sender, RoutedEventArgs e)
        {
            if (this.Presenter.SelectedSubject == null)
            {
                return;
            }

            AddSubject window = new AddSubject(new Presenter.AddSubjectPresenter(this.Presenter));

            window.Show();
        }

        private void removeSubject_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
              new Presenter.YesNoQuestionPresenter()
              {
                  Message = "دسته بندی موضوعی / مکانی مورد نظر حذف می شود. آیا مطمئن هستید؟",
                  Title = "حذف دسته بندی موضوعی / مکانی"
              });

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveDocSubject();
                }
            };
        }

        private void addFile_Click(object sender, RoutedEventArgs e)
        {
            if (this.Presenter.SelectedSubject == null)
            {
                return;
            }

            UserControls.Banader.AddFile window = new UserControls.Banader.AddFile(
                new Presenter.AddFilePresenter(this.Presenter.SelectedSubject, this.Presenter));

            window.Show();
        }

        private void removeFile_Click(object sender, RoutedEventArgs e)
        {
            Controls.YesNoQuestion dialog = new Controls.YesNoQuestion(
            new Presenter.YesNoQuestionPresenter()
            {
                Message = "فایل مورد نظر حذف می شود. آیا مطمئن هستید؟",
                Title = "حذف فایل"
            });

            if (sender is MenuItem && this.docFileList.SelectedItems.Count > 1)
            {
                MessageWindow window = new MessageWindow();

                window.messageTextBlock.Text = "لطفا فقط یک فایل انتخاب کنید.";

                window.Show();

                return;
            }

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.RemoveDocFile(this.docFileList.SelectedItems);

                    //ForTest
                    WebMethodsServiceSoapClient webMethods = new WebMethodsServiceSoapClient();

                    webMethods.DeleteFileAsync(this.Presenter.SelectedFileFullPath);
                }
            };
        }

        private void docFileList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MouseButtonHelper.IsDoubleClick(sender, e))
            {
                OpenFile();
            }
        }

        private void viewFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            if (this.Presenter.SelectedFile == null)
            {
                MessageWindow win = new MessageWindow();
                win.messageTextBlock.Text = "لطفا یک فایل را انتخاب کنید";
                win.Show();

                return;
            }

            string path = this.Presenter.SelectedFileFullPath;

            PMOContext context = new PMOContext();

            context.DocFileUserLogs.Add(new DocFileUserLog()
            {
                DateVisited = DateTime.Now,
                FileId = this.Presenter.SelectedFile.FileId,
                UserId = this._userId,
            });

            context.SubmitChanges();

            ReadSelectedFile(this.Presenter.SelectedFile.FileName, this.Presenter.SelectedFile.FileExt,path);

            //ForTest
            //WebMethodsServiceSoapClient webMethods = new WebMethodsServiceSoapClient();

            //webMethods.AccessFileAsync(path);

            //HtmlPage.Window.Navigate(new Uri(path, UriKind.Absolute), "_blank");

            //WebBrowserOpener.OpenURL(path);
        }

        private void ReadSelectedFile(string fileName, string fileExt, string path)
        {
            PMOContext downloadContext = new PMOContext();

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultFileName = fileName + "." + fileExt;
            // set filters - this can be done in properties as well
            //savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            savefile.Filter = "All files (*.*)|*.*";


            if (savefile.ShowDialog() == true)
            {
                InvokeOperation<byte[]> InvokeOp = downloadContext.DownloadFile(path);
                this.Presenter.IsLoadingData = true;

                InvokeOp.Completed += (s, args) =>
                {
                    if (!InvokeOp.HasError)
                    {
                        byte[] document = InvokeOp.Value;

                        using (Stream ms = (Stream)savefile.OpenFile())
                        {
                            ms.Write(document, 0, document.Length);
                            ms.Close();
                        }

                        //MessageBox.Show("Yes!");
                        this.Presenter.IsLoadingData = false;
                    }
                    else
                    {
                        this.Presenter.IsLoadingData = false;
                        MessageBox.Show(InvokeOp.Error.Message);
                    }
                };

            }

        }

        private void fileDetails_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.ViewFileLog();
        }

        private void adminAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.ChangeSelectedFileFlag();
        }

        private void subjectAdminAccept_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.ChangeSelectedSubjectFilesFlag();
        }

        private void editTitle_Click(object sender, RoutedEventArgs e)
        {
            UserControls.Banader.EditWindow dialog = new UserControls.Banader.EditWindow(this.Presenter.SelectedTitle.TitleFName);

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.EditDocTitle(dialog.Value);
                }
            };

        }

        private void editSubject_Click(object sender, RoutedEventArgs e)
        {
            UserControls.Banader.EditWindow dialog = new UserControls.Banader.EditWindow(this.Presenter.SelectedSubject.SubjectFName);

            dialog.Show();

            dialog.Closed += delegate
            {
                if (dialog.DialogResult == true)
                {
                    this.Presenter.EditDocSubject(dialog.Value);
                }
            };
        }


        private void cutMenuContext_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.CutSelectedDocTitle();

            this.pasteMenuContext.InvalidateArrange();
            this.pasteSubject.UpdateLayout();
        }

        private void pasteMenuContext_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.PasteSelectedDocTitle();

            this.pasteMenuContext.InvalidateArrange();
            this.pasteSubject.UpdateLayout();
        }

        private void cutSubject_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.CutSelectedDocSubject();

            this.pasteSubject.InvalidateArrange();
            this.pasteSubject.UpdateLayout();
        }

        private void pasteSubject_Click(object sender, RoutedEventArgs e)
        {
            this.Presenter.PasteSelectedDocSubject();

            this.pasteSubject.InvalidateArrange();
            this.pasteSubject.UpdateLayout();
        }

        private void setAccess_Click(object sender, RoutedEventArgs e)
        {
            UserControls.Banader.SetAccessLevels dialog = new UserControls.Banader.SetAccessLevels(
                new Presenter.Banader.SetAccessLevelPresenter());

            dialog.Show();
        }

        private void dg_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.MouseRightButtonDown += new MouseButtonEventHandler(Row_MouseRightButtonDown);
        }
        void Row_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            docFileList.SelectedItem = ((sender) as DataGridRow).DataContext;
        }

        private void fileStamp_Click(object sender, RoutedEventArgs e)
        {
            UserControls.Banader.Stamp dialog = new UserControls.Banader.Stamp(this.Presenter.SelectedFile, this.Presenter.SelectedSubject);

            dialog.Show();
        }

        private void subjectStamp_Click(object sender, RoutedEventArgs e)
        {
            UserControls.Banader.Stamp dialog = new UserControls.Banader.Stamp(this.Presenter.SelectedSubject);

            dialog.Show();
        }

    }

    public class WebBrowserOpener
    {
        public static void OpenURL(string navigateUri)
        {
            HyperlinkButtonWrapper hlbw = new HyperlinkButtonWrapper();
            hlbw.OpenURL(navigateUri);
        }

        public static void OpenURL(Uri navigateUri)
        {
            HyperlinkButtonWrapper hlbw = new HyperlinkButtonWrapper();
            hlbw.OpenURL(navigateUri);
        }
    }

    public class HyperlinkButtonWrapper : HyperlinkButton
    {
        public void OpenURL(string navigateUri)
        {
            OpenURL(new Uri(navigateUri, UriKind.Absolute));
        }

        public void OpenURL(Uri navigateUri)
        {
            base.NavigateUri = navigateUri;
            base.TargetName = "_blank";
            base.OnClick();
        }
    }
}
