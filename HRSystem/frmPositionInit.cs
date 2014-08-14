﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HRSystem
{
    public partial class frmPositionInit : Form
    {
        public frmPositionInit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Load Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPositionInit_Load(object sender, EventArgs e)
        {
            Utility.FillComberWithEnum(cmbHiringType, typeof(PositionBasicInfo.HiringTypeEnum));
            String[] BandArray = new string[] { "6A","6B","7A","7B","8A","8B" };
            Utility.FillComberWithArray(cmbLBound, BandArray);
            Utility.FillComberWithArray(cmbHBound, BandArray);
            String[] HiringManagerArray = new string[] {
                "Paul Ambraz",
                "Li Ling",
                "Hou Yan",
                "Yi Shangmin",
                "Jiang Meishan",
                "Li Bing" };
            Utility.FillComberWithArray(cmbHiringManager, HiringManagerArray);
        }
        /// <summary>
        /// OK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            PositionBasicInfo basic = new PositionBasicInfo();
            basic.No = (DataCenter.PositionBasicDataSet.Count + 1).ToString();
            basic.Position = txtPosition.Text;
            basic.HiringManager = cmbHiringManager.Text;
            basic.ApprovedDate = DataPickerApprovedDate.Value;
            basic.OpenDate = DataPickerOpenDate.Value;
            basic.Target = (int)NumTarget.Value;
            basic.isOpen = true;
            basic.BandHBound = (PositionBasicInfo.BandEnum)cmbHBound.SelectedIndex;
            basic.BandLBound = (PositionBasicInfo.BandEnum)cmbLBound.SelectedIndex;
            basic.HiringType = (PositionBasicInfo.HiringTypeEnum)cmbHiringType.SelectedIndex;
            DataCenter.PositionBasicDataSet.Add(basic);
            XmlSerializer xml = new XmlSerializer(typeof(List<PositionBasicInfo>));
            xml.Serialize(new StreamWriter(SystemManager.PositionBasicInfoXmlFilename), DataCenter.PositionBasicDataSet);
            DataCenter.ReCompute();
            Close();
        }
    }
}
