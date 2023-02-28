using PaymentLogInterfce.API.Models.Domain;

namespace PaymentLogInterfce.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        //private readonly IUserRepository userRepository;

        private List<User> Users = new List<User>()
        {
            new User()
            {
                Id = Guid.NewGuid(),
                OwnerId= "L481301",
                FirstName= "Read Only",
                LastName= "User",
                Email= "readonly@user.com",
                MobileNo= "9903449477",
                UserName= "readonly@user.com",
                Password="Readonly@user",
                Roles=new List<string>{ "reader" },
                IsDeleted="N"

            },

            new User()
            {
                Id = Guid.NewGuid(),
                OwnerId= "L481302",
                FirstName= "Read Write",
                LastName= "User",
                Email= "readonlywrite@user.com",
                MobileNo= "9831654470",
                UserName= "readwrite@user.com",
                Password="Readwrite@user",
                Roles=new List<string>{ "reader", "write" },
                IsDeleted="N"

            }



        };

        //public UserRepository(IUserRepository userRepository)
        //{
        //    this.userRepository = userRepository;
        //}
        public async Task<User> AuthenticateAsync(string username, string password)
        {
            //return await this.userRepository.AuthenticateAsync(username, password);

            var user = Users.Find(x=> x.UserName.Equals(username,StringComparison.InvariantCultureIgnoreCase) && x.Password==password);

            return user;

        }


    }
}
