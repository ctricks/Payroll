using PayrollSystem.Database;
using PayrollSystem.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PayrollSystem.Settings
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        DataSet dsSettings = new DataSet();
        clsDatabase cdb = new clsDatabase();
        clsHelpers chelper = new clsHelpers();
        private void FormInit()
        {
            tvSettings.Nodes.Add("System Settings");
            dsSettings = cdb.getDSFromSPSelect("sp_getSettings");

            if (dsSettings.Tables.Count > 0)
            {
                int levelcount = 0;
                DataView dvSet = new DataView(dsSettings.Tables[0]);
                DataView dvSetChild = new DataView(dsSettings.Tables[0]);
                dvSet.RowFilter = "tblmgb_settings_ParentID < 0";
                // Adding a child node to the first root node
                foreach (DataRow drow in dvSet.ToTable().Rows)
                {
                    string ParentNodeName = drow["tblmgb_settings_name"].ToString();
                    tvSettings.Nodes[0].Nodes.Add(drow["tblmgb_settings_Id"].ToString(),ParentNodeName);
                    //tcPanels.TabPages.Add(ParentNodeName,ParentNodeName);
                    int ParentID = chelper.GetInteger(drow["tblmgb_settings_Id"].ToString());
                    dvSetChild.RowFilter = "tblmgb_settings_ParentID = " + ParentID;
                    if (dvSetChild.ToTable().Rows.Count > 0)
                    {
                        foreach (DataRow drowChild in dvSetChild.ToTable().Rows)
                        {
                            string ChildValue = drowChild["tblmgb_settings_name"].ToString();
                            TreeNode tn = new TreeNode(ChildValue);
                            tvSettings.Nodes[0].Nodes[levelcount].Nodes.Add(tn);
                        }
                        levelcount++;
                    }
                }

                
                
            }

            
            
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            FormInit();
        }

        private void tvSettings_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                tcPanels.SelectTab(e.Node.Index);                
            }
            if(e.Node.Level == 2)
            {
                tcPanels.SelectTab(e.Node.Parent.Index);
            }
        }
    }
}
