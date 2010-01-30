using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveTrader.Core.Migration
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TargetVersionAttribute : Attribute
    {
        public Version FromVersion { get; private set; }
        public Version ToVersion { get; private set; }

        public TargetVersionAttribute (int fromMajor, int fromMinor, int fromRevision, int toMajor, int toMinor,int toRevision )
        {
            this.FromVersion = new Version(fromMajor, fromMinor, fromRevision);
            this.ToVersion = new Version(toMajor, toMinor, toRevision );
        }
    }
}
