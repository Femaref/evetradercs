﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainModel;
using Core.Network.EveApi.Requests;

namespace Core.Updaters
{
    public class CharacterWalletTransactionsUpdater : ICharacterUpdater
    {
        public bool UpdateCharacter(Character character)
        {
            WalletTransactionsRequest walletTransactionsRequest = new WalletTransactionsRequest(character);
            WalletTransactionComparer walletTransactionComparer = new WalletTransactionComparer();

            if (character.NextWalletTransactionsUpdateTime <= DateTime.Now)
            {
                IEnumerable<WalletTransaction> newWalletTransactions = walletTransactionsRequest.Request();
            
                if (walletTransactionsRequest.ErrorCode == 0)
                {
                    foreach (WalletTransaction wt in newWalletTransactions)
                        wt.CalculateSalesTax(character.AccountingLevel);

                    character.WalletTransactions = character.WalletTransactions.Union(newWalletTransactions, walletTransactionComparer).OrderByDescending(p => p.TransactionID).ToList();
                    character.NextWalletTransactionsUpdateTime = DateTime.Now.AddHours(1).AddMinutes(1);
                    return true;
                }
            }

            return false;
        }
    }
}
