#pragma managed



#include "StdAfx.h"
#include <time.h>
#include <msclr\marshal_cppstd.h>
#include "evecache\reader.hpp"
#include "evecache\parser.hpp"
#include "evecache\market.hpp"
#include "ManagedMarket.h"

#using <mscorlib.dll>


using namespace System;
using namespace System::Collections::Generic;
using namespace EveCache;
using namespace msclr::interop;



namespace EveCacheCLI
{
    ManagedMarket::ManagedMarket(System::String^ fileName)
    {
        this->iFileName = fileName;
        Load();
    }
    MarketOrderList^ ManagedMarket::GetOrders()
    {

        MarketParser mp(this->iNode);
        mp.parse();

        MarketList list = mp.getList();

        MarketOrderList^ orderList = gcnew MarketOrderList();
        orderList->TypeID = list.type();
        orderList->RegionID = list.region();
        

        time_t t = list.timestamp();
        struct tm* tmp = gmtime(&t);

        char times[200];
        strftime(times, 200, "%Y-%m-%d %H:%M:%S", tmp);

        orderList->FetchTime = DateTime::Parse(marshal_as<System::String^>(times));

        //"price,volRemaining,typeID,range,orderID,volEntered,minVolume,bid,issued,duration,stationID,regionID,solarSystemID,jumps,"

        std::vector<EveCache::MarketOrder> buy = list.getBuyOrders();
        std::vector<EveCache::MarketOrder> sell = list.getSellOrders();

        std::vector<EveCache::MarketOrder>::const_iterator i = sell.begin();
        for (; i != sell.end(); ++i)
        {
            EveCacheCLI::MarketOrder^ cachedCLIOrder = EveCacheCLI::MarketOrder::fromEveCacheMarketOrder(*i);
            orderList->Orders->Add(cachedCLIOrder);
        }
        i = buy.begin();
        for (; i != buy.end(); ++i)
        {
            EveCacheCLI::MarketOrder^ cachedCLIOrder = EveCacheCLI::MarketOrder::fromEveCacheMarketOrder(*i);
            orderList->Orders->Add(cachedCLIOrder);
        }

        return orderList;
    }
    void ManagedMarket::Load()
    {
        System::String^ toMarshal = this->iFileName;

        CacheFile cF(marshal_as<std::string>(toMarshal));

        if (cF.readFile() == false) {
            throw gcnew Exception("unable to load "+ this->iFileName);
        }
            CacheFile_Iterator i = cF.begin();
            Parser *parser = new Parser(&i);
            parser->parse();
            this->iNode = parser->streams()[0];
            delete parser;
    }

}


