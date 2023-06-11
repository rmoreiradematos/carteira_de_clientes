using Repository;

namespace Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }

        public Service()
        {
        }

        public Service(string name, string price)
        {
            this.Name = name;
            this.Price = price;
            Database db = new Database();
            db.Services.Add(this);
            db.SaveChanges();
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}";
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
            Service service = (Service)obj;
            return this.Id == service.Id;
        }

        public static List<Service> ListarServicos()
        {
            Database db = new Database();
            return db.Services.ToList();
        }

        public static Service BuscarServico(int id)
        {

            Database db = new Database();
            try
            {
                Service service = (from p in db.Services
                                   where p.Id == id
                                   select p).First();
                return service;
            }
            catch (Exception)
            {
                throw new Exception("Serviço não encontrado");
            }
        }

        public static void ExcluirServico(int id)
        {
            Database db = new Database();
            Service service = BuscarServico(id);
            db.Services.Remove(service);
            db.SaveChanges();
        }

        public static void EditarService(int id, string name, string price)
        {
            Database db = new Database();
            Service service = BuscarServico(id);
            service.Name = name;
            service.Price = price;
            db.SaveChanges();
        }
    }
}