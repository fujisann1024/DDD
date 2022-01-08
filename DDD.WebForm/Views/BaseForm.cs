using DDD.Domain;
using DDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDD.WebForm.Views
{
    public partial class BaseForm : Form
    {
        private static log4net.ILog _logger =

      log4net.LogManager.GetLogger(

          System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseForm()
        {
            InitializeComponent();

            DebugLayoutLabel.Visible = false;

#if DEBUG
            DebugLayoutLabel.Visible = true;
#endif

            UserIDLayoutLabel.Text = Shared.LoginId;

        }

        protected void ExceptionProc(Exception ex)
        {
            _logger.Error(ex.Message);
            MessageBoxIcon icon = MessageBoxIcon.Error;
            string caption = "エラー";

            var exceptionBase = ex as ExceptionBase;
            if (exceptionBase != null)
            {
                if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Info)
                {
                    icon = MessageBoxIcon.Information;
                    caption = "情報";
                }
                else if (exceptionBase.Kind == ExceptionBase.ExceptionKind.Warning)
                {
                    icon = MessageBoxIcon.Warning;
                    caption = "警告";
                }
            }

            MessageBox.Show(ex.Message, caption, MessageBoxButtons.OK, icon);
        }
    }


}
