﻿using BaseFramework.Core.Mapper;
using BaseFramework.Entity;
using BaseFramework.Model.CompanyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.MapConfig.MapperProfile
{
    public class CompanyBranchProfile : ProfileBase
    {
        public CompanyBranchProfile()
        {
            CreateMap<CompanyBranch, CompanyBranchDTO>().ReverseMap();
        }
    }
}
