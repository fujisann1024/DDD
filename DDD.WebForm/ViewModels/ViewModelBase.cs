using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //ViewModelとViewの値が一致したらなにもしない、一致しなければ
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            
            if (Equals(field,value))
            {
                return false;
            }

            field = value;

            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }

            return true;
        }

        public virtual DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        //データが変更された時、View側に通知をとばす
        public void OnPropertyChanged()
        {
            PropertyChanged.Invoke(
                this,
                new PropertyChangedEventArgs("")//すべてのプロパティを指定
                ); 
        }
    }
}
