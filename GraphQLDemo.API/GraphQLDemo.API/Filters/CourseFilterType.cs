﻿using GraphQLDemo.API.Types;
using HotChocolate.Data.Filters;

namespace GraphQLDemo.API.Filters
{
    public class CourseFilterType : FilterInputType<CourseType>
    {
        protected override void Configure(IFilterInputTypeDescriptor<CourseType> descriptor)
        {
            descriptor.Ignore(c => c.Students);
            base.Configure(descriptor);
        }
    }
}
