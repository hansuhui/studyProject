using System;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace Console1
{

    [DataContract]
    public class Sample {
        [DataMember]
        public string Value { get; set; }
    }

    class Serializer_Ex
    {
        public void Main()
        {
            Sample obj = new Sample();
            obj.Value = "Hello!";

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Sample));
            using (Stream stream = new FileStream("sample.json", FileMode.Create)) {
                serializer.WriteObject(stream, obj);
            }


            using (Stream stream = new FileStream("sample.json", FileMode.Open))
            {
                Sample read = (Sample)serializer.ReadObject(stream);
                Console.WriteLine(read.Value);
            }



        }
    }
}


