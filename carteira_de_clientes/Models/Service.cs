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

    public Service(int id, string name, string price)
    {
      this.Id = id;
      this.Name = name;
      this.Price = price;
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
  }
}