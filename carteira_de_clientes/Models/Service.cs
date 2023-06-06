namespace Models
{
  public class Service
  {
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
      if (obj == null) {
        return false;
      }
      if (obj == this) {
        return true;
      }
      if (obj.GetType() != this.GetType()) {
        return false;
      }
      Service service = (Service) obj;
      return this.Id == service.Id;
    }

    public static List<Service> ListarServices()
    {
      Database db = new Database();
      return db.Services.Include("Services").ToList();  
    }

    public static Service BuscarService(int id)
    {
      Database db = new Database();

      Service service = BuscarService(id);

      return service;

    }

    public static void ExcluirService(int id)
    {
      Database db = new Database();
      Service service = db.Services.Find(id);
      db.Services.Remove(service);
      db.SaveChanges();
    }

    public static void EditarService(int id, string name, string price)
    {
      Database db = new Database();
      Service service = db.Services.Find(id);
      service.Name = name;
      service.Price = price;
      db.SaveChanges();
    }
  }
}