using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace ExemploAPI.Dominio.Modelos.Dto
{
    public class ListaBaseDto<TDto> : ListDto<TDto>, IListaBaseDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
