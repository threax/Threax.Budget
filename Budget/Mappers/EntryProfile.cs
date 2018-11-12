using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Budget.InputModels;
using Budget.Database;
using Budget.ViewModels;

namespace Budget.Mappers
{
    public partial class AppMapper
    {
        public EntryEntity MapEntry(EntryInput src, EntryEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public Entry MapEntry(EntryEntity src, Entry dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class EntryProfile : Profile
    {
        public EntryProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<EntryInput, EntryEntity>()
                .ForMember(i => i.Category, o => o.Ignore()));

            //Map the entity to the view model.
            MapEntityToView(CreateMap<EntryEntity, Entry>());
        }

        partial void MapInputToEntity(IMappingExpression<EntryInput, EntryEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<EntryEntity, Entry> mapExpr);
    }
}