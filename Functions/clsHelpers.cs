using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.Functions
{
    public class clsHelpers
    {
        IniFile MyIni = new IniFile("Settings.ini");
        public ComboBox cmbReference(DataTable dtSource,string DisplayCode)
        { 
            ComboBox cRef = new ComboBox(); 

            cRef.DropDownStyle = ComboBoxStyle.DropDownList;
            cRef.DataSource = dtSource;
            cRef.DisplayMember = DisplayCode;            
            cRef.ValueMember = "ID";
            
            return cRef;
        }
        public List<string> getIniList(string Key,string Section)
        {
            List<string> slistItem = new List<string>();
            string IniValue = MyIni.Read(Key,Section);
            if (IniValue != null || !string.IsNullOrEmpty(IniValue))
            {
                slistItem = IniValue.Split(',').ToList();
            }
            return slistItem;
        }
        public void ControlEnableDisable(TabControl tc,bool status,string defaultValue = "")
        {
            foreach(TabPage tc2 in tc.TabPages)
            {
                if(tc2.TabIndex == 0)
                {
                    foreach (Control ctrl in tc2.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ctrl.Enabled = status;
                            ctrl.Text = defaultValue;
                        }
                        if (ctrl is ComboBox)
                        {
                            ctrl.Enabled = status;
                            ctrl.Text = defaultValue;
                        }
                        if(ctrl is CheckBox)
                        {
                            ctrl.Enabled = status;
                        }
                        
                        if(ctrl is GroupBox)
                        {
                            foreach (Control ctr in ctrl.Controls)
                            {
                                if (ctr is TextBox)
                                {
                                    ctr.Enabled = status;
                                    ctr.Text = defaultValue;
                                }
                                if (ctr is CheckBox)
                                {
                                    ctr.Enabled = status;
                                }
                                if (ctrl is DataGridView)
                                {
                                    ctrl.Enabled = status;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
