using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using APICore.Models;
using APICore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Controllers
{
    public class DivisionsController : Controller
    {
        readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:44341/api/")
        };
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LoadDivision()
        {
            IEnumerable<DivisionVM> divisionsVM = null;
            var resTask = client.GetAsync("divisions");
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<List<DivisionVM>>();
                readTask.Wait();
                divisionsVM = readTask.Result;
            }
            else
            {
                divisionsVM = Enumerable.Empty<DivisionVM>();
                ModelState.AddModelError(string.Empty, "Server Error try after sometimes.");
            }
            return Json(divisionsVM);
        }

        public JsonResult GetById(int Id)
        {
            DivisionVM divisionsVM = null;
            var resTask = client.GetAsync("divisions/" + Id);
            resTask.Wait();

            var result = resTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result).ToString();
                divisionsVM = JsonConvert.DeserializeObject<DivisionVM>(json);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Server Error.");
            }
            return Json(divisionsVM);
        }

        public JsonResult InsertAndUpdate(DivisionVM divisionsVM, int id)
        {
            var json = JsonConvert.SerializeObject(divisionsVM);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            
            if (divisionsVM.id == 0)
            {
                var result = client.PostAsync("divisions", byteContent).Result;
                return Json(result);
            }
            else if (divisionsVM.id == id)
            {
                var result = client.PutAsync("divisions/" + id, byteContent).Result;
                return Json(result);
            }

            return Json(404);
        }

        public JsonResult Delete(int id)
        {
            var result = client.DeleteAsync("divisions/" + id).Result;
            return Json(result);
        }

        //public JsonResult Insert(DivisionVM divisionsVM)
        //{
        //    var json = JsonConvert.SerializeObject(divisionsVM);
        //    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        //    var byteContent = new ByteArrayContent(buffer);
        //    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    if (divisionsVM.id == 0)
        //    {
        //        var result = client.PostAsync("divisions", byteContent).Result;
        //        return Json(result);
        //    }
        //    return Json(404);
        //}

        //public JsonResult Update(DivisionVM divisionsVM, int id)
        //{
        //    var json = JsonConvert.SerializeObject(divisionsVM);
        //    var buffer = System.Text.Encoding.UTF8.GetBytes(json);
        //    var byteContent = new ByteArrayContent(buffer);
        //    byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        //    if (divisionsVM.id == id)
        //    {
        //        var result = client.PutAsync("divisions/" + id, byteContent).Result;
        //        return Json(result);
        //    }
        //    return Json(404);
        //}


    }
}
