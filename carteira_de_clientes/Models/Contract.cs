namespace Models
{
  public class Contract
  {
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int UserId { get; set; }
    public int ServiceId { get; set; }
    public string DateLimit { get; set; }
    public string DateDone { get; set; }
    public string DateContract { get; set; }

    public Contract()
    {
    }

    public Contract(int id, int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract)
    {
      this.Id = id;
      this.ClientId = clientId;
      this.UserId = userId;
      this.ServiceId = serviceId;
      this.DateLimit = dateLimit;
      this.DateDone = dateDone;
      this.DateContract = dateContract;
    }

    public override string ToString()
    {
      return $"Id: {Id}, ClientId: {ClientId}, UserId: {UserId}, ServiceId: {ServiceId}, DateLimit: {DateLimit}, DateDone: {DateDone}, DateContract: {DateContract}";
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
      Contract contract = (Contract) obj;
      return this.Id == contract.Id;
    }

  }

}