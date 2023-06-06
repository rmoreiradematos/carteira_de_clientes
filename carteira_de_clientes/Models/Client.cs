namespace Models
{
 
  public class Client
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string phone { get; set; }

    public Client()
    {
    }

    public Client(string name, string address, string phone)
    {
      this.Name = name;
      this.Address = address;
      this.phone = phone;
      Database db = new Database();
      db.Clients.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"Id: {Id}, Name: {Name}, Address: {Address}, phone: {phone}";
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
      Client client = (Client) obj;
      return this.Id == client.Id;
    }

    public static List<Client> ListarClientes()
    {
      Database db = new Database();
      return db.Perfis.Include("Clients").ToList();  
    }

    public static Client BuscarCliente(int id)
    {
      Database db = new Database();

      Client client = BuscarClient(id);
      db.Client.Remove(perfil);
      db.SaveChanges();
    }

    public static Client BuscarClient(int id) 
    {
      Database db = new Database();
      try
      {
        Client client = (from p in db.Clients
                          where p.Id == id
                          select p).First();
        return client;
      }
      catch (Exception)
      {
          throw new Exception("Cliente não encontrado");
      }
    }

    public static void ExcluirCliente(int id)
    {
      Database db = new Database();

      Client client = BuscarClient(id);
      db.Client.Remove(client);
      db.SaveChanges();
    }

    public static void EditarCliente(int id, string name, string address, string phone)
    {
      Database db = new Database();

      Client client = BuscarClient(id);
      client.Name = name;
      client.Address = address;
      client.phone = phone;
      db.SaveChanges();
    }
  }
   
}