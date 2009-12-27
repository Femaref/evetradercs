namespace Core.DomainModel
{
    public enum AssetStorageType
    {
        [EnumStringValue("None")]
        None = 0,
        [EnumStringValue("Wallet")]
        Wallet = 1,
        [EnumStringValue("Factory")]
        Factory = 2,
        [EnumStringValue("Hangar")]
        Hangar = 4,
        [EnumStringValue("Cargo")]
        Cargo = 5,
        [EnumStringValue("Briefcase")]
        Briefcase = 6,
        [EnumStringValue("Skill")]
        Skill = 7,
        [EnumStringValue("Reward")]
        Reward = 8,
        [EnumStringValue("Character in station connected")]
        Connected = 9,
        [EnumStringValue("Character in station offline")]
        Disconnected = 10,
        [EnumStringValue("Low power slot 1")]
        LoSlot0 = 11,
        [EnumStringValue("Low power slot 2")]
        LoSlot1 = 12,
        [EnumStringValue("Low power slot 3")]
        LoSlot2 = 13,
        [EnumStringValue("Low power slot 4")]
        LoSlot3 = 14,
        [EnumStringValue("Low power slot 5")]
        LoSlot4 = 15,
        [EnumStringValue("Low power slot 6")]
        LoSlot5 = 16,
        [EnumStringValue("Low power slot 7")]
        LoSlot6 = 17,
        [EnumStringValue("Low power slot 8")]
        LoSlot7 = 18,
        [EnumStringValue("Medium power slot 1")]
        MedSlot0 = 19,
        [EnumStringValue("Medium power slot 2")]
        MedSlot1 = 20,
        [EnumStringValue("Medium power slot 3")]
        MedSlot2 = 21,
        [EnumStringValue("Medium power slot 4")]
        MedSlot3 = 22,
        [EnumStringValue("Medium power slot 5")]
        MedSlot4 = 23,
        [EnumStringValue("Medium power slot 6")]
        MedSlot5 = 24,
        [EnumStringValue("Medium power slot 7")]
        MedSlot6 = 25,
        [EnumStringValue("Medium power slot 8")]
        MedSlot7 = 26,
        [EnumStringValue("High power slot 1")]
        HiSlot0 = 27,
        [EnumStringValue("High power slot 2")]
        HiSlot1 = 28,
        [EnumStringValue("High power slot 3")]
        HiSlot2 = 29,
        [EnumStringValue("High power slot 4")]
        HiSlot3 = 30,
        [EnumStringValue("High power slot 5")]
        HiSlot4 = 31,
        [EnumStringValue("High power slot 6")]
        HiSlot5 = 32,
        [EnumStringValue("High power slot 7")]
        HiSlot6 = 33,
        [EnumStringValue("High power slot 8")]
        HiSlot7 = 34,
        [EnumStringValue("Fixed Slot")]
        FixedSlot = 35,
        [EnumStringValue("Capsule")]
        Capsule = 56,
        [EnumStringValue("Pilot")]
        Pilot = 57,
        [EnumStringValue("Passenger")]
        Passenger = 58,
        [EnumStringValue("Boarding gate")]
        BoardingGate = 59,
        [EnumStringValue("Crew")]
        Crew = 60,
        [EnumStringValue("Skill in training")]
        SkillInTraining = 61,
        [EnumStringValue("Corporation Market Deliveries / Returns")]
        CorpMarket = 62,
        [EnumStringValue("Locked item, can not be moved unless unlocked")]
        Locked = 63,
        [EnumStringValue("Unlocked item, can be moved")]
        Unlocked = 64,
        [EnumStringValue("Office slot 1")]
        OfficeSlot1 = 70,
        [EnumStringValue("Office slot 2")]
        OfficeSlot2 = 71,
        [EnumStringValue("Office slot 3")]
        OfficeSlot3 = 72,
        [EnumStringValue("Office slot 4")]
        OfficeSlot4 = 73,
        [EnumStringValue("Office slot 5")]
        OfficeSlot5 = 74,
        [EnumStringValue("Office slot 6")]
        OfficeSlot6 = 75,
        [EnumStringValue("Office slot 7")]
        OfficeSlot7 = 76,
        [EnumStringValue("Office slot 8")]
        OfficeSlot8 = 77,
        [EnumStringValue("Office slot 9")]
        OfficeSlot9 = 78,
        [EnumStringValue("Office slot 10")]
        OfficeSlot10 = 79,
        [EnumStringValue("Office slot 11")]
        OfficeSlot11 = 80,
        [EnumStringValue("Office slot 12")]
        OfficeSlot12 = 81,
        [EnumStringValue("Office slot 13")]
        OfficeSlot13 = 82,
        [EnumStringValue("Office slot 14")]
        OfficeSlot14 = 83,
        [EnumStringValue("Office slot 15")]
        OfficeSlot15 = 84,
        [EnumStringValue("Office slot 16")]
        OfficeSlot16 = 85,
        [EnumStringValue("Bonus")]
        Bonus = 86,
        [EnumStringValue("Drone Bay")]
        DroneBay = 87,
        [EnumStringValue("Booster")]
        Booster = 88,
        [EnumStringValue("Implant")]
        Implant = 89,
        [EnumStringValue("Ship Hangar")]
        ShipHangar = 90,
        [EnumStringValue("Ship Offline")]
        ShipOffline = 91,
        [EnumStringValue("Rig power slot 1")]
        RigSlot0 = 92,
        [EnumStringValue("Rig power slot 2")]
        RigSlot1 = 93,
        [EnumStringValue("Rig power slot 3")]
        RigSlot2 = 94,
        [EnumStringValue("Rig power slot 4")]
        RigSlot3 = 95,
        [EnumStringValue("Rig power slot 5")]
        RigSlot4 = 96,
        [EnumStringValue("Rig power slot 6")]
        RigSlot5 = 97,
        [EnumStringValue("Rig power slot 7")]
        RigSlot6 = 98,
        [EnumStringValue("Rig power slot 8")]
        RigSlot7 = 99,
        [EnumStringValue("Factory Background Operation")]
        FactoryOperation = 100,
        [EnumStringValue("Corp Security Access Group 2")]
        CorpSAG2 = 116,
        [EnumStringValue("Corp Security Access Group 3")]
        CorpSAG3 = 117,
        [EnumStringValue("Corp Security Access Group 4")]
        CorpSAG4 = 118,
        [EnumStringValue("Corp Security Access Group 5")]
        CorpSAG5 = 119,
        [EnumStringValue("Corp Security Access Group 6")]
        CorpSAG6 = 120,
        [EnumStringValue("Corp Security Access Group 7")]
        CorpSAG7 = 121,
        [EnumStringValue("Secondary Storage")]
        SecondaryStorage = 122
    }
}
