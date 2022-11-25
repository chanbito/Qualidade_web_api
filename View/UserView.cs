using Qualidade_web_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Qualidade_web_api.View
{
    public class UserView
    {
        private static List<UserModel> banco;
        private static int acessos;


        private static void start()
        {
            if (banco == null)
            {
                banco = new List<UserModel>();
            }
        }

        internal static List<UserModel> get()
        {
            acessos++;
            if(acessos > 10)
            {
                Thread.Sleep((acessos / 10)* 1000);
            }

            start();
            acessos--;
            return banco;
        }

        internal static bool inserir(UserModel user)
        {
            try
            {
                acessos++;
                if (acessos > 10)
                {
                    Thread.Sleep((acessos / 10) * 1000);
                }

                start();

                if (banco.Select(x => x.id).Contains(user.id))
                {
                    acessos--;
                    throw new Exception("ID ja existente na base");
                }

                banco.Add(user);

                acessos--;
                return true;
            }
            catch
            {
                acessos--;
                return false;
            }


        }

        internal static bool Update(int user_id, UserModel user)
        {
            try
            {
                acessos++;
                if (acessos > 10)
                {
                    Thread.Sleep((acessos / 10) * 1000);
                }

                start();

                if (!banco.Select(x => x.id).Contains(user_id))
                {
                    acessos--;
                    throw new Exception("user_id não existente na base");
                }

                banco.Remove(banco.Where(x => x.id == user_id).FirstOrDefault());
                banco.Add(user);
                acessos--;
                return true;
            }
            catch(Exception e)
            {
                acessos--;
                return false;
            }

        }

        internal static bool Delete(int user_id)
        {
            try
            {
                acessos++;
                if (acessos > 10)
                {
                    Thread.Sleep((acessos / 10) * 1000);
                }

                start();

                if (!banco.Select(x => x.id).Contains(user_id))
                {
                    acessos--;
                    throw new Exception("user_id não existente na base");
                }

                banco.Remove(banco.Where(x => x.id == user_id).FirstOrDefault());

                acessos--;
                return true;
            }
            catch (Exception e)
            {
                acessos--;
                return false;
            }
        }

        internal static UserModel get(int user_ID)
        {
            try
            {
                acessos++;
                if (acessos > 10)
                {
                    Thread.Sleep((acessos / 10) * 1000);
                }

                start();

                if (!banco.Select(x => x.id).Contains(user_ID))
                {
                    acessos--;
                    throw new Exception("user_id não existente na base");
                }

                acessos--;
                return banco.Where(x=>x.id == user_ID).FirstOrDefault();

            }
            catch
            {
                acessos--;
                return null;
            }
        }
    }
}