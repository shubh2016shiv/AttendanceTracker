using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceTracker
{
    static class JSON_Deserialize_Serialize
    {
        public static List<EnrollInformationObject> EnrollInformationObjectsList = new List<EnrollInformationObject>();

        public static void Serialize(List<EnrollInformationObject> classList)
        {
            if (File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\Saved Records\\EnrollmentRecords.json"))
            {
                File.Delete(System.IO.Directory.GetCurrentDirectory() + "\\Saved Records\\EnrollmentRecords.json");
            }
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Converters.Add(new JavaScriptDateTimeConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;



                string JSON_Output = JsonConvert.SerializeObject(classList, Formatting.Indented);

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\Saved Records\\Records.json"))
                {
                    sw.Write(JSON_Output);
                }
                Console.WriteLine("Serialized Successfully in JSON");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not serialize successfully :" + ex.Message);
            }

        }

        public static List<EnrollInformationObject> DeSerialize(string path)
        {


            try
            {

                var records = JsonConvert.DeserializeObject<List<EnrollInformationObject>>(File.ReadAllText(path));
                Console.WriteLine("JSON deserialized successfully");
                return records;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserializing failed due to : " + ex.Message);
                return new List<EnrollInformationObject>();
            }

        }

    }
}
