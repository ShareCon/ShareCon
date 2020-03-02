using System;
using System.Collections.Generic;
using System.Text;
using HelloWord.UserServices;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Management;
using Xamarin.Forms;
using System.Threading.Tasks;


namespace HelloWord.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Users> _userList;
        private Users _selectedUsers = new Users();
        

        // public List<Users> UserList { get => userList; set => userList = value; }

            //below code can be used
        public List<Users> UserList
        {
            get { return _userList; }
            set 
            { 
                 _userList = value;
                 OnPropertyChanged();
            }
        }

        
        public Users selectedUsers
        {
            get { return _selectedUsers; }
            set
            {
                _selectedUsers = value;
                OnPropertyChanged();
            }
        }
        // public Users selectedUsers { get => selectedUsers; set => selectedUsers = value; }



        public async Task MainViewModels()
        {
            var userservice = new UserServices.UserServices();
            UserList =await userservice.GetUsersAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Command PostCommand
        {
            get 
            {
                return new Command(async() => 
                {
                    var userservices =new  UserServices.UserServices();
                     await userservices.PostUserAsyncs(_selectedUsers);

                });
            }
        }


        //public Users GetUseID(int)
        //{
        //    var UserID = new UserServices.UserServices();
        //    return UserID.GetUserIDAsync()

        //}

        public Command PutCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var userservices = new UserServices.UserServices();
                    await userservices.PutUserAsync(_selectedUsers.ID,_selectedUsers);

                });
            }
        }
    }
}
