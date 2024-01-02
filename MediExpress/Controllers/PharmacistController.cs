using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MediExpress.Controllers
{
    public class PharmacistController : ApiController
    {
        //pharmaacist checking all customers
        [HttpGet]
        [Route("api/Customers")]
        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }

        }
        //pharmaacist checking customers individually
        [HttpGet]
        [Route("api/customers/{uname}")]
        public HttpResponseMessage Get(string uname)
        {
            try
            {
                var data = CustomerService.Get(uname);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        //Get Customer with Adresses
        [HttpGet]
        [Route("api/customers/{uname}/address")]
        public HttpResponseMessage CustomerWithAddress(string uname)
        {
            try
            {
                var data = CustomerService.GetWithAddress(uname);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        //Get Customer with Orders
        [HttpGet]
        [Route("api/customers/{uname}/orders")]
        public HttpResponseMessage CustomerWithOrders(string uname)
        {
            try
            {
                var data = CustomerService.GetOrderInfo(uname);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

    }
}
