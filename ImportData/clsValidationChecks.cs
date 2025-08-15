using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PayrollSystem.ImportData
{
    public class clsValidationChecks
    {
        public string ValidatationReason;
        public bool CheckForUniqueField(string UniqueField,DataTable dtData)
        {
            bool result = false;
            try
            {
                var CheckDataDT = dtData.AsEnumerable()
                                  .GroupBy(row => row[UniqueField])
                                  .Where(group => group.Count() > 1)
                                  .Select(group => group.Key);

                if(CheckDataDT.Any())
                {
                    ValidatationReason = "Duplicate found: " + CheckDataDT.ToList().First().ToString();
                    MessageBox.Show("Error: "+ ValidatationReason, "Please check first ("+ UniqueField +"). Import Abort", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message.ToString(), "Error in Data.Please check", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            return result;
        }
    }
}
