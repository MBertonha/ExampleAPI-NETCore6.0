using System;
using System.Collections.Generic;
using System.Text;
using Tnf.Dto;

namespace ExemploAPI.Dominio.Modelos.Dto
{
    public interface IListaBaseDto<TDto> : IListDto<TDto>
    {
        public int QuantidadeRegistros { get; set; }
    }
}
