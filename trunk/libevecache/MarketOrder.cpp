#pragma managed
#using <mscorlib.dll>

#include "StdAfx.h"
#include <msclr\marshal_cppstd.h>
#include <time.h>
#include "MarketOrder.h"
#include "evecache\dbtypes.hpp"


using namespace System;
using namespace msclr::interop;

namespace EveCacheCLI
{
    EveCacheCLI::MarketOrder^ MarketOrder::fromEveCacheMarketOrder(EveCache::MarketOrder input)
    {
        EveCacheCLI::MarketOrder^ output = gcnew EveCacheCLI::MarketOrder();
        output->Price = static_cast<Decimal>(input.price()/10000.0);
        output->VolumeRemaining = input.volRemaining();
        output->TypeID = input.type();
        output->Range = input.range();
        output->OrderID = input.orderID();
        output->VolumeEntered = input.volEntered();
        output->MinimumVolume= input.minVolume();
        output->Bid = input.isBid();

        time_t t = EveCache::windows_to_unix_time(input.issued());
        struct tm *tmp;
        tmp = gmtime(&t);
        char times[200];
        strftime(times, 200, "%Y-%m-%d %H:%M:%S", tmp);
        
        output->Issued = DateTime::Parse(marshal_as<System::String^>(times));

        output->Duration = input.duration();
        output->StationID = input.stationID();
        output->RegionID = input.regionID();
        output->SolarSystemID = input.solarSystemID();
        output->Jumps = input.jumps();

        return output;
    }

    MarketOrder::MarketOrder()
    {
    }

    
    Decimal MarketOrder::Price::get()
    {
        return this->iPrice;
    }
    void MarketOrder::Price::set(Decimal value)
    {
         this->iPrice = value;
    }
    
    int MarketOrder::VolumeRemaining::get()
    {
        return this->iVolumeRemaining;
    }
    void  MarketOrder::VolumeRemaining::set(int value)
    {
        this->iVolumeRemaining = value;
    }
    
    int MarketOrder::TypeID::get()
    {
        return this->iTypeID;
    }
    void  MarketOrder::TypeID::set(int value)
    {
        this->iTypeID = value;
    }
    int MarketOrder::Range::get()
    {
        return this->iRange;
    }
    void  MarketOrder::Range::set(int value)
    {
        this->iRange = value;
    }
    int MarketOrder::OrderID::get()
    {
        return this->iOrderID;
    }
    void  MarketOrder::OrderID::set(int value)
    {
        this->iOrderID = value;
    }
    
    int MarketOrder::VolumeEntered::get()
    {
        return this->iVolumeEntered;
    }
    void MarketOrder::VolumeEntered::set(int value)
    {
        this->iVolumeEntered = value;
    }
    int MarketOrder::MinimumVolume::get()
    {
        return this->iMinimumVolume;
    }
    void MarketOrder::MinimumVolume::set(int value)
    {
        this->iVolumeEntered = value;
    }
    bool MarketOrder::Bid::get()
    {
        return this->iBid;
    }
    void MarketOrder::Bid::set(bool value)
    {
        this->iBid = value;
    }
    DateTime^ MarketOrder::Issued::get()
    {
        return this->iIssued;
    }
    void MarketOrder::Issued::set(DateTime^ value)
    {
        this->iIssued = value;
    }
    int MarketOrder::Duration::get()
    {
        return this->iDuration;
    }
    void MarketOrder::Duration::set(int value)
    {
        this->iDuration = value;
    }
    int MarketOrder::StationID::get()
    {
        return this->iStationID;
    }
    void MarketOrder::StationID::set(int value)
    {
        this->iStationID = value;
    }
    int MarketOrder::RegionID::get()
    {
        return this->iRegionID;
    }
    void MarketOrder::RegionID::set(int value)
    {
        this->iRegionID = value;
    }
    int MarketOrder::SolarSystemID::get()
    {
        return this->iSolarSystemID;
    }
    void MarketOrder::SolarSystemID::set(int value)
    {
        this->iSolarSystemID = value;
    }	
    int MarketOrder::Jumps::get()
    {
        return this->iJumps;
    }
    void MarketOrder::Jumps::set(int value)
    {
        this->iJumps = value;
    }
}