using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    internal class PilotRepository : IRepository<IPilot>
    {
        private readonly List<IPilot> pilots;
        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots.AsReadOnly();

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            IPilot car = pilots.FirstOrDefault(x => x.FullName == name);
            if (car == null || car == default) return null;
            else return car;
        }

        public bool Remove(IPilot model)
        {
            return pilots.Remove(model);
        }
    }
}
