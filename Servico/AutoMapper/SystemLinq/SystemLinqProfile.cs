using AutoMapper;
using ExemploAPI.Dominio.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tnf.Dto;

namespace ExampleAPI.Servico.AutoMapper
{
    public class SystemLinqProfile : Profile
    {
        public SystemLinqProfile()
        {
            CreateMap(typeof(ListDto<>), typeof(ListaBaseDto<>)).ForMember("QuantidadeRegistros", opt => opt.Ignore());//.ForAllMembers(opt => opt.Ignore());
        }
    }
}
