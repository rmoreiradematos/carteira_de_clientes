namespace Models
{
  public class ServiceOrder
  {
    public int Id { get; set; }
    public bool Done { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }

    public ServiceOrder()
    {
    }

    public ServiceOrder(int id, bool done, int userId, int serviceId)
    {
      this.Id = id;
      this.Done = done;
      this.UserId = userId;
      this.ServiceId = serviceId;
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

  }
}