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

    public Client(int id, string name, string address, string phone)
    {
      this.Id = id;
      this.Name = name;
      this.Address = address;
      this.phone = phone;
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
    
  }
   
}