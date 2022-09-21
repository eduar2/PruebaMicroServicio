using AutoMapper;
using Core.Domains;
using WebAPITest.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPITest.Utils
{
    public static class MapperUtil
    {

        internal static Cliente MapToCliente(this ContractCliente obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ContractCliente, Cliente>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Cliente>(obj);
        }

        internal static Cuenta MapToCuenta(this ContractCuenta obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ContractCuenta, Cuenta>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Cuenta>(obj);
        }

        internal static Persona MapToPersona(this ContractCliente obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ContractCliente, Persona>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Persona>(obj);
        }

        internal static ContractCliente MapToContractCliente(this Persona obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Persona, ContractCliente>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<ContractCliente>(obj);
        }

        internal static Movimiento MapToMovimiento(this ContractMovimiento obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ContractMovimiento, Movimiento>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Movimiento>(obj);
        }

    }
}
