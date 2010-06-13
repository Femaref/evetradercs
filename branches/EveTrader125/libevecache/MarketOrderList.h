#pragma managed

#include "MarketOrder.h"

#using <mscorlib.dll>

using namespace System;
using namespace System::Collections::Generic;


namespace EveCacheCLI
{
	public ref class MarketOrderList
	{
	public:
		MarketOrderList(void);
		property List<MarketOrder^>^ Orders
		{
			List<MarketOrder^>^ get(void);
			void set(List<MarketOrder^>^);
		};
		property DateTime^ FetchTime
		{
			DateTime^ get(void);
			void set(DateTime^);
		};
		property int RegionID
		{
			int get(void);
			void set(int);
		};
		property int TypeID
		{
			int get(void);
			void set(int);
		};
	private:
		List<MarketOrder^>^ iOrders;
		DateTime^ iFetchTime;
		int iRegionID;
		int iTypeID;
	};
}

