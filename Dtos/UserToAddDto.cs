namespace DotnetAPI.Dtos
{

    public partial class UserToAddDto
    {
        //public int UserId {get; set;}     // We dont need UserId because it will be generated automatically
        public string FirstName {get; set;} = "";
        public string LastName {get; set;} = "";
        public string Email {get; set;} = "";
        public string Gender {get; set;} = "";
        public bool Active {get; set;}


    }

















}