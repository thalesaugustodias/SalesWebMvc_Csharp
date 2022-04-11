using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly SalesWebMvcContext _context;

        public SellerService (SalesWebMvcContext context)
        {
            _context = context;
        }

        //retornando a lista com todos os vendedores do banco de dados;

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
        
        public Seller FindById (int id)
        {
            //lá no banco de dados, na tabela seller, encontre o seller com o id igual ao indicado na aplicação
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            //criando uma variável que vai armazenar o id do seller a ser deletado e vai encaminhar pro dbset que irá enviar pro banco de dados a solicitação de deleção
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
