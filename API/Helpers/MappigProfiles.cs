using API.Dtos;
using API.Dtos.Client;
using API.Dtos.Firma;
using API.Dtos.Furnizor;
using API.Dtos.Magazin;
using API.Dtos.Pozitia;
using API.Dtos.Receptie;
using API.Dtos.TipDoc;
using API.Dtos.UnitateDeMasura;
using API.Dtos.Lucrare;
using AutoMapper;
using Core.Entities;
using API.Dtos.Tarif;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

            CreateMap<FirmaToSaveDto, Firma>();
            CreateMap<Firma, FirmaToReturnDto>()
                .ForMember(d => d.SiglaUrl, o => o.MapFrom<FirmaUrlResolver>());

            CreateMap<ContToSaveDto, Cont>();
            CreateMap<Cont, ContToReturnDto>();

            CreateMap<ClientToSaveDto, Client>();
            CreateMap<Client, ClientToReturnDto>();
            CreateMap<Client, ClientToChooseDto>();

            CreateMap<PozitiaToSaveDto, Pozitia>();
            CreateMap<Pozitia, PozitiaToReturnDto>();

            CreateMap<MagazinToSaveDto, Magazin>();
            CreateMap<Magazin, MagazinToReturnDto>();

            CreateMap<FurnizorToSaveDto, Furnizor>();
            CreateMap<Furnizor, FurnizorToReturnDto>();
            CreateMap<Furnizor, FurnizorWithStoc>();

            CreateMap<ReceptieToSaveDto, Receptie>();
            CreateMap<Receptie, ReceptieToReturnDto>()
                .ForMember(d => d.Furnizor, o => o.MapFrom(s => s.Furnizor.PrefixDen + ' ' + s.Furnizor.Den));
            CreateMap<Receptie, ReceptieInListDto>()
                .ForMember(d => d.Furnizor, o => o.MapFrom(s => s.Furnizor.PrefixDen + ' ' + s.Furnizor.Den))
                .ForMember(d => d.TipDocument, o => o.MapFrom(s => s.TipDocument.Den));
            CreateMap<Receptie, ReceptieInStocDto>()
                .ForMember(d => d.TipDocument, o => o.MapFrom(s => s.TipDocument.Cod));

            CreateMap<UnitateDeMasuraToSaveDto, UnitateDeMasura>();
            CreateMap<UnitateDeMasura, UnitateDeMasuraToReturnDto>();

            CreateMap<MaterialToSaveDto, Material>();
            CreateMap<Material, MaterialToReturnDto>();

            CreateMap<TipDocToSaveDto, TipDocument>();
            CreateMap<TipDocument, TipDocToReturnDto>();

            CreateMap<CoordonatorToSaveDto, Coordonator>();
            CreateMap<Coordonator, CoordonatorToReturnDto>();

            CreateMap<ServiciuToSaveDto, Serviciu>();
            CreateMap<Serviciu, ServiciuToReturnDto>();

            CreateMap<TarifToSaveDto, Tarif>();
            CreateMap<Tarif, TarifToReturnDto>()
                .ForMember(d => d.Cod, o => o.MapFrom(s => s.Serviciu.Cod))
                .ForMember(d => d.Den, o => o.MapFrom(s => s.Serviciu.Den))
                .ForMember(d => d.Um, o => o.MapFrom(s => s.Serviciu.Um));
        }
    }
}
