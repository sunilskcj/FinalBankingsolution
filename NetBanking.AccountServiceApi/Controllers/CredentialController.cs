using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetBanking.BusinessModels;
using NetBanking.DataAccessLayer.Repository.Abstraction;

namespace NetBanking.AccountServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : ControllerBase
    {
        private ICredentialsDaoImpl credentialsDao;

        public CredentialController(ICredentialsDaoImpl credentialsDao)
        {
            this.credentialsDao = credentialsDao;
        }

        [HttpGet]
        public IActionResult GetAllAccountDetails()
        {

            var fetchedData = credentialsDao.FetchAllAccountCredential();
            return this.Ok(fetchedData);
        }


        [HttpPost]
        [Route("{id}")]
        public IActionResult AddProduct(int id)
        {

            var result = credentialsDao.InsertAccountCredential(id);
            return this.CreatedAtAction(
                "AddProduct",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    
                });
        }
    }
}
