using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Models;


namespace WebApplication2.ServiceDB
{
    public class Service
    {
        systemdbEntities db = new systemdbEntities();

        

        public bool checkAcc(string _userName, string _passWord)
        {
            var q = (from e in db.accounts
                     where e.UserName == _userName
                     select new
                     {
                         name = e.UserName,
                         pass = e.Password
                     }).ToList();
            if (q.Count == 0)
                return false;
            else
                if (q[0].pass != _passWord)
                return false;
            return true;
        }

        public List<MerchantReward> getlistReward()
        {
            List<MerchantReward> result = new List<MerchantReward>();
            for (int i = 0; i < db.rewards.Count(); i++)
            {
                MerchantReward temp = new MerchantReward();
                
                temp.Id = db.rewards.ToList()[i].Id;
                temp.Name = db.rewards.ToList()[i].Name;
                temp.Status = db.rewards.ToList()[i].Status;
                //temp.TimeRemain = db.rewards.ToList()[i].TimeRemain;
                result.Add(temp);
            }
            return result;
        }

        public List<dbPromotion> getListPromotion(string idStore)
        {
            List<dbPromotion> result = new List<dbPromotion>();
            //List<promotion> temp = new List<promotion>();
            //temp = db.promotions.ToList().Find(idStore);
            int id = Convert.ToInt32(idStore);
            var q = (from e in db.promotions
                     where e.IdSTORE == id
                     select new
                     {
                         DateBegin = e.DateBegin,
                         DateEnd = e.DateEnd,
                         Description = e.Description,
                         Id = e.Id,
                         IdSTORE = e.IdSTORE,
                         Name = e.Name,
                         Status = e.Status,
                         idList = e.IdListReward,
                         
        }).ToList();
            for(int i = 0; i < q.Count; i++)
            {
                dbPromotion temp = new dbPromotion();
                temp.DateBegin = q[i].DateBegin;
                temp.DateEnd = q[i].DateEnd;
                temp.Description = q[i].Description;
                temp.Id = q[i].Id;
                temp.IdSTORE = q[i].IdSTORE;
                temp.Name = q[i].Name;
                temp.Status = q[i].Status;
                temp.listReward = new List<dbItemListReward>();
                int idListrw = Convert.ToInt32(q[i].idList);
                var r = (from m in db.listrewards 
                         
                         join k in db.rewards on m.IdReward equals k.Id
                         where m.IdList == idListrw
                         select new
                         {
                             name = k.Name,
                             status = k.Status,
                             chanceToGet = m.ChanceToGet,
                             chanceToRoll = m.ChanceToRoll,
                             quantity = m.Quantity,
                             
                             
                         }).ToList();
                for(int j = 0; j < r.Count; j++)
                {
                    dbItemListReward tmp = new dbItemListReward();
                    tmp.ChanceToGet = r[i].chanceToGet;
                    tmp.ChanceToRoll = r[i].chanceToRoll;
                    tmp.quantity = Convert.ToInt32(r[i].quantity);
                    tmp.Status = r[i].status;
                    
                    tmp.name = r[i].name;
                    temp.listReward.Add(tmp);
                }

                result.Add(temp);
            }
            return result;
        }

        public int getIdStore(string _userName, string _passWord)
        {
            var q = (from e in db.accounts
                     join h in db.storeaccounts on e.Id equals h.IdACCOUNT
                     where e.UserName == _userName
                     select new
                     {
                         id = h.IdSTORE
                     }).ToList();
            if (q.Count == 0)
                return -1;
            else
                return Convert.ToInt32(q[0].id);
        }

        public void createNewAccStore(storeAcc input)
        {
            account acc = new account();
            storeaccount storeAcc = new storeaccount();
            acc.AccountType = input.AccountType;
            acc.Password = input.Password;
            acc.UserName = input.UserName;
            storeAcc.Address = input.Address;
            storeAcc.Age = input.Age;
            storeAcc.Email = input.Email;
            storeAcc.Name = input.Name;
            storeAcc.Sex = input.Sex;
            db.accounts.Add(acc);
            db.SaveChanges();
            string name = acc.UserName, pass = acc.Password;
            var q = (from e in db.accounts
                     where e.UserName == name && e.Password == pass
                     select new
                     {
                         value = e.Id
                     }).ToList();
            storeAcc.IdACCOUNT = q[0].value;
            db.storeaccounts.Add(storeAcc);
            db.SaveChanges();
        }

        /// <summary>
        /// return -1: khong phai acc. return 1: Admin return 2: Merchant, return 3: Client
        /// </summary>
        /// <param name="_userName"></param>
        /// <param name="_passWord"></param>
        /// <returns></returns>
        public int getTypeAcc(string _userName, string _passWord)
        {
            var q = (from e in db.accounts
                     where e.UserName == _userName
                     select new
                     {
                         name = e.UserName,
                         pass = e.Password,
                         acctype = e.AccountType
                     }).ToList();
            if (q.Count == 0)
                return -1;
            else
            {
                if (q[0].pass != _passWord)
                    return -1;
            }
            if (q[0].acctype == "Admin")
                return 1;
            if (q[0].acctype == "Merchant")
                return 2;

            return 3;
        }

        public List<dbStore> getListStore()
        {
            List<dbStore> result = new List<dbStore>();
            var q = (from e in db.stores
                     join k in db.bussinesstypes on e.BussinessType equals k.Id
                     select new
                     {

                         id = e.Id,
                         name = e.Name,
                         mapaddress = e.MapAddress,
                         physicaladdress = e.PhysicAddress,
                         email = e.Email,
                         avatar = e.Avatar,
                         description = e.Description,
                         bussinesstype = k.Name,
                         phone = e.PhoneNumber         
                    
                    }).ToList();
            for(int i = 0; i < q.Count; i++)
            {
                dbStore temp = new dbStore();
                temp.Avatar = q[i].avatar;
                temp.bussinesstype = q[i].bussinesstype;
                temp.Description = q[i].description;
                temp.Email = q[i].email;
                temp.Id = q[i].id;
                temp.MapAddress = q[i].mapaddress;
                temp.PhysicAddress = q[i].physicaladdress;
                temp.PhoneNumber = q[i].phone;
                result.Add(temp);
            }
            return result;
        }

        public int getAccountType(string userName, string password) // return 1: Admin, return 2: client, return 3: merchant
        {
            var q = (from e in db.accounts
                     
                     where e.UserName == userName
                     select new
                     {
                         name = e.UserName,
                         pass = e.Password,
                         type = e.AccountType
                     }).ToList();
            if (q.Count == 0)
                return -1;
            else
                if (q[0].pass != password)
                return -1;
            switch(q[0].type)
            {
                case "Admin": return 1; break;
                case "Client": return 2; break;
                case "Merchant": return 3; break;
                default: return -1;
            }
            
        }


        public clientTicket getTicket(string idStore, string idPromotion, string idClient)
        {
            int _idStore = Convert.ToInt32(idStore), _idPromotion = Convert.ToInt32(idPromotion), _idClient = Convert.ToInt32(idClient);

            var q = (from e in db.promotions
                    join m in db.stores on e.IdSTORE equals m.Id
                    join k in db.listrewards on e.IdListReward equals k.IdList
                    join h in db.rewards on k.IdReward equals h.Id
                    where e.Id == _idPromotion && m.Id == _idStore
                    select new
                    {
                        name = h.Name,
                        chanceToGet = k.ChanceToGet,
                        chanceToRoll = k.ChanceToRoll,
                        status = h.Status,
                        timeRemain = k.TimeRemain,
                        idReward = h.Id,
                        promotion = e.Name,
                        reward = h.Name
                    }).ToList();
            ticket temp = new ticket();
            Random rd = new Random();
            int rollResult = rd.Next(1, 100), pos = 0;
            while(rollResult > 0)
            {
                rollResult = rollResult - (int)q[pos].chanceToRoll;
                pos++;
            }
            rollResult = rd.Next(1, 100);
            if (rollResult <= q[pos].chanceToGet)
            {
                if (q[pos].status == true)
                    temp.IsWin = true;
                else
                    temp.IsWin = false;
            }
            else
                temp.IsWin = false;
            temp.IdClientUser = _idClient;
            temp.IdPromotion = _idPromotion;
            temp.IdReWard = q[pos].idReward;
            db.tickets.Add(temp);
            db.SaveChanges();
            clientTicket client = new clientTicket();
            client.Id = _idClient;
            client.IdClientUser = idClient;
            client.IsWin = (bool)temp.IsWin;
            client.Promotion = q[pos].promotion;
            client.ReWard = q[pos].reward;
            client.Status = (bool)q[pos].status;
            return client;
        }

        public int getIdClient(string userName, string password)
        {
            var q = (from e in db.clientaccounts
                     join m in db.accounts on e.IdACCOUNT equals m.Id
                     where m.UserName == userName
                     select new
                     {
                         id = e.Id
                     }).ToList();
            if (q[0] == null)
                return -1;
            else
                return q[0].id;
        }



    }
}