using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Attendance
{
    public class AttendanceInfo
    {
        public int BiometricID { get; set; }    
        public string SourceFilename { get; set; }
        public List<ExcelInfo> ExcelInfo { get; set; }
        public DateTime TotalHoursWork { get; set; }
        public int DaysPresent { get; set; }
    }
    public class ExcelInfo
    { 
        public int BiometricID { get; set; }
        public DateTime AttendanceDate { get; set; }
        public DateTime TimeIn_1 { get; set; }
        public DateTime TimeIn_2 { get; set; }
        public DateTime TimeIn_3 { get; set; }
        public DateTime TimeIn_4 { get; set; }

        public DateTime TotalTimeRow { get; set; }

    }

}
