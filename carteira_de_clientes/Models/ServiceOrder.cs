namespace Models
{
  public class ServiceOrder
  {
    public bool Done { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public ServiceOrder()
    {
    }

    public ServiceOrder(bool done, int userId, int serviceId)
    {
      this.Done = done;
      this.UserId = userId;
      this.ServiceId = serviceId;
      Database db = new Database();
      db.ServiceOrders.Add(this);
      db.SaveChanges();
    }

    public override string ToString()
    {
      return $"Id: {Id}, Done: {Done}, UserId: {UserId}, ServiceId: {ServiceId}";
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
      ServiceOrder serviceOrder = (ServiceOrder) obj;
      return this.Id == serviceOrder.Id;
    }

    public static List<ServiceOrder> ListarServiceOrders()
    {
      Database db = new Database();
      return db.ServiceOrders.Include("ServiceOrders").ToList();  
    }

    public static ServiceOrder BuscarServiceOrder(int id)
    {
      Database db = new Database();

      ServiceOrder serviceOrder = BuscarServiceOrder(id);

      return serviceOrder;
    }

    public static void ExcluirServiceOrder(int id)
    {
      Database db = new Database();

      ServiceOrder serviceOrder = BuscarServiceOrder(id);

      db.ServiceOrders.Remove(serviceOrder);
      db.SaveChanges();
    }

    public static void EditarServiceOrder(int id, bool done, int userId, int serviceId)
    {
      Database db = new Database();

      ServiceOrder serviceOrder = BuscarServiceOrder(id);

      serviceOrder.Done = done;
      serviceOrder.UserId = userId;
      serviceOrder.ServiceId = serviceId;

      db.SaveChanges();
    }

  }
}