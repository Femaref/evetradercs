using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Visual.View;
using EveTrader.Core.DataConverter;
using System.IO;

namespace EveTrader.Core.Visual.ViewModel
{
    public class ConverterViewModel : ViewModel<IConverterView>
    {
        private readonly XmlToSqlite iConverter;
        private int iObjects;
        private int iCurrentObject;
        private bool iFinished;

        public int Objects
        {
            get { return iObjects; }
            private set
            {
                iObjects = value;
                RaisePropertyChanged("Objects");
            }
        }

        public int CurrentObject
        {
            get { return iCurrentObject; }
            private set
            {
                iCurrentObject = value;
                RaisePropertyChanged("CurrentObject");
            }
        }

        public bool Finished
        {
            get { return iFinished; }
            private set
            {
                iFinished = value;
                RaisePropertyChanged("Finished");
            }
        }


        public ConverterViewModel(IConverterView view)
            : base(view)
        {
            iConverter = new XmlToSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EveTrader", "settings.xml"));

            iConverter.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(iConverter_PropertyChanged);
        }

        void iConverter_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Objects")
                this.Objects = (sender as XmlToSqlite).Objects;
            if (e.PropertyName == "CurrentObject")
                this.CurrentObject = (sender as XmlToSqlite).CurrentObject;
            if (e.PropertyName == "Finished")
                this.Finished = (sender as XmlToSqlite).Finished;

        }
    }
}
