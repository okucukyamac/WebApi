using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
    {
        Brand brand = new();
        brand.Name = createBrandRequest.Name;
        brand.CreatedDate = DateTime.Now;

        _brandDal.Add(brand);

        CreatedBrandResponse createdBrandResponse = new CreatedBrandResponse();
        createdBrandResponse.Name = createBrandRequest.Name;
        createdBrandResponse.Id = brand.Id;
        createdBrandResponse.CreatedDate = brand.CreatedDate;

        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
        List<Brand> brands = _brandDal.GetAll();

        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach (var item in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();

            getAllBrandResponse.Name = item.Name;
            getAllBrandResponse.Id = item.Id;
            getAllBrandResponse.CreatedDate = item.CreatedDate;

            getAllBrandResponses.Add(getAllBrandResponse);
        }

        return getAllBrandResponses;
    }
}
