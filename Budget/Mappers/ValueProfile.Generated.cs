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
    public partial class ValueProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<ValueInput, ValueEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.ValueId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.ResolveUsing<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.ResolveUsing<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<ValueEntity, Value> mapExpr)
        {
            
        }
    }
}