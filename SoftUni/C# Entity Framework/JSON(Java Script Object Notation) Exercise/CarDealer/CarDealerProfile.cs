using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            //this.CreateMap<ImportPartIdDto, PartCar>();
            // this.CreateMap<ImportCarDto, Car>();

            //this.CreateMap<ImportCarDto, Car>()
            //    .ForMember(d => d.PartsCars, opt => opt.MapFrom(s => s.PartsId.Select(p => new PartCar() { PartId = p.Id })));

            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.PartsId, opt => opt.DoNotValidate());

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BirthDate, opt => opt.MapFrom(s => s.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)));

            this.CreateMap<Car, ExportCarDto>();

            this.CreateMap<Supplier, ExportSupplierDto>()
                .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));

            this.CreateMap<Part, ExportPartDto>()
                .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price.ToString("f2")));

            this.CreateMap<Car, ExportCarWithPartsDto>();
              //  .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.))
                
                
        }
    }
}
