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
    public class BankingController : Controller
    {
        private ILogger<BankingController> _logger;
        private SBTransaction obj;

        public BankingController(ILogger<BankingController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }
        [HttpGet]
        // GET: BankingController
        public IActionResult Login(int ID)
        {
            try
            {
                if (ID != 0)
                {
                    SBAccount sBAccount = new SBAccount();
                    sBAccount.AccountNumber = ID;
                    return View(sBAccount);
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(SBAccount sBAccount)
        {
            try
            {
                int id = sBAccount.AccountNumber;
                return RedirectToAction("Details", "Customer", new { ID = id });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        // GET: BankingController/Details/5
        public async Task<ActionResult> TransactionById(int ID)
        {
            try
            {
                SBTransaction sBTransaction = new SBTransaction();
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("http://localhost:61931/api/SBTransactions/" + ID))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sBTransaction = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                    }
                }
                return View(sBTransaction);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Transactions(int id)
        {
            try
            {
                string Baseurl = "http://localhost:61931/";
                List<SBTransaction> BankInfo = new List<SBTransaction>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("api/SBTransactions");
                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var BankResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        BankInfo = JsonConvert.DeserializeObject<List<SBTransaction>>(BankResponse);
                    }
                    List<SBTransaction> sBTransactions = new List<SBTransaction>();
                    foreach (var item in BankInfo)
                    {
                        if (item.Account_Number == id)
                        {
                            sBTransactions.Add(item);
                        }
                    }
                    //returning the employee list to view  
                    return View(sBTransactions);
                }
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }
        // GET: BankingController/Create
        public async Task<ActionResult> AddTransaction(int id)
        {
            try
            {
                TempData["AccNo"] = id;
                SBTransaction sBTransaction = new SBTransaction();
                sBTransaction.Account_Number = id;
                return View(sBTransaction);
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // POST: BankingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddTransaction(SBTransaction sBTransaction)
        {
            try
            {
                var objSBA = new SBAccount();
                SBAccount sBAccount = new SBAccount();
                sBTransaction.Account_Number = (int)TempData.Peek("AccNo");
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(sBTransaction), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("http://localhost:61931/api/SBTransactions/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<SBTransaction>(apiResponse);
                    }
                    using (var response = await httpClient.GetAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + obj.Account_Number))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        sBAccount = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                    if (obj.TransactionType == "Deposit")
                    {
                        sBAccount.CurrentBalance += (float)obj.Amount;
                    }
                    else if (obj.TransactionType == "Withdraw")
                    {
                        sBAccount.CurrentBalance -= (float)obj.Amount;
                    }
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(sBAccount), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync("http://localhost:61931/api/SBTransactions/SBAccounts/" + obj.Account_Number, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        objSBA = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                    }
                }
                int id = obj.TransactionId;
                return RedirectToAction("TransactionById", "Banking", new { ID = id });
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return View();
        }

        // GET: BankingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BankingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        
        // POST: BankingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
