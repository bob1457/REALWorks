﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Queries
{
    public class PropertyDetailsQueryHandler : IRequestHandler<PropertyDetailsQuery, PropertyDetailViewModel>
    {
        private readonly AppDataBaseContext _context;

        public PropertyDetailsQueryHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<PropertyDetailViewModel> Handle(PropertyDetailsQuery request, CancellationToken cancellationToken)
        {
            //var ppt = _context.Property
            //    .Select(p => new
            //    {
            //        p.Id,
            //        p.PropertyName,
            //        Owners = string.Join(", ", p.OwnerProperty                                  
            //       .Select(o => o.PropertyOwner.FirstName))

            //    }).FirstOrDefault(i => i.Id == request.Id);

            var ppt = _context.Property
                .Include(a => a.Address)
                .FirstOrDefault(p => p.Id == request.Id);

            _context.Entry(ppt)
                .Collection(c => c.OwnerProperty).Load();
            foreach(var op in ppt.OwnerProperty)
            {
                _context.Entry(op)
                    .Reference(o => o.PropertyOwner).Load();
            }


            var prop = _context.Property
                //.Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner)
                .Where(po => po.Id == request.Id)
                .Select(op => new PropertyDetailViewModel
                {
                    PropertyName = op.PropertyName,
                    PropertyId = op.Id,
                    PropertyDesc = op.PropertyDesc,
                    PropertyLogoImgUrl = op.PropertyLogoImgUrl,
                    PropertyVideoUrl = op.PropertyVideoUrl,
                    IsActive = op.IsActive,
                    IsShared = op.IsShared,
                    IsBasementSuite = op.IsBasementSuite,
                    PropertyType1 = op.Type.ToString(),
                    Status = op.Status.ToString(),
                    PropertyBuildYear = op.PropertyBuildYear,
                    

                    PropertySuiteNumber = op.Address.PropertySuiteNumber,
                    PropertyNumber = op.Address.PropertyNumber,
                    PropertyStreet = op.Address.PropertyStreet,
                    PropertyCity = op.Address.PropertyCity,
                    PropertyStateProvince = op.Address.PropertyStateProvince,
                    PropertyZipPostCode = op.Address.PropertyZipPostCode,
                    PropertyCountry = op.Address.PropertyCountry,
                    GpslatitudeValue = op.Address.GpslatitudeValue,
                    GpslongitudeValue = op.Address.GpslongitudeValue,

                    NumberOfBathrooms = op.Feature.NumberOfBathrooms,
                    NumberOfBedrooms = op.Feature.NumberOfBedrooms,
                    NumberOfLayers = op.Feature.NumberOfLayers,
                    NumberOfParking = op.Feature.NumberOfParking,
                    BasementAvailable = op.Feature.BasementAvailable,
                    TotalLivingArea = op.Feature.TotalLivingArea,
                    FeatureNotes = op.Feature.Notes,

                    Stove = op.Facility.Stove,
                    Refrigerator = op.Facility.Refrigerator,
                    Dishwasher = op.Facility.Dishwasher,
                    Laundry = op.Facility.Laundry,
                    BlindsCurtain = op.Facility.BlindsCurtain,
                    Furniture = op.Facility.Furniture,
                    Tvinternet = op.Facility.Tvinternet,
                    CommonFacility = op.Facility.CommonFacility,
                    SecuritySystem = op.Facility.SecuritySystem,
                    UtilityIncluded = op.Facility.UtilityIncluded,
                    FireAlarmSystem = op.Facility.FireAlarmSystem,
                    Others = op.Facility.Others,
                    FacilityNotes = op.Facility.Notes,

                    CreationDate = op.Created,
                    UpdateDate = op.Modified,
                    OwnerList = op.OwnerProperty.Select(o => o.PropertyOwner).ToList(),
                    ContractList = op.ManagementContract/*.Where(c =>c.IsActive == true)*/.ToList(),
                    ImagetList = op.PropertyImg.ToList()
                });
                //.FirstOrDefault(op => op.PropertyId == request.Id);


            //var pptList = (from p in _context.Property
            //               .Include(fe => fe.Feature)
            //               .Include(fa => fa.Facility)
            //               .Include(a => a.Address)
            //               .Include(m => m.PropertyImg)
            //               join op in _context.OwnerProperty on p.Id equals op.PropertyId
            //               join po in _context.PropertyOwner on op.PropertyOwnerId equals po.Id

            //               select new PropertyDetailViewModel
            //               {
            //                   PropertyName = p.PropertyName
            //               }





            //               );



            var property = _context.Property
                .Include(c => c.ManagementContract)
                .Include(fe => fe.Feature)
                .Include(fa => fa.Facility)
                .Include(a => a.Address)
                .Include(m => m.PropertyImg)
                .Include(op => op.OwnerProperty)
                .ThenInclude(po => po.PropertyOwner).ToList();

            //return property.FirstOrDefault(p => p.Id == request.Id);

            return prop.FirstOrDefault(p => p.PropertyId == request.Id);


            //throw new NotImplementedException();
        }
    }
}
