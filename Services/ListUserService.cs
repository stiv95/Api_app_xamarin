using Estiven_API_Xamarin.Data;
using Estiven_API_Xamarin.Data.Dto;
using Estiven_API_Xamarin.Data.Models;

namespace Estiven_API_Xamarin.Services
{
    public class ListUserService : IListUserService
    {
        public readonly Db_API_XamarinContext _context;
        public ListUserService(Db_API_XamarinContext _contexts) { 
        
            _context = _contexts;

        }

        public ListUser listmarket(ListUserDto Lista)
        {
            var consult = this._context.Users.Where(w => w.Id == Lista.idUser).Select(s => s).FirstOrDefault();
            
            var respuesta = new ListUser() {
                IdUser = Lista.idUser,
                NameList = Lista.nameList,
                NameProduct = Lista.nameProduct,
                Marca = Lista.marca,
                 User = consult,
                 Cantidad = Lista.cantidad,
                 ValorUnitario = Lista.valorUnitario
                
            };

            return respuesta;

        }

    }


}
