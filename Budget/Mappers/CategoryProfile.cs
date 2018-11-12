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
        public CategoryEntity MapCategory(CategoryInput src, CategoryEntity dest)
        {
            return mapper.Map(src, dest);
        }

        public Category MapCategory(CategoryEntity src, Category dest)
        {
            return mapper.Map(src, dest);
        }
    }

    public partial class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            //Map the input model to the entity
            MapInputToEntity(CreateMap<CategoryInput, CategoryEntity>());

            //Map the entity to the view model.
            MapEntityToView(CreateMap<CategoryEntity, Category>());
        }

        partial void MapInputToEntity(IMappingExpression<CategoryInput, CategoryEntity> mapExpr);

        partial void MapEntityToView(IMappingExpression<CategoryEntity, Category> mapExpr);
    }
}