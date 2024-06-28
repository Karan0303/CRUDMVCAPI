using CRUDMVCAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace CRUDMVCAPI.Controllers
{
    public class StudentController : Controller
    {
        private string url = "https://localhost:7295/api/StudentAPI/";
        private HttpClient client = new HttpClient();
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage responce = client.GetAsync(url).Result;
            if (responce.IsSuccessStatusCode)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data= JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data,Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PostAsync(url,content).Result;
            if (responce.IsSuccessStatusCode)
            {
                TempData["Insert Message"] = "Student Added..";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            Student std = new Student();
            HttpResponseMessage responce = client.GetAsync(url + id).Result;

            if (responce.IsSuccessStatusCode)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }

            return View(std);
        }
        [HttpPost]
        public IActionResult Edit(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responce = client.PutAsync(url + std.id, content).Result;
            if (responce.IsSuccessStatusCode)
            {
                TempData["Update Message"] = "Student Updated..";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            Student std = new Student();
            HttpResponseMessage responce = client.GetAsync(url + id).Result;

            if (responce.IsSuccessStatusCode)
            {
                string result = responce.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    std = data;
                }
            }

            return View(std);
        }
    }
}

//hii hello this is test message for git 123
