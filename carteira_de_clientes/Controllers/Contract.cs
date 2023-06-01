using System;
using System.Collections.Generic;

namespace carteira_de_clientes
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
    }

    public class ContractManager
    {
        private List<Contract> contracts;

        public ContractManager()
        {
            contracts = new List<Contract>();
        }

        // Create a new contract
        public void CreateContract(Contract contract)
        {
            contracts.Add(contract);
        }

       
        // Update a contract
        public void UpdateContract(int id, Contract updatedContract)
        {
            Contract contract = contracts.Find(c => c.Id == id);
            if (contract != null)
            {
                contract.ClientId = updatedContract.ClientId;
                contract.UserId = updatedContract.UserId;
                contract.ServiceId = updatedContract.ServiceId;
                contract.DateLimit = updatedContract.DateLimit;
                contract.DateDone = updatedContract.DateDone;
                contract.DateContract = updatedContract.DateContract;
            }
        }

        // Delete a contract
        public void DeleteContract(int id)
        {
            Contract contract = contracts.Find(c => c.Id == id);
            if (contract != null)
            {
                contracts.Remove(contract);
            }
        }
    }
}

   
