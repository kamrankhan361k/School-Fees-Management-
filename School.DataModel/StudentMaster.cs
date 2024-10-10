using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class StudentMaster
    {
        public int? StudentID { get; set; }
        public int StandardId { get; set; }
        public string Standard { get; set; }
        public int DepartmentId { get; set; }
        public string Department { get; set; }
        public int DivisionId { get; set; }
        public string Division { get; set; }
        public int GRNumber { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public bool IsGender { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public int YearId { get; set; }
        public string CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsOtherFees { get; set; }
        public string Category { get; set; }

    }
}
