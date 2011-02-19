using System.ComponentModel.Composition;

namespace EveTrader.Core.ViewModel
{
    [InheritedExport]
    public interface ISettingsPage
    {
        object View { get; }
        string Name { get; }
        int Index { get; }
    }
}
