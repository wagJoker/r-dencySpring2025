using CoworkingBooking.API.Models;
using CoworkingBooking.API.Models.Dto;
using System.Collections.Generic;

namespace CoworkingBooking.API.Services
{
    public interface IWorkspaceService
    {
        IEnumerable<WorkspaceDto> GetAll();
        WorkspaceDto GetById(int id);
        WorkspaceDto Create(WorkspaceDto dto);
        void Update(int id, WorkspaceDto dto);
        void Delete(int id);
    }

    public class WorkspaceService : IWorkspaceService
    {
        // Здесь будет репозиторий для работы с БД
        
        public IEnumerable<WorkspaceDto> GetAll() 
        {
            // Заглушка - в реальности запрос к БД
            return new List<WorkspaceDto>();
        }
        
        public WorkspaceDto GetById(int id) 
        {
            return new WorkspaceDto();
        }
        
        public WorkspaceDto Create(WorkspaceDto dto)
        {
            // Валидация и сохранение в БД
            return dto;
        }
        
        public void Update(int id, WorkspaceDto dto)
        {
            // Поиск и обновление в БД
        }
        
        public void Delete(int id)
        {
            // Удаление из БД
        }
    }
}