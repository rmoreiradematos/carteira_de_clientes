namespace Models
{

    public enum UserType
    {
        Commom = 0,
        Admin = 1
    }
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public UserType Role { get; set; }

        public User()
        {
        }
        public User(string name, string password, UserType role)
        {
            this.Name = name;
            this.Password = password;
            this.Role = role;
            Database db = new Database();
            db.Users.Add(this);
            db.SaveChanges();
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

        public static List<User> ListarUsers()
        {
            Database db = new Database();
            return db.Users.Include("Users").ToList();
        }

        public static User BuscarUser(int id)
        {
            Database db = new Database();

            User user = BuscarUser(id);

            return user;

        }

        public static User EditarUser(int id, string name, string password, UserType role)
        {
            Database db = new Database();

            User user = BuscarUser(id);

            user.Name = name;
            user.Password = password;
            user.Role = role;

            db.SaveChanges();

            return user;
        }

        public static User ExcluirUser(int id)
        {
            Database db = new Database();

            User user = BuscarUser(id);

            db.Users.Remove(user);
            db.SaveChanges();

            return user;
        }
    }
}