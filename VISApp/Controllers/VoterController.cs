using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace VISApp.Controllers
{
    public class VoterController : Controller
    {
        VoterRepository voterRepository = new VoterRepository();
        // GET: Voter
        [HttpGet]
        public ActionResult Index()
        {
            //if (Session["EmailId"] == null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            List<DataAccess.Voter> entityVoter = voterRepository.GetVoterList();
            List<Models.Voter> voters = new List<Models.Voter>();
            foreach(var ev in entityVoter)
            {
                Models.Voter temp = new Models.Voter();

                temp.VoterId = ev.VoterId;
                temp.VoterName = ev.VoterName;
                temp.Age = ev.Age;
                temp.DOB = ev.DOB;
                temp.Gender = ev.Gender;
                temp.City = ev.City;
                temp.State = ev.State;
                temp.EmailId = ev.EmailId;
                temp.MobileNumber = ev.MobileNumber;

                voters.Add(temp);
            }
            return View(voters);
        }

        public ActionResult Create()
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.Voter voter)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                DataAccess.Voter voterInfo = new DataAccess.Voter()
                {
                    VoterName = voter.VoterName,
                    Age = voter.Age,
                    DOB = voter.DOB,
                    Gender = voter.Gender,
                    City = voter.City,
                    State=voter.State,
                    EmailId=voter.EmailId,
                    MobileNumber=voter.MobileNumber
                };
                bool result = voterRepository.AddVoter(voterInfo);

                if (!result)
                {
                    return View("error");
                }
            }
            return View(voter);
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var businessEntity = voterRepository.FindbyPK(Id);
            Models.Voter voter = new Models.Voter()
            {
                VoterId = businessEntity.VoterId,
                VoterName = businessEntity.VoterName,
                Age = businessEntity.Age,
                DOB = businessEntity.DOB,
                Gender = businessEntity.Gender,
                City = businessEntity.City,
                State = businessEntity.State,
                EmailId = businessEntity.EmailId,
                MobileNumber = businessEntity.MobileNumber
            };
            return View(voter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.Voter voter)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            
            DataAccess.Voter voterInfo = new DataAccess.Voter()
            {
                VoterId = voter.VoterId,
                VoterName = voter.VoterName,
                Age = voter.Age,
                DOB = voter.DOB,
                Gender = voter.Gender,
                City = voter.City,
                State = voter.State,
                EmailId = voter.EmailId,
                MobileNumber = voter.MobileNumber
            };

            bool result = voterRepository.UpdateVoter(voterInfo);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            
            var businessEntity = voterRepository.FindbyPK(Id);
            Models.Voter voter = new Models.Voter()
            {
                VoterId = businessEntity.VoterId,
                VoterName = businessEntity.VoterName,
                Age = businessEntity.Age,
                DOB = businessEntity.DOB,
                Gender = businessEntity.Gender,
                City = businessEntity.City,
                State = businessEntity.State,
                EmailId = businessEntity.EmailId,
                MobileNumber = businessEntity.MobileNumber
            };
            return View(voter);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConformed(int id)
        {
            if (Session["EmailId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            
            bool result = voterRepository.DeleteVoterId(id);
            if (!result)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}