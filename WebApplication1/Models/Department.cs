using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public int Id { get; set; }
        
        [Display(Name="部门名称")]
        public string Name { get; set; }

        [Display(Name = "部门地址")]
        public string Location { get; set; }

        [Display(Name = "部门人数")]
        public int EmployeeCount { get; set; }
    }
}
