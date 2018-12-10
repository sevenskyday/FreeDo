using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileupload.Models
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Get(string key);
        Contact Remove(string key);
        void Update(Contact contact);
    }
}
