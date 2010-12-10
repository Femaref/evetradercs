Create Table ItemPrices (
	TypeID integer NOT NULL,
	LastUpload datetime NOT NULL,
	RegionID integer NOT NULL,
	MinimumBuy decimal NOT NULL,
	MinimumSell decimal NOT NULL,
	MaximumBuy decimal NOT NULL,
	MaximumSell decimal NOT NULL,
	MedianBuy decimal NOT NULL,
	MedianSell decimal NOT NULL,
	AverageBuy decimal NOT NULL,
	AverageSell decimal NOT NULL,
	KurtosisBuy decimal NOT NULL,
	KurtosisSell decimal NOT NULL,
	SkewBuy decimal NOT NULL,
	SkewSell decimal NOT NULL,
	VarianceBuy decimal NOT NULL,
	VarianceSell decimal NOT NULL,
	StandardDeviationBuy decimal NOT NULL,
	StandardDeviationSell decimal NOT NULL,
	SimulatedBuy decimal NOT NULL,
	SimulatedSell decimal NOT NULL,
	PRIMARY KEY (TypeID, RegionID)
);

Create Table Cache (
ID integer NOT NULL PRIMARY KEY,
RequestString string NOT NULL,
RequestDate datetime NOT NULL,
Data string NOT NULL);