using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankTransactionWebAPIProject.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace BankTransactionWebAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SBTransactionsController : ControllerBase
    {
        private readonly BankTransactionContext _context;
        

        public SBTransactionsController(BankTransactionContext context)
        {
            _context = context;
        }

        // GET: api/SBTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SBTransaction>>> GetSBTransactions()
        {
            return await _context.SBTransactions.ToListAsync();
        }

        // GET: api/SBTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SBTransaction>> GetSBTransaction(int id)
        {
            var sBTransaction = await _context.SBTransactions.FindAsync(id);

            if (sBTransaction == null)
            {
                return NotFound();
            }

            return sBTransaction;
        }

        // PUT: api/SBTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSBTransaction(int id, SBTransaction sBTransaction)
        {
            if (id != sBTransaction.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(sBTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SBTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SBTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SBTransaction>> PostSBTransaction(SBTransaction sBTransaction)
        {
            _context.SBTransactions.Add(sBTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSBTransaction", new { id = sBTransaction.TransactionId }, sBTransaction);
        }

        // DELETE: api/SBTransactions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSBTransaction(int id)
        {
            var sBTransaction = await _context.SBTransactions.FindAsync(id);
            if (sBTransaction == null)
            {
                return NotFound();
            }

            _context.SBTransactions.Remove(sBTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("SBAccounts")]
        public async Task<ActionResult<List<SBAccount>>> GetSBAccounts()
        {
            string Baseurl = "http://localhost:1517/";
            var BankInfo = new List<SBAccount>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/SBAccounts");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BankResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    BankInfo = JsonConvert.DeserializeObject<List<SBAccount>>(BankResponse);

                }
                //returning the employee list to view  
                return BankInfo;
            }
        }
        [HttpGet]
        [Route("SBAccounts/{id}")]
        public async Task<ActionResult<SBAccount>> GetSBAccountsById(int id)
        {
            var sBAccount = new SBAccount();
            //var sBAccount=new SBAccount().ToString();
            using (var httpClient = new HttpClient())
            {
                //Define request data format  
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (HttpResponseMessage response = await httpClient.GetAsync("http://localhost:1517/api/SBAccounts/" + id))
                {
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    sBAccount = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return sBAccount;
        }
        [HttpPost]
        [Route("SBAccounts")]
        public async Task<ActionResult<SBAccount>> AddAccount(SBAccount sBAccount)
        {
            var obj = new SBAccount();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(sBAccount), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:1517/api/SBAccounts/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return obj;
        }

        [HttpPut]
        [Route("SBAccounts/{id}")]
        public async Task<ActionResult<SBAccount>> Edit(int id,SBAccount sBAccount)
        {
            //int Acc = Convert.ToInt32(TempData["AccID"]);
            //sBAccount.AccountNumber = Acc;
            var obj = new SBAccount();
            StringContent content1 = new StringContent(JsonConvert.SerializeObject(sBAccount), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsync("http://localhost:1517/api/SBAccounts/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<SBAccount>(apiResponse);
                }
            }
            return obj;
        }
        [HttpDelete]
        [Route("SBAccounts/{id}")]
        public async Task<ActionResult<SBAccount>> Delete(int id,SBAccount sBAccount)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:1517/api/SBAccounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return NoContent();
        }
        private bool SBTransactionExists(int id)
        {
            return _context.SBTransactions.Any(e => e.TransactionId == id);
        }
    }
}
