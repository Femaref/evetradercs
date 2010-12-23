using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Waf.Applications;
using EveTrader.Core.Visual.View;
using EveTrader.Core.DataConverter;
using System.IO;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel.Composition;
using EveTrader.Core.Services;

namespace EveTrader.Core.Visual.ViewModel
{
    [Export]
    public class ConverterViewModel : ViewModel<IConverterView>, ISettingsPage
    {
        private readonly IConversionService converter;
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

        private bool working;

        public bool Working
        {
            get { return working; }
            set
            {
                working = value;
                RaisePropertyChanged("Working");
            }
        }

        private ICommand closeCommand;

        public ICommand CloseCommand
        {
            get { return closeCommand; }
            set { closeCommand = value;
            RaisePropertyChanged("CloseCommand");
            }
        }

        private ICommand convertCommand;

        public ICommand ConvertCommand
        {
            get { return convertCommand; }
            set
            {
                convertCommand = value;
                RaisePropertyChanged("ConvertCommand");
            }
        }

        [ImportingConstructor]
        public ConverterViewModel(IConverterView view, IConversionService converter)
            : base(view)
        {
            this.converter = converter;

            ConvertCommand = new DelegateCommand(() => Convert());
            CloseCommand = new DelegateCommand(() => RaiseClosed());
        }

        void converter_OperationFinished(object sender, EventArgs e)
        {
            Finished = true;
        }

        void converter_ObjectsIncreased(object sender, ValueIncreasedEventArgs e)
        {
            Objects = e.NewValue;
        }

        void converter_CurrentObjectIncreased(object sender, ValueIncreasedEventArgs e)
        {
            CurrentObject = e.NewValue;
        }

        private readonly object updaterLock = new object();

        private void Convert()
        {
            Thread t = new Thread(new ThreadStart(ThreadedConvert));
            t.Name = "Converter Thread";
            t.Start();
        }

        private void ThreadedConvert()
        {
            lock (updaterLock)
            {
                Working = true;
                this.converter.CurrentObjectIncreased += new EventHandler<ValueIncreasedEventArgs>(converter_CurrentObjectIncreased);
                this.converter.ObjectsIncreased += new EventHandler<ValueIncreasedEventArgs>(converter_ObjectsIncreased);
                this.converter.OperationFinished += new EventHandler(converter_OperationFinished);
                converter.Convert();
                Working = false;
            }
        }

        #region ISettingsPage

        public event EventHandler Closed;

        private void RaiseClosed()
        {
            var handler = Closed;

            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        #endregion
    }
}
