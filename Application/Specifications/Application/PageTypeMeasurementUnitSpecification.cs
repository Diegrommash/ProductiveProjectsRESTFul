using Ardalis.Specification;
using Domain.Entities.Application;

namespace Application.Specifications.Application
{
    public class PageTypeMeasurementUnitSpecification : Specification<TypeMeasurementUnit>
    {
        public PageTypeMeasurementUnitSpecification(int pageNumber, int pageSize, string name)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, "%" + name + "%");
        }
    }
}
