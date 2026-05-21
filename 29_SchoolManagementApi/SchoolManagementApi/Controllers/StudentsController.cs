using Microsoft.AspNetCore.Mvc;
using SchoolManagementApi.Data;
using System;
using SchoolManagementApi.Models;

namespace SchoolManagementApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        // Alle Daten holen
        [HttpGet]
        public List<Student> GetAll()
        {
            return SchoolDataScore.Students.ToList();
        }

        [HttpGet("{id}")]
        public Student GetId(int id)
        {
            foreach (Student c in SchoolDataScore.Students.ToList())
            {
                if (c.Id == id)
                    return c;
            }
            return null;
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            SchoolDataScore.Students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student newStudent)
        {
            for (int i = 0; i < SchoolDataScore.Students.Count; i++)
            {
                if (SchoolDataScore.Students[i].Id == id)
                {
                    SchoolDataScore.Students[i] = newStudent;
                    return Ok(newStudent);
                }
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < SchoolDataScore.Students.Count; i++)
            {
                if (SchoolDataScore.Students[i].Id == id)
                {
                    SchoolDataScore.Students.RemoveAt(i);
                    return Ok();
                }
            }
            return NotFound();
        }
    }
}
