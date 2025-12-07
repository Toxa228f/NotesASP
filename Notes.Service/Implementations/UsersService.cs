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
    public class UsersService : IUsersService
    {
        private IUserRepository rep;
        public UsersService(IUserRepository rep) => this.rep = rep;

        public async Task<IBaseResponse<bool>> CreateAsync(User entity)
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
                        Responce = "Успешное создание пользователя"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Пользователь не создан"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в создании пользователя"
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteAsync(User entity)
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
                        Responce = "Успешное удаление пользователя"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Пользователь не удален"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в удалении пользователя"
                };
            }
        }

        public async Task<IBaseResponse<User>> GetByLoginAndPasswordAsync(string login, string password)
        {
            try
            {
                User ans = await rep.GetByLoginAndPassword(login, password);
                if (ans != null)
                {
                    return new BaseResponse<User>()
                    {
                        Data = ans,
                        Responce = "Успешное получение пользователя"
                    };
                }
                else
                {
                    return new BaseResponse<User>()
                    {
                        Data = null,
                        Responce = "Пользователь не найден"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<User>()
                {
                    Data = null,
                    Responce = "Ошибка в получении пользователя"
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<User>>> SelectAllAsync()
        {
            try
            {
                IEnumerable<User> ans = await rep.SelectAll();
                if (ans.Count() > 0)
                {
                    return new BaseResponse<IEnumerable<User>>()
                    {
                        Data = ans.ToList(),
                        Responce = "Успешное получение списка пользователей"
                    };
                }
                else
                {
                    return new BaseResponse<IEnumerable<User>>()
                    {
                        Data = null,
                        Responce = "Список пользователей пуст"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<IEnumerable<User>>()
                {
                    Data = null,
                    Responce = "Ошибка в получении списка всех пользователей"
                };
            }
        }

        public async Task<IBaseResponse<User>> SelectByIdAsync(Guid id)
        {
            try
            {
                User ans = await rep.GetById(id);
                if (ans != null)
                {
                    return new BaseResponse<User>()
                    {
                        Data = ans,
                        Responce = "Успешное получение пользователя"
                    };
                }
                else
                {
                    return new BaseResponse<User>()
                    {
                        Data = null,
                        Responce = "Пользователь не найден"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<User>()
                {
                    Data = null,
                    Responce = "Ошибка в получении пользователя"
                };
            }
        }

        public async Task<IBaseResponse<bool>> UpdateAsync(User entity)
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
                        Responce = "Успешное обновление пользователя"
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        Responce = "Пользователь не обновлен"
                    };
                }
            }
            catch (Exception)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Responce = "Ошибка в обновлении пользователя"
                };
            }
        }
    }
}
