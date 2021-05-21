using BankWebAPIMVCProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BankWebAPIMVCProject.Controllers
{
    public class CustomerController : Controller
    {
        private ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            try
            {
                string Baseurl = "http://localhost:61931/";
                var BankInfo = new List<SBAccount>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/SBTransactions/SBAccounts");
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var BankResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        BankInfo = JsonConvert.DeserializeObject<List<SBAccount>>(BankResponse);

                    }
                    //returning the employee list to view  
                    return View(BankInfo);
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // GET: CustomerController/Details/5
        public async Task<ActionResult> Details(int ID)
        {
            try
            {
                SBAccount sBAccount = new SBAccount();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + ID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sBAccount = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                return View(sBAccount);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SBAccount sBAccount)
        {
            try
            {
                var obj = new SBAccount();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(sBAccount), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:61931/api/SBTransactions/SBAccounts/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                int id = obj.AccountNumber;
                return RedirectToAction("Login", "Banking", new { ID = id });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                TempData["AccID"] = id;
                SBAccount sBAccount = new SBAccount();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sBAccount = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                return View(sBAccount);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SBAccount sBAccount)
        {
            try
            {
                int Acc = Convert.ToInt32(TempData["AccID"]);
                sBAccount.AccountNumber = Acc;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(sBAccount), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PutAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + Acc, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                return RedirectToAction("Details", new { ID = Acc });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // GET: CustomerController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                TempData["AccID"] = id;
                SBAccount sBAccount = new SBAccount();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + id))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sBAccount = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                return View(sBAccount);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SBAccount sBAccount)
        {
            try
            {
                int AccId = Convert.ToInt32(TempData["AccID"]);
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + AccId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
    }
}
