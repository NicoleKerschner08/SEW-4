using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Data;
using System;
using SchoolManagementApi.Models;
namespace SchoolManagementApi.Controllers
{
        [ApiController]
        [Route("api/assignments")]
        public class AssignmentsController : ControllerBase
        {
            // Alle Daten holen
            [HttpGet]
            public List<Assignment> GetAll()
            {
                return SchoolDataScore.Assignments.ToList();
            }

            [HttpGet("student/{studentId}")]
            public List<Assignment> GetId(int studentId)
            {
                List<Assignment> studentAssignments = new List<Assignment>();
                foreach (Assignment c in SchoolDataScore.Assignments.ToList())
                {
                    if (c.StudentId == studentId)
                        studentAssignments.Add(c);
                }
                return studentAssignments;
            }

            [HttpPost]
            public IActionResult Create(Assignment assignment)
            {
                SchoolDataScore.Assignments.Add(assignment);
                return Ok(assignment);
            }

            [HttpPut("{id}")]
            public IActionResult Update(int id, Assignment assignment)
            {
                for (int i = 0; i < SchoolDataScore.Assignments.Count; i++)
                {
                    if (SchoolDataScore.Assignments[i].Id == id)
                    {
                        SchoolDataScore.Assignments[i] = assignment;
                        return Ok(assignment);
                    }
                }
                return NotFound();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                for (int i = 0; i < SchoolDataScore.Assignments.Count; i++)
                {
                    if (SchoolDataScore.Assignments[i].Id == id)
                    {
                        SchoolDataScore.Assignments.RemoveAt(i);
                        return Ok();
                    }
                }
                return NotFound();
            }
        }
    
}
