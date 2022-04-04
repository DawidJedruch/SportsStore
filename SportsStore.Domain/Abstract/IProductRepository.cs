using SportsStore.Domain.Entities;
using System.Collections.Generic;

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
