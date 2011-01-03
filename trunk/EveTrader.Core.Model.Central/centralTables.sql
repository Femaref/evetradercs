CREATE TABLE ItemPrices (
TypeID integer NOT NULL,
RegionID integer NOT NULL,
VolumeBuy integer NOT NULL,
VolumeSell integer NOT NULL,
AverageBuy decimal NOT NULL,
AverageSell decimal NOT NULL,
MaximumBuy decimal NOT NULL,
MaximumSell decimal NOT NULL,
MinimumBuy decimal NOT NULL,
MinimumSell decimal NOT NULL,
StandardDeviationBuy decimal NOT NULL,
StandardDeviationSell decimal NOT NULL,
MedianBuy decimal NOT NULL,
MedianSell decimal NOT NULL,
PRIMARY KEY (TypeID, RegionID));

Create Table Cache (
ID integer NOT NULL PRIMARY KEY AUTOINCREMENT,
RequestString string NOT NULL,
RequestDate datetime NOT NULL,
Data string NOT NULL);