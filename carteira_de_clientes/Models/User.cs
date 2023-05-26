namespace Models
{

    public enum UserType
    {
        Commom = 0,
        Admin = 1
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Role { get; set; }

        public User()
        {
        }
        public User(int id, string name, string password, UserType role)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.Role = role;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Password: {Password}, Role: {Role}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            User user = (User)obj;
            return this.Id == user.Id;
        }
    }
}