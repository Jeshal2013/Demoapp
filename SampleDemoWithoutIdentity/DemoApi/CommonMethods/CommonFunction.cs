namespace DemoApi.CommonMethods
{
    public static class CommonFunction
    {
        public static void WriteMessage(string Content)
        {


            // set file path and append text on file
            string fileName = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".txt";
            //check file exists or not if not exists create and write
            //if exists just append
            System.IO.File.WriteAllText(fileName,Content);

        }

        //public static void WriteToFile(string filePath, string content, bool append)
        //{
            
        //        StreamWriter sw = new StreamWriter(filePath, append);
        //        sw.Write(content);
        //        sw.Flush();
        //        sw.Close();
            
        //}
    }
}
