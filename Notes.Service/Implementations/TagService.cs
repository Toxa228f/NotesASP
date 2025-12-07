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
    public class TagService : ITagService
    {
        private ITagRepository rep;
        public TagService(ITagRepository rep) => this.rep = rep;

        public async Task<IBaseResponse<bool>> CreateAsync(Tag entity)
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
                        Responce = "Успешное создание тега"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Тег не создан"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в создании тега"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteAsync(Tag entity)
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
                        Responce = "Успешное удаление тега"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Тег не удален"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в удалении тега"
                };
            }
        }

        public async Task<IBaseResponse<Tag>> GetTagByNameAsync(string name)
        {
            try
            {
                Tag ans = await rep.GetTagByName(name);
                if (ans != null)
                {
                    return new BaseResponse<Tag>()
                    {
                        Data = ans,
                        Responce = "Успешное получение тега"
                    };
                }
                else
                {
                    return new BaseResponse<Tag>()
                    {
                        Data = null,
                        Responce = "Тег не найден"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<Tag>()
                {
                    Data = null,
                    Responce = "Ошибка в получении тега"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Tag>>> SelectAllAsync()
        {
            try
            {
                IEnumerable<Tag> ans = await rep.SelectAll();
                if (ans.Count() > 0)
                {
                    return new BaseResponse<IEnumerable<Tag>>()
                    {
                        Data = ans.ToList(),
                        Responce = "Успешное получение списка тегов"
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<Tag>>()
                    {
                        Data = null,
                        Responce = "Список тегов пуст"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<Tag>>()
                {
                    Data = null,
                    Responce = "Ошибка в получении списка всех тегов"
                };
            }
        }

        public async Task<IBaseResponse<Tag>> SelectByIdAsync(Guid id)
        {
            try
            {
                Tag ans = await rep.GetById(id);
                if (ans != null)
                {
                    return new BaseResponse<Tag>()
                    {
                        Data = ans,
                        Responce = "Успешное получение тега"
                    };
                }
                else
                {
                    return new BaseResponse<Tag>()
                    {
                        Data = null,
                        Responce = "Тег не найден"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<Tag>()
                {
                    Data = null,
                    Responce = "Ошибка в получении пользователя"
                };
            }
        }

        public async Task<IBaseResponse<bool>> UpdateAsync(Tag entity)
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
                        Responce = "Успешное обновление тега"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Тег не обновлен"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в обновлении тега"
                };
            }
        }
    }
}
