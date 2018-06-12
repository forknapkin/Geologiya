using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Common;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Geologiya
{
    class Util
    {
        public static bool Insert;

        public static int ID;

        private static string ConStr;

        public static string language = "Русскоязычная";

        public static string cultureInfo = "";
        
        public static void ReadCultureInfo()
        {
            string fileName = "cultureInfo.ini";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            try
            {
                cultureInfo = reader.ReadLine();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                reader.Close();
            }

        }
        public static bool IsAuthotization
        { get; set; }

        public static bool ReportView { set; get; }

        public static bool ReadConStr()
        {
            string fileName = "config.ini";
            if (language == "Русскоязычная")
                fileName = "config.ini";
            else
                fileName = "configUz.ini";
            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            try
            {
                ConStr = reader.ReadLine();
            }
            catch
            { }
            finally
            {
                reader.Close();
            }
            if (ConStr != "")
            {
                //MessageBox.Show(ConStr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetConnectionString()
        {
            if (ReadConStr())
            {
                return ConStr;                
            }
            return "";
        }
        // 1 - ключевые слова, 2 - оператор, 3 - запрос из линка, 4 - сложный, 5 - исключения
        public static string ExComboQuery(string strQuery, string op, string rescom, bool comboSelect, bool exception, bool isAccuracySearch)
        {
            string str1 = "SELECT [t1].[ID] FROM [dbo].[danie] AS [t1] WHERE ";
            if (comboSelect)
            {
                strQuery = strQuery.Replace("(", " ( ");
                strQuery = strQuery.Replace(")", " ) ");
                strQuery = strQuery.Replace("&", " AND ");
                strQuery = strQuery.Replace("|", " OR ");
                string[] array = ((IEnumerable<string>)strQuery.Split(' ')).Where<string>((Func<string, bool>)(s => s != string.Empty)).ToArray<string>();
                for (int index = 0; index < array.Length; ++index)
                {
                    string str2 = array[index];
                    if (str2 == "(" || str2 == ")" || (str2 == "AND" || str2 == "OR"))
                        str1 = str1 + " " + array[index] + " ";
                    else if (isAccuracySearch)
                        str1 = str1 + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                    else
                        str1 = str1 + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                }
            }
            else
            {
                string[] array = ((IEnumerable<string>)strQuery.Split(new char[2]
                {
          ' ',
          ','
                })).Where<string>((Func<string, bool>)(s => s != string.Empty)).ToArray<string>();
                if (isAccuracySearch)
                    str1 = str1 + "((Slova LIKE '" + array[0] + ",%') OR (Slova LIKE '" + array[0] + " %') OR (Slova LIKE '" + array[0] + "') OR (Slova LIKE '% " + array[0] + ",%') OR (Slova LIKE '% " + array[0] + " %') OR (Slova LIKE '% " + array[0] + "'))";
                else
                    str1 = str1 + "((Slova LIKE '% " + array[0] + "%') OR (Slova LIKE '%." + array[0] + "%') OR (Slova LIKE '" + array[0] + "%'))";
                for (int index = 1; index < array.Length; ++index)
                {
                    if (isAccuracySearch)
                        str1 = str1 + op + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                    else
                        str1 = str1 + op + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                }
            }
            if (exception)
                str1 = str1.Insert(0, " AND [t0].[ID] NOT IN (");
            if (!exception)
                str1 = str1.Insert(0, " AND [t0].[ID] IN (");
            string str3 = str1.Insert(str1.Length - 1, ") ");
            rescom = rescom.Insert(rescom.IndexOf("ORDER") - 1, str3);
            return rescom;

        }

        public static string MultiComboQuery(string keyWords, string exKeyWords, string firstOp, string secondOp, string linqQuery, bool comboSelect, bool excomboSelect, bool isAccuracySearch)
        {
            string com = "SELECT [t1].[ID] FROM [dbo].[danie] AS [t1] WHERE ";
            if (comboSelect)
            {
                keyWords = keyWords.Replace("(", " ( ");
                keyWords = keyWords.Replace(")", " ) ");
                keyWords = keyWords.Replace("&", " AND ");
                keyWords = keyWords.Replace("|", " OR ");
                string[] array = keyWords.Split(' ');
                array = array.Where(s => s != string.Empty).ToArray();

                for (int index = 0; index < array.Length; index++)
                {
                    //old code
                    /*
                    switch (keywords[i])
                    {
                        case "(":
                        case ")":
                        case "AND":
                        case "OR":
                            com = com + " " + keywords[i] + " ";
                            break;
                        default:
                            com = com + "((Slova LIKE '%" + " " + keywords[i] + "%') OR (Slova LIKE '%." + keywords[i] + "%') " +
                                "OR (Slova LIKE '" + keywords[i] + "%'))";
                            break;
                    }*/

                    //start code from decompil
                    string str2 = array[index];
                    if (str2 == "(" || str2 == ")" || (str2 == "AND" || str2 == "OR"))
                        com = com + " " + array[index] + " ";
                    else if (isAccuracySearch)
                        com = com + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                    else
                        com = com + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                    //end code from decompil
                }
            }
            else
            {
                //old code
                /*
                string[] keywords = keyWords.Split(' ', ',').Where(s => s != string.Empty).ToArray();

                com += "((Slova LIKE '%" + " " + keywords[0] + "%') OR (Slova LIKE '%." + keywords[0] + "%') OR (Slova LIKE '" + keywords[0] + "%'))";
                for (int i = 1; i < keywords.Length; i++)
                {
                    com = com + firstOp + "((Slova LIKE '%" + " " + keywords[i] + "%') OR (Slova LIKE '%." + keywords[i] + "%') OR (Slova LIKE '" + keywords[i] + "%'))";
                }*/

                //
                string[] array = ((IEnumerable<string>)keyWords.Split(new char[2]{' ',','}))
                    .Where<string>((Func<string, bool>)(s => s != string.Empty)).ToArray<string>();
                    if (isAccuracySearch)
                        com = com + "((Slova LIKE '" + array[0] + ",%') OR (Slova LIKE '" + array[0] + " %') OR (Slova LIKE '" + array[0] + "') OR (Slova LIKE '% " + array[0] + ",%') OR (Slova LIKE '% " + array[0] + " %') OR (Slova LIKE '% " + array[0] + "'))";
                    else
                    com = com + "((Slova LIKE '% " + array[0] + "%') OR (Slova LIKE '%." + array[0] + "%') OR (Slova LIKE '" + array[0] + "%'))";
                    for (int index = 1; index < array.Length; ++index)
                    {
                        if (isAccuracySearch)
                        com = com + firstOp + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                        else
                        com = com + firstOp + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                    }
            }

            //old code
            /*
            com = com.Insert(com.Length - 1, ") ");
            com = com.Insert(0, " AND [t0].[ID] IN (");
            

            string exCom = "SELECT [t2].[ID] FROM [dbo].[danie] AS [t2] WHERE ";
            if (excomboSelect)
            {
                exKeyWords = exKeyWords.Replace("(", " ( ");
                exKeyWords = exKeyWords.Replace(")", " ) ");
                exKeyWords = exKeyWords.Replace("&", " AND ");
                exKeyWords = exKeyWords.Replace("|", " OR ");
                string[] keywords = exKeyWords.Split(' ');
                keywords = keywords.Where(s => s != string.Empty).ToArray();

                for (int i = 0; i < keywords.Length; i++)
                {
                    switch (keywords[i])
                    {
                        case "(":
                        case ")":
                        case "AND":
                        case "OR":
                            exCom = exCom + " " + keywords[i] + " ";
                            break;
                        default:
                            exCom = exCom + "((Slova LIKE '%" + " " + keywords[i] + "%') OR (Slova LIKE '%." + keywords[i] + "%') " +
                                "OR (Slova LIKE '" + keywords[i] + "%'))";
                            break;
                    }
                }
            }
            else
            {
                string[] keywords = exKeyWords.Split(' ', ',').Where(s => s != string.Empty).ToArray();

                exCom += "((Slova LIKE '%" + " " + keywords[0] + "%') OR (Slova LIKE '%." + keywords[0] + "%') OR (Slova LIKE '" + keywords[0] + "%'))";
                for (int i = 1; i < keywords.Length; i++)
                {
                    exCom = exCom + secondOp + "((Slova LIKE '%" + " " + keywords[i] + "%') OR (Slova LIKE '%." + keywords[i] + "%') OR (Slova LIKE '" + keywords[i] + "%'))";
                }
            }
            
            exCom = exCom.Insert(exCom.Length - 1, ") ");
            exCom = exCom.Insert(0, " AND [t1].[ID] NOT IN (");

            com = com.Insert(com.Length - 1, exCom);
            
            linqQuery = linqQuery.Insert(linqQuery.IndexOf("ORDER") - 1, com);

            //MessageBox.Show(com);

            return linqQuery;
            */
            //end old code

            string str3 = com.Insert(com.Length - 1, ") ").Insert(0, " AND [t0].[ID] IN (");
            string str4 = "SELECT [t2].[ID] FROM [dbo].[danie] AS [t2] WHERE ";
            if (excomboSelect)
            {
                exKeyWords = exKeyWords.Replace("(", " ( ");
                exKeyWords = exKeyWords.Replace(")", " ) ");
                exKeyWords = exKeyWords.Replace("&", " AND ");
                exKeyWords = exKeyWords.Replace("|", " OR ");
                string[] array = ((IEnumerable<string>)exKeyWords.Split(' ')).Where<string>((Func<string, bool>)(s => s != string.Empty)).ToArray<string>();
                for (int index = 0; index < array.Length; ++index)
                {
                    string str2 = array[index];
                    if (str2 == "(" || str2 == ")" || (str2 == "AND" || str2 == "OR"))
                        str4 = str4 + " " + array[index] + " ";
                    else if (isAccuracySearch)
                        str4 = str4 + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                    else
                        str4 = str4 + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                }
            }
            else
            {
                string[] array = ((IEnumerable<string>)exKeyWords.Split(new char[2]
                {
          ' ',
          ','
                })).Where<string>((Func<string, bool>)(s => s != string.Empty)).ToArray<string>();
                if (isAccuracySearch)
                    str4 = str4 + "((Slova LIKE '" + array[0] + ",%') OR (Slova LIKE '" + array[0] + " %') OR (Slova LIKE '" + array[0] + "') OR (Slova LIKE '% " + array[0] + ",%') OR (Slova LIKE '% " + array[0] + " %') OR (Slova LIKE '% " + array[0] + "'))";
                else
                    str4 = str4 + "((Slova LIKE '% " + array[0] + "%') OR (Slova LIKE '%." + array[0] + "%') OR (Slova LIKE '" + array[0] + "%'))";
                for (int index = 1; index < array.Length; ++index)
                {
                    if (isAccuracySearch)
                        str4 = str4 + "((Slova LIKE '" + array[index] + ",%') OR (Slova LIKE '" + array[index] + " %') OR (Slova LIKE '" + array[index] + "') OR (Slova LIKE '% " + array[index] + ",%') OR (Slova LIKE '% " + array[index] + " %') OR (Slova LIKE '% " + array[index] + "'))";
                    else
                        str4 = str4 + secondOp + "((Slova LIKE '% " + array[index] + "%') OR (Slova LIKE '%." + array[index] + "%') OR (Slova LIKE '" + array[index] + "%'))";
                }
            }
            string str5 = str4.Insert(str4.Length - 1, ") ").Insert(0, " AND [t1].[ID] NOT IN (");
            string str6 = str3.Insert(str3.Length - 1, str5);
            linqQuery = linqQuery.Insert(linqQuery.IndexOf("ORDER") - 1, str6);
            return linqQuery;

        }

        // 1- ключевые слова, 2 - оператор, 3 - объект команды, 4 - сложный, 5 - исключения
        public static DataTable ComboQueryResult(string str, string sign, DbCommand dbcom, bool comboSelect, bool exception, string author, bool isAccuracySearch)
        {
            DataTable tab = new DataTable("danie");
          
            BindingSource bs = new BindingSource();

            SqlConnection con = new SqlConnection(Util.GetConnectionString());
            string rescom = dbcom.CommandText;

            if (author != string.Empty)
            {
                string paramName = "";
                for (int i = 0; i < dbcom.Parameters.Count; i++)
                {
                    if (dbcom.Parameters[i].Value.ToString() == "%" + author + "%")
                        paramName = dbcom.Parameters[i].ParameterName;
                }

                string strReplace = string.Format("[t0].[Aftor] LIKE {0}", paramName);
                rescom = rescom.Replace(strReplace, "[t0].[Aftor] LIKE '" + author + "'" + " OR [Aftor] LIKE '" + author +
                    " %'" + " OR [Aftor] LIKE '% " + author + " %'" + " OR [Aftor] LIKE '% " + author + "'");
            }

            string com = ExComboQuery(str, sign, rescom, comboSelect, exception, isAccuracySearch).ToString();
            
            SqlCommand cmd = new SqlCommand();
            for (int i = 0; i < dbcom.Parameters.Count; i++)
            {
                if (dbcom.Parameters[i].Value.ToString() != "%" + author + "%")
                {
                    SqlParameter p = new SqlParameter(dbcom.Parameters[i].ParameterName, dbcom.Parameters[i].Value);
                    cmd.Parameters.Add(p);
                }
                
            }

           /* FileStream stream = new FileStream(@"query.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(com);
            
            writer.Close();*/

            cmd.CommandText = com;
            cmd.Connection = con;
            
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            
            try
            {
                con.Open();
                adapt.Fill(tab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return tab;
        }

        public static DataTable MultiQueryResult(string keyWords, string exKeyWords, string firstOp, string secondOp, DbCommand dbcom, bool comboSelect, bool excomboSelect, string author, bool isAccuracySearch)
        {
            DataTable tab = new DataTable("danieEx");
            BindingSource bs = new BindingSource();
            SqlConnection con = new SqlConnection(Util.GetConnectionString());
            string rescom = dbcom.CommandText;
            if (author != string.Empty)
            {
                string paramName = "";
                for (int i = 0; i < dbcom.Parameters.Count; i++)
                {
                    if (dbcom.Parameters[i].Value.ToString() == "%" + author + "%")
                        paramName = dbcom.Parameters[i].ParameterName;
                }

                string strReplace = string.Format("[t0].[Aftor] LIKE {0}", paramName);
                rescom = rescom.Replace(strReplace, "[t0].[Aftor] LIKE '" + author + "'" + " OR [Aftor] LIKE '" + author +
                    " %'" + " OR [Aftor] LIKE '% " + author + " %'" + " OR [Aftor] LIKE '% " + author + "'");
            }

            string com = MultiComboQuery(keyWords, exKeyWords, firstOp, secondOp, rescom, comboSelect, excomboSelect, isAccuracySearch).ToString();

            SqlCommand cmd = new SqlCommand();
            for (int i = 0; i < dbcom.Parameters.Count; i++)
            {
                if (dbcom.Parameters[i].Value.ToString() != "%" + author + "%")
                {
                    SqlParameter p = new SqlParameter(dbcom.Parameters[i].ParameterName, dbcom.Parameters[i].Value);
                    cmd.Parameters.Add(p);
                }

            }
            
            cmd.CommandText = com;
            cmd.Connection = con;

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                adapt.Fill(tab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return tab;
        }

        public static DataTable AuthorQueryResult(string author, DbCommand dbcom)
        {
            DataTable tab = new DataTable("danie");

            SqlConnection con = new SqlConnection(Util.GetConnectionString());
            string rescom = dbcom.CommandText;

            string paramName = "";
            for (int i = 0; i < dbcom.Parameters.Count; i++)
            {
                if(dbcom.Parameters[i].Value.ToString() == "%" + author + "%")
                    paramName = dbcom.Parameters[i].ParameterName;
            }

            string strReplace = string.Format("[t0].[Aftor] LIKE {0}", paramName);
            rescom = rescom.Replace(strReplace, "[t0].[Aftor] LIKE '" + author + "'" + " OR [Aftor] LIKE '" + author +
                " %'" + " OR [Aftor] LIKE '% " + author + " %'" + " OR [Aftor] LIKE '% " + author + "'" + "OR [Aftor] LIKE '" + author + ",'" + " OR [Aftor] LIKE '" + author +
                ", %'" + " OR [Aftor] LIKE '% " + author + ", %'" + " OR [Aftor] LIKE '% " + author + ",'");

            //return rescom;
            SqlCommand cmd = new SqlCommand();
            for (int i = 0; i < dbcom.Parameters.Count; i++)
            {
                if (dbcom.Parameters[i].Value.ToString() != "%" + author + "%")
                {
                    SqlParameter p = new SqlParameter(dbcom.Parameters[i].ParameterName, dbcom.Parameters[i].Value);
                    cmd.Parameters.Add(p);
                }
            }

            cmd.CommandText = rescom;
            cmd.Connection = con;

            FileStream stream = new FileStream(@"query.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(rescom);

            writer.Close();

            SqlDataAdapter adapt = new SqlDataAdapter(cmd);

            try
            {
                con.Open();
                adapt.Fill(tab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return tab;
        }

        public static void CreateBackup(string dbName, string fileName)
        {
            try
            {
                SqlConnectionStringBuilder conStringBuilder = new SqlConnectionStringBuilder(ConStr);

                // Connect to the local, default instance of SQL Server.   
                Server srv = new Server(conStringBuilder.DataSource);
                                                                    
                // Define a Backup object variable.   
                Backup bk = new Backup();

                // Specify the type of backup, the description, the name, and the database to be backed up.   
                bk.Action = BackupActionType.Database;
                bk.BackupSetDescription = "Full backup of " + dbName;
                bk.BackupSetName = dbName + " Backup";
                bk.Database = dbName;

                // Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file.   
                BackupDeviceItem bdi = default(BackupDeviceItem);
                bdi = new BackupDeviceItem(fileName, DeviceType.File);

                // Add the device to the Backup object.   
                bk.Devices.Add(bdi);
                // Set the Incremental property to False to specify that this is a full database backup.   
                bk.Incremental = false;
            
                // Specify that the log must be truncated after the backup is complete.   
                bk.LogTruncation = BackupTruncateLogType.Truncate;

                // Run SqlBackup to perform the full database backup on the instance of SQL Server.   
                bk.SqlBackup(srv);

                // Remove the backup device from the Backup object.   
                bk.Devices.Remove(bdi);
                MessageBox.Show("Создание резервной копии завершено");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
