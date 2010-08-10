#pragma managed
#using <mscorlib.dll>
#include "MarketOrderList.h"
#include "evecache\market.hpp"

using namespace System;
using namespace System::Collections::Generic;


namespace EveCacheCLI
{
	public ref class ManagedMarket
	{
	public:
		ManagedMarket(System::String^);
		MarketOrderList^ GetOrders();
		void Load();
	private:
		System::String^ iFileName;
		const EveCache::SNode* iNode;
	};
}

