﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kosturas.ViewModels;
using Domain;
namespace Kosturas.InfraExtructura
{
  public  class AutoMapperPerfil:AutoMapper.Profile
    {
        public AutoMapperPerfil()
        {
            CreateMap<OrdenDetalleViewModel, TemDetallesOrdenes>()
            .ForMember(dest => dest.Detalle, opt=>opt.Ignore())
            .ForMember(dest => dest.Prenda, opt => opt.Ignore());

            CreateMap<OrdenPrendaViewModel, TemDetallesOrdenPrenda>()
                .ForMember(dest => dest.Orden, opt => opt.Ignore())
                .ForMember(dest => dest.Prenda, opt => opt.Ignore())
                .ForMember(dest => dest.DetalleTareas, opt => opt.Ignore());

            CreateMap<TemDetallesOrdenes, OrdenDetalleViewModel>();

            CreateMap<TemDetallesOrdenPrenda, OrdenPrendaViewModel>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(w =>
            {
                w.AddProfile<AutoMapperPerfil>();
            });

        }

    

    }
    public static class ExtensionMethod
    {

        public static string Encrypt(this Int32 num)
        {
            return "Technotips:" + num;
        }
    }
}