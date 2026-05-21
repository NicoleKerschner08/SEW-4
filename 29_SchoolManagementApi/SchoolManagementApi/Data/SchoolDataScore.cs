using SchoolManagementApi.Models;
namespace SchoolManagementApi.Data
{
    public class SchoolDataScore
    {
        public static List<Student> Students { get; set; } = new()
       {
             new Student { Id = 1, FirstName = "Ana" , LastName = "Heschl" , Email = "ana.heschl@shtlwy.at" , ClassName = "5AHIT" },
             new Student { Id = 2, FirstName = "Silke" , LastName = "Guntendorfer" , Email = "silke.guntendorfer@htlwy.at" , ClassName = "5AHIT" }
       };

        public static List<Assignment> Assignments { get; set; } = new()
       {
         new Assignment
         {
             Id = 1,
             StudentId = 1,
             Title = "Erstelle REST - API" ,
             Description = "Baue ein einfaches Resp - API" ,
             DueDate = new DateTime (2026, 4, 15),
             IsCompleted = false
         },
         new Assignment
         {
             Id = 2,
             StudentId = 2,
             Title = "Veröffentliche REST - API auf IIS" ,
             Description = "Veröffentliche REST - API auf deinem IIS - Testserver" ,
             DueDate = new DateTime (2025, 4, 18),
             IsCompleted = true
         }
       };
    }
}
