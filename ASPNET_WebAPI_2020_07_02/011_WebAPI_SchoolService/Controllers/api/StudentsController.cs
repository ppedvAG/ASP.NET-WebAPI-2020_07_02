using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using _011_Shared.ViewModels;
using _011_WebAPI_SchoolService;


namespace _011_WebAPI_SchoolService.Controllers.api
{
    public class StudentsController : ApiController
    {
        //Wird verwendet für anzeigen der Liste
        public IHttpActionResult GetAllStudents(bool includeAddress = false)
        {
            IList<StudentViewModel> students = null;

            using (var ctx = new SchoolDBEntities())
            {
                students = ctx.Students.Include("StudentAddress").Select(s => new StudentViewModel()
                    {
                        Id = s.StudentID,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Address = s.StudentAddress ==null || includeAddress == false ? null : new AddressViewModel()
                        {
                            StudentId = s.StudentAddress.StudentID,
                            Address1 = s.StudentAddress.Address1,
                            Address2 = s.StudentAddress.Address2,
                            City = s.StudentAddress.City,
                            State = s.StudentAddress.State
                        }

                }).ToList<StudentViewModel>();

                if (students.Count == 0)
                    return NotFound();

                return Ok(students);
            }
        }


        //Wird verwendet für Detail-View, Edit-View, Delete-View
        public IHttpActionResult GetStudentById(int id)
        {
            StudentViewModel student = null;

            using (var ctx = new SchoolDBEntities())
            {
                student = ctx.Students.Include("StudentAddress")
                    .Where(s => s.StudentID == id)
                    .Select(s => new StudentViewModel()
                    {
                        Id = s.StudentID,
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }).FirstOrDefault<StudentViewModel>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }


        //Get action methods of the previous section
        //Wird verwendet beim hinzufügen eines Studenten
        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new SchoolDBEntities())
            {
                ctx.Students.Add(new Student()
                {
                    StudentID = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        //Update
        public async Task<IHttpActionResult> Put(StudentViewModel student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            using (var ctx = new SchoolDBEntities())
            {
                var existingStudent = await ctx.Students.Where(s => s.StudentID == student.Id)
                                                        .FirstOrDefaultAsync<Student>();

                //Wenn kein ViewModel verwendet wird, sondern ein Entity-Object. Ist das Updaten gegenüber EF direkt
                //Bei ViewModels, müssen die Properties gegenüber den Entites gemappt sein. Ein ViewModel kann aus mehreren Entity-Klassen befüllt werden. 
                
                //db.Entry(modifiedStudent).State = EntityState.Modified;

                if (existingStudent != null)
                {
                    existingStudent.FirstName = student.FirstName;
                    existingStudent.LastName = student.LastName;

                    //Save Changes generiert einen SQL-Statement und sendet das gegen die DB 
                    await ctx.SaveChangesAsync();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public async Task<IHttpActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");

            using (var ctx = new SchoolDBEntities())
            {
                var student = await ctx.Students
                    .Where(s => s.StudentID == id)
                    .FirstOrDefaultAsync();

                //Da bei Delete nur die ID relevant ist, wird so das Student-Entity ermittelt und man kann mit Entry(student).State sagen, ob dieser Datensatz den Status Delete / oder Modified besitzt. 

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;

                ctx.SaveChanges();
            }

            return Ok();
        }
    }
}