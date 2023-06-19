using Repository;


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

        public static List<User> ListarUsuarios()
        {
            Database db = new Database();
            return db.Users.ToList();
        }

        public static User BuscarUsuario(int id)
        {
            Database db = new Database();
            try
            {
                User user = (from p in db.Users
                                            where p.Id == id
                                            select p).First();
                return user;
            }
            catch (Exception)
            {
                throw new Exception("Usuario não encontrado");
            }
        }

        public static void ExcluirUsuario(int id)
        {
            Database db = new Database();

            User user = BuscarUsuario(id);

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public static void EditarUsuario(int id, string name, string password, UserType role)
        {
            Database db = new Database();
            User user = BuscarUsuario(id);
            user.Name = name;
            user.Password = password;
            user.Role = role;
            db.SaveChanges();
        }
    }
}