using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWpf.Utils
{
    public static class MsgHelper
    {
        public enum MsgType { Info, Warn, Error, Success, Fatal }

        /// <summary>
        /// 打印消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="type"></param>
        /// <param name="isGlobal"></param>
        public static void ShowMsg(string msg, MsgType type, bool isGlobal = false)
        {
            if (isGlobal)
            {
                switch (type)
                {
                    case MsgType.Info:
                        NLogHelper.Info(msg);
                        Growl.InfoGlobal(msg);
                        break;
                    case MsgType.Warn:
                        NLogHelper.Warning(msg);
                        Growl.WarningGlobal(msg);
                        break;
                    case MsgType.Error:
                        NLogHelper.Error(msg);
                        Growl.ErrorGlobal(msg);
                        break;
                    case MsgType.Success:
                        NLogHelper.Info(msg);
                        Growl.SuccessGlobal(msg);
                        break;
                    case MsgType.Fatal:
                        NLogHelper.Error(msg);
                        Growl.FatalGlobal(msg);
                        break;
                }
            }
            else
            {
                switch (type)
                {
                    case MsgType.Info:
                        NLogHelper.Info(msg);
                        Growl.Info(msg);
                        break;
                    case MsgType.Warn:
                        NLogHelper.Warning(msg);
                        Growl.Warning(msg);
                        break;
                    case MsgType.Error:
                        NLogHelper.Error(msg);
                        Growl.Error(msg);
                        break;
                    case MsgType.Success:
                        NLogHelper.Info(msg);
                        Growl.Success(msg);
                        break;
                    case MsgType.Fatal:
                        NLogHelper.Error(msg);
                        Growl.Fatal(msg);
                        break;
                }
            }
        }



        /// <summary>
        /// 询问回调
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="callback"></param>
        /// <param name="isGlobal"></param>
        public static void Ask(string msg, Action<bool> callback, bool isGlobal = false)
        {
            NLogHelper.Info(msg);
            if (isGlobal)
            {
                Growl.AskGlobal(msg, isConfrimed =>
                {
                    callback(isConfrimed);
                    return true;
                });
            }
            else
            {
                Growl.Ask(msg, isConfrimed =>
                {
                    callback(isConfrimed);
                    return true;
                });
            }
        }

        /// <summary>
        /// 强制清空全部消息
        /// </summary>
        public static void CleanAll()
        {
            Growl.Clear();
            Growl.ClearGlobal();
        }

        public static void Info(string msg)
        {
            NLogHelper.Info(msg);
            Growl.Info(msg);
        }

        public static void Warning(string msg)
        {
            NLogHelper.Warning(msg);
            Growl.Warning(msg);

        }

        public static void Error(string msg)
        {
            NLogHelper.Error(msg);
            Growl.Error(msg);
        }

        public static void Fatal(string msg)
        {
            NLogHelper.Error(msg);
            Growl.Fatal(msg);
        }

        public static void Success(string msg)
        {
            NLogHelper.Info(msg);
            Growl.Success(msg);
        }

        public static void InfoGlobal(string msg)
        {
            NLogHelper.Info(msg);
            Growl.InfoGlobal(msg);
        }

        public static void WarningGlobal(string msg)
        {
            NLogHelper.Warning(msg);
            Growl.WarningGlobal(msg);

        }

        public static void ErrorGlobal(string msg)
        {
            NLogHelper.Error(msg);
            Growl.ErrorGlobal(msg);
        }

        public static void FatalGlobal(string msg)
        {
            NLogHelper.Error(msg);
            Growl.FatalGlobal(msg);
        }

        public static void SuccessGlobal(string msg)
        {
            NLogHelper.Info(msg);
            Growl.SuccessGlobal(msg);
        }

    }
}
