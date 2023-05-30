namespace carteira_de_clientes
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



    }
}