using System.Windows.Forms;

namespace EveTrader.Main.CrossRegionalMarket
{
    public partial class EveRegionalMarketView : UserControl
    {
        public EveRegionalMarketView()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.BuyOrdersListView.Columns.Clear();

            foreach(ColumnHeader columnHeader in this.SellOrdersListView.Columns)
            {
                this.BuyOrdersListView.Columns.Add(columnHeader.Clone() as ColumnHeader);
            }
        }
    }
}
