using TodoApplication.DataAccess.EFImplementations;
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;
using TodoApplication.Mapper;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Services
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public FilterService(
            IRepository<Category> categoryRepository,
            IRepository<Status> statusRepository)
        {
            //_categoryRepository = new CategoryRepository();
            //_statusRepository = new StatusRepository();
            //_categoryRepository = new EFCategoryRepository();
            //_statusRepository = new EFStatusRepository();

            _categoryRepository = categoryRepository;
            _statusRepository = statusRepository;
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetAll().Select(c => c.Map()).ToList();
        }

        public List<StatusDto> GetStatuses()
        {
            return _statusRepository.GetAll().Select(s => s.Map()).ToList();
        }
    }
}
