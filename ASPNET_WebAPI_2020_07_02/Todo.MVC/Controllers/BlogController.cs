using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Todo.Domain.Entities;
using Todo.MVC.Data;

namespace Todo.MVC.Controllers
{
    public class BlogController : Controller
    {

        public BlogController()
        {
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            List<Blog> blogList = null;

            string url = "https://localhost:44334/api/Blog";


            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blogList = JsonConvert.DeserializeObject<List<Blog>>(apiResponse);
                }
            }

            if (blogList == null)
            {
                return NotFound();
            }

            
            return View(blogList);
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog blog = null;

            string url = "https://localhost:44334/api/Blog/" + id.Value ;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<Blog>(apiResponse);
                }
            }

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }


        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,CreatedBy,CreatedAt")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(blog);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = "https://localhost:44334/api/Blog";

                using var client = new HttpClient();
                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog blog = null;

            string url = "https://localhost:44334/api/Blog/" + id.Value;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<Blog>(apiResponse);
                }
            }


            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CreatedBy,CreatedAt")] Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(blog);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    var url = "https://localhost:44334/api/Blog/" + blog.Id;
                    using var client = new HttpClient();

                    var response = await client.PutAsync(url, data);
                    string result = response.Content.ReadAsStringAsync().Result;




                }
                catch (Exception ex)
                {
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog blog = null;

            string url = "https://localhost:44334/api/Blog/" + id.Value;
            using (HttpClient httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    blog = JsonConvert.DeserializeObject<Blog>(apiResponse);
                }
            }

            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var url = "https://localhost:44334/api/Blog/" + id;
            using var client = new HttpClient();

            var response = await client.DeleteAsync(url);

            string result = response.Content.ReadAsStringAsync().Result;

            return RedirectToAction(nameof(Index));
        }
    }
}
