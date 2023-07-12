using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Flurl;
using Flurl.Http;

namespace CursusCase.FrontEnd.Repositories
{
    public class CursusInstanceRepo : ICursusInstanceRepo
    {
        private readonly string baseUrl = "https://localhost:7236/api/";

        public CourseInstanceOperationResult AddInstances(List<CourseInstance> instances)
        {
            return AddInstancesImpl(instances).Result;
        }

        private async Task<CourseInstanceOperationResult> AddInstancesImpl(List<CourseInstance> instances)
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string url = baseUrl.AppendPathSegment("cursusinstanties/new");
                return await url.PostJsonAsync(instances).ReceiveJson<CourseInstanceOperationResult>();
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }

        public CourseInstanceOperationResult GetAllInstances()
        {
            return GetAllInstancesImpl().Result;
        }

        private async Task<CourseInstanceOperationResult> GetAllInstancesImpl()
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string appendPath = "cursusinstanties";

                await GetDtoFromApi(dto, appendPath);
                return dto;
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }

        private async Task GetDtoFromApi(CourseInstanceOperationResult dto, string appendPath)
        {
            string url = baseUrl.AppendPathSegment(appendPath);
            CourseInstanceOperationResult response = await url.GetJsonAsync<CourseInstanceOperationResult>();
            dto.CursusInstances = ExtractInstancesFromResponse(response);
        }

        private static List<CourseInstance> ExtractInstancesFromResponse(
            CourseInstanceOperationResult response
        )
        {
            return response.CursusInstances.ToList();
        }

        private static CourseInstanceOperationResult HandleApiError(CourseInstanceOperationResult dto, Exception ex)
        {
            dto.Errors.Add(ex.Message);
            return dto;
        }

        public async Task<CourseInstanceOperationResult> GetInstancesBySearchPerWeekAndYearImpl(
            int year,
            int week
        )
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string appendPath = $"cursusinstanties/{year}/{week}";

                await GetDtoFromApi(dto, appendPath);
                return dto;
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }

        public CourseInstanceOperationResult GetInstancesBySearchPerWeekAndYear(int year, int week)
        {
            return GetInstancesBySearchPerWeekAndYearImpl(year, week).Result;
        }

        public CourseInstanceOperationResult GetInstancesBySearchPerPeriod(
            DateTime dateFrom,
            DateTime dateTill
        )
        {
            return GetInstancesBySearchPerPeriodImpl(dateFrom, dateTill).Result;
        }

        public async Task<CourseInstanceOperationResult> GetInstancesBySearchPerPeriodImpl(
            DateTime dateFrom,
            DateTime dateTo
        )
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string url = baseUrl.AppendPathSegment("cursusinstanties/date");
                Period period = new Period() { DateFrom = dateFrom, DateTo = dateTo };

                return await url.PostJsonAsync(period).ReceiveJson<CourseInstanceOperationResult>();
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }

        public async Task<CourseInstanceOperationResult> GetCursusInstanceByIdImpl(int id)
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string appendPath = $"cursusinstanties/{id}";

                await GetDtoFromApi(dto, appendPath);
                return dto;
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }

        public CourseInstanceOperationResult GetCursusInstanceById(int id)
        {
            return GetCursusInstanceByIdImpl(id).Result;
        }

        public CourseInstanceOperationResult AddStudent(Student student, int selectedId)
        {
            return AddStudentImpl(student, selectedId).Result;
        }

        private async Task<CourseInstanceOperationResult> AddStudentImpl(Student student, int selectedId)
        {
            CourseInstanceOperationResult dto = new CourseInstanceOperationResult();
            try
            {
                string url = baseUrl.AppendPathSegment($"cursusinstanties/{selectedId}/newstudent");
                return await url.PostJsonAsync(student).ReceiveJson<CourseInstanceOperationResult>();
            }
            catch (Exception ex)
            {
                return HandleApiError(dto, ex);
            }
        }
    }
}