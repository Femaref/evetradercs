using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.ClassExtenders;
using Core.DomainModel;

namespace EveTrader.Main
{
    public partial class CustomPriceWindow : Form
    {
        private double? buyPrice;
        private double? sellPrice;
        private bool buyPriceValid = false;
        private bool sellPriceValid = false;

        private CustomPrice customPrice;

        public CustomPriceWindow(Character character, int productId)
        {
            InitializeComponent();

            EveObjects.Type product = Resources.Instance.EveObjects.Types.GetTypeById(productId);
            
            try
            {
                this.customPrice = Settings.Instance.UserData.CustomPrice.Single( 
                    cp => 
                        cp.ProductId == productId &&
                        cp.CharactedId == character.Id
                    );
            }
            catch
            {
                this.customPrice = new CustomPrice
                                       {
                                           ProductId = productId,
                                           CharactedId = character.Id
                                       };
                Settings.Instance.UserData.CustomPrice.Add(customPrice);
            }

            this.sellPrice = customPrice.SellPrice;
            this.buyPrice = customPrice.BuyPrice;

            this.MainGroupBox.Text = product.Name;
            this.SellPriceTextBox.Text = sellPrice.HasValue
                                             ? customPrice.SellPrice.Value.FormatCurrency()
                                             : string.Empty;
            this.BuyPriceTextBox.Text = buyPrice.HasValue
                                             ? customPrice.BuyPrice.Value.FormatCurrency()
                                             : string.Empty;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!this.buyPriceValid)
            {
                MessageBox.Show(
                    "Custom buy price is invalid", 
                    "Set custom price", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            if (!this.sellPriceValid)
            {
                MessageBox.Show(
                    "Custom sell price is invalid",
                    "Set custom price", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            this.customPrice.SellPrice = this.sellPrice;
            this.customPrice.BuyPrice = this.buyPrice;

            this.Close();
        }

        private void BuyPriceTextBox_Validated(object sender, EventArgs e)
        {
            if (!this.buyPriceValid)
            {
                return;
            }

            this.BuyPriceTextBox.Text = this.buyPrice.HasValue
                                             ? this.buyPrice.Value.FormatCurrency()
                                             : string.Empty;
        }

        private void BuyPriceTextBox_Enter(object sender, EventArgs e)
        {
            if (!this.buyPriceValid)
            {
                return;
            }

            this.BuyPriceTextBox.Text = this.buyPrice.HasValue
                                             ? this.buyPrice.Value.ToString()
                                             : string.Empty;
        }

        private void SellPriceTextBox_Validated(object sender, EventArgs e)
        {
            if (!this.sellPriceValid)
            {
                return;
            }

            this.SellPriceTextBox.Text = this.sellPrice.HasValue
                                             ? this.sellPrice.Value.FormatCurrency()
                                             : string.Empty;
        }

        private void SellPriceTextBox_Enter(object sender, EventArgs e)
        {
            if (!this.sellPriceValid)
            {
                return;
            }

            this.SellPriceTextBox.Text = this.sellPrice.HasValue
                                             ? this.sellPrice.Value.ToString()
                                             : string.Empty;
        }

        private void SellPriceTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.SellPriceTextBox.Text))
            {
                this.sellPrice = null;
            }
            else
            {
                double newSellPrice;

                if (!double.TryParse(this.SellPriceTextBox.Text, out newSellPrice))
                {
                    this.SellPriceErrorProvider.SetError(this.SellPriceTextBox, "Numeric value required");
                    this.sellPriceValid = false;
                    return;
                }
                
                this.sellPrice = newSellPrice;
            }

            this.sellPriceValid = true;
            this.SellPriceErrorProvider.Clear();
        }

        private void BuyPriceTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.BuyPriceTextBox.Text))
            {
                this.buyPrice = null;
            }
            else
            {
                double newBuyPrice;

                if (!double.TryParse(this.BuyPriceTextBox.Text, out newBuyPrice))
                {
                    this.BuyPriceErrorProvider.SetError(this.BuyPriceTextBox, "Numeric value required");
                    this.buyPriceValid = false;
                    return;
                }

                this.buyPrice = newBuyPrice;
            }

            this.buyPriceValid = true;
            this.BuyPriceErrorProvider.Clear();
        }
    }
}
