using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebApplication2.Models;
using WebApplication2.ServiceDB;
using Gma.QrCodeNet;
using MessagingToolkit.QRCode;
using System.Web;

namespace WebApplication2.Controllers
{

    [RoutePrefix("api/server")]
    
    public class ServerAPIController : ApiController
    {
        private systemdbEntities db = new systemdbEntities();
        private ServiceDB.Service Service = new ServiceDB.Service(); 



    

        //[Authorize(Roles ="Manager")]
        [HttpPost]
        [Route("createQRCode")]
        public bool createQRcode(string idStore, string idPromotio)
        {
            return true;
        }

        /// <summary>
        /// return ticket when client scan qrCode
        /// </summary>
        /// <param name="idStore"></param>
        /// <param name="idPromotion"></param>
        /// <param name="idClient"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [Route("GetTicket")]
        public clientTicket getTicket(string idStore, String idPromotion, string idClient)
        {
            try
            {
                return Service.getTicket(idStore, idPromotion, idClient);

            }

            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
            }
        }

        [HttpGet]
        [Authorize]
        [Route("getIdClient")]
        public int getid(string username, string password)
        {
            try
            {
                return Service.getIdClient(username, password);

            }

            catch (Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getReward")]
        public ICollection<MerchantReward> getReward()
        {
            List<MerchantReward> result = new List<MerchantReward>();
            try
                {
                result = Service.getlistReward();
                return result;
                
            }
            
            catch(Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
            }
            
        }

    
        [Authorize]
        [HttpGet]
        [Route("getLogin")]
        public bool getLogin(string UserName, string PassWord)
        {
            string username = UserName, password = PassWord;

            var q = (from e in db.accounts
                     where e.UserName == username && e.Password == password
                     select
                     new
                     {
                         name = e.UserName,
                         pass = e.Password
                     }).ToList();
            if (q.Count == 0)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid database"));
            else throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Created, true));
        }
 
        [HttpGet]
        [Route("getListPromotion")]

        public List<dbPromotion> getListPromotion(string id)
        {
            //try
            //{
                
                return Service.getListPromotion(id);
           // }

           //catch(Exception e)
           // {
           //     throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
           // }
        }

        [Authorize]
        [HttpGet]
        [Route("getLoginClient")]
        
         public bool getLoginClient(string UserName, string PassWord)
        {
            string username = UserName, password = PassWord;
            try
            {
                var q = (from e in db.accounts
                         where e.UserName == username && e.Password == password
                         select
                         new
                         {
                             name = e.UserName,
                             pass = e.Password
                         }).ToList();
                if (q.Count == 0)
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Created, false));
                else throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Created, true));
            }
            catch(Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
            }
        }

        [HttpGet]
        [Route("getacctype")]
        public int getacctype(string _userName, string _passWord)
        {
            try
            {
                return Service.getTypeAcc(_userName, _passWord);
                //HttpContext.Current.Server.MapPath
            }
            catch(Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));
            }
        }

        [HttpGet]
        [Route("getIdStore")]

        public int getidStore(string _userName, string _passWord)
        {
            try 
            {
                return Service.getIdStore(_userName, _passWord);
            }
            catch(Exception e)
            {

                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));

            }
        }

        [HttpGet]
        [Route("getliststore")]
        public List<dbStore> list()
        {
            try
            {
                return Service.getListStore();
            }
            catch(Exception e)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest, e.ToString()));

            }
        }

        [HttpGet]
        [Route("acc")]
        public bool accws(string userName, string password)
        {
            return true;
        }
    }
}
