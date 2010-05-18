PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE [Corporations] (



    [ID] integer PRIMARY KEY NOT NULL,



    [Ticker] nvarchar(50) NOT NULL,



	[Npc] bit NOT NULL DEFAULT 0,



    CONSTRAINT [FK_Corporations_ID_Entity_ID] FOREIGN KEY ([ID]) REFERENCES [Entity] ([ID])



);
CREATE TABLE [Accounts] (



    [ID] integer PRIMARY KEY NOT NULL,



    [ApiKey] text NOT NULL



);
CREATE TABLE [Entity] (



    [ID] integer PRIMARY KEY NOT NULL,



    [Name] nvarchar(50) NOT NULL,



    [AccountID] integer DEFAULT 0,



    CONSTRAINT [FK_Entity_AccountID_Accounts_ID] FOREIGN KEY ([AccountID]) REFERENCES [Accounts] ([ID])



);
CREATE TABLE [Characters] (



    [ID] integer PRIMARY KEY NOT NULL,



    [CorporationID] integer NOT NULL,



    [Race] varchar(50) NOT NULL,



    [Bloodline] varchar(50) NOT NULL,



    [Gender] varchar(50) NOT NULL,



    [Balance] decimal NOT NULL,



    CONSTRAINT [FK_Characters_CorporationID_Corporations_ID] FOREIGN KEY ([CorporationID]) REFERENCES [Corporations] ([ID])



);
CREATE TABLE [WalletHistories] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [WalletID] integer NOT NULL,



    [Balance] decimal NOT NULL,



    [Date] datetime NOT NULL,



    CONSTRAINT [FK_WalletHistories_WalletID_Wallets_ID] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])



);
CREATE TABLE [CustomTransactions] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [Created] datetime NOT NULL,



    [Description] text DEFAULT '',



    CONSTRAINT [FK_CustomTransactions_0] FOREIGN KEY ([ID]) REFERENCES [Transactions] ([ID])



);
CREATE TABLE [ApiTransactions] (



    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,



    [ExternalID] bigint NOT NULL,



    CONSTRAINT [FK_ApiTransactions_0] FOREIGN KEY ([ID]) REFERENCES [Transactions] ([ID])



);
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



    [Date] datetime NOT NULL,



    [Ignored] bit NOT NULL DEFAULT 0,



    CONSTRAINT [FK_Transactions_0] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])



);
CREATE TABLE [Wallets] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [EntityID] integer NOT NULL,

    [AccountKey] integer NOT NULL,

    [Name] nvarchar(50) NOT NULL,

    [Balance] decimal NOT NULL,

    CONSTRAINT [FK_Wallets_0] FOREIGN KEY ([EntityID]) REFERENCES [Entity] ([ID])

);
CREATE TABLE [ApplicationLog] (

    [ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,

    [Date] datetime NOT NULL,

    [Message] text NOT NULL,

    [CallingClass] text NOT NULL

);
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

    CONSTRAINT [FK_Journal_0] FOREIGN KEY ([WalletID]) REFERENCES [Wallets] ([ID])

);

CREATE TABLE [ApiJournal] (
[ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
[ExternalID] integer NOT NULL,
CONSTRAINT [FK_ApiJournal_0] FOREIGN KEY ([ID]) REFERENCES [Journal] ([ID])
);

CREATE TABLE [CustomJournal](
[ID] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
[Created] datetime NOT NULL,
[Description] text NOT NULL,
CONSTRAINT [FK_CustomJournal_0] FOREIGN KEY ([ID]) REFERENCES [Journal] ([ID])
);

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

    CONSTRAINT [FK_MarketOrders_0] FOREIGN KEY ([EntityID]) REFERENCES [Entity] ([ID])

);
DELETE FROM sqlite_sequence;
INSERT INTO "sqlite_sequence" VALUES('Wallets',NULL);
INSERT INTO "sqlite_sequence" VALUES('ApplicationLog',0);
INSERT INTO "sqlite_sequence" VALUES('Journal',0);
INSERT INTO "sqlite_sequence" VALUES('MarketOrders',0);
COMMIT;
