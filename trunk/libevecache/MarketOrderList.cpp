#include "StdAfx.h"
#include "MarketOrderList.h"

#using <mscorlib.dll>

using namespace System::Collections::Generic;

namespace EveCacheCLI
{
		MarketOrderList::MarketOrderList(void)
		{
			this->iOrders = gcnew List<MarketOrder^>();
		}
		List<MarketOrder^>^ MarketOrderList::Orders::get(void)
		{
			return this->iOrders;
		}
		void MarketOrderList::Orders::set(List<MarketOrder^>^ value)
		{
			this->iOrders = value;
		}

		DateTime^ MarketOrderList::FetchTime::get(void)
		{
			return this->iFetchTime;
		}
		void MarketOrderList::FetchTime::set(DateTime^ value)
		{
			this->iFetchTime = value;
		}
		int MarketOrderList::RegionID::get(void)
		{
			return this->iRegionID;
		}
		void MarketOrderList::RegionID::set(int value)
		{
			this->iRegionID = value;
		}
		int MarketOrderList::TypeID::get(void)
		{
			return this->iTypeID;
		}
		void MarketOrderList::TypeID::set(int value)
		{
			this->iTypeID = value;
		}
}
