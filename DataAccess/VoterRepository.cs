using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess
{
    public class VoterRepository
    {
        private VISContext db;

        public  VoterRepository()
        {
            db = new VISContext();
        }
        // This record will find the record in the admin users table that match..
        public AdminUser ValidateUser(string emailid,string password)
        {
            AdminUser adminUser = null;
            try
            {
                adminUser = db.AdminUsers.Where(v => v.EmailId == emailid && v.Password == password).FirstOrDefault();

            }
            catch
            {
                adminUser = null;
            }
            return adminUser;
        }
        //This method will add new voters details
        public bool AddVoter(Voter voterInfo)
        {
            if (voterInfo == null)
            {
                return false;
            }
            try
            {
                db.Voters.Add(voterInfo);
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        //this method will find voter details by id
        public Voter FindbyPK(int voterid)
        {
            Voter voter = null;
            try
            {
                voter = db.Voters.Find(voterid);
            }
            catch
            {
                voter = null;
            }
            return voter;
        }
        //this method will update  voters details
        public bool UpdateVoter(Voter VoterInfo)
        {
            if (VoterInfo == null)
            {
                return false;
            }
            try
            {
                db.Entry(VoterInfo).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
        //This method will remove voters details
        public bool DeleteVoterId(int id)
        {
            try
            {
                Voter voter = FindbyPK(id);
                db.Voters.Remove(voter);
                db.SaveChanges();

            }
            catch
            {
                return false;
            }
            return true;
        }
        // This method will get the voter list
        public List<Voter> GetVoterList()
        {
            try
            {
                return db.Voters.ToList();
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }


        }
    }
}
