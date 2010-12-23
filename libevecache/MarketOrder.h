#pragma managed

#using <mscorlib.dll>

#include "evecache\market.hpp"

using namespace System;

namespace EveCacheCLI
{
    public ref class MarketOrder
    {
    public:
        static EveCacheCLI::MarketOrder^ fromEveCacheMarketOrder (EveCache::MarketOrder);
        MarketOrder(void);
        //"price,volRemaining,typeID,range,orderID,volEntered,minVolume,bid,issued,duration,stationID,regionID,solarSystemID,jumps,"
        property Decimal Price
        {
            Decimal get(void);
            void set(Decimal);
        };
        property int VolumeRemaining
        {
            int get(void);
            void set(int);
        };
        property int TypeID
        {
            int get(void);
            void set(int);
        };
        property int Range
        {
            int get(void);
            void set(int);
        };
        property int OrderID
        {
            int get(void);
            void set(int);
        };		
        property int VolumeEntered
        {
            int get(void);
            void set(int);
        };
        property int MinimumVolume
        {
            int get(void);
            void set(int);
        };
        property bool Bid
        {
            bool get(void);
            void set(bool);
        };
        property DateTime^ Issued
        {
            DateTime^ get(void);
            void set(DateTime^);
        };
        property int Duration
        {
            int get(void);
            void set(int);
        };
        property int StationID
        {
            int get(void);
            void set(int);
        };
        property int RegionID
        {
            int get(void);
            void set(int);
        };
        property int SolarSystemID
        {
            int get(void);
            void set(int);
        };
        property int Jumps
        {
            int get(void);
            void set(int);
        };
    private:
        Decimal iPrice;
        int iVolumeRemaining;
        int iTypeID;
        int iRange;
        int iOrderID;
        int iVolumeEntered;
        int iMinimumVolume;
        bool iBid;
        DateTime^ iIssued;
        int iDuration;
        int iStationID;
        int iRegionID;
        int iSolarSystemID;
        int iJumps;

    };
}

