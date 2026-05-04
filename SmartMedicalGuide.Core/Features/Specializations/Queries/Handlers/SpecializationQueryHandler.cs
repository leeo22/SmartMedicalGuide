using AutoMapper;
using MediatR;
using SmartMedicalGuide.Core.Bases;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Models;
using SmartMedicalGuide.Core.Features.Specializations.Queries.Results;
using SmartMedicalGuide.Data.Entities;
using SmartMedicalGuide.Services.Abstracts;

namespace SmartMedicalGuide.Core.Features.Specializations.Queries.Handlers
{
    public class SpecializationQueryHandler : ResponseHandler,
        IRequestHandler<GetSpecializationListQuery, Response<List<GetSpecializationListResponse>>>,
        IRequestHandler<GetSpecializationByIdQuery, Response<GetSingleSpecializationResponse>>,
        IRequestHandler<GetSpecializationByNameQuery, Response<GetSingleSpecializationResponse>>,
        IRequestHandler<SearchSpecializationsQuery, Response<List<GetSpecializationListResponse>>>,
        IRequestHandler<GetPopularSpecializationsQuery, Response<List<GetSpecializationListResponse>>>,
        IRequestHandler<GetSpecializationWithDetailsQuery, Response<GetSpecializationWithDetailsResponse>>,
        IRequestHandler<GetSpecializationStatisticsQuery, Response<object>>
    {
        #region Fields
        private readonly ISpecializationServices _specializationServices;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public SpecializationQueryHandler(ISpecializationServices specializationServices, IMapper mapper)
        {
            _specializationServices = specializationServices;
            _mapper = mapper;
        }
        #endregion

        #region Handlers
        public async Task<Response<List<GetSpecializationListResponse>>> Handle(GetSpecializationListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<Specialization> specializations;

                if (!string.IsNullOrWhiteSpace(request.SearchKeyword))
                    specializations = await _specializationServices.SearchSpecializationsAsync(request.SearchKeyword);
                else
                    specializations = await _specializationServices.GetListAsync();

                var result = new List<GetSpecializationListResponse>();

                foreach (var spec in specializations)
                {
                    var item = _mapper.Map<GetSpecializationListResponse>(spec);

                    if (request.IncludeDoctorCount == true)
                    {
                        item.DoctorsCount = await _specializationServices.GetDoctorsCountBySpecializationAsync(spec.SpecializationId);
                    }

                    result.Add(item);
                }

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<List<GetSpecializationListResponse>>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<GetSingleSpecializationResponse>> Handle(GetSpecializationByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = await _specializationServices.GetByIDAsync(request.Id);
                if (specialization == null)
                    return NotFound<GetSingleSpecializationResponse>("Specialization not found");

                var result = _mapper.Map<GetSingleSpecializationResponse>(specialization);
                result.DoctorsCount = await _specializationServices.GetDoctorsCountBySpecializationAsync(specialization.SpecializationId);

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<GetSingleSpecializationResponse>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<GetSingleSpecializationResponse>> Handle(GetSpecializationByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = await _specializationServices.GetByNameAsync(request.Name);
                if (specialization == null)
                    return NotFound<GetSingleSpecializationResponse>("Specialization not found");

                var result = _mapper.Map<GetSingleSpecializationResponse>(specialization);
                result.DoctorsCount = await _specializationServices.GetDoctorsCountBySpecializationAsync(specialization.SpecializationId);

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<GetSingleSpecializationResponse>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<List<GetSpecializationListResponse>>> Handle(SearchSpecializationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specializations = await _specializationServices.SearchSpecializationsAsync(request.Keyword);
                var result = _mapper.Map<List<GetSpecializationListResponse>>(specializations);

                foreach (var spec in result)
                {
                    spec.DoctorsCount = await _specializationServices.GetDoctorsCountBySpecializationAsync(spec.SpecializationId);
                }

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<List<GetSpecializationListResponse>>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<List<GetSpecializationListResponse>>> Handle(GetPopularSpecializationsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specializations = await _specializationServices.GetPopularSpecializationsAsync(request.Limit);
                var result = _mapper.Map<List<GetSpecializationListResponse>>(specializations);

                foreach (var spec in result)
                {
                    spec.DoctorsCount = await _specializationServices.GetDoctorsCountBySpecializationAsync(spec.SpecializationId);
                }

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<List<GetSpecializationListResponse>>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<GetSpecializationWithDetailsResponse>> Handle(GetSpecializationWithDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var specialization = await _specializationServices.GetSpecializationWithDetailsAsync(request.Id);
                if (specialization == null)
                    return NotFound<GetSpecializationWithDetailsResponse>("Specialization not found");

                var result = _mapper.Map<GetSpecializationWithDetailsResponse>(specialization);

                return Success(result);
            }
            catch (Exception ex)
            {
                return BadRequest<GetSpecializationWithDetailsResponse>($"An error occurred: {ex.Message}");
            }
        }

        public async Task<Response<object>> Handle(GetSpecializationStatisticsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var statistics = await _specializationServices.GetSpecializationStatisticsAsync(request.SpecializationId);
                if (statistics == null)
                    return NotFound<object>("Specialization not found");

                return Success(statistics);
            }
            catch (Exception ex)
            {
                return BadRequest<object>($"An error occurred: {ex.Message}");
            }
        }
        #endregion
    }
}