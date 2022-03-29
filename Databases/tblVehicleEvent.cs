using System;
using System.Data;
using System.IO;
using FaceRecognition.UserControls;
namespace FaceRecognition.Database
{
    public class tblVehicleEvent
    {
        private const string TBL_VEHICLEEVENT_NAME = "tblVehicleEvent";
        private const string TBL_VEHICLEEVENT_COL_EVENTTYPE = "EventType";
        private const string TBL_VEHICLEEVENT_COL_VEHICLE_COLOR = "VehicleColor";
        private const string TBL_VEHICLEEVENT_COL_VEHICLE_TYPE = "VehicleType";
        private const string TBL_VEHICLEEVENT_COL_PLATE_COLOR = "PlateColor";
        private const string TBL_VEHICLEEVENT_COL_PLATE_NUMBER = "PlateNumber";
        private const string TBL_VEHICLEEVENT_COL_SEATBELT = "SeatBelt";
        private const string TBL_VEHICLEEVENT_COL_CALLING = "Calling";
        private const string TBL_VEHICLEEVENT_COL_SMOKING = "Smoking";
        private const string TBL_VEHICLEEVENT_COL_GLOBALIMAGE = "GlobaleImage";
        private const string TBL_VEHICLEEVENT_COL_VEHICLEIMAGE = "VehicleImage";
        private const string TBL_VEHICLEEVENT_COL_DATE = "Date";

        private const int SEARCH_NON_MOTOR = 0;
        private const int SEARCH_MOTOR = 1;
        private const int SEARCH_ALL = 2;

        private static string GetInsertNonMotorVehicleCommand(ucVehicleNonMotor _ucVehicleNonMotor, string globalImage, string vehicleImage)
        {
            return $"Insert into tblVehicleEvent({TBL_VEHICLEEVENT_COL_EVENTTYPE},{TBL_VEHICLEEVENT_COL_DATE},{TBL_VEHICLEEVENT_COL_VEHICLE_COLOR},{TBL_VEHICLEEVENT_COL_GLOBALIMAGE},{TBL_VEHICLEEVENT_COL_VEHICLEIMAGE})" +
                $" values(0,'{DateTime.Now}',N'{_ucVehicleNonMotor.Color}','{Path.Combine(@".\EventData", globalImage)}','{Path.Combine(@".\EventData", vehicleImage)}')";
        }
        private static string GetInsertMotorVehicleCommand(ucVehicleCar _ucVehicleCar, string globalImage, string vehicleImage)
        {
            return $"Insert into tblVehicleEvent({TBL_VEHICLEEVENT_COL_EVENTTYPE},{TBL_VEHICLEEVENT_COL_DATE},{TBL_VEHICLEEVENT_COL_VEHICLE_COLOR},{TBL_VEHICLEEVENT_COL_VEHICLE_TYPE},{TBL_VEHICLEEVENT_COL_PLATE_COLOR},{TBL_VEHICLEEVENT_COL_PLATE_NUMBER},{TBL_VEHICLEEVENT_COL_SEATBELT},{TBL_VEHICLEEVENT_COL_CALLING},{TBL_VEHICLEEVENT_COL_SMOKING},{TBL_VEHICLEEVENT_COL_GLOBALIMAGE},{TBL_VEHICLEEVENT_COL_VEHICLEIMAGE})" +
                $" values(1,'{DateTime.Now}',N'{_ucVehicleCar.VehicleColor}',N'{_ucVehicleCar.VehicleType}',N'{_ucVehicleCar.PlateColor}',N'{_ucVehicleCar.PlateNo}',N'{_ucVehicleCar.SeatBelt}',N'{_ucVehicleCar.Calling}',N'{_ucVehicleCar.Smoking}','{Path.Combine(@".\EventData",globalImage)}','{Path.Combine(@".\EventData", vehicleImage)}')";
        }
        public static bool InsertNonMotorVehicle(ucVehicleNonMotor _ucVehicleNonMotor, string globalImage, string vehicleImage)
        {
            if (!StaticPool.mdb.ExecuteCommand(GetInsertNonMotorVehicleCommand(_ucVehicleNonMotor, globalImage, vehicleImage)))
            {
                if (!StaticPool.mdb.ExecuteCommand(GetInsertNonMotorVehicleCommand(_ucVehicleNonMotor, globalImage, vehicleImage)))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool InsertMotorVehicle(ucVehicleCar _ucVehicleCar, string globalImage, string vehicleImage)
        {
            if (!StaticPool.mdb.ExecuteCommand(GetInsertMotorVehicleCommand(_ucVehicleCar, globalImage, vehicleImage)))
            {
                if (!StaticPool.mdb.ExecuteCommand(GetInsertMotorVehicleCommand(_ucVehicleCar, globalImage, vehicleImage)))
                {
                    return false;
                }
            }
            return true;
        }

        public static DataTable GetVehicleData(string startTime, string endTime, int Search_Type)
        {
            if(Search_Type == SEARCH_ALL)
                return StaticPool.mdb.FillData($"Select * from {TBL_VEHICLEEVENT_NAME} where cast({TBL_VEHICLEEVENT_COL_DATE} as datetime) between '{startTime }' AND '{endTime}'");
            return StaticPool.mdb.FillData($"Select * from {TBL_VEHICLEEVENT_NAME} where cast({TBL_VEHICLEEVENT_COL_DATE} as datetime)  between '{startTime }' AND '{endTime}' AND {TBL_VEHICLEEVENT_COL_EVENTTYPE} = {Search_Type}");
        }


    }
}
