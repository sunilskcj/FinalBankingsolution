using Microsoft.AspNetCore.Http;
using NetBanking.DataAccessLayer.Repository.Abstraction;
using NetBanking.BusinessModels;
using Microsoft.AspNetCore.Mvc;

namespace NetBanking.AccountServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountFieldDao _accountFieldDao;
        

        public AccountsController(IAccountFieldDao accountFieldDao)
        {
            _accountFieldDao = accountFieldDao;
        }

        [HttpGet]
        public IActionResult GetAllAccountDetails()
        {

            var fetchedData = _accountFieldDao.FetchAllAccount();
            return this.Ok(fetchedData);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult FetchAccountById(int id)
        {

            var fetchedData = _accountFieldDao.FetchAccountById(id);
            return this.Ok(fetchedData);
        }

        [HttpPost]
        public IActionResult AddProduct(AccountModel account)
        {

            var result = _accountFieldDao.InsertAccountField(account);
            return this.CreatedAtAction(
                "AddProduct",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = account
                }
                );
        }


        [HttpPut]
        [Route("{customerId}")]
        public IActionResult UpdateProduct(AccountModel account, int customerId)
        {
            var result = _accountFieldDao.UpdateAccountField(account, customerId);
           
            return this.CreatedAtAction(
                "UpdateProduct",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    
                    Data = account
                }
                ) ;
        }

        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult DeleteProduct(int customerId)
        {
            var result = _accountFieldDao.DeleteAccountFieldbyID(customerId);
            return this.CreatedAtAction(
                "DeleteProduct",
                new
                {
                    StatusCode = 201,
                    Response = result,

                }
                );
        }




 
    }

}