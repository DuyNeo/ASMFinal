

namespace asmfinal.Models {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class ProductModel { 

        private readonly ASMContext context; 

        public ProductModel(ASMContext context) { 
            this.context = context;
        }

     

        public async Task<List<Sanpham>> FindAll() {

            return(await context.Sanpham.ToListAsync());
        }

          public async Task<Sanpham> Find(int? id) {

            return(await context.Sanpham.FindAsync(id));
        }


    }
}