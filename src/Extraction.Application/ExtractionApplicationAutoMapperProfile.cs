﻿using AutoMapper;

namespace Extraction
{
    public class ExtractionApplicationAutoMapperProfile : Profile
    {
        public ExtractionApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<ExtractorProvider, ExtractorProviderDto>();
            CreateMap<ExtractorProviderResource, ExtractorProviderResourceDto>()
                .ForMember(dest => dest.Url, s => s.Ignore());
            CreateMap<ParameterDefination, ParameterDefinationDto>();

            CreateMap<ExtractorInfo, ExtractorInfoDto>();
            CreateMap<ExtractorInfoResource, ExtractorInfoResourceDto>()
                .ForMember(dest => dest.Url, s => s.Ignore());
            CreateMap<ExtractorInfoRule, ExtractorInfoRuleDto>();

            CreateMap<ExtractResultInfo, ExtractResultInfoDto>();
            CreateMap<ExtractRecord, ExtractRecordDto>();
        }
    }
}