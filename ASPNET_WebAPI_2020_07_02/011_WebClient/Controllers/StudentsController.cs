using _011_Shared.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace _011_WebClient.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();

            string url = "https://localhost:44378/api/students";



            using (HttpClient httpClient = new HttpClient())
            {


                using (var response = httpClient.GetAsync(url))
                {
                    //Hier wandel ich das Ergebnis in JSON um
                    Task<string> apiResponse = response.Result.Content.ReadAsStringAsync();

                    //Deserialsiere
                    students = JsonConvert.DeserializeObject<List<StudentViewModel>>(apiResponse.Result);
                }

                if (students == null)
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(students);
        }

        public ActionResult Create()
        {
            return View(new StudentViewModel()); 
        }

        

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(student);

                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44378/api/Students";


                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> response = client.PostAsync(url, data);
                    string result = response.Result.Content.ReadAsStringAsync().Result;
                }

                return RedirectToAction("Index", "Students");
            }
            return View(student);
        }


        public ActionResult Edit(int? id)
        {

            string url = "https://localhost:44378/api/students?id=" + id.Value;
            StudentViewModel student;

            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(url))
                {
                    //Hier wandel ich das Ergebnis in JSON um
                    Task<string> apiResponse = response.Result.Content.ReadAsStringAsync();

                    //Deserialsiere
                    student = JsonConvert.DeserializeObject<StudentViewModel>(apiResponse.Result);
                }

                if (student == null)
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }


            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44378/api/Students/" + student.Id;

                using (HttpClient client = new HttpClient())
                {
                    var response = client.PutAsync(url, data);
                    Task<string> result = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                //Schreibe Exception in LogFile
            }

            return RedirectToAction(nameof(Index));
        }




        public ActionResult Delete(int id)
        {
            var url = "https://localhost:44378/api/students/" + id;

            using (HttpClient client = new HttpClient())
            {
                Task<HttpResponseMessage> response = client.DeleteAsync(url);
                string result = response.Result.Content.ReadAsStringAsync().Result;
            }

            return RedirectToAction(nameof(Index));
        }


    }
}