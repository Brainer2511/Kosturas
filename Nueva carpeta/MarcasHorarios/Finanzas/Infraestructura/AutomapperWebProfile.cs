using Domain;
using Finanzas.ViewModels;
using System;

namespace Finanzas.Infraestructura
{
    public class AutomapperWebProfile : AutoMapper.Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<HorarioPersona, HorarioPersonaViewModel>()
                 .ForMember(dest => dest.sFecha, opt => opt.MapFrom(src => src.Fecha.ToString("dd/MM/yyyy")))
                 .ForMember(dest => dest.sHora, opt => opt.MapFrom(src => src.Hora.ToString("HH:mm")));

            //Reverese mapping
            CreateMap<HorarioPersonaViewModel, HorarioPersona>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomapperWebProfile>();
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