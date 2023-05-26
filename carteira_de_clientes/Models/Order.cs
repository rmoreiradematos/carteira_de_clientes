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

    public Order(int id, int clientId, int serviceId)
    {
      this.Id = id;
      this.ClientId = clientId;
      this.ServiceId = serviceId;
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
  }
}