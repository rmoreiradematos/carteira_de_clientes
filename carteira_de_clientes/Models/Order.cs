namespace Models
{
  public class Order
  {
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int ServiceId { get; set; }

    public Order()
    {
    }

    public Order(int clientId, int serviceId)
    {
      this.ClientId = clientId;
      this.ServiceId = serviceId;
      Database db = new Database();
      db.Orders.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"Id: {Id}, ClientId: {ClientId}, ServiceId: {ServiceId}";
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
      Order order = (Order) obj;
      return this.Id == order.Id;
    }

    public static List<Order> ListarOrders()
    {
      Database db = new Database();
      return db.Orders.Include("Orders").ToList();  
    }

    public static Order BuscarOrder(int id)
    {
      Database db = new Database();

      Order order = BuscarOrder(id);

      return order;
    }

    public static void ExcluirOrder(int id)
    {
      Database db = new Database();
      Order order = db.Orders.Find(id);
      db.Orders.Remove(order);
      db.SaveChanges();
    }

    public static void EditarOrder(int id, int clientId, int serviceId)
    {
      Database db = new Database();
      Order order = db.Orders.Find(id);
      order.ClientId = clientId;
      order.ServiceId = serviceId;
      db.SaveChanges();
    }
  }
}