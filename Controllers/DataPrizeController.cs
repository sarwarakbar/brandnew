using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Data.Entity.Validation;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class DataPrizeController : ApiController
    {
        Entities db = new Entities();
        
        //Add Post Request
        public string Post(prizenew prize1)
        {
            try 
            {                 
            db.prizenews.Add(prize1);
            db.SaveChanges();
            return "Prize Added";
            }
            catch(Exception)
            {
                return "Enter Correct credentials!";
            }
        }

        //Get Records by Category

        public IEnumerable<prizenew> GetbyCategory(string cat)
        {
            return db.prizenews.Where(x => x.category.ToLower().Contains(cat.ToLower())).ToList();
        }



        //Get Records by Year
        public IEnumerable<prizenew> GetByYear(int year)
        {
            return db.prizenews.Where(x => x.year == year).ToList();
        }



        //Get Records by Share
        public IEnumerable<prizenew> GetByShare(int share)
        {
            return db.prizenews.Where(x => x.share == share).ToList();
        }



        //Get Records by Firstname
        public IEnumerable<prizenew> GetByName(string fname)
        {
            return db.prizenews.Where(x => x.firstname.ToLower().Contains(fname.ToLower())).ToList();
        }



        //Get Records by Year & Laureates Firstname
        public IEnumerable<prizenew> GetDynamic(int year, string fname)
        {
            return db.prizenews.Where(x => x.year == year && x.firstname.ToLower().Contains(fname.ToLower())).ToList();

        }


        //Get All Records

        public IEnumerable<prizenew>Get()
        {           
           return  db.prizenews. ToList();            
        }     
        
     

        //Get Single Record
        public prizenew Get(int id, int year)
        {         
            
            prizenew prize1= db.prizenews.Find(id);        
            return prize1;                    

        }


        //Update Record

        public string Put(int id, prizenew prize1)
        {
            try { 
                var prize_ = db.prizenews.Find(id);
                prize_.year = prize1.year;
                prize_.category = prize1.category;
                prize_.id = prize1.id;
                prize_.firstname = prize1.firstname;
                prize_.surname = prize1.surname;
                prize_.motivation = prize1.motivation;
                prize_.share = prize1.share;
                prize_.overallMotivation = prize1.overallMotivation;
                prize_.LastModified = prize1.LastModified.GetValueOrDefault(DateTime.Now);
                db.Entry(prize_).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Record Updated";
            }
            catch (Exception)
            {
                return "Enter Correct credentials!";
            }
        }                

        //Delete the Record
        public string Delete(int id)
        {
            try
            { 
            prizenew prize1 = db.prizenews.Find(id);
            db.prizenews.Remove(prize1);
            db.SaveChanges();   
            return "Record Deleted";
            }

            catch(Exception)
            {
                return "Something went wrong. Please Check!";
            }
        }      
       
    }

    
}
