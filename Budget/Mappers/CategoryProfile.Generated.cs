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
    public partial class CategoryProfile : Profile
    {
        partial void MapInputToEntity(IMappingExpression<CategoryInput, CategoryEntity> mapExpr)
        {
            mapExpr.ForMember(d => d.CategoryId, opt => opt.Ignore())
                .ForMember(d => d.Created, opt => opt.MapFrom<ICreatedResolver>())
                .ForMember(d => d.Modified, opt => opt.MapFrom<IModifiedResolver>());
        }

        partial void MapEntityToView(IMappingExpression<CategoryEntity, Category> mapExpr)
        {
            
        }
    }
}