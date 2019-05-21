using System.Collections.Generic;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        public List<UserModel> allModeList = new List<UserModel>() {
          new UserModel(){ Id=1,UserName="zhang", PassWord="123"},
          new UserModel(){ Id=2,UserName="lishi", PassWord="123456"},
          new UserModel(){ Id=3,UserName="wang", PassWord="1234567"}
        };

        //Get  api/User/ 
        public IEnumerable<UserModel> GetAll()
        {
            return allModeList;
        }

        //Get api/User/1  
        public IEnumerable<UserModel> GetOne(int id)
        {
            return allModeList.FindAll((m) => { return m.Id == id; });
        }
        

        //POST api/User/  
        public bool PostNew(UserModel user)
        {
            try
            {
                allModeList.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Delete api/User/ 
        public int DeleteAll()
        {
            return allModeList.RemoveAll((mode) => { return true; });
        }
        //Delete api/User/1 
        public IEnumerable<UserModel> DeleteOne(int id)
        {
             allModeList.RemoveAll((m) => { return m.Id == id; });
            return allModeList;
        }
        //Put api/User  
        public int PutOne(int id, UserModel user)
        {
            List<UserModel> upDataList = allModeList.FindAll((mode) => { return mode.Id == id; });
            foreach (var mode in upDataList)
            {
                mode.PassWord = user.PassWord;
                mode.UserName = user.UserName;
            }
            return upDataList.Count;
        }
    }
}
