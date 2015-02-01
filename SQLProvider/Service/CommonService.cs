using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityClassLibrary;


namespace SQLProvider.Service
{
    public class CommonService :BaseService
    {
        public static void saveExceptionEntity(Exception e)
        {
            BaseService baseService = new BaseService();
            ExceptionRecord except = new ExceptionRecord();
            except.State = 1;
            except.TimeStamp = DateTime.Now.Ticks;
            except.ExceptionMessage = e.Message;
            except.ExceptionStackTrace = e.StackTrace;
            except.ExceptionTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            try
            {
                baseService.SaveOrUpdateEntity(except);
            }
            catch (Exception exception)
            {
                CommonMethod.ErrorManage.DealErrorByFile(exception);
            }
        }
    }
}
