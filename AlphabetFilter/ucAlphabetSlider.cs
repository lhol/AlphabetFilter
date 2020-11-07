using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Shellshock_Rome
{
    public partial class ucAlphabetSlider : UserControl
    {
        private DataView myDataView;
        private CheckBox[] _cbxArray;
        public ucAlphabetSlider()
        {
        }
        public ucAlphabetSlider(DataView myDataViewToFilter)
        {
            this.myDataView = myDataViewToFilter;
            InitializeComponent();
            _cbxArray = new CheckBox[26] {
                cbx1, cbx2, cbx3, cbx4, cbx5, cbx6, cbx7, cbx8, cbx9, cbx10,
                cbx11, cbx12, cbx13, cbx14, cbx15, cbx16, cbx17, cbx18, cbx19, cbx20,
                cbx21, cbx22, cbx23, cbx24, cbx25, cbx26};
            for(int i = 0; i < 26; i++) {
                this._cbxArray[i].Click += new System.EventHandler(this.ClickHandler);
                this._cbxArray[i].Appearance = System.Windows.Forms.Appearance.Button; 
                //this._cbxArray[i].TextAlign = MiddleCenter;
            }
//same as cbxton 
//MinimumSize = (75, 23)//To prevent shrinkage! 
        }
        public void ClickHandler(object sender, System.EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("You have clicked cbxton " +
            //((System.Windows.Forms.CheckBox)sender).Tag.ToString());
            if (!((System.Windows.Forms.CheckBox)sender).Checked)
            {
                myDataView.RowFilter = "Name LIKE '*'";
            }
            else
            {
                for(int i = 0; i < 26; i++) {
                    this._cbxArray[i].Checked = false;
                }
                myDataView.RowFilter = "Name LIKE '" + ((System.Windows.Forms.CheckBox)sender).Text.ToUpper() + "*'";
                ((System.Windows.Forms.CheckBox)sender).Checked = true;
            }
        } 
    }
}
