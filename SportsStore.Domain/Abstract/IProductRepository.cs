using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    // Klasa używająca interfejsu IProductRepository może uzyskać obiekty Product bez potrzeby znajomości jakichkolwiek szczegółów ich pochodzenia czy sposobu dostarczenia
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productId);
    }
}
