using Apache.Ignite.Core.Cache.Configuration;
using Models.FDC;
using Models.FDC.Analysis;
using Models.FDC.Equipments.DataEntry;
using Models.FDC.FFVTruckTicket.DataEntry;
using Models.FDC.GlobalAdmin;
using Models.Ignite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IngiteClientServerNetCoreConsoleApp.Model.Records
{
    public class ProductionDayRecord : ICustomCacheStore
    {
        [QuerySqlField]
        private DateTime _CreatedDateTime;
        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set
            {
                _CreatedDateTime = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }
        [QuerySqlField]
        private DateTime _ProductionDay;
        public DateTime ProductionDay
        {
            get { return _ProductionDay; }
            set
            {
                _ProductionDay = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        [QuerySqlField]
        public string Reason { get; set; }

        //Common Fields
        [QuerySqlField]
        public string DistrictId { get; set; }
        [QuerySqlField]
        public string District { get; set; }
        [QuerySqlField]
        public string AreaId { get; set; }
        [QuerySqlField]
        public string Area { get; set; }
        [QuerySqlField]
        public string FieldId { get; set; }
        [QuerySqlField]
        public string Field { get; set; }
        [QuerySqlField]
        public string EntityId { get; set; }
        [QuerySqlField]
        public string EntityType { get; set; }
        [QuerySqlField]
        public string EntityName { get; set; }
        [QuerySqlField]
        public string TimeZone { get; set; }
        [QuerySqlField]
        public string TenantId { get; set; }
        [QuerySqlField]
        public string TenantName { get; set; }
        [QuerySqlField]
        public string IsDeleted { get; set; }
        [QuerySqlField]
        public string CreatedBy { get; set; }
        [QuerySqlField]
        public string ModifiedBy { get; set; }

        [QuerySqlField]
        private DateTime _ModifiedDateTime;
        public DateTime ModifiedDateTime
        {
            get { return _ModifiedDateTime; }
            set
            {
                _ModifiedDateTime = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }

        //Entity Form Fields
        [QuerySqlField]
        public string ExternalLocation { get; set; }
        [QuerySqlField]
        public double LostBOE { get; set; }
        [QuerySqlField]
        public string Tag { get; set; } //replace with datasources
        [QuerySqlField]
        public string ShutIn { get; set; }

        [QuerySqlField]
        private DateTime _ProductionDate;
        public DateTime ProductionDate
        {
            get { return _ProductionDate; }
            set
            {
                _ProductionDate = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }
        [QuerySqlField]
        public double HoursOn { get; set; } = 24;
        [QuerySqlField]
        public double HoursDown { get; set; } // 24 - HoursOn
        [QuerySqlField]
        public double Runtime { get; set; }
        [QuerySqlField]
        public string DowntimeCode { get; set; }
        [QuerySqlField]
        public string DowntimeCodeId { get; set; }
        [QuerySqlField]
        public string WellType { get; set; }
        [QuerySqlField]
        public double WorkingInterest { get; set; }
        [QuerySqlField]
        public string HydroCarbonType { get; set; }

        [QuerySqlField]
        private DateTime _LastAllocationtime;
        public DateTime LastAllocationtime
        {
            get { return _LastAllocationtime; }
            set
            {
                _LastAllocationtime = DateTime.SpecifyKind(value != null ? value : DateTime.UtcNow, DateTimeKind.Utc);
            }
        }
        [QuerySqlField]
        public string AllocationStatus { get; set; }
        [QuerySqlField]
        public string DownStreamLocationType { get; set; }
        [QuerySqlField]
        public string DownStreamLocationId { get; set; }
        [QuerySqlField]
        public string DownStreamLocationName { get; set; }
        [QuerySqlField]
        public double WellMeasuredTotal { get; set; }
        [QuerySqlField]
        public double WellTestedTotal { get; set; }

        // Well Characteristics
        [QuerySqlField]
        public double CasingPressure { get; set; }
        [QuerySqlField]
        public double TubingPressure { get; set; }
        [QuerySqlField]
        public double PumpEfficiency { get; set; }
        [QuerySqlField]
        public double FlowingTemp { get; set; }
        [QuerySqlField]
        public double FlowPressure { get; set; }
        [QuerySqlField]
        public string Intermittent { get; set; }
        [QuerySqlField]
        public double H2S { get; set; }
        [QuerySqlField]
        public double Salinity { get; set; }
        [QuerySqlField]
        public double Ph { get; set; }
        [QuerySqlField]
        public double Choke { get; set; }
        [QuerySqlField]

        //Injection Pressure
        public double InjectionPressure { get; set; }
        [QuerySqlField]
        public double InjectionTemp { get; set; }

        // Gross Production
        [QuerySqlField]
        public double GasMeasured { get; set; }
        [QuerySqlField]
        public double CondyMeasured { get; set; }
        [QuerySqlField]
        public double OilMeasured { get; set; }
        [QuerySqlField]
        public double WaterMeasured { get; set; }
        [QuerySqlField]
        public double SandMeasured { get; set; }
        [QuerySqlField]
        public double GasGathered { get; set; }

        //Tested 
        [QuerySqlField]
        public double GasTested { get; set; }
        [QuerySqlField]
        public double CondyTested { get; set; }
        [QuerySqlField]
        public double NglTested { get; set; }
        [QuerySqlField]
        public double OilTested { get; set; }
        [QuerySqlField]
        public double WaterTested { get; set; }
        [QuerySqlField]
        public double SandTested { get; set; }

        //LiftGas
        [QuerySqlField]
        public double LiftGas { get; set; }
        [QuerySqlField]
        public double LiftGasRemaining { get; set; }

        //Load
        [QuerySqlField]
        public double CondyLoadInjected { get; set; }
        [QuerySqlField]
        public double OilLoadInjected { get; set; }
        [QuerySqlField]
        public double WaterLoadInjected { get; set; }
        [QuerySqlField]
        public double SandLoadInjected { get; set; }

        //source
        [QuerySqlField]
        public double WaterSource { get; set; }

        //Injected
        [QuerySqlField]
        public double FluidInjected { get; set; }
        [QuerySqlField]
        public double WaterInjected { get; set; }
        [QuerySqlField]
        public double GasInjected { get; set; }
        [QuerySqlField]
        public double OilInjected { get; set; }
        [QuerySqlField]
        public double CondyInjected { get; set; }

        //Recovered
        [QuerySqlField]
        public double GasRecovered { get; set; }
        [QuerySqlField]
        public double CondyRecovered { get; set; }
        [QuerySqlField]
        public double OilRecovered { get; set; }
        [QuerySqlField]
        public double WaterRecovered { get; set; }
        [QuerySqlField]
        public double FluidRecovered { get; set; }
        [QuerySqlField]
        public double SandRecovered { get; set; }

        //LoadRemaining
        [QuerySqlField]
        public double CondyLoadRemaining { get; set; }
        [QuerySqlField]
        public double OilLoadRemaining { get; set; }
        [QuerySqlField]
        public double WaterLoadRemaining { get; set; }
        [QuerySqlField]
        public double FluidLoadRemaining { get; set; }
        [QuerySqlField]
        public double SandLoadRemaining { get; set; }

        //LoadYesterdayRemaining
        [QuerySqlField]
        public double CondyLoadYesterdayRemaining { get; set; }
        [QuerySqlField]
        public double OilLoadYesterdayRemaining { get; set; }
        [QuerySqlField]
        public double WaterLoadYesterdayRemaining { get; set; }
        [QuerySqlField]
        public double FluidLoadYesterdayRemaining { get; set; }

        //Produced
        [QuerySqlField]
        public double GasProduced { get; set; }
        [QuerySqlField]
        public double CondyProduced { get; set; }
        [QuerySqlField]
        public double OilProduced { get; set; }
        [QuerySqlField]
        public double WaterProduced { get; set; }
        [QuerySqlField]
        public double SandProduced { get; set; }

        //ProducedBOE
        [QuerySqlField]
        public double GasProducedBOE { get; set; }
        [QuerySqlField]
        public double CondyProducedBOE { get; set; }
        [QuerySqlField]
        public double OilProducedBOE { get; set; }

        //Prorated
        [QuerySqlField]
        public double GasProrated { get; set; }
        [QuerySqlField]
        public double CondyProrated { get; set; }
        [QuerySqlField]
        public double OilProrated { get; set; }
        [QuerySqlField]
        public double WaterProrated { get; set; }
        [QuerySqlField]
        public double SandProrated { get; set; }

        //ProrationFactor
        [QuerySqlField]
        public double GasProrationFactor { get; set; }
        [QuerySqlField]
        public double CondyProrationFactor { get; set; }
        [QuerySqlField]
        public double OilProrationFactor { get; set; }
        [QuerySqlField]
        public double WaterProrationFactor { get; set; }
        [QuerySqlField]
        public double SandProrationFactor { get; set; }

        //DeliveredFwd 
        public double GasDeliveredFwd { get; set; }
        [QuerySqlField]
        public double CondyDeliveredFwd { get; set; }
        [QuerySqlField]
        public double OilDeliveredFwd { get; set; }
        [QuerySqlField]
        public double WaterDeliveredFwd { get; set; }
        [QuerySqlField]
        public double SandDeliveredFwd { get; set; }
        [QuerySqlField]
        public double NGLDeliveredFwd { get; set; }


        //DisposedFwd
        [QuerySqlField]
        public double GasDisposedFwd { get; set; }
        [QuerySqlField]
        public double CondyDisposedFwd { get; set; }
        [QuerySqlField]
        public double OilDisposedFwd { get; set; }
        [QuerySqlField]
        public double WaterDisposedFwd { get; set; }
        [QuerySqlField]
        public double SandDisposedFwd { get; set; }
        [QuerySqlField]
        public double NGLDisposedFwd { get; set; }


        //AllocatedCollectedBwrd
        [QuerySqlField]
        public double GasAllocated { get; set; }
        [QuerySqlField]
        public double CondyAllocated { get; set; }
        [QuerySqlField]
        public double OilAllocated { get; set; }
        [QuerySqlField]
        public double WaterAllocated { get; set; }
        [QuerySqlField]
        public double SandAllocated { get; set; }
        [QuerySqlField]
        public double NglAllocated { get; set; }
        [QuerySqlField]
        public double FuelAllocated { get; set; }
        [QuerySqlField]
        public double FlareAllocated { get; set; }
        [QuerySqlField]
        public double VentAllocated { get; set; }
        [QuerySqlField]
        public double TotalFFVAllocated { get; set; }

        //Net Allocated Volumes
        [QuerySqlField]
        public double GasAllocatedNet { get; set; }  // GasAllocated * (Working Interest/100)
        [QuerySqlField]
        public double CondyAllocatedNet { get; set; }
        [QuerySqlField]
        public double OilAllocatedNet { get; set; }
        [QuerySqlField]
        public double WaterAllocatedNet { get; set; }
        [QuerySqlField]
        public double SandAllocatedNet { get; set; }
        [QuerySqlField]
        public double NglAllocatedNet { get; set; }

        //AllocatedCollectedBwrdBOE
        public double GasAllocatedBOE { get; set; }
        [QuerySqlField]
        public double CondyAllocatedBOE { get; set; }
        [QuerySqlField]
        public double OilAllocatedBOE { get; set; }
        [QuerySqlField]
        public double NGLAllocatedBOE { get; set; }


        //AllocatedCollectedBwrdBOENet
        [QuerySqlField]
        public double GasAllocatedBOENet { get; set; } // GasAllocatedBOE * (Working Interest/100) 
        [QuerySqlField]
        public double CondyAllocatedBOENet { get; set; }
        [QuerySqlField]
        public double OilAllocatedBOENet { get; set; }
        [QuerySqlField]
        public double NGLAllocatedBOENet { get; set; }



        //Lost (based on graph)
        [QuerySqlField]
        public double GasLostProduction { get; set; }
        [QuerySqlField]
        public double CondyLostProduction { get; set; }
        [QuerySqlField]
        public double OilLostProduction { get; set; }
        [QuerySqlField]
        public double WaterLostProduction { get; set; }
        [QuerySqlField]
        public double SandLostProduction { get; set; }

        //LostBOE
        [QuerySqlField]
        public double GasLostProductionBOE { get; set; }
        [QuerySqlField]
        public double CondyLostProductionBOE { get; set; }
        [QuerySqlField]
        public double OilLostProductionBOE { get; set; }

        //Rated
        [QuerySqlField]
        public double GasRate { get; set; }    // ProducedGas / 24 to get hourly rate 
        [QuerySqlField]
        public double CondyRate { get; set; }
        [QuerySqlField]
        public double OilRate { get; set; }
        [QuerySqlField]
        public double WaterRate { get; set; }
        [QuerySqlField]
        public double SandRate { get; set; }

        //Capability
        [QuerySqlField]
        public double GasCapability { get; set; }
        [QuerySqlField]
        public double CondyCapability { get; set; }
        [QuerySqlField]
        public double OilCapability { get; set; }
        [QuerySqlField]
        public double WaterCapability { get; set; }

        //inventory
        [QuerySqlField]
        public double NglCloseInventory { get; set; }
        [QuerySqlField]
        public double CondyCloseInventory { get; set; }
        [QuerySqlField]
        public double OilCloseInventory { get; set; }
        [QuerySqlField]
        public double WaterCloseInventory { get; set; }
        [QuerySqlField]
        public double SandCloseInventory { get; set; }
        [QuerySqlField]
        public double TotalInventory { get; set; }

        //TankProduction
        [QuerySqlField]
        public double NglTankProduction { get; set; }
        [QuerySqlField]
        public double CondyTankProduction { get; set; }
        [QuerySqlField]
        public double OilTankProduction { get; set; }
        [QuerySqlField]
        public double WaterTankProduction { get; set; }
        [QuerySqlField]
        public double SandTankProduction { get; set; }
        [QuerySqlField]
        public double TotalTankProduction { get; set; }

        //TruckOut
        [QuerySqlField]
        public double OilTruckedOut { get; set; }
        [QuerySqlField]
        public double CondyTruckedOut { get; set; }
        [QuerySqlField]
        public double NglTruckedOut { get; set; }
        [QuerySqlField]
        public double WaterTruckedOut { get; set; }
        [QuerySqlField]
        public double SandTruckedOut { get; set; }

        //TruckIn
        [QuerySqlField]
        public double OilTruckedIn { get; set; }
        [QuerySqlField]
        public double CondyTruckedIn { get; set; }
        [QuerySqlField]
        public double NglTruckedIn { get; set; }
        [QuerySqlField]
        public double WaterTruckedIn { get; set; }
        [QuerySqlField]
        public double SandTruckedIn { get; set; }

        //sale
        [QuerySqlField]
        public double GasSales { get; set; }
        [QuerySqlField]
        public double CondySales { get; set; }
        [QuerySqlField]
        public double OilSales { get; set; }
        [QuerySqlField]
        public double WaterSales { get; set; }
        [QuerySqlField]
        public double NglSales { get; set; }
        [QuerySqlField]
        public double SandSales { get; set; }

        //Delivered
        [QuerySqlField]
        public double GasDelivered { get; set; }

        //Transout
        [QuerySqlField]
        public double GasTransOut { get; set; }   // Trans Out Gas
        [QuerySqlField]
        public double CondyTransOut { get; set; }  // Trans Out Condy
        [QuerySqlField]
        public double OilTransOut { get; set; }  // Trans Out Oil
        [QuerySqlField]
        public double WaterTransOut { get; set; }  // Trans Out Water
        [QuerySqlField]
        public double NglTransOut { get; set; }  // Trans Out Ngl
        [QuerySqlField]
        public double SandTransOut { get; set; }  // Trans Out Sand

        //FFV UpStream and DownStream
        [QuerySqlField]
        public double FuelGasUpstreamMetered { get; set; }
        [QuerySqlField]
        public double FuelGasDownstreamMetered { get; set; }
        [QuerySqlField]
        public double FlareGasUpstreamMetered { get; set; }
        [QuerySqlField]
        public double FlareGasDownstreamMetered { get; set; }
        [QuerySqlField]
        public double VentGasUpstreamMetered { get; set; }
        [QuerySqlField]
        public double VentGasDownstreamMetered { get; set; }

        [QuerySqlField]
        public double FuelGasUpstreamEvents { get; set; }
        [QuerySqlField]
        public double FuelGasDownstreamEvents { get; set; }
        [QuerySqlField]
        public double FlareGasUpstreamEvents { get; set; }
        [QuerySqlField]
        public double FlareGasDownstreamEvents { get; set; }
        [QuerySqlField]
        public double VentGasUpstreamEvents { get; set; }
        [QuerySqlField]
        public double VentGasDownstreamEvents { get; set; }
        [QuerySqlField]
        public double TakeoffUpstream { get; set; } // Total Upstream
        [QuerySqlField]
        public double TakeoffDownstream { get; set; }  // Total Downstream
        [QuerySqlField]
        public double TotalFuelFlareVent { get; set; }  // TakeoffUpstream + TakeoffDownstream

        [QuerySqlField]
        public double HydrogenAllocated { get; set; } // H2
        [QuerySqlField]
        public double HeliumAllocated { get; set; } // He
        [QuerySqlField]
        public double NitrogenAllocated { get; set; } // N2
        [QuerySqlField]
        public double CarbonDioxideAllocated { get; set; } // CO2
        [QuerySqlField]
        public double HydrogenSulfideAllocated { get; set; } // H2S
        [QuerySqlField]
        public double MethaneAllocated { get; set; } // C1
        [QuerySqlField]
        public double EthaneAllocated { get; set; } // C2
        [QuerySqlField]
        public double PropaneAllocated { get; set; } // C3
        [QuerySqlField]
        public double IsoButaneAllocated { get; set; } // IC4
        [QuerySqlField]
        public double NormalButaneAllocated { get; set; } // NC4
        [QuerySqlField]
        public double IsoPentaneAllocated { get; set; } // IC5
        [QuerySqlField]
        public double NormalPentaneAllocated { get; set; } // NC5
        [QuerySqlField]
        public double HexanesAllocated { get; set; } // C6
        [QuerySqlField]
        public double HeptanesAllocated { get; set; } // C7
        [QuerySqlField]
        public double HydrogenAllocatedNet { get; set; } // H2// HydrogenAllocated * (Working Interest/100)
        [QuerySqlField]
        public double HeliumAllocatedNet { get; set; } // He
        [QuerySqlField]
        public double NitrogenAllocatedNet { get; set; } // N2
        [QuerySqlField]
        public double CarbonDioxideAllocatedNet { get; set; } // CO2
        [QuerySqlField]
        public double HydrogenSulfideAllocatedNet { get; set; } // H2S
        [QuerySqlField]
        public double MethaneAllocatedNet { get; set; } // C1
        [QuerySqlField]
        public double EthaneAllocatedNet { get; set; } // C2
        [QuerySqlField]
        public double PropaneAllocatedNet { get; set; } // C3
        [QuerySqlField]
        public double IsoButaneAllocatedNet { get; set; } // IC4
        [QuerySqlField]
        public double NormalButaneAllocatedNet { get; set; } // NC4
        [QuerySqlField]
        public double IsoPentaneAllocatedNet { get; set; } // IC5
        [QuerySqlField]
        public double NormalPentaneAllocatedNet { get; set; } // NC5
        [QuerySqlField]
        public double HexanesAllocatedNet { get; set; } // C6
        [QuerySqlField]
        public double HeptanesAllocatedNet { get; set; } // C7



        //NetProduced
        [QuerySqlField]
        public double GasNetProduced { get; set; }
        [QuerySqlField]
        public double CondyNetProduced { get; set; }
        [QuerySqlField]
        public double OilNetProduced { get; set; }
        [QuerySqlField]
        public double WaterNetProduced { get; set; }
        [QuerySqlField]
        public double SandNetProduced { get; set; }

        //NetProducedBOE
        [QuerySqlField]
        public double GasNetProducedBOE { get; set; }
        [QuerySqlField]
        public double CondyNetProducedBOE { get; set; }
        [QuerySqlField]
        public double OilNetProducedBOE { get; set; }

        //NetLostProduction
        [QuerySqlField]
        public double GasNetLostProduction { get; set; }
        [QuerySqlField]
        public double CondyNetLostProduction { get; set; }
        [QuerySqlField]
        public double OilNetLostProduction { get; set; }
        [QuerySqlField]
        public double WaterNetLostProduction { get; set; }
        public double SandNetLostProduction { get; set; }

        //Uom
        [QuerySqlField]
        public string GasUnitsOfMeasurements { get; set; }
        [QuerySqlField]
        public string LiquidUnitsOfMeasurements { get; set; }

        //Uom
        [QuerySqlField]
        public double GasBOE { get; set; }
        [QuerySqlField]
        public double LiquidBOE { get; set; }

        // Dicts of the ProductionDayRecords from the "Equipment" enties which are "related to" the battery (i.e. equipment and meters on site at the battery)

        public Dictionary<String, OrificeMeterProductionDayRecord> OrificeMetersRecordsDict { get; set; } = new Dictionary<string, OrificeMeterProductionDayRecord>();

        public Dictionary<String, PdMeterProductionDayRecord> PdMetersRecordsDict { get; set; } = new Dictionary<string, PdMeterProductionDayRecord>();

        public Dictionary<String, TurbineProductionDayRecord> TurbineMetersRecordsDict { get; set; } = new Dictionary<string, TurbineProductionDayRecord>();

        public Dictionary<String, TankProductionDayRecord> TanksRecordsDict { get; set; } = new Dictionary<string, TankProductionDayRecord>();

        public Dictionary<String, CoriolisProductionDayRecord> CoriolisMetersRecordsDict { get; set; } = new Dictionary<string, CoriolisProductionDayRecord>();

        public Dictionary<String, RotaMeterProductionDayRecord> RotaMetersRecordsDict = new Dictionary<String, RotaMeterProductionDayRecord>();

        public Dictionary<String, UltrasonicProductiondayRecord> UltrasonicRecordsDict = new Dictionary<string, UltrasonicProductiondayRecord>();

        public Dictionary<String, NonMeteredProductionDayRecord> NonMeteredRecordsDict { get; set; } = new Dictionary<string, NonMeteredProductionDayRecord>();

        public Dictionary<String, TruckTicketListRecord> TruckTicketDictionary { get; set; } = new Dictionary<string, TruckTicketListRecord>();

        public Dictionary<String, TruckTicketListRecord> TicketHoldingDict { get; set; } = new Dictionary<string, TruckTicketListRecord>();

        public Dictionary<String, FuelFlareVentRecord> TodayFuelFlareVentDict { get; set; } = new Dictionary<string, FuelFlareVentRecord>();


        public Queue<CapabilityRecord> DTNullWellProductionRecordQueue { get; set; } = new Queue<CapabilityRecord>();

        public Dictionary<string, AllocationSettings> AllocationMessagesDict { get; set; } = new Dictionary<string, AllocationSettings>();

        public Dictionary<string, TransferVolumes> AllocatedTransferVolumesDict { get; set; } = new Dictionary<string, TransferVolumes>();

        public Dictionary<String, TransferVolumes> DeliveredDict { get; set; } = new Dictionary<string, TransferVolumes>();

        public Dictionary<String, TransferVolumes> DisposedDict { get; set; } = new Dictionary<string, TransferVolumes>();

        public Dictionary<String, TransferVolumes> UpstreamTransferVolumesDict { get; set; } = new Dictionary<string, TransferVolumes>();

        public Dictionary<string, WellProductVolume> DownstreamDict { get; set; } = new Dictionary<string, WellProductVolume>();

        public Dictionary<string, WellInjectedVolume> UpstreamDict { get; set; } = new Dictionary<string, WellInjectedVolume>();


        public GasAnalysis GasAnalysis { get; set; }

        public OilAnalysis OilAnalysis { get; set; }

        public WaterAnalysis WaterAnalysis { get; set; }

        public CondyAnalysis CondyAnalysis { get; set; }

        public NglAnalysis NglAnalysis { get; set; }
        public ProductionDayRecord()
        {
            ProductionDay = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            CreatedDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            ModifiedDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            ProductionDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);

            LastAllocationtime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        }
    }
}


