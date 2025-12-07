using Notes.Dal.Interfaces;
using Notes.Domain.Entities;
using Notes.Domain.Interfaces;
using Notes.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Service.Implementations
{
    public class NoteService : INoteService
    {
        private INoteRepository rep;
        public NoteService(INoteRepository rep) => this.rep = rep;

        public async Task<IBaseResponse<bool>> CreateAsync(Note entity)
        {
            try
            {
                bool ans = await rep.Create(entity);
                if (ans)
                {
                    await rep.SaveChanges();
                    return new BaseResponse<bool>()
                    {
                        Data = true,
                        Responce = "Успешное создание заметки"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Заметка не создана"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в создании заметки"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteAsync(Note entity)
        {
            try
            {
                bool ans = rep.Delete(entity);
                if (ans)
                {
                    await rep.SaveChanges();
                    return new BaseResponse<bool>()
                    {
                        Data = true,
                        Responce = "Успешное удаление заметки"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Заметка не удалена"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в удалении заметки"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Note>>> GetAllByUserIdAsync(Guid id)
        {
            try
            {
                IEnumerable<Note> ans = await rep.GetAllByUserId(id);
                if (ans.Count()>0)
                {
                    return new BaseResponse<IEnumerable<Note>> ()
                    {
                        Data = ans.ToList(),
                        Responce = "Успешное получение списка заметок"
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<Note>> ()
                    {
                        Data = null,
                        Responce = "Список заметок пуст"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    Data = null,
                    Responce = "Ошибка в получении списка заметок по Id пользователя"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Note>>> SelectAllAsync()
        {
            try
            {
                IEnumerable<Note> ans = await rep.SelectAll();
                if (ans.Count() > 0)
                {
                    return new BaseResponse<IEnumerable<Note>>()
                    {
                        Data = ans.ToList(),
                        Responce = "Успешное получение списка заметок"
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<Note>>()
                    {
                        Data = null,
                        Responce = "Список заметок пуст"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<Note>>()
                {
                    Data = null,
                    Responce = "Ошибка в получении списка всех заметок"
                };
            }
        }

        public async Task<IBaseResponse<Note>> SelectByIdAsync(Guid id)
        {
            try
            {
                Note ans = await rep.GetById(id);
                if (ans != null)
                {
                    return new BaseResponse<Note>()
                    {
                        Data = ans,
                        Responce = "Успешное получение заметки"
                    };
                }
                else
                {
                    return new BaseResponse<Note>()
                    {
                        Data = null,
                        Responce = "Заметка не найдена"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<Note>()
                {
                    Data = null,
                    Responce = "Ошибка в получении заметки"
                };
            }
        }

        public async Task<IBaseResponse<bool>> UpdateAsync(Note entity)
        {
            try
            {
                bool ans = rep.Update(entity);
                if (ans)
                {
                    await rep.SaveChanges();
                    return new BaseResponse<bool>()
                    {
                        Data = true,
                        Responce = "Успешное обновление заметки"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Заметка не обновлена"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в обновлении заметки"
                };
            }
        }
    }
}
