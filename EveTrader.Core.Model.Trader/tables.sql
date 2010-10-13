DROP TABLE IF EXISTS [Accounts];
CREATE TABLE [Accounts] (



    [ID] integer PRIMARY KEY NOT NULL,



    [ApiKey] text NOT NULL



);
DROP TABLE IF EXISTS [ApiCache];
CREATE TABLE [ApiCache] (
    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [RequestString] text NOT NULL,
    [RequestDate] datetime NOT NULL,
    [Data] text NOT NULL
);
DROP TABLE IF EXISTS [ApiJournal];
CREATE TABLE [ApiJournal] (
[ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
[ExternalID] integer NOT NULL,
CONSTRAINT [FK_ApiJournal_0] FOREIGN KEY ([ID]) REFERENCES [Journal] ([ID])
);
DROP TABLE IF EXISTS [ApiTransactions];
CREATE TABLE [ApiTransactions] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [ExternalID] bigint NOT NULL,



    CONSTRAINT [FK_ApiTransactions_0] FOREIGN KEY ([ID]) REFERENCES [Transactions] ([ID])



);
DROP TABLE IF EXISTS [ApplicationLog];
CREATE TABLE [ApplicationLog] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [Date] datetime NOT NULL,

    [Message] text NOT NULL,

    [CallingClass] text NOT NULL

);
DROP TABLE IF EXISTS [CachedPriceInfo];
CREATE TABLE [CachedPriceInfo] (
    [TypeID] integer PRIMARY KEY NOT NULL,
    [BuyPrice] decimal NOT NULL DEFAULT '0.0',
    [SellPrice] decimal NOT NULL DEFAULT '0.0'
);
DROP TABLE IF EXISTS [Characters];
CREATE TABLE [Characters] (



    [ID] integer PRIMARY KEY NOT NULL,



    [CorporationID] integer NOT NULL,



    [Race] varchar(50) NOT NULL,



    [Bloodline] varchar(50) NOT NULL,



    [Gender] varchar(50) NOT NULL,



    [Balance] decimal NOT NULL,



    CONSTRAINT [FK_Characters_CorporationID_Corporations_ID] FOREIGN KEY ([CorporationID]) REFERENCES [Corporations] ([ID])



);
DROP TABLE IF EXISTS [Corporations];
CREATE TABLE [Corporations] (



    [ID] integer PRIMARY KEY NOT NULL,



    [Ticker] nvarchar(50) NOT NULL,



    [Npc] bit NOT NULL DEFAULT 0,

    [ApiCharacterID] integer NOT NULL,



    CONSTRAINT [FK_Corporations_ID_Entity_ID] FOREIGN KEY ([ID]) REFERENCES [Entity] ([ID])



);
DROP TABLE IF EXISTS [CustomJournal];
CREATE TABLE [CustomJournal](
[ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
[Created] datetime NOT NULL,
[Description] text NOT NULL,
CONSTRAINT [FK_CustomJournal_0] FOREIGN KEY ([ID]) REFERENCES [Journal] ([ID])
);
DROP TABLE IF EXISTS [CustomTransactions];
CREATE TABLE [CustomTransactions] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [Created] datetime NOT NULL,



    [Description] text DEFAULT '',



    CONSTRAINT [FK_CustomTransactions_0] FOREIGN KEY ([ID]) REFERENCES [Transactions] ([ID])



);
DROP TABLE IF EXISTS [Entity];
CREATE TABLE [Entity] (



    [ID] integer PRIMARY KEY NOT NULL,



    [Name] nvarchar(50) NOT NULL,



    [AccountID] integer DEFAULT 0,



    CONSTRAINT [FK_Entity_AccountID_Accounts_ID] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([ID])



);
DROP TABLE IF EXISTS [Journal];
CREATE TABLE [Journal] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [WalletID] integer NOT NULL,

    [RefTypeID] integer NOT NULL,

    [OwnerName1] text NOT NULL,

    [OwnerID1] integer NOT NULL,

    [OwnerName2] text NOT NULL,

    [OwnerID2] integer NOT NULL,

    [ArgName1] text NOT NULL,

    [ArgID1] integer NOT NULL,

    [Amount] decimal NOT NULL,

    [Balance] decimal NOT NULL,

    [Reason] text NOT NULL,

    [TaxReceiverID] integer NOT NULL,

    [TaxAmount] decimal NOT NULL,

    [DateTime] DateTime NOT NULL,
    [Date] DateTime NOT NULL,

    CONSTRAINT [FK_Journal_0] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])

);
DROP TABLE IF EXISTS [MarketOrders];
CREATE TABLE [MarketOrders] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [EntityID] integer NOT NULL,

    [StationID] integer NOT NULL,

    [VolumeEntered] integer NOT NULL,

    [VolumeRemaining] integer NOT NULL,

    [MinimumVolume] integer NOT NULL,

    [OrderState] integer NOT NULL,

    [TypeID] integer NOT NULL,

    [Range] integer NOT NULL,

    [AccountKey] integer NOT NULL,

    [Duration] integer NOT NULL,

    [Escrow] decimal NOT NULL,

    [Price] decimal NOT NULL,

    [Bid] bit NOT NULL,

    [Issued] datetime NOT NULL,
    [IssuedDate] datetime NOT NULL,

    [ExternalID] integer  NOT NULL,

    CONSTRAINT [FK_MarketOrders_0] FOREIGN KEY ([EntityID]) REFERENCES [Entity] ([ID])

);
DROP TABLE IF EXISTS [Transactions];
CREATE TABLE [Transactions] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [WalletID] integer NOT NULL,



    [Quantity] integer NOT NULL,



    [TypeName] text NOT NULL,



    [TypeID] integer NOT NULL,



    [Price] decimal NOT NULL,



    [ClientID] integer NOT NULL,



    [ClientName] text NOT NULL,



    [StationID] integer NOT NULL,



    [StationName] text NOT NULL,



    [TransactionType] integer NOT NULL,



    [TransactionFor] integer NOT NULL,



    [DateTime] datetime NOT NULL,
    [Date] datetime NOT NULL,



    [Ignored] bit NOT NULL DEFAULT 0,



    CONSTRAINT [FK_Transactions_0] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])



);
DROP TABLE IF EXISTS [WalletHistories];
CREATE TABLE [WalletHistories] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [WalletID] integer NOT NULL,



    [Balance] decimal NOT NULL,



    [Date] datetime NOT NULL,



    CONSTRAINT [FK_WalletHistories_WalletID_Wallets_ID] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])



);
DROP TABLE IF EXISTS [Wallets];
CREATE TABLE [Wallets] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [EntityID] integer NOT NULL,

    [AccountKey] integer NOT NULL,

    [Name] nvarchar(50) NOT NULL,

    [Balance] decimal NOT NULL,

    CONSTRAINT [FK_Wallets_0] FOREIGN KEY ([EntityID]) REFERENCES [Entity] ([ID])

);
