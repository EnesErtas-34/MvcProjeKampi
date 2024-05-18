using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService:IGenericService<Content>
    {
        List<Content> TGetListByHeadingID(int id);//generic dışında buraya özgü birşey yapacaksan buraya yaz

    }
}
