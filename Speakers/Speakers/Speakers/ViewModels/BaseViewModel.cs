using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Speakers.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Property change notification stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            RaisePropertyChangedExplicit(propertyName);
        }
        protected void RaisePropertyChanged<TProperty>(Expression<Func<TProperty>> projection)
        {
            var memberExpression = (MemberExpression)projection.Body;
            RaisePropertyChangedExplicit(memberExpression.Member.Name);
        }
        void RaisePropertyChangedExplicit(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion

        private string _title;
        public string Title
        {
            get { return _title; }
            set { if (_title != value) { _title = value; RaisePropertyChanged(() => Title); } }
        }

        public bool IsWindowsPhone { get { return Device.OS == TargetPlatform.WinPhone; } }
    }
}
