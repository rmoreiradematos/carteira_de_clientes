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

    public Contract(int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract)
    {
      this.ClientId = clientId;
      this.UserId = userId;
      this.ServiceId = serviceId;
      this.DateLimit = dateLimit;
      this.DateDone = dateDone;
      this.DateContract = dateContract;
      Database db = new Database();
      db.Contratos.Add(this);
      db.SaveChanges();
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

    public static List<Contract> ListarContratos()
    {
      Database db = new Database();
      return db.Contratos.Include("Contratos").ToList();  
    }

    public static Contract BuscarContrato(int id)
    {
      Database db = new Database();

      Contract contract = BuscarContract(id);
      db.Contract.Remove(contract);
      db.SaveChanges();
    }

    public static void ExcluirContrato(int id)
    {
      Database db = new Database();
      Contract contract = BuscarContract(id);
      db.Contract.Remove(contract);
      db.SaveChanges();
    }

    public static void EditarContrato(int id, int clientId, int userId, int serviceId, string dateLimit, string dateDone, string dateContract)
    {
      Database db = new Database();
      Contract contract = BuscarContract(id);
      contract.ClientId = clientId;
      contract.UserId = userId;
      contract.ServiceId = serviceId;
      contract.DateLimit = dateLimit;
      contract.DateDone = dateDone;
      contract.DateContract = dateContract;
      db.SaveChanges();
    }
  }

}