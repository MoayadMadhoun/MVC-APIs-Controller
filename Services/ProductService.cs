using Microsoft.EntityFrameworkCore;
using MVCAPIs_Controller.Data;
using MVCAPIs_Controller.Model;

namespace MVCAPIs_Controller.Services
{
    public class ProductService
    {
        private readonly ApplicationDb _dbcontext;

        public ProductService(ApplicationDb dbcontext)
        {
            _dbcontext = dbcontext;
        }





        public async Task<List<Product>> GetProducts()
        {

            try
            {
                return await _dbcontext.tblProducts.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public async Task<Product?> GetProductById(int id, bool includeCategory = false)
        {
            try
            {
                if (includeCategory)
                    return await _dbcontext.tblProducts.AsNoTracking().Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
                else
                    return await _dbcontext.tblProducts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task<List<Product>> GetProductByCatId(int categoryId, bool includeCategory = false)
        {
            try
            {
                if (includeCategory)
                    return await _dbcontext.tblProducts.AsNoTracking().Include(p => p.Category).Where(p => p.CategoryId == categoryId).ToListAsync();
                else
                    return await _dbcontext.tblProducts.AsNoTracking().Where(p => p.CategoryId == categoryId).ToListAsync();

            }
            catch (Exception ex)
            {

                return null;
            }
        }


        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                //await _dbcontext.tblProducts.AddAsync(product);

                _dbcontext.Entry(product).State = EntityState.Added;

                await _dbcontext.SaveChangesAsync();
                return product;
            }
            catch (Exception ex)
            {

                return null;
            }



        }



        public async Task<Product> UpdateProduct(Product product)
        {

            try
            {
                _dbcontext.Entry(product).State = EntityState.Modified;


                await _dbcontext.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                return null;

            }

        }


        public async Task<(bool, string)> DeleteProduct(Product product)
        {
            try
            {
                var prod = await _dbcontext.tblProducts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == product.Id);

                if (prod == null)
                    return (false, "The Product could not be deleted.");

                else
                    _dbcontext.Remove(prod);
                await _dbcontext.SaveChangesAsync();

                return (true, "Product is deleted .");
            }
            catch (Exception ex)
            {

                return (false, $"An Error accured , Error Message {ex.Message}");
            }
        }

    }
}
