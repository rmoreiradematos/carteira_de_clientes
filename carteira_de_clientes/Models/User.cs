using Repository;

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
            if (obj == null)
            {
                return false;
            }
            if (obj == this)
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            ServiceOrder serviceOrder = (ServiceOrder)obj;
            return this.Id == serviceOrder.Id;
        }

        public static List<ServiceOrder> ListarServicoOrdens()
        {
            Database db = new Database();
            return db.ServiceOrders.ToList();
        }

        public static ServiceOrder BuscarServicoOrdem(int id)
        {
            Database db = new Database();
            try
            {
                ServiceOrder serviceOrder = (from p in db.ServiceOrders
                                            where p.Id == id
                                            select p).First();
                return serviceOrder;
            }
            catch (Exception)
            {
                throw new Exception("Ordem de serviço não encontrada");
            }
        }

        public static void ExcluirServicoOrdem(int id)
        {
            Database db = new Database();

            ServiceOrder serviceOrder = BuscarServicoOrdem(id);

            db.ServiceOrders.Remove(serviceOrder);
            db.SaveChanges();
        }

        public static void EditarServicoOrdem(int id, bool done, int userId, int serviceId)
        {
            Database db = new Database();
            ServiceOrder serviceOrder = BuscarServicoOrdem(id);
            serviceOrder.Done = done;
            serviceOrder.UserId = userId;
            serviceOrder.ServiceId = serviceId;
            db.SaveChanges();
        }
    }
}