using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition.Database;
using LazZiya.ImageResize;

namespace FaceRecognition.Forms
{
    public partial class frmVehicleReport : Form
    {
        static int VehicleNonMotorCount = 0, VehicleMotorCount = 0;
        private const string TBL_VEHICLEEVENT_NAME = "tblVehicleEvent";
        private const string TBL_VEHICLEEVENT_COL_ID = "ID";
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
        public frmVehicleReport()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Clear();
            string startTime = dtpStart.Value.ToString("yyyyMMdd HH:mm:ss");
            string endTime = dtpEnd.Value.ToString("yyyyMMdd HH:mm:ss");
            DataTable data = tblVehicleEvent.GetVehicleData(startTime, endTime, cbVehicleType.SelectedIndex);


            foreach (DataRow row in data.Rows)
            {
                string ID = row[TBL_VEHICLEEVENT_COL_ID].ToString();
                string Type = row[TBL_VEHICLEEVENT_COL_EVENTTYPE].ToString();
                if (Type == SEARCH_NON_MOTOR.ToString())
                {
                    VehicleNonMotorCount++;
                    Type = "NonMotor";
                }
                else
                {
                    VehicleMotorCount++;
                    Type = "Motor";
                }
                string Datetime = row[TBL_VEHICLEEVENT_COL_DATE].ToString();
                string vehicleColor = row[TBL_VEHICLEEVENT_COL_VEHICLE_COLOR].ToString();
                string vehicleType =row[TBL_VEHICLEEVENT_COL_VEHICLE_TYPE].ToString(); 
                string plateColor = row[TBL_VEHICLEEVENT_COL_PLATE_COLOR].ToString(); 
                string plateNo = row[TBL_VEHICLEEVENT_COL_PLATE_NUMBER].ToString(); 
                string seatBelt = row[TBL_VEHICLEEVENT_COL_SEATBELT].ToString();
                string calling = row[TBL_VEHICLEEVENT_COL_SEATBELT].ToString();
                string smoking = row[TBL_VEHICLEEVENT_COL_SMOKING].ToString();
                string globalImage = row[TBL_VEHICLEEVENT_COL_GLOBALIMAGE].ToString();
                string vehicleImage = row[TBL_VEHICLEEVENT_COL_VEHICLEIMAGE].ToString();
                dgvData.Rows.Add(ID, Datetime, Type, vehicleColor, vehicleType, plateColor, plateNo, seatBelt, calling, smoking, ImageResize.Scale(Image.FromFile(globalImage), 150, 150), ImageResize.Scale(Image.FromFile(vehicleImage), 150, 150));
            }
            txtMotorCount.Text = VehicleNonMotorCount.ToString();
            txtNonMotorCount.Text = VehicleNonMotorCount.ToString();
        }

        private void frmVehicleReport_Load(object sender, EventArgs e)
        {
            dgvData.Columns.Add("ID", TBL_VEHICLEEVENT_COL_ID);
            dgvData.Columns.Add("Date", TBL_VEHICLEEVENT_COL_DATE);
            dgvData.Columns.Add("Type", TBL_VEHICLEEVENT_COL_EVENTTYPE);
            dgvData.Columns.Add("Color", TBL_VEHICLEEVENT_COL_VEHICLE_COLOR);
            dgvData.Columns.Add("Logo", TBL_VEHICLEEVENT_COL_VEHICLE_TYPE);
            dgvData.Columns.Add("PlateColor", TBL_VEHICLEEVENT_COL_PLATE_COLOR);
            dgvData.Columns.Add("PlateNo", TBL_VEHICLEEVENT_COL_PLATE_NUMBER);
            dgvData.Columns.Add("SeatBelt", TBL_VEHICLEEVENT_COL_SEATBELT);
            dgvData.Columns.Add("Calling", TBL_VEHICLEEVENT_COL_CALLING);
            dgvData.Columns.Add("Smoking", TBL_VEHICLEEVENT_COL_SMOKING);


            DataGridViewImageColumn GlobalImageCol = new DataGridViewImageColumn();
            GlobalImageCol.HeaderText = TBL_VEHICLEEVENT_COL_GLOBALIMAGE;
            GlobalImageCol.Name = "GlobalImage";
            dgvData.Columns.Add(GlobalImageCol);

            DataGridViewImageColumn VehicleImageCol = new DataGridViewImageColumn();
            GlobalImageCol.HeaderText = TBL_VEHICLEEVENT_COL_GLOBALIMAGE;
            GlobalImageCol.Name = "VehicleImage";
            dgvData.Columns.Add(VehicleImageCol);

            cbVehicleType.SelectedIndex = 0;
        }
    }
}
